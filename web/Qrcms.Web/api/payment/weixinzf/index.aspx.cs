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
using Senparc.Weixin.MP.TenPayLibV3;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;

namespace Qrcms.Web.api.payment.weixinzf
{
    public partial class index : Web.UI.UserPage
    {
        public string ImageUrl = "";
        public string wxJsApiParam = "";
        protected void Page_Load(object sender, EventArgs e)
        {
          
            //读取站点配置信息
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //系统配置
            XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixinzf.config"));
            string id = doc.SelectSingleNode(@"Root/mch_id").InnerText;
            string number = doc.SelectSingleNode(@"Root/mch_number").InnerText;
            string key = doc.SelectSingleNode(@"Root/zf_key").InnerText;
            string url = doc.SelectSingleNode(@"Root/notify_Url").InnerText;

            string order_no = DTRequest.GetString("pay_order_no").ToUpper();
            decimal order_amount = Common.Utils.StrToDecimal(DTRequest.GetString("pay_order_amount"), 0);
            order_amount = order_amount * 100;
            //if (order_amount < 1000)
            //{
            //    Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("对不起，支付金额不能少于10元！")));
            //    return;
            //}

            string user_name = DTRequest.GetString("pay_user_name");
            string subject = DTRequest.GetString("pay_subject");

            //=====================POST XML 内容体进行请求========================//
            string mch_id = id;//	是	String(32)	商户号，由UCHANG分配
            string sub_appid = "wx45fcdf0cc3d5b8b4";	//否	String(32)	商户微信公众号appid,app支付时,为在微信开放平台上申请的APPID
            string device_info = "";//	否	String(32)	终端设备号(门店号或收银设备ID)，注意：PC网页或公众号内支付请传"WEB"
            string nonce_str = yzQRcodestate();//	是	String(32)	随机字符串，不长于32位
            string sign = "";//	是	String(32)	MD5 签名结果，详见“第 4 章 MD5 签名规则”
            string body = "在线充值";//	是	String(128)	商品描述
            string detail = "";//	否	String(8192 )	商品详细列表，使用Json格式，传输签名前请务必使用CDATA标签将JSON文本串保护起来。goods_detail 服务商必填 []：└ goods_id String 必填 32 商品的编号└ wxpay_goods_id String 可选 32 微信支付定义的统一商品编号└ goods_name String 必填 256 商品名称└ quantity Int 必填 商品数量└ price Int 必填 商品单价，单位为分└ goods_category String 可选 32 商品类目ID└ body String 可选 1000 商品描述信息
            string attach = "";//	否	String(127)	附加数据，在查询API和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据
            string out_trade_no = order_no;//	是	String(32)	商户系统内部的订单号,32个字符内、可包含字母, 其他说明见商户订单号
            string fee_type = "";//	否	String(16)	符合ISO 4217标准的三位字母代码，默认人民币：CNY
            string total_fee = order_amount.ToString("0");//	是	Int	总金额，以分为单位，不允许包含任何字、符号
            string spbill_create_ip = DTRequest.GetIP();// Request.ServerVariables["LOCAL_ADDR"];//	是	String(16)	APP和网页支付提交用户端ip，Native支付填调用微信支付API的机器IP。
            string time_start = "";//	否	String(14)	订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010
            string time_expire = "";//	否	String(14)	如上
            string goods_tag = "";//	否	String(32)	商品标记，代金券或立减优惠功能的参数
            string notify_url = siteConfig.weburl + url;//	是	String(256)	接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。
            //siteConfig.weburl + notifyUrls;
            //网上http://jiufangzc.com/api/payment/weixinsm/notify_url.aspx
            //本地http://localhost:10080/api/payment/weixinsm/notify_url.aspx
            string trade_type = "JSAPI";//	是	String(16)	取值如下：JSAPI，NATIVE，APP，MWEB（H5支付）
            string product_id = "";//	否	String(32)	trade_type=NATIVE，此参数必传。此id为二维码中包含的商品ID，商户自行定义。
            string limit_pay = "";//	否	String(32)	no_credit–指定不能使用信用卡支付
            string sub_openid = userModel.openid;//	否	String(128)	trade_type=JSAPI，此参数必传，用户在子商户appid下的唯一标识。openid和sub_openid可以选传其中之一，如果选择传sub_openid,则必须传sub_appid。
            string wxapp = "";//	否	String(32)	true–小程序支付；此字段控制 js_prepay_info 的生成，为true时js_prepay_info返回小程序支付参数，否则返回公众号支付参数
            string scene_info = "";//	否  String(256)	trade_type=MWEB，此参数必传。WAP网站应用 {“h5_info”: {“type”:“Wap”,“wap_url”: “WAP网站URL地址”,“wap_name”: “WAP网站名”}}，IOS移动应用 {“h5_info”: {“type”:“IOS”,“app_name”: “应用名”,“bundle_id”: “包名”}}，安卓移动应用 {“h5_info”: {“type”:“Android”,“app_name”: “应用名”,“package_name”: “包名”}}。H5支付建议只在Wap场景上使用。


            string signtext = "body=" + body + "&mch_id=" + mch_id + "&nonce_str=" + nonce_str + "&notify_url=" + notify_url + "&out_trade_no=" + out_trade_no + "&spbill_create_ip=" + spbill_create_ip + "&sub_appid=" + sub_appid + "&sub_openid=" + sub_openid + "&total_fee=" + total_fee + "&trade_type=" + trade_type + "&key=" + key;
            sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(signtext, "md5").ToLower();
            sign = sign.ToUpper();
            //检查参数是否正确

            //链接
            string send_url = "http://api.mch.spd.uline.cc/wechat/orders";
            string XML = "";
            XML += "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            XML += "<xml>";
            XML += "<body>" + body + "</body>";
            XML += "<mch_id>" + mch_id + "</mch_id>";
            XML += "<sub_appid>" + sub_appid + "</sub_appid>";
            //XML += "<device_info>" + device_info + "</device_info>";
            XML += "<nonce_str>" + nonce_str + "</nonce_str>";
            XML += "<notify_url>" + notify_url + "</notify_url>";
            //XML += "<detail>" + detail + "</detail>";
            //XML += "<attach>" + attach + "</attach>";
            XML += "<out_trade_no>" + out_trade_no + "</out_trade_no>";
            //XML += "<fee_type>" + fee_type + "</fee_type>";
            XML += "<spbill_create_ip>" + spbill_create_ip + "</spbill_create_ip>";
            //XML += "<time_start>" + time_start + "</time_start>";
            //XML += "<time_expire>" + time_expire + "</time_expire>";
            //XML += "<goods_tag>" + goods_tag + "</goods_tag>";
            XML += "<total_fee>" + total_fee + "</total_fee>";
            XML += "<trade_type>" + trade_type + "</trade_type>";
            //XML += "<product_id>" + product_id + "</product_id>";
            //XML += "<limit_pay>" + limit_pay + "</limit_pay>";
            XML += "<sub_openid>" + sub_openid + "</sub_openid>";
            //XML += "<wxapp>" + wxapp + "</wxapp>";
            //XML += "<scene_info>" + scene_info + "</scene_info>";
            XML += "<sign>" + sign + "</sign>";
            XML += "</xml>";
            pageHelper.WriteLog(XML);
            string Json = Common.Utils.HttpPost(send_url, XML);
            pageHelper.WriteLog(Json);
            //Response.Write(Json);

            //声明参数//
            string return_mch_id = "";//商户号,由UChang分配
            string return_code = "";//SUCCESS/FAIL 此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断
            string return_msg = "";
            string result_code = "";//业务返回结果SUCCESS/FAIL,
            string return_nonce_str = "";//随机字符串,不长于 32 位
            string return_sign = "";//MD5 签名结果,详见“第 4 章 MD5 签名规则”
            string return_out_trade_no = "";
            string return_code_url = "";//微信支付异步通知回调地址
            string return_prepay_id = "";
            string return_trade_type = "";//调用接口提交的交易类型，取值如下：JSAPI，NATIVE，APP，WMWEB

            //解析回调的XML
            XmlDocument XMLHD = new XmlDocument();
            XMLHD.LoadXml(Json);
            XmlNode root = XMLHD.SelectSingleNode("xml");
            if (root.SelectSingleNode("mch_id") != null)
            {
                return_mch_id = (root.SelectSingleNode("mch_id")).InnerText;
            }
            if (root.SelectSingleNode("return_code") != null)
            {
                return_code = (root.SelectSingleNode("return_code")).InnerText;
            }
            if (root.SelectSingleNode("return_msg") != null)
            {
                return_msg = (root.SelectSingleNode("return_msg")).InnerText;
            }
            if (root.SelectSingleNode("result_code") != null)
            {
                result_code = (root.SelectSingleNode("result_code")).InnerText;
            }
            if (root.SelectSingleNode("nonce_str") != null)
            {
                return_nonce_str = (root.SelectSingleNode("nonce_str")).InnerText;
            }
            if (root.SelectSingleNode("sign") != null)
            {
                return_sign = (root.SelectSingleNode("sign")).InnerText;
            }
            if (root.SelectSingleNode("out_trade_no") != null)
            {
                return_out_trade_no = (root.SelectSingleNode("out_trade_no")).InnerText;
            }
            if (root.SelectSingleNode("code_url") != null)
            {
                return_code_url = (root.SelectSingleNode("code_url")).InnerText;
            }
            if (root.SelectSingleNode("prepay_id") != null)
            {
                return_prepay_id = (root.SelectSingleNode("prepay_id")).InnerText;
            }
            if (root.SelectSingleNode("trade_type") != null)
            {
                return_trade_type = (root.SelectSingleNode("trade_type")).InnerText;
            }
            if (root.SelectSingleNode("js_prepay_info") != null)
            {
                wxJsApiParam = (root.SelectSingleNode("js_prepay_info")).InnerText.Replace("&#34;", "\"");
            }
            //回调路径
            if (wxJsApiParam != "")
            {
                //Bitmap bt;
                //string enCodeString = return_code_url;
                //QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                //qrCodeEncoder.QRCodeVersion = 0;
                //bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
                //string filename = string.Format(DateTime.Now.ToString(), "yyyymmddhhmmss")
                // + ".jpg";
                //filename = filename.Replace(" ", "");
                //filename = filename.Replace(":", "");
                //filename = filename.Replace("-", "");
                //filename = filename.Replace(".", "");
                //filename = filename.Replace("/", "");
                //if (!Directory.Exists("/images/"))
                //{
                //    Directory.CreateDirectory("/images/");
                //}
                //string dz = "/images/" + filename + ".png";
                //bt.Save(Server.MapPath(dz));
                //ImageUrl = "/images/" + filename + ".png";
                // Response.Write("<img style=\"margin:150px auto; width:150px; height:150px\" src=\"" + ImageUrl + "\"/><p style=\"color:#666; font-size:12px; text-align: center;\">保存二维码，用微信扫一扫付款</p>");
            }
            else
            {
                Response.Redirect(new Web.UI.BasePage().linkurl("error", "?msg=" + Common.Utils.UrlEncode("对不起，您提交的参数有误！")));
                return;
            }
        }

        #region 生成随机字符串===========================
        /// </summary>
        /// <param name="QRcodestate"></param>
        /// <returns></returns>
        private string yzQRcodestate()
        {
            string QRcodestateNew = "";
            Random rd = new Random();
            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
            string result = "";
            for (int i = 0; i < 6; i++)
            {
                result += str[rd.Next(str.Length)];
            }
            QRcodestateNew = result;
            return QRcodestateNew;
        }
        #endregion
    }
}