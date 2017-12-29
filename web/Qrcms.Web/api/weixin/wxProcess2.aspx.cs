using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using System.Data;
using Qrcms.Common;
using Qrcms.API.Weixin.Common;
namespace Qrcms.Web.api.weixin
{
    public partial class wxProcess2 : Web.UI.BasePage
    {
        public string reurl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string code = "";
                if (Request.QueryString["code"] != null && Request.QueryString["code"] != "")
                {

                    //获取微信回传的code
                    code = Request.QueryString["code"].ToString();
                    string url = DTRequest.GetString("url");
                    string group = DTRequest.GetString("group");
                    int uid = 0;
                    BLL.weixin_account bllacc = new BLL.weixin_account();
                    DataTable dt = bllacc.GetList("").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        uid = Convert.ToInt32(dt.Rows[0]["id"]);
                    }

                    OAuth_Token Model = Get_token(code, uid); 
                    if (Model.openid != null && Model.openid != "") 
                    {
                        BLL.users bll = new BLL.users();
                        Model.users userModel = null;//是否判断用户登录

                        if (userModel != null)
                        {

                            string turl = "/mobile/usercenter.aspx?action=index";
                            if (!string.IsNullOrEmpty(url))
                            {
                                turl = url;
                            }
                            //记住登录状态，防止Session提前过期
                            HttpContext.Current.Session[DTKeys.SESSION_USER_INFO] = userModel;
                            HttpContext.Current.Session.Timeout = 45;
                            Utils.WriteCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "Qrcms", userModel.user_name);
                            Utils.WriteCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "Qrcms", userModel.password);
                            //更新最新的Access Token
                            CRMComm comm = new CRMComm();
                            string error = "";
                            comm.FlushAccessToken(uid, out error);

                            //自动登录,跳转URL
                            HttpContext.Current.Response.Redirect(turl);
                            Response.End();
                        }
                        else
                        {
                            Utils.WriteCookie("openid", Model.openid);
                            string turl = "/mobile/login.aspx?openid=" + Model.openid;
                            if (!string.IsNullOrEmpty(url))
                            {
                                turl = url;
                            }
                            Response.Redirect(turl);
                            return;
                        }
                    }
                    else  //未获得openid，回到wxProcess.aspx，访问弹出微信授权页面，提示用户授权
                    {
                        Response.Write("您的身份需要重新认证，请取消关注后重新关注 ！");
                        Response.End();
                    }
                }

            }
        }

        //根据appid，secret，code获取微信openid、access token信息
        protected OAuth_Token Get_token(string Code, int uid)
        {
            string appid = "";  //公众微信平台下可以找到
            string appsecret = "";  //公众微信平台下可以找到

            Model.weixin_account model = new BLL.weixin_account().GetModel(uid);
            appid = model.appid; //获取公众账户的ToKen
            appsecret = model.appsecret; //获取公众账户的ToKen
            
            //获取微信回传的openid、access token
            string Str = GetJson("https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appid + "&secret=" + appsecret + "&code=" + Code + "&grant_type=authorization_code");
            if (string.IsNullOrEmpty(Str))
            {
                HttpContext.Current.Response.Redirect("/mobile/zh_index.aspx");
                Response.End();
                return new OAuth_Token();
            }
            else
            {
                //微信回传的数据为Json格式，将Json格式转化成对象
                OAuth_Token Oauth_Token_Model = JsonHelper.ParseFromJson<OAuth_Token>(Str);
                return Oauth_Token_Model;
            }
        }
        //访问微信url并返回微信信息
        protected string GetJson(string url)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            wc.Encoding = Encoding.UTF8;
            try
            {
                string returnText = wc.DownloadString(url);
                return returnText;
            }
            catch
            {

                return "";
            }
        }

    }
    /// <summary>
    /// token类
    /// </summary>
    public class OAuth_Token
    {
        public OAuth_Token()
        {

            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //access_token	网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
        //expires_in	access_token接口调用凭证超时时间，单位（秒）
        //refresh_token	用户刷新access_token
        //openid	用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        //scope	用户授权的作用域，使用逗号（,）分隔
        public string _access_token;
        public string _expires_in;
        public string _refresh_token;
        public string _openid;
        public string _scope;
        public string access_token
        {
            set { _access_token = value; }
            get { return _access_token; }
        }
        public string expires_in
        {
            set { _expires_in = value; }
            get { return _expires_in; }
        }

        public string refresh_token
        {
            set { _refresh_token = value; }
            get { return _refresh_token; }
        }
        public string openid
        {
            set { _openid = value; }
            get { return _openid; }
        }
        public string scope
        {
            set { _scope = value; }
            get { return _scope; }
        }

    }


    /// <summary>
    /// 将Json格式数据转化成对象
    /// </summary>
    public class JsonHelper
    {
        /// <summary>  
        /// 生成Json格式  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="obj"></param>  
        /// <returns></returns>  
        public static string GetJson<T>(T obj)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, obj);
                string szJson = Encoding.UTF8.GetString(stream.ToArray()); return szJson;
            }
        }
        /// <summary>  
        /// 获取Json的Model  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="szJson"></param>  
        /// <returns></returns>  
        public static T ParseFromJson<T>(string szJson)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }
    }
}