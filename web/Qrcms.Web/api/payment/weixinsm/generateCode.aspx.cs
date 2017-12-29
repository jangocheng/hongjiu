using Qrcms.Web.UI;
using swiftpass.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qrcms.Web.api.payment.weixinsm
{
    public partial class generateCode : System.Web.UI.Page
    {
        private static int SUM = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["pavlue"] == null)
                {
                    Response.Redirect("/aspx/mobile/usercenter.aspx");//
                }
                else
                {
                    string[] getvalue = (string[])Session["pavlue"];
                    if (getvalue[0] != "" && getvalue[1] != "" && getvalue[2] != "" && getvalue[4] != "")
                    {
                        this.QRcode.Src = getvalue[0];
                        this.orderno.Text = getvalue[1];
                        this.shopdesc.Text = getvalue[2];
                        this.attach.Text = getvalue[3];
                        this.money.Text = Convert.ToString(float.Parse(getvalue[4]));
                        this.totalmoney.Text = Convert.ToString(float.Parse(getvalue[4]));
                        ////^^^……以上信息展示 
                        SUM++;
                        if (SUM > 5)
                        {
                            //30秒后自动返回支付主页
                            qclear();//清零
                            Response.Redirect("/aspx/mobile/usercenter.aspx");//
                        }
                        if(CheckBll( this.orderno.Text))
                        {
                            int userid = Convert.ToInt32(DBUtility.DbHelperSQL.GetSingle(" select id from dt_user_recharge where recharge_no='" + this.orderno.Text + "'"));
                            //数据库里有值，充值成功
                            if (userid > 0)
                            {
                                //BLL.users usersModel = new BLL.users();
                                Model.users model = new BasePage().GetUserInfo();
                                model.amount += decimal.Parse(getvalue[4]) - decimal.Parse(getvalue[4]) * (decimal)0.01; ;
                                bool result = new BLL.users().Update(model);
                                if (result)
                                {
                                    BLL.user_recharge user_recharge = new BLL.user_recharge();
                                    Model.user_recharge rechage = user_recharge.GetModel(this.orderno.Text);
                                    rechage.complete_time = DateTime.Now;
                                    rechage.status = 1;
                                    rechage.amount -= rechage.amount * (decimal)0.01;
                                    user_recharge.Update(rechage);

                                    Response.Redirect("/aspx/mobile/usercenter.aspx");//
                                }
                            }
                        }
                      
                        ////根据订单号查询商户数据库记录是否支付成功，然后跳转成功页面。 
                        //if ("数据库表记录状态" == "已支付")
                        //{
                        //    Response.Redirect("payCode.aspx?success=Y");
                        //}
                    }
                    else
                    {
                        Response.Redirect("/aspx/mobile/usercenter.aspx");//
                    }
                }
            }
        }

        #region 查询订单号

        private ClientResponseHandler resHandler = new ClientResponseHandler();
        private PayHttpClient pay = new PayHttpClient();
        private RequestHandler reqHandler = null;
        private Dictionary<string, string> cfg = new Dictionary<string, string>(1);

        public  bool CheckBll(string tbout_trade_no)
        {
            bool result = false;
            this.reqHandler = new RequestHandler(null);
            //加载配置数据
            this.cfg = swiftpass.utils.Utils.loadCfg(); ;
            //初始化数据 
            this.reqHandler.setGateUrl(this.cfg["req_url"].ToString());
            this.reqHandler.setKey(this.cfg["key"].ToString());
            this.reqHandler.setParameter("out_trade_no", tbout_trade_no);//商户订单号
            //this.reqHandler.setParameter("transaction_id", tbtransaction_id.Text);//平台订单号                
            this.reqHandler.setParameter("service", "unified.trade.query");//接口 unified.trade.query 
            this.reqHandler.setParameter("mch_id", this.cfg["mch_id"].ToString());//必填项，商户号，由平台分配
            this.reqHandler.setParameter("version", this.cfg["version"].ToString());//接口版本号

            this.reqHandler.setParameter("nonce_str", Utils.random());//随机字符串，必填项，不长于 32 位
            this.reqHandler.createSign();//创建签名
            //以上参数进行签名
            string data = Utils.toXml(this.reqHandler.getAllParameters());//生成XML报文
            Dictionary<string, string> reqContent = new Dictionary<string, string>();
            reqContent.Add("url", this.reqHandler.getGateUrl());
            reqContent.Add("data", data);
            this.pay.setReqContent(reqContent);

            if (this.pay.call())
            {
                this.resHandler.setContent(this.pay.getResContent());
                this.resHandler.setKey(this.cfg["key"].ToString());
                Hashtable param = this.resHandler.getAllParameters();
                if (this.resHandler.isTenpaySign())
                {
                    //当返回状态与业务结果都为0时才返回结果，其它结果请查看接口文档
                    if (int.Parse(param["status"].ToString()) == 0 && int.Parse(param["result_code"].ToString()) == 0)
                    {
                        Utils.writeFile("查询订单", param);

                        if (param.ContainsKey("trade_state"))
                        {
                            if (Convert.ToString(param["trade_state"]) == "SUCCESS")
                            {
                                result = true;
                            }
                        }
                        
                        //Response.Write("<script>alert('查询订单成功，请查看result.txt文件！')</script>");
                    

                    }
                    else
                    {
                        Response.Write("<script>alert('错误代码：" + param["err_code"] + ",错误信息：" + param["err_msg"] + "')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('错误代码：" + param["status"] + ",错误信息：" + param["message"] + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('错误代码：" + this.pay.getResponseCode() + ",错误信息：" + this.pay.getErrInfo() + "')</script>");
            }
            return result;
        }

        #endregion

        public static void qclear()
        {
            SUM = 0;//初始化刷新计数值

        }
        public string ReadHtml()
        {
            HttpWebResponse httpResp;
            HttpWebRequest httpReq;
            string strBuff = "";
            char[] cbuffer = new char[256];
            int byteRead = 0;
            Uri httpURL = new Uri("http://zhangwei.dev.swiftpass.cn/notify.aspx");

            ///HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换 
            httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
            ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换

            httpResp = (HttpWebResponse)httpReq.GetResponse();
            ///GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容

            ///若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理 
            Stream respStream = httpResp.GetResponseStream();

            ///返回的内容是Stream形式的，所以可以利用StreamReader类获取GetResponseStream的内容，并以

            //StreamReader类的Read方法依次读取网页源程序代码每一行的内容，直至行尾（读取的编码格式：UTF8） 
            StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);

            byteRead = respStreamReader.Read(cbuffer, 0, 256);

            while (byteRead != 0)
            {
                string strResp = new string(cbuffer, 0, byteRead);
                strBuff = strBuff + strResp;
                byteRead = respStreamReader.Read(cbuffer, 0, 256);
            }

            respStream.Close();
            return strBuff;
        }
    }
}