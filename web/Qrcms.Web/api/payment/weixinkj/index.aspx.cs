using Qrcms.API.Payment.weixinkj;
using Qrcms.Common;
using Qrcms.Web.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qrcms.Web.api.payment.weixinkj
{
    public partial class index : Qrcms.Web.UI.UserPage
    {
        public string order_no = "";
        public decimal order_amount = 0;
        private ClientResponseHandler resHandler = new ClientResponseHandler();
        private PayHttpClient pay = new PayHttpClient();
        private RequestHandler reqHandler = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            //读取站点配置信息
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //系统配置

            //=============================获得订单信息================================
            order_no = DTRequest.GetString("pay_order_no").ToUpper();
            order_amount = Common.Utils.StrToDecimal(DTRequest.GetString("pay_order_amount"), 0);
            string user_name = DTRequest.GetString("pay_user_name");
            string subject = DTRequest.GetString("pay_subject");
            if (!IsWeiChat())//如果不是微信环境
            {
                Response.Redirect("/api/payment/alipaywap/index.aspx?pay_order_no=" + order_no + "&pay_order_amount=" + order_amount + "&pay_user_name=" + user_name + "&pay_subject=" + subject);
                return;
            }

            Model.users user = GetUserInfo();

            //以下收货人信息
            string receive_name = string.Empty; //收货人姓名
            string receive_address = string.Empty; //收货人地址
            string receive_zip = string.Empty; //收货人邮编
            string receive_phone = string.Empty; //收货人电话
            string receive_mobile = string.Empty; //收货人手机
            //检查参数是否正确
            if (order_no == "" || order_amount == 0)
            {
                Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，您提交的参数有误！")));
                return;
            }
            if (order_no.StartsWith("R")) //R开头为在线充值订单
            {
                Model.user_recharge model = new BLL.user_recharge().GetModel(order_no);
                if (model == null)
                {
                    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，您充值的订单号不存在或已删除！")));
                    return;
                }
                if (model.amount != order_amount)
                {
                    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，您充值的订单金额与实际金额不一致！")));
                    return;
                }
                //取得用户信息
                Model.users userModel = new BLL.users().GetModel(model.user_id);
                if (userModel == null)
                {
                    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，用户账户不存在或已删除！")));
                    return;
                }
                receive_name = userModel.nick_name;
                receive_address = userModel.address;
                receive_phone = userModel.telphone;
                receive_mobile = userModel.mobile;
                subject = "账户充值";
            }
            else //B开头为商品订单
            {
                Model.orders model = new BLL.orders().GetModel(order_no);
                if (model == null)
                {
                    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，您支付的订单号不存在或已删除！")));
                    return;
                }
                if (model.order_amount != order_amount)
                {
                    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，您支付的订单金额与实际金额不一致！")));
                    return;
                }
                receive_name = model.accept_name;
                receive_address = model.address;
                receive_zip = model.post_code;
                receive_phone = model.telphone;
                receive_mobile = model.mobile;
                subject = "商城下单";
            }

            string openid = user.openid;
            if (openid != null && openid != "")
            {
                this.reqHandler = new RequestHandler(null);
                //加载配置数据
                var cfg = API.Payment.weixinkj.Utils.loadCfg();
                //初始化数据  
                this.reqHandler.setGateUrl(cfg.req_url);
                this.reqHandler.setKey(cfg.key);
                this.reqHandler.setParameter("out_trade_no", order_no);//商户订单号
                this.reqHandler.setParameter("body", subject);//商品描述
                this.reqHandler.setParameter("attach", "");//附加信息
                this.reqHandler.setParameter("total_fee", (order_amount * 100).ToString("0"));//总金额
                this.reqHandler.setParameter("mch_create_ip", Common.DTRequest.GetIP());//终端IP
                this.reqHandler.setParameter("time_start", DateTime.Now.ToString("yyyyMMddHHmmss")); //订单生成时间
                this.reqHandler.setParameter("time_expire", DateTime.Now.AddDays(1).ToString("yyyyMMddHHmmss"));//订单超时时间
                this.reqHandler.setParameter("service", "pay.weixin.jspay");//接口类型：pay.weixin.jspay
                this.reqHandler.setParameter("mch_id", cfg.mch_id);//必填项，商户号，由威富通分配
                this.reqHandler.setParameter("version", cfg.version);//接口版本号
                this.reqHandler.setParameter("notify_url", cfg.notify_url);
                this.reqHandler.setParameter("nonce_str", API.Payment.weixinkj.Utils.random());//随机字符串，必填项，不长于 32 位
                this.reqHandler.setParameter("charset", "UTF-8");//字符集
                this.reqHandler.setParameter("sign_type", "MD5");//签名方式
                this.reqHandler.setParameter("is_raw", "0");//是否原生泰支付方式
                this.reqHandler.setParameter("device_info", "");//终端设备号
                this.reqHandler.setParameter("sub_openid", openid);
                this.reqHandler.setParameter("callback_url", config.weburl + "/api/payment/weixinkj/return_url.aspx?order_no="+order_no);
                this.reqHandler.setParameter("goods_tag", "");//商品标记                
                this.reqHandler.createSign();//创建签名
                //以上参数进行签名
                string data = API.Payment.weixinkj.Utils.toXml(this.reqHandler.getAllParameters());//生成XML报文
                Dictionary<string, string> reqContent = new Dictionary<string, string>();
                reqContent.Add("url", this.reqHandler.getGateUrl());
                reqContent.Add("data", data);
                this.pay.setReqContent(reqContent);

                if (this.pay.call())
                {
                    this.resHandler.setContent(this.pay.getResContent());
                    this.resHandler.setKey(cfg.key);
                    Hashtable param = this.resHandler.getAllParameters();
                    pageHelper.WriteLog(JsonHelper.ObjectToJSON(param));
                    if (this.resHandler.isTenpaySign())
                    {
                        //当返回状态与业务结果都为0时才返回，其它结果请查看接口文档
                        if (int.Parse(param["status"].ToString()) == 0 && int.Parse(param["result_code"].ToString()) == 0)
                        {
                            Response.Redirect("https://pay.swiftpass.cn/pay/jspay?token_id=" + param["token_id"].ToString() + "&showwxtitle=1");
                        }
                        else
                        {
                            Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("错误代码：" + param["err_code"] + ",错误信息：" + param["err_msg"] + "")));
                        }

                    }
                    else
                    {
                        Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("错误代码：" + param["status"] + ",错误信息：" + param["message"] + "")));
                    }
                }
                else
                {
                    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("错误代码：" + this.pay.getResponseCode() + ",错误信息：" + this.pay.getErrInfo() + "")));
                }
            }
            else
            {
                Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，参数不正确")));
                return;
            }
        }
    }
}