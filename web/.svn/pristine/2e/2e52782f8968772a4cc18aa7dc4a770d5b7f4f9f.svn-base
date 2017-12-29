using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Xml;
using System.Collections.Generic;
using Qrcms.Common;

namespace Qrcms.API.Payment.weixinwap
{
    public class Config
    {
        #region 字段
        private string appid = string.Empty;
        private string appsecret = string.Empty;
        private string mechid = string.Empty;
        private string mechkay = string.Empty;
        private string notify_url = string.Empty;
        private string input_charset = string.Empty;
        #endregion

        public Config()
        {
            //读取XML配置信息
            string fullPath = Utils.GetMapPath("~/xmlconfig/weixinwap.config");
            XmlDocument doc = new XmlDocument();
            doc.Load(fullPath);
            XmlNode _appid = doc.SelectSingleNode(@"Root/appid");
            XmlNode _appsecret = doc.SelectSingleNode(@"Root/appsecret");
            XmlNode _mechid = doc.SelectSingleNode(@"Root/mechid");
            XmlNode _mechkay = doc.SelectSingleNode(@"Root/mechkay");
            XmlNode _notify_url = doc.SelectSingleNode(@"Root/notify_url");
            //读取站点配置信息
            Model.siteconfig model = new BLL.siteconfig().loadConfig();

            //赋值变量值
            appid = _appid.InnerText;
            appsecret = _appsecret.InnerText;
            mechid = _mechid.InnerText;
            mechkay = _mechkay.InnerText;
            notify_url = "http://" + HttpContext.Current.Request.Url.Authority.ToLower() + _notify_url.InnerText;
            input_charset = "utf-8";
        }

        #region 属性
        /// <summary>
        /// 微信支付AppID
        /// </summary>
        public string Appid
        {
            get { return appid; }
            set { appid = value; }
        }

        /// <summary>
        /// 微信支付AppSecret
        /// </summary>
        public string Appsecret
        {
            get { return appsecret; }
            set { appsecret = value; }
        }

        /// <summary>
        /// 微信支付商户号
        /// </summary>
        public string Mechid
        {
            get { return mechid; }
            set { mechid = value; }
        }
        /// <summary>
        /// 微信支付商户密钥
        /// </summary>
        public string Mechkay
        {
            get { return mechkay; }
            set { mechkay = value; }
        }

        /// <summary>
        /// 获取服务器异步通知页面路径
        /// </summary>
        public string Notify_url
        {
            get { return notify_url; }
        }

        /// <summary>
        /// 获取字符编码格式
        /// </summary>
        public string Input_charset
        {
            get { return input_charset; }
        }
        #endregion
    }
}
