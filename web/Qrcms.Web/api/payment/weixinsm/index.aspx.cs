﻿using System;
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
using System.Xml;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.Text;
using System.IO;
using swiftpass.utils;
using System.Collections;
using System.Net;

namespace Qrcms.Web.api.payment.weixinsm
{
    public partial class index : System.Web.UI.Page
    {
         //Qrcms.Web.UI.UserPage
        public string ImageUrl = "";

        private ClientResponseHandler resHandler = new ClientResponseHandler();
        private PayHttpClient pay = new PayHttpClient();
        private RequestHandler reqHandler = null;
        private Dictionary<string, string> cfg = new Dictionary<string, string>(1);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DTRequest.GetString("action") == "sel")
            {
                sel();
                return;
            }

            string order_no = DTRequest.GetString("pay_order_no").ToUpper();
            string orderNo = order_no;//商户订单号
            string extraDesc = "充值";//附加信息
            string reqTime = DateTime.Now.ToString("yyyyMMddhhmmss");//请求时间
            string goodsName = "充值支付";//商品名称
            decimal order_amount = Common.Utils.StrToDecimal(DTRequest.GetString("pay_order_amount"), 0);//交易金额
            int int_orm = Convert.ToInt32(order_amount * 100);
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
                //this.reqHandler.setParameter("time_expire", reqTime);//订单超时时间
                this.reqHandler.setParameter("service", "pay.weixin.native");//接口类型：pay.weixin.native
                this.reqHandler.setParameter("mch_id", this.cfg["mch_id"].ToString());//必填项，商户号，由平台分配
                this.reqHandler.setParameter("version", this.cfg["version"].ToString());//接口版本号
                this.reqHandler.setParameter("notify_url", this.cfg["notify_url"].ToString());
                //通知地址，必填项，接收平台通知的URL，需给绝对路径，255字符内;此URL要保证外网能访问   
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
                    var pay = this.pay.getResContent();
                    this.resHandler.setContent(pay);
                    this.resHandler.setKey(this.cfg["key"].ToString());
                    Hashtable param = this.resHandler.getAllParameters();
                    if (this.resHandler.isTenpaySign())
                    {
                        //当返回状态与业务结果都为0时才返回支付二维码，其它结果请查看接口文档
                        if (int.Parse(param["status"].ToString()) == 0 && int.Parse(param["result_code"].ToString()) == 0)
                        {
                            string[] arr;
                            arr = new string[] { param["code_img_url"].ToString(), orderNo, goodsName, extraDesc, Convert.ToString(order_amount) };
                            Session["pavlue"] = arr;
                            Response.Redirect("generateCode.aspx");
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


            //this.old();
        }


        #region oldsolution

        public void old()
        {
            if (DTRequest.GetString("action") == "sel")
            {
                sel();
                return;
            }

            //Web.UI.UserPage basepage = new UserPage();
            //if (!basepage.IsUserLogin())
            //{
            //    Response.Write("已经超时，请关闭当前页，重新从微信进入");
            //    Response.End();
            //}

            //if (!basepage.IsWeiChat())//如果不是微信环境
            //{
            //    Response.Redirect("");
            //    return;
            //}

            //读取站点配置信息

            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //系统配置
            string order_no = DTRequest.GetString("pay_order_no").ToUpper();
            decimal order_amount = Common.Utils.StrToDecimal(DTRequest.GetString("pay_order_amount"), 0);
            order_amount = order_amount * 100;
            if (order_amount < 1000)
            {
                Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Qrcms.Common.Utils.UrlEncode("对不起，支付金额不能少于10元！")));
                return;
            }

