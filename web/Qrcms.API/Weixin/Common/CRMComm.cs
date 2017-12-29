using System;
using System.Collections.Generic;
using System.Text;
using Senparc.Weixin.MP;
using System.IO;
using System.Web;
using System.Net;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Qrcms.Common;

namespace Qrcms.API.Weixin.Common
{
    /// <summary>
    /// 负责获取或刷新AccessToken
    /// </summary>
    public class CRMComm
    {
        public CRMComm()
        { }

        BLL.weixin_access_token tokenBLL = new BLL.weixin_access_token(); //账户AccessToken
        BLL.weixin_account accountBLL = new BLL.weixin_account(); //公众平台账户

        /// <summary>
        /// 及时获得access_token值
        /// access_token是公众号的全局唯一票据，公众号调用各接口时都需使用access_token。正常情况下access_token有效期为7200秒，
        /// 重复获取将导致上次获取的access_token失效。
        /// 每日限额获取access_token.我们将access_token保存到数据库里，间隔时间为20分钟，从微信公众平台获得一次。
        /// </summary>
        public string GetAccessToken(int accountId, out string error)
        {
            string access_token = string.Empty;
            error = string.Empty;
            //try
            //{
                pageHelper.WriteLog("开始获取access_token");
                Model.weixin_account accountModel = accountBLL.GetModel(accountId); //公众平台账户信息
                if (string.IsNullOrEmpty(accountModel.appid) || string.IsNullOrEmpty(accountModel.appsecret))
                {
                    error = "AppId或者AppSecret未填写,请在补全信息！";
                    return string.Empty;
                }
                //没有找到该账户则获取AccessToKen写入存储1200秒
                //if (!tokenBLL.ExistsAccount(accountId))
                //{
                    var res = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(accountModel.appid, accountModel.appsecret);
                    access_token = res.access_token;
                    tokenBLL.Add(accountId, access_token);
                    return access_token;
                //}
                pageHelper.WriteLog(access_token);
                //获取公众账户的实体
                Model.weixin_access_token tokenModel = tokenBLL.GetAccountModel(accountId);
                //计算时间判断是否过期
                TimeSpan ts = DateTime.Now - tokenModel.add_time;
                double chajunSecond = ts.TotalSeconds;
                if (string.IsNullOrEmpty(tokenModel.access_token) || chajunSecond >= tokenModel.expires_in)
                {
                    //从微信平台重新获得AccessToken
                    var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(accountModel.appid, accountModel.appsecret);
                    access_token = result.access_token;
                    //更新到数据库里的AccessToken
                    tokenModel.access_token = access_token;
                    tokenModel.add_time = DateTime.Now;
                    tokenBLL.Update(tokenModel);

                }
                else
                {
                    access_token = tokenModel.access_token;
                }
            //}
            //catch (Exception ex)
            //{
            //    error = "获取AccessToken出错:" + ex.Message;
            //}
            return access_token;
        }
        public static string downRemoteImgup(string savedir, string imgpath)
        {
            #region 获取原图
            WebRequest wReq = WebRequest.Create(imgpath);
            HttpWebResponse wResp = (HttpWebResponse)wReq.GetResponse();
            Stream fs = wResp.GetResponseStream();



            System.Drawing.Image fsImage = System.Drawing.Image.FromStream(fs);
            System.Drawing.Image fromImg = new System.Drawing.Bitmap(fsImage);

            //fsImage.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
            //fromImg.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);//图片旋转90度


            #endregion

            Random ran = new Random();
            string jVimgUrl = "/" + savedir + "" + DateTime.Now.ToString("yyyyMMddhhmmsss") + ran.Next(0, 99) + ".jpg";
            fromImg.Save(HttpContext.Current.Server.MapPath(jVimgUrl), System.Drawing.Imaging.ImageFormat.Jpeg);
            fsImage.Dispose();
            fromImg.Dispose();
            return jVimgUrl;
        }
        /// <summary>
        ///【强制刷新】access_token值
        /// access_token是公众号的全局唯一票据，公众号调用各接口时都需使用access_token。正常情况下access_token有效期为7200秒，
        /// 重复获取将导致上次获取的access_token失效。
        /// 每日限额获取access_token.我们将access_token保存到数据库里，间隔时间为20分钟，从微信公众平台获得一次。
        /// </summary>
        /// <returns></returns>
        public string FlushAccessToken(int accountId, out string error)
        {
            string access_token = string.Empty;
            error = string.Empty;
            try
            {
                Model.weixin_account accountModel = accountBLL.GetModel(accountId); //公众平台账户信息
                if (string.IsNullOrEmpty(accountModel.appid) || string.IsNullOrEmpty(accountModel.appsecret))
                {
                    error = "AppId或者AppSecret未填写,请在补全信息！";
                    return "";
                }

                var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(accountModel.appid, accountModel.appsecret);
                access_token = result.access_token;

                //没有找到该账户则获取AccessToKen写入存储1200秒
                if (!tokenBLL.ExistsAccount(accountId))
                {
                    tokenBLL.Add(accountId, access_token);
                }
                else
                {
                    //获取公众账户的实体
                    Model.weixin_access_token tokenModel = tokenBLL.GetAccountModel(accountId);
                    //更新到数据库里的AccessToken
                    tokenModel.access_token = access_token;
                    tokenModel.add_time = DateTime.Now;
                    tokenBLL.Update(tokenModel);
                }
            }
            catch (Exception ex)
            {
                error = "获得AccessToken出错:" + ex.Message;
            }
            return access_token;
        }

