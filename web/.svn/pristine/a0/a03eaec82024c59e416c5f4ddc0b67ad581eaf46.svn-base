using Qrcms.API.Weixin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace Qrcms.API.Payment.weixinwap
{
    /// <summary>
    /// JsApiPay 的摘要说明
    /// </summary>
    public class JsApiPay
    {
        
        public JsApiPay()
        {

            //
            // TODO: 在此处添加构造函数逻辑
            //
        }/// <summary>
        /// 保存页面对象，因为要在类的方法中使用Page的Request对象
        /// </summary>
        private Page page { get; set; }

        /// <summary>
        /// openid用于调用统一下单接口
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// access_token用于获取收货地址js函数入口参数
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 商品金额，用于统一下单
        /// </summary>
        public int total_fee { get; set; }

        /// <summary>
        /// 统一下单接口返回结果
        /// </summary>
        public WxPayData unifiedOrderResult { get; set; }

        public JsApiPay(Page page)
        {
            this.page = page;
        }



        /**
         * 调用统一下单，获得下单结果
         * @return 统一下单结果
         * @失败时抛异常WxPayException
         */
        public WxPayData GetUnifiedOrderResult(string out_trade_no, string name)
        {
            //统一下单
            WxPayData data = new WxPayData();
            data.SetValue("body", name);
            data.SetValue("attach", name);
            data.SetValue("out_trade_no", out_trade_no);
            data.SetValue("total_fee", total_fee);
            data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));
            data.SetValue("goods_tag", "test");
            data.SetValue("trade_type", "JSAPI");
            data.SetValue("openid", openid);

            WxPayData result = UnifiedOrder(data);
            if (!result.IsSet("appid") || !result.IsSet("prepay_id") || result.GetValue("prepay_id").ToString() == "")
            {
                //Qrhx.MessageBox("UnifiedOrder response error!", "Back");
                //Log.Error(this.GetType().ToString(), "UnifiedOrder response error!");
                //throw new WxPayException("UnifiedOrder response error!");
            }

            unifiedOrderResult = result;
            return result;
        }

        /**
        * 提现，获得下单结果
        * @return 统一下单结果
        * @失败时抛异常WxPayException
        */
        public WxPayData GetResult(string out_trade_no, string name,string desc)
        {
            //统一下单
            WxPayData data = new WxPayData();
            data.SetValue("body", name);
            data.SetValue("partner_trade_no", out_trade_no);
            data.SetValue("amount", total_fee);
            data.SetValue("check_name", "FORCE_CHECK");
            data.SetValue("desc",desc);
            //data.SetValue("goods_tag", "test");
            //data.SetValue("trade_type", "JSAPI");
            data.SetValue("openid", openid);

            WxPayData result = UnifiedTXJL(data);
            //if (!result.IsSet("appid") || !result.IsSet("prepay_id") || result.GetValue("prepay_id").ToString() == "")
            //{
            //    //Qrhx.MessageBox("UnifiedOrder response error!", "Back");
            //    //Log.Error(this.GetType().ToString(), "UnifiedOrder response error!");
            //    //throw new WxPayException("UnifiedOrder response error!");
            //}

            unifiedOrderResult = result;
            return result;
        }
        /**
          * 
          * 统一下单
          * @param WxPaydata inputObj 提交给统一下单API的参数
          * @param int timeOut 超时时间
          * @throws WxPayException
          * @return 成功时返回，其他抛异常
          */
        public static WxPayData UnifiedOrder(WxPayData inputObj, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no"))
            {
                CRMComm.Writebug("缺少统一支付接口必填参数out_trade_no！");
                HttpContext.Current.Response.End();

            }
            else if (!inputObj.IsSet("body"))
            {
                CRMComm.Writebug("缺少统一支付接口必填参数body！");
                HttpContext.Current.Response.End();
            }
            else if (!inputObj.IsSet("total_fee"))
            {
                CRMComm.Writebug("缺少统一支付接口必填参数total_fee！");
                HttpContext.Current.Response.End();
            }
            else if (!inputObj.IsSet("trade_type"))
            {
                CRMComm.Writebug("缺少统一支付接口必填参数trade_type！");
                HttpContext.Current.Response.End();
            }

            //关联参数
            if (inputObj.GetValue("trade_type").ToString() == "JSAPI" && !inputObj.IsSet("openid"))
            {
                CRMComm.Writebug("统一支付接口中，缺少必填参数openid！trade_type为JSAPI时，openid为必填参数");
                HttpContext.Current.Response.End();
            }
            if (inputObj.GetValue("trade_type").ToString() == "NATIVE" && !inputObj.IsSet("product_id"))
            {
                CRMComm.Writebug("统一支付接口中，缺少必填参数product_id！trade_type为JSAPI时，product_id为必填参数！");
                HttpContext.Current.Response.End();
            }

            Config xmlConfig = new Config(); //读取配置
            string appid = xmlConfig.Appid.Trim();
            string appsecret = xmlConfig.Appsecret.Trim();
            string mechid = xmlConfig.Mechid.Trim().ToLower();
            string mechkay = xmlConfig.Mechkay.Trim();
            string notify_url = xmlConfig.Notify_url.Trim();

            //异步通知url未设置，则使用配置文件中的url
            if (!inputObj.IsSet("notify_url"))
            {
                inputObj.SetValue("notify_url", notify_url);//异步通知url
            }
            CRMComm.Writebug("appid:" + appid);
        

            string logip = null;
            logip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            inputObj.SetValue("appid", appid);//公众账号ID
            inputObj.SetValue("mch_id", mechid);//商户号
            inputObj.SetValue("spbill_create_ip", logip);//终端ip	  	    
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串

            //签名
            inputObj.SetValue("sign", inputObj.MakeSign());
            string xml = inputObj.ToXml();

            var start = DateTime.Now;

            string response = HttpService.Post(xml, url, false, timeOut);
            CRMComm.Writebug("response:" + response);
            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);

            WxPayData result = new WxPayData();
            result.FromXml(response);


            return result;
        }


        /**
       * 
       * 统一下单
       * @param WxPaydata inputObj 提交给统一下单API的参数
       * @param int timeOut 超时时间
       * @throws WxPayException
       * @return 成功时返回，其他抛异常
       */
        public static WxPayData UnifiedTXJL(WxPayData inputObj, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers";
            //检测必填参数
            if (!inputObj.IsSet("partner_trade_no"))
            {
                CRMComm.Writebug("缺少统一支付接口必填参数partner_trade_no！");
                HttpContext.Current.Response.End();

            }
            else if (!inputObj.IsSet("body"))
            {
                CRMComm.Writebug("缺少统一支付接口必填参数body！");
                HttpContext.Current.Response.End();
            }
            else if (!inputObj.IsSet("amount"))
            {
                CRMComm.Writebug("缺少统一支付接口必填参数amount！");
                HttpContext.Current.Response.End();
            }
            else if (!inputObj.IsSet("check_name"))
            {
                CRMComm.Writebug("缺少统一支付接口必填参数check_name！");
                HttpContext.Current.Response.End();
            }
            else if (!inputObj.IsSet("desc"))
            {
                CRMComm.Writebug("缺少统一支付接口必填参数desc！");
                HttpContext.Current.Response.End();
            }
            else if (!inputObj.IsSet("openid"))
            {
                CRMComm.Writebug("缺少统一支付接口必填参数openid！");
                HttpContext.Current.Response.End();
            }
           

            Config xmlConfig = new Config(); //读取配置
            string appid = xmlConfig.Appid.Trim();
            string appsecret = xmlConfig.Appsecret.Trim();
            string mechid = xmlConfig.Mechid.Trim().ToLower();
            string mechkay = xmlConfig.Mechkay.Trim();
            string notify_url = xmlConfig.Notify_url.Trim();

            //异步通知url未设置，则使用配置文件中的url
            if (!inputObj.IsSet("notify_url"))
            {
                inputObj.SetValue("notify_url", notify_url);//异步通知url
            }
            CRMComm.Writebug("appid:" + appid);


            string logip = null;
            logip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            inputObj.SetValue("appid", appid);//公众账号ID
            inputObj.SetValue("mch_id", mechid);//商户号
            inputObj.SetValue("spbill_create_ip", logip);//终端ip	  	    
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串

            //签名
            inputObj.SetValue("sign", inputObj.MakeSign());
            string xml = inputObj.ToXml();

            var start = DateTime.Now;

            string response = HttpService.Post(xml, url, false, timeOut);
            CRMComm.Writebug("response:" + response);
            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);

            WxPayData result = new WxPayData();
            result.FromXml(response);


            return result;
        }

        /**
        *  
        * 从统一下单成功返回的数据中获取微信浏览器调起jsapi支付所需的参数，
        * 微信浏览器调起JSAPI时的输入参数格式如下：
        * {
        *   "appId" : "wx2421b1c4370ec43b",     //公众号名称，由商户传入     
        *   "timeStamp":" 1395712654",         //时间戳，自1970年以来的秒数     
        *   "nonceStr" : "e61463f8efa94090b1f366cccfbbb444", //随机串     
        *   "package" : "prepay_id=u802345jgfjsdfgsdg888",     
        *   "signType" : "MD5",         //微信签名方式:    
        *   "paySign" : "70EA570631E4BB79628FBCA90534C63FF7FADD89" //微信签名 
        * }
        * @return string 微信浏览器调起JSAPI时的输入参数，json格式可以直接做参数用
        * 更详细的说明请参考网页端调起支付API：http://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=7_7
        * 
        */
        public string GetJsApiParameters()
        {

            WxPayData jsApiParam = new WxPayData();
            jsApiParam.SetValue("appId", unifiedOrderResult.GetValue("appid"));
            jsApiParam.SetValue("timeStamp", GenerateTimeStamp());
            jsApiParam.SetValue("nonceStr", GenerateNonceStr());
            jsApiParam.SetValue("package", "prepay_id=" + unifiedOrderResult.GetValue("prepay_id"));
            jsApiParam.SetValue("signType", "MD5");
            jsApiParam.SetValue("paySign", jsApiParam.MakeSign());

            string parameters = jsApiParam.ToJson();
            CRMComm.Writebug("parameters:" + parameters + "|");
            return parameters;
        }
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        /**
       * 生成随机串，随机串包含字母或数字
       * @return 随机串
       */
        public static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

    }
}