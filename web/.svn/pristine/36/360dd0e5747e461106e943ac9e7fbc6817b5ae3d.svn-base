using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Qrcms.API.SMS
{
    /// <summary>
    /// 腾讯云短信服务
    /// </summary>
    public class QcloudSMSServer
    {
        string sdkappid;
        string appkey;
        string url;


        public QcloudSMSServer()
        {
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            url = siteConfig.smsapiurl;
            sdkappid = siteConfig.smsusername;
            appkey = siteConfig.smspassword;
        }
        /// <summary>
        ///  发送短信
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        /// <param name="content">发送内容</param>
        /// <param name="nationCode">国家码（默认 86）</param>
        /// <param name="mes">返回信息，如果失败返回错误信息</param>
        public bool sendMsg(string phoneNumber, string content, out string mes, string nationCode = "86")
        {
            mes = "";
            JObject data = new JObject();
            JObject tel = new JObject();
            tel.Add("nationcode", nationCode);
            tel.Add("phone", phoneNumber);
            data.Add("msg", content);
            string sig = stringMD5(appkey + phoneNumber);
            data.Add("type", "0");          // 默认为单发
            data.Add("sig", sig);
            data.Add("tel", tel);
            data.Add("extend", "");         // 根据需要添加，一般保持默认
            data.Add("ext", "");            // 根据需要添加，一般保持默认
            string msgString = JsonConvert.SerializeObject(data);
            try
            {
                // 发送 POST 请求
                Random rnd = new Random();
                int random = rnd.Next(1000000) % (900000) + 1000000;
                string wholeUrl = url + "?sdkappid=" + sdkappid + "&random=" + random;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(wholeUrl);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] requestData = Encoding.UTF8.GetBytes(msgString);
                request.ContentLength = requestData.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(requestData, 0, requestData.Length);
                requestStream.Close();

                // 接收返回包
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                string retString = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
                
                if (!string.IsNullOrEmpty(retString))
                {
                    JObject jj = new JObject();
                    jj = (JObject)JsonConvert.DeserializeObject(retString);
                    if (jj["result"].ToString() == "0")
                    {
                        return true;
                    }
                    else
                    {
                        mes = jj["errmsg"].ToString();
                    }
                }

            }
            catch (Exception e) { }
            return false;
        }

        private static string stringMD5(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] targetData = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            return byteToHexStr(targetData);
        }
        private static string byteToHexStr(byte[] input)
        {
            string returnStr = "";
            if (input != null)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    returnStr += input[i].ToString("x2");
                }
            }
            return returnStr;
        }

    }
}
