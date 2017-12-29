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

namespace Qrcms.Web.api.payment.weixinsmtwo
{
    public partial class index : System.Web.UI.Page
    {
        public string ImageUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DTRequest.GetString("action") == "sel")
            {
                sel();
                return;
            }

            //            1> 生成签名字符串
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
            XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixinsmtwo.config"));
            string merNo = doc.SelectSingleNode(@"Root/merNo").InnerText;//商户号
            string url = doc.SelectSingleNode(@"Root/url").InnerText;//接口地址
            string Key = doc.SelectSingleNode(@"Root/Key").InnerText;//接口地址
            string notifyUrl = siteConfig.weburl + doc.SelectSingleNode(@"Root/notifyUrl").InnerText;//异步通知url
            pageHelper.WriteLog("Response================\r\n" + notifyUrl);
            string orderNo = order_no;//商户订单号
            //orderNo = "R17090716593529";//---------
            string channelFlag = "00";//支付渠道默认微信支付
            string amount = order_amount.ToString("0");//订单金额
            string reqId = DateTime.Now.ToString("yyyyMMddhhmmss");//请求交易的流水号
            string reqTime = DateTime.Now.ToString("yyyyMMddhhmmss");//请求时间
            ////以下否必填
            string termNo = "00000090";//终端编码
            string operatorId = "10005";//操作员编号
            string currency = "CNY";//默认CNY（币种）
            string goodsName = "钱包扫码";//商品名称
            //string alipayUserId = "2088102146225135";//支付宝uerid
            string extraDesc = "充值";//附加信息
            string termNokey = termNo + Key;
            string signtext = "amount=" + amount + "&channelFlag=" + channelFlag + "&currency=" + currency + "&extraDesc=" + extraDesc + "&goodsName=" + goodsName + "&merNo=" + merNo + "&notifyUrl=" + notifyUrl + "&operatorId=" + operatorId + "&orderNo=" + orderNo + "&reqId=" + reqId + "&reqTime=" + reqTime + "&termNo=" + termNokey;//签名
            signtext = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(signtext));
            string signIn = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(signtext, "md5").ToUpper();

            string msgurlcs = "merNo=" + merNo + "&orderNo=" + orderNo + "&channelFlag=" + channelFlag + "&amount=" + amount + "&reqId=" + reqId + "&reqTime=" + reqTime + "&signIn=" + signIn + "&termNo=" + termNo + "&notifyUrl=" + notifyUrl + "&operatorId=" + operatorId + "&currency=" + currency + "&goodsName=" + goodsName + "&extraDesc=" + extraDesc + "";
            //发送请求
            pageHelper.WriteLog(url + "Response================\r\n" + msgurlcs);
            string Json = Common.Utils.HttpPost(url, msgurlcs);//" + url + "?
            dynamic response = Newtonsoft.Json.JsonConvert.DeserializeObject(Json);
            string statusa = response.codeUrl;
            pageHelper.WriteLog("Response================\r\n" + Json + "response.desc" + response.desc);
            //Response.Write(response);
            if (statusa == "" || statusa == null)
            {
                string ts = response.desc;
                Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + ts));
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
    }
}