        /// <summary>
        /// 获得所有关注用户的openid字符串(别的方法调用此方法)
        /// </summary>
        private IList<string> BaseUserOpenId(int uid, out string error)
        {
            IList<string> ret = new List<string>();

            string access_token = GetAccessToken(uid, out error);
            if (error != "")
            {
                return null;
            }
            Senparc.Weixin.MP.AdvancedAPIs.User.OpenIdResultJson openidJson = Senparc.Weixin.MP.AdvancedAPIs.UserApi.Get(access_token, string.Empty);
            if (openidJson.count == openidJson.total)
            {
                ret = openidJson.data.openid;
            }
            else
            {
                GetNextUserOpenId(uid, openidJson.next_openid, ret);
            }
            return ret;
        }

        /// <summary>
        /// (基础方法)获得所有关注用户的openid字符串(递归算法)
        /// </summary>
        private void GetNextUserOpenId(int accountId, string nexOpenid, IList<string> openidList)
        {
            string err = string.Empty;
            string access_token = GetAccessToken(accountId, out err);
            Senparc.Weixin.MP.AdvancedAPIs.User.OpenIdResultJson openidJson = Senparc.Weixin.MP.AdvancedAPIs.UserApi.Get(access_token, nexOpenid);
            if (openidJson == null || openidJson.count <= 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < openidJson.data.openid.Count; i++)
                {
                    openidList.Add(openidJson.data.openid[i]);
                }
                GetNextUserOpenId(accountId, openidJson.next_openid, openidList);
            }
        }
        //根据openid，access token获得用户信息
        public static OAuthUser Get_UserInfo(string REFRESH_TOKEN, string OPENID)
        {
            CRMComm.Writebug("Get_UserInfo：" + OPENID + "|" + REFRESH_TOKEN + "|");
            string Str = GetJson("https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + REFRESH_TOKEN + "&openid=" + OPENID + "&lang=zh_CN");
            OAuthUser OAuthUser_Model = ParseFromJson<OAuthUser>(Str);
            return OAuthUser_Model;
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
        //访问微信url并返回微信信息
        public static string GetJson(string url)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            wc.Encoding = Encoding.UTF8;
            string returnText = wc.DownloadString(url);

            if (returnText.Contains("errcode"))
            {
                //可能发生错误
            }
            return returnText;
        }
        /// <summary>
        /// 记录bug，以便调试
        /// </summary>
        /// <returns></returns>
        public static bool Writebug(string str)
        {
            try
            {
                FileStream FileStream = new FileStream(HttpContext.Current.Server.MapPath("/wxbugLog.txt"), FileMode.Append);
                StreamWriter StreamWriter = new StreamWriter(FileStream);
                //开始写入
                StreamWriter.WriteLine(str);
                //清空缓冲区
                StreamWriter.Flush();
                //关闭流
                StreamWriter.Close();
                StreamWriter.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 下载远程图片保存到本地
        /// </summary>
        /// <param name="savedir">本地保存路径</param>
        /// <param name="imgpath">远程图片文件</param>
        /// <returns></returns>
        public static string downRemoteImg(string savedir, string imgpath)
        {
            #region 获取原图
            WebRequest wReq = WebRequest.Create(imgpath);
            HttpWebResponse wResp = (HttpWebResponse)wReq.GetResponse();
            Stream s = wResp.GetResponseStream();
            System.Drawing.Image fsImage = System.Drawing.Image.FromStream(s);
            System.Drawing.Image fromImg = new System.Drawing.Bitmap(fsImage);

            //fsImage.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
            //fromImg.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);//图片旋转90度


            #endregion

            Random ran = new Random();
            string jVimgUrl = "/" + savedir + "" + DateTime.Now.ToString("yyyyMMddhhmmsss") + ran.Next(0, 99) + ".jpg";
            fromImg.Save(HttpContext.Current.Server.MapPath(jVimgUrl), System.Drawing.Imaging.ImageFormat.Jpeg);
            fsImage.Dispose();
            fromImg.Dispose();
            return jVimgUrl;
        }
        public static string getJsApiTicket()
        {
            string result = "";
            if (HttpRuntime.Cache["ticket"] != null)
            {
                result = HttpRuntime.Cache["ticket"].ToString();
                API.Weixin.Common.CRMComm.Writebug("ticketold:" + result);
            }
            else
            {

                string token = string.Empty; //与微信公众账号后台的Token设置保持一致，区分大小写。
                int uid = 0;
                string appid = "";
                BLL.weixin_account bll = new BLL.weixin_account();
                DataTable dt = bll.GetList("").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    uid = Convert.ToInt32(dt.Rows[0]["id"]);
                    appid = dt.Rows[0]["appid"].ToString();
                }
                API.Weixin.Common.CRMComm tokenn = new API.Weixin.Common.CRMComm();
                string error = "";
                token = tokenn.FlushAccessToken(uid, out error); //获取公众账户的ToKen
                API.Weixin.Common.CRMComm.Writebug("token:" + token);
                if (token != "")
                {
                    string url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token=" + token + "";
                    result = API.Weixin.Common.CRMComm.GetJson(url);
                    JObject jsonObj = (JObject)JsonConvert.DeserializeObject(result);
                    if (jsonObj["errcode"].ToString() == "0")
                    {
                        result = jsonObj["ticket"].ToString();
                        HttpRuntime.Cache.Insert("ticket", result, null, DateTime.Now.AddMinutes(110), System.Web.Caching.Cache.NoSlidingExpiration);
                        API.Weixin.Common.CRMComm.Writebug("ticket:" + result);
                    }
                }
            }
            return result;
        }
        public static string Getapijasdk()
        {
            long timestamp;
            string nonceStr = "", signature = "", appid = "";
            string strJs = "";
            BLL.weixin_account bll = new BLL.weixin_account();
            DataTable dt = bll.GetList("").Tables[0];
            if (dt.Rows.Count > 0)
            {
                appid = dt.Rows[0]["appid"].ToString();
            }
            DateTime unixTPStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            timestamp = toUTP(DateTime.Now, unixTPStart);
            nonceStr = GenerateNonceStr();
            string url = HttpContext.Current.Request.Url.ToString().Split('#')[0].Replace("aspx/", "");//"http://rsl.qrit.cn/place/daowei_index.aspx";
                                                                                                       //  Writebug(url);
            string jsapi = getJsApiTicket();
            string rawstring = "jsapi_ticket=" + jsapi + "&noncestr=" + nonceStr + "&timestamp=" + timestamp + "&url=" + url;
            signature = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(rawstring, "SHA1").ToLower();
            API.Weixin.Common.CRMComm.Writebug("rawstring:" + rawstring);
            strJs = "<script>wx.config({";
            strJs += "debug: false,";
            strJs += "appId: '" + appid + "',";
            strJs += "timestamp: " + timestamp.ToString() + ",";
            strJs += "nonceStr: '" + nonceStr + "', ";
            strJs += "signature: '" + signature + "',";
            strJs += "jsApiList: ['checkJsApi','openLocation','getLocation']});</script> ";
            return strJs;
        }
        public static long toUTP(DateTime dt, DateTime unixTPStart)
        {
            TimeSpan toNow = dt.Subtract(unixTPStart);
            return (long)Math.Round(toNow.TotalSeconds);
        }
        /**
       * 生成随机串，随机串包含字母或数字
       * @return 随机串
       */
        public static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Substring(Guid.NewGuid().ToString().LastIndexOf('-') + 1);
        }

        public string SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = System.Text.UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "").ToLower();
            return str_sha1_out;
        }
    }
}
