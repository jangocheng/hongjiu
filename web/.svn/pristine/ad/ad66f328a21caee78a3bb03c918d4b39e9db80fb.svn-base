using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;
using Qrcms.API.Payment.alipaypc;

namespace Qrcms.Web.api.terrace
{
    public partial class terracedf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取请求参数
            string merchantCode = DTRequest.GetString("merchantCode");//平台商户编号
            string service = "cj006";//服务类型(默认填写cj006)
            string orderNum = DTRequest.GetString("orderNum");//合作商订单号，全局唯一
            string accountName = DTRequest.GetString("accountName");//收款人账户名
            string bankCard = DTRequest.GetString("bankCard");//收款人账户号
            string bankName = DTRequest.GetString("bankName");//收款人账户开户行名称
            string bankLinked = DTRequest.GetString("bankLinked");//收款人账户开户行联行号
            string transMoney = DTRequest.GetString("transMoney");//交易金额(单位:分)"1000"
            string type = DTRequest.GetString("type");//交易类型(T1:1,D0:0)
            string sign = "";//以上数据签名MD5
            string signtext = accountName + bankCard + bankLinked + bankName + merchantCode + orderNum + service + transMoney + type + "947d48d9a40f44318595237632123456";
            sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(signtext, "md5").ToLower();


            string send_url = "http://60.28.24.164:8102/app_posp/live/qrcode/interface.action";
            string send_param = "merchantCode=" + merchantCode + "&service=" + service + "&orderNum=" + orderNum + "&accountName=" + accountName + "&bankCard=" + bankCard + "&bankName=" + bankName + "&bankLinked=" + bankLinked + "&transMoney=" + transMoney + "&type=" + type + "&sign=" + sign;

            //开始发送
            string Json = Common.Utils.HttpPost(send_url, send_param);

            dynamic response = Newtonsoft.Json.JsonConvert.DeserializeObject(Json);
            Response.Write(response);
        }
    }
}