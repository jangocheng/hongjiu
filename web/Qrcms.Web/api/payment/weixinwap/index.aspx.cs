using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;
using Qrcms.API.Payment.chinabankpc;
using Qrcms.API.Payment.weixinwap;
using Qrcms.Web.UI;
using Qrcms.API.Weixin.Common;
using System.Collections.Specialized;

namespace Qrcms.Web.api.payment.weixinwap
{
    public partial class index : System.Web.UI.Page
    {
        public string order_no = "";
        public Decimal order_amount = 0;
        public static string wxEditAddrParam { get; set; }
        public static string wxJsApiParam { get; set; } //H5调起JS API参数
        protected void Page_Load(object sender, EventArgs e)
        {
            Web.UI.UserPage basepage = new UserPage();
            if (!basepage.IsUserLogin())
            {
                Response.Write("已经超时，请关闭当前页，重新从微信进入");
                Response.End();
            }

            //读取站点配置信息
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //系统配置

            //=============================获得订单信息================================
            order_no = DTRequest.GetString("pay_order_no").ToUpper();
            order_amount = Utils.StrToDecimal(DTRequest.GetString("pay_order_amount"), 0);
            string user_name = DTRequest.GetString("pay_user_name");
            string subject = DTRequest.GetString("pay_subject");
            if (!basepage.IsWeiChat())//如果不是微信环境
            {
                Response.Redirect("/api/payment/alipaywap/index.aspx?pay_order_no=" + order_no + "&pay_order_amount=" + order_amount + "&pay_user_name=" + user_name + "&pay_subject=" + subject);
                return;
            }
            
            Model.users user = basepage.GetUserInfo();
           
            //以下收货人信息
            string receive_name = string.Empty; //收货人姓名
            string receive_address = string.Empty; //收货人地址
            string receive_zip = string.Empty; //收货人邮编
            string receive_phone = string.Empty; //收货人电话
            string receive_mobile = string.Empty; //收货人手机
            //检查参数是否正确
            if (order_no == "" || order_amount == 0)
            {
                Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("对不起，您提交的参数有误！")));
                return;
            }
            if (order_no.StartsWith("R")) //R开头为在线充值订单
            {
                Model.user_recharge model = new BLL.user_recharge().GetModel(order_no);
                if (model == null)
                {
                    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("对不起，您充值的订单号不存在或已删除！")));
                    return;
                }
                if (model.amount != order_amount)
                {
                    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("对不起，您充值的订单金额与实际金额不一致！")));
                    return;
                }
                //取得用户信息
                Model.users userModel = new BLL.users().GetModel(model.user_id);
                if (userModel == null)
                {
                    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("对不起，用户账户不存在或已删除！")));
                    return;
                }
                receive_name = userModel.nick_name;
                receive_address = userModel.address;
                receive_phone = userModel.telphone;
                receive_mobile = userModel.mobile;
            }
            else //B开头为商品订单
            {
                Model.orders model = new BLL.orders().GetModel(order_no);
                if (model == null)
                {
                    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("对不起，您支付的订单号不存在或已删除！")));
                    return;
                }
                if (model.order_amount != order_amount)
                {
                    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("对不起，您支付的订单金额与实际金额不一致！")));
                    return;
                }
                receive_name = model.accept_name;
                receive_address = model.address;
                receive_zip = model.post_code;
                receive_phone = model.telphone;
                receive_mobile = model.mobile;
            }

            string openid = user.openid;

            JsApiPay jsApiPay = new JsApiPay(this);

            if (openid != null && openid != "")
            {
                //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数
                jsApiPay.openid = openid;
                jsApiPay.total_fee = Convert.ToInt32(order_amount * 100);

                //JSAPI支付预处理
                try
                {
                    Model.siteconfig config = new BLL.siteconfig().loadConfig();
                    WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult(order_no, config.webname);
                    wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数                    
                    //在页面上显示订单信息
                    CRMComm.Writebug("订单详情：" + unifiedOrderResult.ToPrintStr());
                    //Response.Write("<span style='color:#00CD00;font-size:20px'>订单详情：</span><br/>");
                    //Response.Write("<span style='color:#00CD00;font-size:20px'>" + unifiedOrderResult.ToPrintStr() + "</span>");

                }
                catch (Exception ex)
                {
                    CRMComm.Writebug("cuowu:" + ex.Message);
                    //btn_submit.Visible = false;
                }
            }
            else
            {
                Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("对不起，参数不正确")));
                return;
            }
        }
    }
}