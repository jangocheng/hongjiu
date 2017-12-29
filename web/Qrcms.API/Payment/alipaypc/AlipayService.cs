﻿using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Qrcms.API.Payment.alipaypc
{
    /// <summary>
    /// 类名：Service
    /// 功能：支付宝各接口构造类
    /// 详细：构造支付宝各接口请求参数
    /// 版本：3.2
    /// 修改日期：2011-03-17
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考
    /// 
    /// 要传递的参数要么不允许为空，要么就不要出现在数组与隐藏控件或URL链接里。
    /// </summary>
    public class Service
    {
        #region 字段
        //合作者身份ID
        private string _partner = string.Empty;
        //交易安全验证码
        private string _key = string.Empty;
        //接口类型1即时到帐2担保交易
        private string _type = "1";
        //字符编码格式
        private string _input_charset = string.Empty;
        //签约支付宝账号或卖家支付宝帐户
        private string _email = string.Empty;
        //页面跳转同步返回页面文件路径
        private string _return_url = string.Empty;
        //服务器通知的页面文件路径
        private string _notify_url = string.Empty;
        //支付宝网关地址（新）
        private string GATEWAY_NEW = "https://mapi.alipay.com/gateway.do?";
        #endregion

        /// <summary>
        /// 构造函数
        /// 从配置文件及入口文件中初始化变量
        /// </summary>
        public Service()
        {
            _partner = Config.Partner.Trim();
            _key = Config.Key.Trim();
            _type = Config.Type.Trim();
            _input_charset = Config.Input_charset.Trim().ToLower();
            _email = Config.Email.Trim();
            _return_url = Config.Return_url.Trim();
            _notify_url = Config.Notify_url.Trim();
        }

        /// <summary>
        /// 构造即时到帐接口
        /// </summary>
        /// <param name="sParaTemp">请求参数集合</param>
        /// <returns>表单提交HTML信息</returns>
        public string Create_direct_pay_by_user(SortedDictionary<string, string> sParaTemp)
        {
            //增加基本配置
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("partner", _partner);
            sParaTemp.Add("_input_charset", _input_charset);
            sParaTemp.Add("seller_email", _email);
            sParaTemp.Add("return_url", _return_url);
            sParaTemp.Add("notify_url", _notify_url);

            //确认按钮显示文字
            string strButtonValue = "确认";
            //表单提交HTML数据
            string strHtml = "";

            //构造表单提交HTML数据
            strHtml = Submit.BuildFormHtml(sParaTemp, GATEWAY_NEW, "get", strButtonValue);

            return strHtml;
        }

        /// <summary>
        /// 构造担保交易接口
        /// </summary>
        /// <param name="sParaTemp">请求参数集合</param>
        /// <returns>表单提交HTML信息</returns>
        public string Create_partner_trade_by_buyer(SortedDictionary<string, string> sParaTemp)
        {
            //增加基本配置
            sParaTemp.Add("service", "create_partner_trade_by_buyer");
            sParaTemp.Add("partner", _partner);
            sParaTemp.Add("_input_charset", _input_charset);
            sParaTemp.Add("seller_email", _email);
            sParaTemp.Add("return_url", _return_url);
            sParaTemp.Add("notify_url", _notify_url);

            //确认按钮显示文字
            string strButtonValue = "确认";
            //表单提交HTML数据
            string strHtml = "";

            //构造表单提交HTML数据
            strHtml = Submit.BuildFormHtml(sParaTemp, GATEWAY_NEW, "get", strButtonValue);

            return strHtml;
        }

        /// <summary>
        /// 构造担保交易发货接口
        /// </summary>
        /// <param name="trade_no">支付宝交易号</param>
        /// <param name="logistics_name">物流公司名称</param>
        /// <param name="invoice_no">物流发货单号</param>
        /// <param name="transport_type">发货运输类型：其它快递(EXPRESS)、无需物流(DIRECT)</param>
        /// <returns>是否成功(布尔值)</returns>
        public bool Send_goods_confirm_by_platform(string trade_no, string logistics_name, string invoice_no, string transport_type)
        {
            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("service", "send_goods_confirm_by_platform");
            sParaTemp.Add("partner", _partner);
            sParaTemp.Add("_input_charset", _input_charset);
            sParaTemp.Add("trade_no", trade_no);
            sParaTemp.Add("logistics_name", logistics_name); //物流名称
            sParaTemp.Add("invoice_no", invoice_no); //发货单号
            sParaTemp.Add("transport_type", transport_type); //可选值：其它快递(EXPRESS)、无需物流(DIRECT)

            //建立请求
            XmlDocument xmlDoc = Submit.SendPostInfo(sParaTemp, GATEWAY_NEW);
            try
            {
                string strXmlResponse = xmlDoc.SelectSingleNode("/alipay/is_success").InnerText;
                if (!string.IsNullOrEmpty(strXmlResponse) && strXmlResponse == "T")
                {
                    return true;
                }
            }
            catch (Exception exp)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// 用于防钓鱼，调用接口query_timestamp来获取时间戳的处理函数
        /// 注意：远程解析XML出错，与IIS服务器配置有关
        /// </summary>
        /// <returns>时间戳字符串</returns>
        public string Query_timestamp()
        {
            string url = GATEWAY_NEW + "service=query_timestamp&partner=" + Config.Partner;
            string encrypt_key = "";

            XmlTextReader Reader = new XmlTextReader(url);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Reader);

            encrypt_key = xmlDoc.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText;

            return encrypt_key;
        }

        //******************若要增加其他支付宝接口，可以按照下面的格式定义******************//
        /// <summary>
        /// 构造(支付宝接口名称)接口
        /// </summary>
        /// <param name="sParaTemp">请求参数集合</param>
        /// <returns>表单提交HTML文本或者支付宝返回XML处理结果</returns>
        public string AlipayInterface(SortedDictionary<string, string> sParaTemp)
        {
            //增加基本配置

            //表单提交HTML数据变量
            string strHtml = "";


            //构造请求参数数组


            //构造给支付宝处理的请求
            //请求方式有以下三种：
            //1.构造表单提交HTML数据:Submit.BuildFormHtml()
            //2.构造模拟远程HTTP的POST请求，获取支付宝的返回XML处理结果:Submit.SendPostInfo()
            //3.构造模拟远程HTTP的GET请求，获取支付宝的返回XML处理结果:Submit.SendGetInfo()
            //请根据不同的接口特性三选一


            return strHtml;
        }
    }
}