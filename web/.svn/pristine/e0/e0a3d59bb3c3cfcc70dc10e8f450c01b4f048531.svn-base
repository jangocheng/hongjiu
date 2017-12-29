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
using System.Xml;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.Text;
using System.IO;

namespace Qrcms.Web.api.payment.weixinsmtwo
{
    public partial class notify_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            callback();
        }

        public void callback()
        {
            pageHelper.WriteLog("==============weixinsmtwo=======");
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //系统配置
            XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixinsmtwo.config"));
            string Key = doc.SelectSingleNode(@"Root/Key").InnerText;//接口地址

            string extraDesc = Request.Params["extraDesc"];
            string reqId = Request.Params["reqId"];
            string notifyTime = Request.Params["notifyTime"];
            string payTime = Request.Params["payTime"];
            string currency = Request.Params["currency"];
            string amount = Request.Params["amount"];
            string orderNo = Request.Params["orderNo"];
            string bankType = Request.Params["bankType"];
            string transId = Request.Params["transId"];
            string outOrderNo = Request.Params["outOrderNo"];
            string channelFlag = Request.Params["channelFlag"];
            string termNo = Request.Params["termNo"];
            string uuid = Request.Params["uuid"];
            string signIn = Request.Params["signIn"];
            string merNo = Request.Params["merNo"];
            string goodsName = Request.Params["goodsName"];
            string uuidNew = uuid + Key;
            pageHelper.WriteLog("++++++++++czcz+++++++++++");
            string signtext = "amount=" + amount + "&bankType=" + bankType + "&channelFlag=" + channelFlag + "&currency=" + currency + "&extraDesc=" + extraDesc + "&goodsName=" + goodsName + "&merNo=" + merNo + "&notifyTime=" + notifyTime + "&orderNo=" + orderNo + "&outOrderNo=" + outOrderNo + "&payTime=" + payTime + "&reqId=" + reqId + "&termNo=" + termNo + "&transId=" + transId + "&uuid=" + uuidNew;//签名
            pageHelper.WriteLog("++++++++++" + signtext + "+++++++++++");
            signtext = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(signtext));
            string signInNew = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(signtext, "md5").ToUpper();
            pageHelper.WriteLog("++++++++++" + signInNew + "+++++++++++");
            if (signIn == signInNew && !string.IsNullOrEmpty(orderNo))
            {
                if (orderNo.StartsWith("R")) //充值订单
                {
                    BLL.user_recharge bll = new BLL.user_recharge();
                    Model.user_recharge model = bll.GetModel(orderNo);
                    if (model == null)
                    {
                        Response.Write("{\"success\":\"false\"}");
                        return;
                    }
                    if (model.status == 1) //已成功
                    {
                        Response.Write("{\"success\":\"true\"}");
                        return;
                    }

                    bool result = bll.Confirm(orderNo);
                    if (!result)
                    {
                        Response.Write("{\"success\":\"false\"}");
                        return;
                    }
                }
                else if (orderNo.StartsWith("B")) //商品订单
                {
                    BLL.orders bll = new BLL.orders();
                    Model.orders model = bll.GetModel(orderNo);
                    if (model == null)
                    {
                        Response.Write("{\"success\":\"false\"}");
                        return;
                    }
                    if (model.payment_status == 2) //已付款
                    {
                        Response.Write("{\"success\":\"true\"}");
                        return;
                    }

                    bool result = bll.UpdateField(orderNo, "status=2,payment_status=2,payment_time='" + DateTime.Now + "'");
                    if (!result)
                    {
                        Response.Write("{\"success\":\"false\"}");
                        return;
                    }
                    //扣除积分
                    if (model.point < 0)
                    {
                        new BLL.user_point_log().Add(model.user_id, model.user_name, model.point, "换购扣除积分，订单号：" + model.order_no, false);
                    }
                }
                Response.Write("{\"success\":\"true\"}");
                return;
            }
            else
            {
                Response.Write("{\"success\":\"false\"}");
                return;
            }
        }
    }
}