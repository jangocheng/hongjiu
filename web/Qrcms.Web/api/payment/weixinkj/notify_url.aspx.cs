using Qrcms.API.Payment.weixinkj;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qrcms.Web.api.payment.weixinkj
{
    public partial class notify_url : System.Web.UI.Page
    {
        private ClientResponseHandler resHandler = new ClientResponseHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RequestType == "POST")
            {
                callback();
            }
        }
        public void callback()
        {
            //加载配置数据
            var cfg = Qrcms.API.Payment.weixinkj.Utils.loadCfg();
            //初始化数据
            using (StreamReader sr = new StreamReader(Request.InputStream))
            {
                this.resHandler.setContent(sr.ReadToEnd());
                this.resHandler.setKey(cfg.key);

                Hashtable resParam = this.resHandler.getAllParameters();
                if (this.resHandler.isTenpaySign())
                {
                    if (int.Parse(resParam["status"].ToString()) == 0 && int.Parse(resParam["result_code"].ToString()) == 0)
                    {
                        string order_no = Common.Utils.ObjectToStr(resParam["out_trade_no"]);
                        decimal total_fee = Common.Utils.ObjToDecimal(resParam["total_fee"],0);
                        if (order_no.StartsWith("R")) //充值订单
                        {
                            BLL.user_recharge bll = new BLL.user_recharge();
                            Model.user_recharge model = bll.GetModel(order_no);
                            if (model == null)
                            {
                                Response.Write("该订单号不存在");
                                return;
                            }
                            if (model.status == 1) //已成功
                            {
                                Response.Write("success");
                                return;
                            }
                            if (model.amount != (total_fee / 100))
                            {
                                Response.Write("订单金额和支付金额不相符");
                                return;
                            }
                            bool result = bll.Confirm(order_no);
                            if (!result)
                            {
                                Response.Write("修改订单状态失败");
                                return;
                            }
                        }
                        else if (order_no.StartsWith("B")) //商品订单
                        {
                            BLL.orders bll = new BLL.orders();
                            Model.orders model = bll.GetModel(order_no);
                            if (model == null)
                            {
                                Response.Write("该订单号不存在");
                                return;
                            }
                            if (model.payment_status == 2) //已付款
                            {
                                Response.Write("success");
                                return;
                            }
                            if (model.order_amount != (total_fee / 100))
                            {
                                Response.Write("订单金额和支付金额不相符");
                                return;
                            }
                            string trade_no = resParam["transaction_id"].ToString();
                            bool result = bll.UpdateField(order_no, "trade_no='" + trade_no + "',status=2,payment_status=2,payment_time='" + DateTime.Now + "'");
                            if (!result)
                            {
                                Response.Write("修改订单状态失败");
                                return;
                            }
                            //扣除积分
                            if (model.point < 0)
                            {
                                new BLL.user_point_log().Add(model.user_id, model.user_name, model.point, "换购扣除积分，订单号：" + model.order_no, false);
                            }
                        }
                        Response.Write("success");

                    }
                    else
                    {
                        Response.Write("failure1");
                    }
                }
                else
                {
                    Response.Write("failure2");
                }
            }
        }
    }
}