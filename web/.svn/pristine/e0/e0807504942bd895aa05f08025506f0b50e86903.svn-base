using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Qrcms.Common;
using Qrcms.API.Weixin.Common;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Data;

namespace Qrcms.Web.UI.Page
{
    public partial class login : Web.UI.BasePage
    {
        protected string turl = string.Empty;
        /// <summary>
        /// 重写父类的虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            this.Init += new EventHandler(UserPage_Init);
        }

        /// <summary>
        /// OnInit事件,检查用户是否已经登录
        /// </summary>
        void UserPage_Init(object sender, EventArgs e)
        {
            turl = linkurl("usercenter", "index");
            if (HttpContext.Current.Request.Url != null && HttpContext.Current.Request.UrlReferrer != null)
            {
                string currUrl = HttpContext.Current.Request.Url.ToString().ToLower(); //当前页面
                string refUrl = HttpContext.Current.Request.UrlReferrer.ToString().ToLower(); //上一页面
                string regPath = linkurl("register").ToLower(); //注册页面
                if (currUrl != refUrl && refUrl.IndexOf(regPath) == -1)
                {
                    turl = HttpContext.Current.Request.UrlReferrer.ToString();
                }
            }
            Utils.WriteCookie(DTKeys.COOKIE_URL_REFERRER, turl); //记住上一页面
            
            Model.users model = GetUserInfo();
            if (model != null)
            {
                HttpContext.Current.Response.Redirect(turl);
            }
            else
            {
                //未登录
                //  BLL.fensi fensiBLL = new BLL.fensi();
                string openid = DTRequest.GetString("openid");
                if (!string.IsNullOrEmpty(openid))
                {
                    // if (!fensiBLL.Exists(openid)){

                    int accountId = new API.Weixin.Common.MessageFunction().GetAccountId();
                    API.Weixin.Common.MessageFunction fun = new MessageFunction();
                    fun.voidupdate(openid, "", "", accountId);
                }
                else
                {
                    if (IsWeiChat())
                    {
                       
                        string code = DTRequest.GetString("code");
                        if (string.IsNullOrEmpty(code))
                        {

                            //  BLL.PageHelp.WriteMess("========================CODE为空时URL" + HttpContext.Current.Request.Url.ToString());
                            GetOpenId(HttpContext.Current.Request.Url.ToString());
                        }
                        else
                        {
                            int uid = 0;
                            DataTable dt = new BLL.weixin_account().GetList("").Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                uid = Convert.ToInt32(dt.Rows[0]["id"]);
                            }
                            OAuth_Token Model = Get_token(code, uid);  //获取token

                            if (Model.openid != null && Model.openid != "")  //已获取得openid及其他信息
                            {

                                BLL.users bll = new BLL.users();
                                model = bll.GetModelopenid(Model.openid);

                                if (model != null)
                                {
                                    //记住登录状态，防止Session提前过期
                                    HttpContext.Current.Session[DTKeys.SESSION_USER_INFO] = model;
                                    HttpContext.Current.Session.Timeout = 45;
                                    Utils.WriteCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "Qrcms", model.user_name);
                                    Utils.WriteCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "Qrcms", model.password);
                                    //更新最新的Access Token
                                    //CRMComm comm = new CRMComm();
                                    //string error = "";
                                    //comm.FlushAccessToken(uid, out error);

                                    //自动登录,跳转到分享页面
                                    HttpContext.Current.Response.Redirect(turl);
                                    System.Web.HttpContext.Current.Response.End();
                                }
                                else
                                {

                                    Utils.WriteCookie("openid", Model.openid);

                                    //将用户加入到fensi表里
                                    int accountId = new API.Weixin.Common.MessageFunction().GetAccountId();
                                    string parentid = "";
                                    string parentname = DTRequest.GetString("parentName");
                                    if (!string.IsNullOrEmpty(parentname))
                                    {
                                        model = bll.GetModel(parentname);
                                        parentid = model != null ? model.id.ToString() : "";
                                    }
                                    API.Weixin.Common.MessageFunction fun = new MessageFunction();
                                    fun.voidupdate(Model.openid, "", parentid, accountId);

                                    // BLL.PageHelp.WriteMess("========================获取OPENID时URL" + HttpContext.Current.Request.Url.ToString());
                                    string[] tus = HttpContext.Current.Request.Url.ToString().Split('?');

                                    string tu = tus[0] + "?1=1";

                                    // BLL.PageHelp.WriteMess("========================tu====" + tu);
                                    foreach (var a in HttpContext.Current.Request.QueryString.AllKeys)
                                    {
                                        if (a.ToLower() != "openid")
                                        {
                                            tu += "&" + a + "=" + HttpContext.Current.Request.QueryString[a];
                                        }
                                    }
                                    tu += "&openid=" + Model.openid;

                                    // BLL.PageHelp.WriteMess("========================tu111====" + tu);
                                    HttpContext.Current.Response.Redirect(tu);

                                }
                            }
                            else
                            {
                                GetOpenId(HttpContext.Current.Request.Url.ToString());
                            }
                        }
                    }
                }
            }
        }
        protected void GetOpenId(string url)
        {
            string appid = "";
            url = url.ToLower().IndexOf(config.weburl.ToLower()) > -1 ? url : config.weburl + url;
            int uid = 0;
            BLL.weixin_account bll = new BLL.weixin_account();
            DataTable dt = bll.GetList("").Tables[0];
            if (dt.Rows.Count > 0)
            {
                uid = Convert.ToInt32(dt.Rows[0]["id"]);
            }
            appid = new BLL.weixin_account().GetModel(uid).appid; //获取公众账户的ToKen
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            string new_url = Server.UrlEncode(url);
            System.Web.HttpContext.Current.Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appid + "&redirect_uri=" + new_url + "&response_type=code&scope=snsapi_base&state=1#wechat_redirect");
        }

        #region 获取Openid的协助方法
        //访问微信url并返回微信信息
        protected string GetJson(string url)
        {

            // BLL.PageHelp.WriteMess(url);
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

        //根据appid，secret，code获取微信openid、access token信息
        protected OAuth_Token Get_token(string Code, int uid)
        {
            string appid = "";  //公众微信平台下可以找到
            string appsecret = "";  //公众微信平台下可以找到

            Model.weixin_account model = new BLL.weixin_account().GetModel(uid);
            //  BLL.PageHelp.WriteMess(Code + "------" + uid);
            appid = model.appid; //获取公众账户的ToKen
            appsecret = model.appsecret; //获取公众账户的ToKen

            //  BLL.PageHelp.WriteMess(appid + "------" + appsecret);
            //  BLL.PageHelp.WriteMess("https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appid + "&secret=" + appsecret + "&code=" + Code + "&grant_type=authorization_code");
            //获取微信回传的openid、access token
            string Str = GetJson("https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appid + "&secret=" + appsecret + "&code=" + Code + "&grant_type=authorization_code");
            // BLL.PageHelp.WriteMess(Str+"==================");
            if (string.IsNullOrEmpty(Str))
            {
                HttpContext.Current.Response.Redirect("/mobile/zh_index.aspx");
                HttpContext.Current.Response.End();
                return new OAuth_Token();
            }
            else
            {
                //微信回传的数据为Json格式，将Json格式转化成对象
                OAuth_Token Oauth_Token_Model = JsonHelper.ParseFromJson<OAuth_Token>(Str);
                return Oauth_Token_Model;
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
        #endregion
    }
}