            string user_name = DTRequest.GetString("pay_user_name");
            string subject = DTRequest.GetString("pay_subject");
            XmlDocument doc = XmlHelper.LoadXmlDoc(Qrcms.Common.Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixinsm.config"));
            string services = doc.SelectSingleNode(@"Root/service").InnerText;
            string keys = doc.SelectSingleNode(@"Root/key").InnerText;
            string merchantCodes = doc.SelectSingleNode(@"Root/merchantCode").InnerText;
            string shmc = doc.SelectSingleNode(@"Root/shmc").InnerText;
            string notifyUrls = doc.SelectSingleNode(@"Root/notifyUrl").InnerText;

            //以下收货人信息
            string receive_name = string.Empty; //收货人姓名
            string receive_address = string.Empty; //收货人地址
            string receive_zip = string.Empty; //收货人邮编
            string receive_phone = string.Empty; //收货人电话
            string receive_mobile = string.Empty; //收货人手机

            //获取请求参数
            string service = services;//服务类型(默认填写cj002)
            string merchantCode = merchantCodes;//平台商户编号10045025819
            string orderNum = order_no;//合作商订单号，全局唯一"150138580872"
            string transMoney = order_amount.ToString("0");//交易金额，单位分
            string notifyUrl = siteConfig.weburl + notifyUrls;//支付结果异步通知地址
            //网上http://jfsc.qianren.wang/api/payment/weixinsm/notify_url.aspx
            //本地http://localhost:10080/api/payment/weixinsm/notify_url.aspx
            string merchantName = shmc;//收款商户名称
            string commodityName = "钱包扫码";//商品名称（如不填使用收款商户名称）(可以随便填写)
            string merchantNum = "2017011717113";//商户门店编号(可以随便填写)
            string sign = "";//以上数据签名MD5

            string signtext = commodityName + merchantCode + merchantName + merchantNum + notifyUrl + orderNum + service + transMoney + keys;
            //string signtext = service + merchantCode + orderNum + transMoney + notifyUrl + merchantName + commodityName + merchantNum + "947d48d9a40f44318595237632123456";
            sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(signtext, "md5").ToLower();


            // //检查参数是否正确
            if (order_no == "" || order_amount == 0)
            {
                Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，您提交的参数有误！")));
                return;
            }
            //if (order_no.StartsWith("R")) //R开头为在线充值订单
            //{
            //    Model.user_recharge model = new BLL.user_recharge().GetModel(order_no);
            //    if (model == null)
            //    {
            //        Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，您充值的订单号不存在或已删除！")));
            //        return;
            //    }
            //    if (model.amount != order_amount)
            //    {
            //        Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，您充值的订单金额与实际金额不一致！")));
            //        return;
            //    }
            //    //取得用户信息
            //    Model.users userModel = new BLL.users().GetModel(model.user_id);
            //    if (userModel == null)
            //    {
            //        Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，用户账户不存在或已删除！")));
            //        return;
            //    }
            //    receive_name = userModel.nick_name;
            //    receive_address = userModel.address;
            //    receive_phone = userModel.telphone;
            //    receive_mobile = userModel.mobile;
            //    subject = "账户充值";
            //}
            //else //B开头为商品订单
            //{
            //    Model.orders model = new BLL.orders().GetModel(order_no);
            //    if (model == null)
            //    {
            //        Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，您支付的订单号不存在或已删除！")));
            //        return;
            //    }
            //    if (model.order_amount != order_amount)
            //    {
            //        Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，您支付的订单金额与实际金额不一致！")));
            //        return;
            //    }
            //    receive_name = model.accept_name;
            //    receive_address = model.address;
            //    receive_zip = model.post_code;
            //    receive_phone = model.telphone;
            //    receive_mobile = model.mobile;
            //    subject = "商城下单";
            //}

            string send_url = "http://60.28.24.164:8107/app_posp/live/qrcode/interface.action";// "http://60.28.24.164:8102/app_posp/live/qrcode/interface.action";//
            string send_param = "service=" + service + "&merchantCode=" + merchantCode + "&orderNum=" + orderNum + "&transMoney=" + transMoney + "&notifyUrl=" + notifyUrl + "&merchantName=" + merchantName + "&commodityName=" + commodityName + "&merchantNum=" + merchantNum + "&sign=" + sign;
            pageHelper.WriteLog("SendParam=========\r\n" + send_param);
            //开始发送
            string Json = Common.Utils.HttpPost(send_url, send_param);

            dynamic response = Newtonsoft.Json.JsonConvert.DeserializeObject(Json);
            string statusa = response.pl_url;
            pageHelper.WriteLog("Response================\r\n" + Json);
            //string html = "<a href=\"" + statusa + "\">支付</a>";
            //Response.Write(response);
            //Response.Write(html);
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "window.location.href='"+statusa+"'", true);
            //Response.Redirect(statusa);

            if (statusa == "" || statusa == null)
            {
                Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Qrcms.Common.Utils.UrlEncode(response.pl_payMessage)));
                return;
            }
            else
            {
                Bitmap bt;
                string enCodeString = statusa;
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeVersion = 0;
                bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
                string filename = string.Format(DateTime.Now.ToString(), "yyyymmddhhmmss")
                 + ".jpg";
                filename = filename.Replace(" ", "");
                filename = filename.Replace(":", "");
                filename = filename.Replace("-", "");
                filename = filename.Replace(".", "");
                filename = filename.Replace("/", "");
                if (!Directory.Exists("/images/"))
                {
                    Directory.CreateDirectory("/images/");
                }
                string dz = "/images/" + filename + ".png";
                bt.Save(Server.MapPath(dz));
                ImageUrl = "/images/" + filename + ".png";
                // Response.Write("<img style=\"margin:150px auto; width:150px; height:150px\" src=\"" + ImageUrl + "\"/><p style=\"color:#666; font-size:12px; text-align: center;\">保存二维码，用微信扫一扫付款</p>");
            }
        }

        #endregion

        private void sel()
        {
            string order_no = DTRequest.GetString("orderno");
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
    }
}