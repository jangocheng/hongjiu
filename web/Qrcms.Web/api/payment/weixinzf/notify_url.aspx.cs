using Qrcms.API.Payment.weixinkj;
using Qrcms.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Qrcms.Web.api.payment.weixinzf
{
    public partial class notify_url : System.Web.UI.Page
    {
        private ClientResponseHandler resHandler = new ClientResponseHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            callback();
        }
        public void callback()
        {
            pageHelper.WriteLog("==============weixinzf=======");
            string return_code = "";
            string result_code = "";
            string out_trade_no = "";
            string total_fee = "";
            //接收并读取POST过来的XML文件流
            StreamReader reader = new StreamReader(Request.InputStream);
            String xmlData = reader.ReadToEnd();
            //解析回调的XML
            XmlDocument XMLHD = new XmlDocument();
            XMLHD.LoadXml(xmlData);
            XmlNode root = XMLHD.SelectSingleNode("xml");
            if (root.SelectSingleNode("return_code") != null)
            {
                return_code = (root.SelectSingleNode("return_code")).InnerText;
            }
            if (root.SelectSingleNode("result_code") != null)
            {
                result_code = (root.SelectSingleNode("out_trade_no")).InnerText;
            }
            if (root.SelectSingleNode("out_trade_no") != null)
            {
                out_trade_no = (root.SelectSingleNode("out_trade_no")).InnerText;
            }
            if (root.SelectSingleNode("total_fee") != null)
            {
                total_fee = (root.SelectSingleNode("total_fee")).InnerText;
            }
            string orderNum = out_trade_no;
            string pl_amount = total_fee;
            pageHelper.WriteLog(JsonHelper.ObjectToJSON(Request.Params));

            if (return_code == "SUCCESS" || result_code == "SUCCESS")
            {
                pageHelper.WriteLog("==============weixinzf=======" + orderNum);
                if (orderNum.StartsWith("R")) //充值订单
                {
                    BLL.user_recharge bll = new BLL.user_recharge();
                    Model.user_recharge model = bll.GetModel(orderNum);
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

                    bool result = bll.Confirm(orderNum);
                    if (!result)
                    {
                        Response.Write("{\"success\":\"false\"}");
                        return;
                    }
                }
                else if (orderNum.StartsWith("B")) //商品订单
                {
                    BLL.orders bll = new BLL.orders();
                    Model.orders model = bll.GetModel(orderNum);
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

                    bool result = bll.UpdateField(orderNum, "status=2,payment_status=2,payment_time='" + DateTime.Now + "'");
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