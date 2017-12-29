using Qrcms.API.Payment.weixinkj;
using Qrcms.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qrcms.Web.api.payment.weixinsm
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
            pageHelper.WriteLog("==============weixinsm=======");
            string orderNum = Request.Params["orderNum"]; // DTRequest.GetString("orderNum");
            string pl_orderNum=Request.Params["pl_orderNum"];//
            string pl_amount = Request.Params["pl_amount"];//DTRequest.GetString("pl_amount");
            string pl_payMessage = Request.Params["pl_payMessage"]; // DTRequest.GetString("pl_payMessage");
            string pl_payState = Request.Params["pl_payState"];// DTRequest.GetString("pl_payState");
            pageHelper.WriteLog(JsonHelper.ObjectToJSON( Request.Params));

            if (pl_payState == "4" && !string.IsNullOrEmpty(orderNum))
            {
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