using Qrcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Linq;
//using Senparc.Weixin.MP.TenPayLibV3;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using swiftpass.utils;
using System.Collections;
using System.Runtime.Serialization.Json;
using Qrcms.Web.UI;

namespace Qrcms.Web.api.payment.weixingzhzf
{
    public partial class index : Web.UI.UserPage
    {
        public string ImageUrl = "";
        public string wxJsApiParam = "";

        private ClientResponseHandler resHandler = new ClientResponseHandler();
        private PayHttpClient pay = new PayHttpClient();
        private RequestHandler reqHandler = null;
        private Dictionary<string, string> cfg = new Dictionary<string, string>(1);

        public string appId { get; set; }
        public string timeStamp { get; set; }
        public string nonceStr { get; set; }
        public string package { get; set; }
        public string signType { get; set; }

        public string paySign { get; set; }

        public string orderno { get; set; }

        public string amount { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (DTRequest.GetString("action") == "sel")
            {
                sel();
                return;
            }

            if (DTRequest.GetString("action") == "PayCompleate")
            {
                PayCompleate();
                return;
            }

            string order_no = DTRequest.GetString("pay_order_no").ToUpper();
            orderno = order_no;
            string orderNo = order_no;//商户订单号
            string extraDesc = "充值";//附加信息
            string reqTime = DateTime.Now.ToString("yyyyMMddhhmmss");//请求时间
            string goodsName = "充值支付";//商品名称
            decimal order_amount = Common.Utils.StrToDecimal(DTRequest.GetString("pay_order_amount"), 0);//交易金额
            amount = DTRequest.GetString("pay_order_amount");
            int int_orm = Convert.ToInt32(order_amount * 100);
            string subOpenId = userModel.openid;//用户在subAppId下的唯一标识

            BLL.weixin_account bll = new BLL.weixin_account();
            Model.weixin_account model = bll.GetModel(1);
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //系统配置
            string subAppId = model.appid;//接入方微信公众号 id
            if (order_amount == 0)
            {
                Response.Write("<script>alert('总金额不能为【0】！')</script>");
            }
            else
            {

                System.Net.IPAddress addr;
                addr = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
                String IPAddress = addr.ToString();//获取本机的IP地址


                this.reqHandler = new RequestHandler(null);
                //加载配置数据
                this.cfg = swiftpass.utils.Utils.loadCfg(); ;
                //初始化数据  
                this.reqHandler.setGateUrl(this.cfg["req_url"].ToString());
                this.reqHandler.setKey(this.cfg["key"].ToString());
                this.reqHandler.setParameter("out_trade_no", orderNo);//商户订单号
                this.reqHandler.setParameter("body", goodsName);//商品描述
                this.reqHandler.setParameter("attach", extraDesc);//附加信息
                this.reqHandler.setParameter("total_fee", Convert.ToString(int_orm));//总金额

                this.reqHandler.setParameter("mch_create_ip", IPAddress);//终端IP
                this.reqHandler.setParameter("time_start", reqTime); //订单生成时间
                //this.reqHandler.setParameter("time_expire", tbtime_expire.Text);//订单超时时间
                this.reqHandler.setParameter("service", "pay.weixin.jspay");//接口类型：pay.weixin.jspay
                this.reqHandler.setParameter("mch_id", this.cfg["mch_id"].ToString());//必填项，商户号，由平台分配
                //this.reqHandler.setParameter("sub_mch_id", this.cfg["mch_id"].ToString());


                this.reqHandler.setParameter("version", this.cfg["version"].ToString());//接口版本号
                this.reqHandler.setParameter("notify_url", this.cfg["notify_url"].ToString());
                //通知地址，必填项，接收平台通知的URL，需给绝对路径，255字符内;此URL要保证外网能访问   
                this.reqHandler.setParameter("nonce_str", swiftpass.utils.Utils.random());//随机字符串，必填项，不长于 32 位
                this.reqHandler.setParameter("charset", "UTF-8");//字符集
                this.reqHandler.setParameter("sign_type", "MD5");//签名方式
                this.reqHandler.setParameter("is_raw", "1");//原生JS值
                //this.reqHandler.setParameter("device_info", "苹果iPhone 6");//终端设备号
                this.reqHandler.setParameter("sub_appid", subAppId);
                this.reqHandler.setParameter("sub_openid", subOpenId);//测试账号不传值,此处默认给空值。正式账号必须传openid值，获取openid值指导文档地址：http://www.cnblogs.com/txw1958/p/weixin76-user-info.html
                this.reqHandler.setParameter("callback_url", "https://www.swiftpass.cn");//前台地址  交易完成后跳转的 URL，需给绝对路径，255字 符 内 格 式如:http://wap.tenpay.com/callback.asp
                this.reqHandler.setParameter("goods_tag", "");//商品标记                
                this.reqHandler.createSign();//创建签名
                //以上参数进行签名
                string data = swiftpass.utils.Utils.toXml(this.reqHandler.getAllParameters());//生成XML报文
                Dictionary<string, string> reqContent = new Dictionary<string, string>();
                reqContent.Add("url", this.reqHandler.getGateUrl());
                reqContent.Add("data", data);
                this.pay.setReqContent(reqContent);

                if (this.pay.call())
                {
                    this.resHandler.setContent(this.pay.getResContent());
                    this.resHandler.setKey(this.cfg["key"].ToString());
                    Hashtable param = this.resHandler.getAllParameters();
                    if (this.resHandler.isTenpaySign())
                    {
                        //当返回状态与业务结果都为0时才返回，其它结果请查看接口文档
                        if (int.Parse(param["status"].ToString()) == 0 && int.Parse(param["result_code"].ToString()) == 0)
                        {

                            //Response.Write("<script>alert('请使用原生态JS支付支付，原生态JS值：" + param["pay_info"].ToString() + "')</script>");
                            weixinzfModel weixinzfModel = new index.weixinzfModel();
                            weixinzfModel = JsonToObject(param["pay_info"].ToString(), weixinzfModel) as weixinzfModel;

                            appId = weixinzfModel.appId;
                            nonceStr = weixinzfModel.nonceStr;
                            package = weixinzfModel.package;
                            paySign = weixinzfModel.paySign;
                            timeStamp = weixinzfModel.timeStamp;
                            signType = weixinzfModel.signType;


                        }
                        else
                        {
                            Response.Write("<script>alert('错误代码：" + param["err_code"] + ",错误信息：" + param["err_msg"] + "')</script>");
                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('错误代码：" + param["status"] + ",错误信息：" + param["message"] + "')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('错误代码：" + this.pay.getResponseCode() + ",错误信息：" + this.pay.getErrInfo() + "')</script>");
                }
            }

        }

        public static object JsonToObject(string jsonString, object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            return serializer.ReadObject(mStream);
        }

        public class weixinzfModel
        {
            public string appId { get; set; }
            public string timeStamp { get; set; }
            public string nonceStr { get; set; }
            public string package { get; set; }
            public string signType { get; set; }

            public string paySign { get; set; }
        }

        #region oldsolution

        public void old()
        {
            if (DTRequest.GetString("action") == "sel")
            {
                sel();
                return;
            }
            //1> 生成签名字符串
            //对于如下的参数数组：
            //string[] parameters={ 
            //" merNo = 999102115200003", 
            //" termNo = 00000090 ", 
            //" orderNo=12345678902 ", 
            //" channelFlag=01 ", 
            //" amount=1 "

            //密钥：amount=1&channelFlag=01&merNo=999310156610001&orderNo=12345678902&termNo=00000090123456（md5加密signIn）
            //00	微信
            //01	支付宝
            //02	百付包
            //03	翼支付
            //04	qq
            //05	京东
            //select *  from dt_weixin_account
            BLL.weixin_account bll = new BLL.weixin_account();
            Model.weixin_account model = bll.GetModel(1);
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //系统配置
            string order_no = DTRequest.GetString("pay_order_no").ToUpper();
            decimal order_amount = Common.Utils.StrToDecimal(DTRequest.GetString("pay_order_amount"), 0);//交易金额
            order_amount = order_amount * 100;
            pageHelper.WriteLog(order_no + "cz mondey================\r\n" + order_amount);
            //order_amount = 1;//--------单位分
            //if (order_amount < 1000)
            //{
            //    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("对不起，支付金额不能少于10元！")));
            //    return;
            //}
            XmlDocument doc = XmlHelper.LoadXmlDoc(Qrcms.Common.Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixingzhzf.config"));
            string merNopz = doc.SelectSingleNode(@"Root/merNo").InnerText;//商户号
            string url = doc.SelectSingleNode(@"Root/url").InnerText;//接口地址
            string Key = doc.SelectSingleNode(@"Root/Key").InnerText;//接口地址
            pageHelper.WriteLog(merNopz + "+++++++++++++" + url + "+++++++++++" + Key);
            string merNo = merNopz;//商户号
            string signIn = "";//签名
            string orderNo = order_no;//商户订单号
            //orderNo = "R17090716593529";//---------
            string amount = order_amount.ToString("0");//订单金额
            string reqId = DateTime.Now.ToString("yyyyMMddhhmmss");//请求交易的流水号
            string reqTime = DateTime.Now.ToString("yyyyMMddhhmmss");//请求时间
            string subAppId = model.appid;//接入方微信公众号 id
            string subOpenId = userModel.openid;//用户在subAppId下的唯一标识
            string notifyUrl = siteConfig.weburl + doc.SelectSingleNode(@"Root/notifyUrl").InnerText;//异步通知url
            pageHelper.WriteLog("Response================\r\n" + notifyUrl);
            string goodsName = "充值支付";//商品名称
            string operatorId = "10005";//操作员编号
            string currency = "CNY";//默认CNY（币种）
            string extraDesc = "充值";//附加信息
            string subOpenIdKey = subOpenId + Key;
            string signtext = "amount=" + amount + "&currency=" + currency + "&extraDesc=" + extraDesc + "&goodsName=" + goodsName + "&merNo=" + merNo + "&notifyUrl=" + notifyUrl + "&operatorId=" + operatorId + "&orderNo=" + orderNo + "&reqId=" + reqId + "&reqTime=" + reqTime + "&subAppId=" + subAppId + "&subOpenId=" + subOpenIdKey;//签名
            signtext = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(signtext));
            signIn = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(signtext, "md5").ToUpper();

            string msgurlcs = "amount=" + amount + "&currency=" + currency + "&extraDesc=" + extraDesc + "&goodsName=" + goodsName + "&merNo=" + merNo + "&notifyUrl=" + notifyUrl + "&operatorId=" + operatorId + "&orderNo=" + orderNo + "&reqId=" + reqId + "&reqTime=" + reqTime + "&signIn=" + signIn + "&subAppId=" + subAppId + "&subOpenId=" + subOpenId;
            //发送请求
            pageHelper.WriteLog(url + "Response================\r\n" + msgurlcs);
            string Json = Common.Utils.HttpPost(url, msgurlcs);//" + url + "?
            pageHelper.WriteLog(Json);
            //Response.Write(Json);
            dynamic response = Newtonsoft.Json.JsonConvert.DeserializeObject(Json);
            string statusa = response.result;
            //组合
            string zh = "";
            if (statusa == "0000")
            {
                wxJsApiParam = Json.Replace("pack", "package"); ;
                pageHelper.WriteLog("++++++" + wxJsApiParam + "+++++");
            }
            else
            {
                Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，您提交的参数有误！")));
                return;
            }
        }

        #endregion

        private void sel()
        {
            string order_no = DTRequest.GetString("orderNo");
            if (order_no.StartsWith("R")) //R开头为在线充值订单
            {
                Model.user_recharge model = new BLL.user_recharge().GetModel(order_no);
                if (model != null && model.status == 1)
                {
                    Response.Write("{\"status\":\"1\"}");
                    Response.End();
                }
            }
            else //B开头为商品订单
            {
                Model.orders model = new BLL.orders().GetModel(order_no);
                if (model != null && model.payment_status == 2)
                {
                    Response.Write("{\"status\":\"1\"}");
                    Response.End();

                }
            }
            Response.Write("{\"status\":\"0\"}");
            Response.End();
        }


        private void PayCompleate()
        {
            string order_no = DTRequest.GetString("orderNo");
            string _amount = DTRequest.GetString("amount");
            if (CheckBll(order_no))
            {

                int userid = Convert.ToInt32(DBUtility.DbHelperSQL.GetSingle(" select id from dt_user_recharge where recharge_no='" + order_no + "'"));
                //数据库里有值，充值成功
                if (userid > 0)
                {
                    //BLL.users usersModel = new BLL.users();
                    Model.users model = new BasePage().GetUserInfo();
                    model.amount += decimal.Parse(_amount) - decimal.Parse(_amount) * (decimal)0.01;
                    bool result = new BLL.users().Update(model);
                    if (result)
                    {
                        BLL.user_recharge user_recharge = new BLL.user_recharge();
                        Model.user_recharge rechage = user_recharge.GetModel(order_no);
                        rechage.complete_time = DateTime.Now;
                        rechage.status = 1;
                        rechage.amount -= rechage.amount * (decimal)0.01;
                        user_recharge.Update(rechage);

                        Response.Write("{\"status\":\"1\"}");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("{\"status\":\"0\"}");
                        Response.End();
                    }
                }
            }
            Response.Write("{\"status\":\"0\"}");
            Response.End();
        }

        #region 查询订单号


        public bool CheckBll(string tbout_trade_no)
        {
            bool result = false;
            this.reqHandler = new RequestHandler(null);
            //加载配置数据
            this.cfg = swiftpass.utils.Utils.loadCfg(); ;
            //初始化数据 
            this.reqHandler.setGateUrl(this.cfg["req_url"].ToString());
            this.reqHandler.setKey(this.cfg["key"].ToString());
            this.reqHandler.setParameter("out_trade_no", tbout_trade_no);//商户订单号
            //this.reqHandler.setParameter("transaction_id", tbtransaction_id.Text);//平台订单号                
            this.reqHandler.setParameter("service", "unified.trade.query");//接口 unified.trade.query 
            this.reqHandler.setParameter("mch_id", this.cfg["mch_id"].ToString());//必填项，商户号，由平台分配
            this.reqHandler.setParameter("version", this.cfg["version"].ToString());//接口版本号

            this.reqHandler.setParameter("nonce_str", swiftpass.utils.Utils.random());//随机字符串，必填项，不长于 32 位
            this.reqHandler.createSign();//创建签名
            //以上参数进行签名
            string data = swiftpass.utils.Utils.toXml(this.reqHandler.getAllParameters());//生成XML报文
            Dictionary<string, string> reqContent = new Dictionary<string, string>();
            reqContent.Add("url", this.reqHandler.getGateUrl());
            reqContent.Add("data", data);
            this.pay.setReqContent(reqContent);

            if (this.pay.call())
            {
                this.resHandler.setContent(this.pay.getResContent());
                this.resHandler.setKey(this.cfg["key"].ToString());
                Hashtable param = this.resHandler.getAllParameters();
                if (this.resHandler.isTenpaySign())
                {
                    //当返回状态与业务结果都为0时才返回结果，其它结果请查看接口文档
                    if (int.Parse(param["status"].ToString()) == 0 && int.Parse(param["result_code"].ToString()) == 0)
                    {
                        swiftpass.utils.Utils.writeFile("查询订单", param);

                        if (param.ContainsKey("trade_state"))
                        {
                            if (Convert.ToString(param["trade_state"]) == "SUCCESS")
                            {
                                result = true;
                            }
                        }

                        //Response.Write("<script>alert('查询订单成功，请查看result.txt文件！')</script>");


                    }
                    else
                    {
                        Response.Write("<script>alert('错误代码：" + param["err_code"] + ",错误信息：" + param["err_msg"] + "')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('错误代码：" + param["status"] + ",错误信息：" + param["message"] + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('错误代码：" + this.pay.getResponseCode() + ",错误信息：" + this.pay.getErrInfo() + "')</script>");
            }
            return result;
        }

        #endregion
    }
}