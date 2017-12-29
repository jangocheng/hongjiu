using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;
using Qrcms.API.Payment.weixinwap;
using System.Text;
using System.Xml;
using Qrcms.Web.UI;

namespace Qrcms.Web.api.payment.weixinwap
{
    public partial class notify_url : System.Web.UI.Page
    {
        protected string v_oid; //订单号

        // protected string v_amount; //支付金额


        protected void Page_Load(object sender, EventArgs e)
        {
            //读取站点配置信息
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            Config xmlConfig = new Config(); //读取配置

            System.IO.Stream s = Request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();


            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(builder.ToString());
            }
            catch
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");

            }

            if (data.GetValue("result_code") != null && data.GetValue("result_code").ToString() == "SUCCESS")
            {
                //检查支付结果中transaction_id是否存在
                if (data.GetValue("out_trade_no") != null && data.GetValue("out_trade_no") != "")
                {

                    v_oid = data.GetValue("out_trade_no").ToString().Trim();
                    //v_amount = data.GetValue("total_fee").ToString().Trim();
                    //成功状态
                    if (v_oid.StartsWith("R")) //充值订单
                    {
                        BLL.user_recharge bll = new BLL.user_recharge();
                        Model.user_recharge model = bll.GetModel(v_oid);
                        if (model == null)
                        {
                            Response.Write("error");
                            return;
                        }
                        if (model.status == 1) //已成功
                        {
                            Response.Write("ok");
                            return;
                        }
                        //if (model.amount != decimal.Parse(v_amount))
                        //{
                        //    Response.Write("error");
                        //    return;
                        //}
                        
                        bool result = bll.Confirm(v_oid);
                        if (!result)
                        {
                            Response.Write("error");
                            return;
                        }
                        
                    }
                   
                    else if (v_oid.StartsWith("B")) //商品订单
                    {
                        BLL.orders bll = new BLL.orders();
                        Model.orders model = bll.GetModel(v_oid);
                        if (model != null)
                        {


                            if (model.payment_status == 2) //已付款
                            {
                                Response.Write("ok");
                                return;
                            }
                            //if (model.order_amount != decimal.Parse(v_amount))
                            //{
                            //    Response.Write("error");
                            //    return;
                            //}
                            bool result = bll.UpdateField(v_oid, "status=2,payment_status=2,payment_id=6,payment_time='" + DateTime.Now + "'");
                            if (!result)
                            {
                                Response.Write("error");
                                return;
                            }
                            //扣除积分
                            if (model.point < 0)
                            {
                                new BLL.user_point_log().Add(model.user_id, model.user_name, model.point, "换购扣除积分，订单号：" + model.order_no, false);
                            }
                        }
                    }
                    

                }
            }


        }
    }
}