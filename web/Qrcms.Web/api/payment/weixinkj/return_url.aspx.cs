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
    public partial class return_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.RequestType == "POST")
            //{
                callback();
           // }

        }
        public void callback()
        {
            //加载配置数据
           // var cfg = Qrcms.API.Payment.weixinkj.Utils.loadCfg();
            //初始化数据
            //using (StreamReader sr = new StreamReader(Request.InputStream))
            //{
            //    this.resHandler.setContent(sr.ReadToEnd());
            //    this.resHandler.setKey(cfg.key);

            //    Hashtable resParam = this.resHandler.getAllParameters();
            //    if (this.resHandler.isTenpaySign())
            //    {
            //        if (int.Parse(resParam["status"].ToString()) == 0 && int.Parse(resParam["result_code"].ToString()) == 0)
            //        {
            //            string out_trade_no = Common.Utils.ObjectToStr(resParam["out_trade_no"]);
                       Response.Redirect("/mobile/payment.aspx?action=succeed&order_no=" +Common.DTRequest.GetString("order_no"));
            //            return;

            //        }
            //        else
            //        {
            //            Response.Redirect(new Web.UI.BasePage().linkurl("payment", "?action=error"));
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        Response.Redirect(new Web.UI.BasePage().linkurl("payment", "?action=error"));
            //        return;
            //    }
            //}
        }
    }
}