using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Qrcode 的摘要说明
/// </summary>
public class Qrcode
{
    public void Getqrcode()
    {
        //string code = System.Configuration.ConfigurationManager.AppSettings["Qrcode"];

        //if (code != null && code != "")
        //{

        //    string key = "hzqianisisi2323HKKsdds85819458256";

        //    string webcode = Decrypt(code, key);

        //    string Sq_Domain = HttpContext.Current.Request.Url.Host.Trim();
        //    if (Sq_Domain == "localhost" || Sq_Domain.IndexOf("qrit.cn") > 0 || Sq_Domain.IndexOf("qwb365.com") > 0 || Sq_Domain.IndexOf("qianren.wang") > 0 || Sq_Domain.IndexOf("hzqianren.com") > 0 || Sq_Domain.IndexOf("hzdianzan.com") > 0 || IsIP(Sq_Domain))
        //    {
        //        return;
        //    }

        //    string domain = GetBaseDomain(Sq_Domain);

        //    string[] codezu = webcode.Split('|');

        //    if (domain != null && domain != "")
        //    {
        //        if (codezu[0].IndexOf(domain) < 0)
        //        {
        //            HttpContext.Current.Response.Write("该系统域名没有被授权！请联系技术开发商！<a href=\"http://www.hzqianren.com\" target=_blank>hzqianren.com</a>");
        //            HttpContext.Current.Response.End();
        //        }

        //    }
        //    string endtime = codezu[2];
        //    TimeSpan jsday = Convert.ToDateTime(endtime) - DateTime.Now;
        //    int jsn = jsday.Days;


        //    if (jsn <= 5)
        //    {
        //        string domaincode = Encrypt(domain, key);
        //        string postdata = "api=" + domaincode + "";
        //        string sys_api = "http://js.hzqianren.com/api/";


        //        string xml = PostWebRequest(sys_api, postdata, Encoding.UTF8);

        //        if (xml.IndexOf("OOKK") > -1)
        //        {
        //            HttpContext.Current.Response.Write(xml.Replace("OOKK|", ""));
        //            HttpContext.Current.Response.End();
        //        }
        //        if (xml.IndexOf("chenggong") > -1)
        //        {
        //            string[] codenewzu = xml.Split('|');
        //            if (codenewzu.Length > 0)
        //            {
        //                string codenew = codenewzu[1];
        //                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        //                //获取appSettings节点
        //                AppSettingsSection appSection = (AppSettingsSection)config.GetSection("appSettings");
        //                //修改appSettings节点中的元素
        //                appSection.Settings["Qrcode"].Value = codenew;
        //                config.Save();
        //            }

        //        }
        //    }
        //    if (jsn < 0)
        //    {
        //        HttpContext.Current.Response.Write("该系统已经到期！请联系技术开发商！<a href=\"http://www.hzqianren.com\" target=_blank>hzqianren.com</a>");
        //        HttpContext.Current.Response.End();
        //    }
        //}
        //else
        //{

        //    HttpContext.Current.Response.Write("请先在配置文件上配置好Qrcode");
        //    HttpContext.Current.Response.End();
        //}


    }
    private string PostWebRequest(string postUrl, string paramData, Encoding dataEncode)
    {
        string ret = string.Empty;
        try
        {
            byte[] byteArray = dataEncode.GetBytes(paramData); //转化
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
            webReq.Method = "POST";
            webReq.ContentType = "application/x-www-form-urlencoded";

            webReq.ContentLength = byteArray.Length;
            Stream newStream = webReq.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);//写入参数
            newStream.Close();
            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            ret = sr.ReadToEnd();
            sr.Close();
            response.Close();
            newStream.Close();
        }
        catch (Exception ex)
        {
            return "出错了";
        }
        return ret;
    }
    string Decrypt(string Text, string sKey)
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        int len;
        len = Text.Length / 2;
        byte[] inputByteArray = new byte[len];
        int x, i;
        for (x = 0; x < len; x++)
        {
            i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
            inputByteArray[x] = (byte)i;
        }
        des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
        des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        return Encoding.Default.GetString(ms.ToArray());
    }
    /// <summary> 
    /// 加密数据 
    /// </summary> 
    /// <param name="Text"></param> 
    /// <param name="sKey"></param> 
    /// <returns></returns> 
    public static string Encrypt(string Text, string sKey)
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        byte[] inputByteArray;
        inputByteArray = Encoding.Default.GetBytes(Text);
        des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
        des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        StringBuilder ret = new StringBuilder();
        foreach (byte b in ms.ToArray())
        {
            ret.AppendFormat("{0:X2}", b);
        }
        return ret.ToString();
    } 
    string GetBaseDomain(string domain)
    {
        //List<string> list = new List<string>(".co.jp|.com.cn|.net.cn|.org.cn|.com|.co|.info|.net|.org|.me|.mobi|.us|.biz|.xxx|.ca|.mx|.tv|.ws|.ag|.com.ag|.net.ag|.org.ag|.am|.asia|.at|.be|.com.br|.net.br|.bz|.com.bz|.net.bz|.cc|.com.co|.net.co|.nom.co|.de|.es|.com.es|.nom.es|.org.es|.eu|.fm|.fr|.gs|.in|.co.in|.firm.in|.gen.in|.ind.in|.net.in|.org.in|.it|.jobs|.jp|.ms|.com.mx|.nl|.nu|.co.nz|.net.nz|.org.nz|.se|.tc|.tk|.tw|.com.tw|.idv.tw|.org.tw|.hk|.co.uk|.me.uk|.org.uk|.vg|.中国|.公司|.网络|.name".Split('|'));
        //string[] hs = host.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        //if (hs.Length > 2)
        //{
        //    //传入的host地址至少有三段
        //    int p2 = host.LastIndexOf('.');                 //最后一次“.”出现的位置
        //    int p1 = host.Substring(0, p2).LastIndexOf('.');//倒数第二个“.”出现的位置
        //    string s1 = host.Substring(p1);
        //    if (!list.Contains(s1))
        //        return s1.TrimStart('.');

        //    //域名后缀为两段（有用“.”分隔）
        //    if (hs.Length > 3)
        //        return host.Substring(host.Substring(0, p1).LastIndexOf('.'));
        //    else
        //        return host.TrimStart('.');
        //}
        //else if (hs.Length == 2)
        //{
        //    return host.TrimStart('.');
        //}
        //else
        //{
        //    return string.Empty;
        //}

        domain = domain.Trim().ToLower();
        string rootDomain = ".co.jp|.com.cn|.net.cn|.org.cn|.com|.co|.info|.net|.org|.me|.mobi|.us|.biz|.xxx|.ca|.mx|.tv|.ws|.ag|.com.ag|.net.ag|.org.ag|.am|.asia|.at|.be|.com.br|.net.br|.bz|.com.bz|.net.bz|.cc|.com.co|.net.co|.nom.co|.de|.es|.com.es|.nom.es|.org.es|.eu|.fm|.fr|.gs|.in|.co.in|.firm.in|.gen.in|.ind.in|.net.in|.org.in|.it|.jobs|.jp|.ms|.com.mx|.nl|.nu|.co.nz|.net.nz|.org.nz|.se|.tc|.tk|.tw|.com.tw|.idv.tw|.org.tw|.hk|.co.uk|.me.uk|.org.uk|.vg|.中国|.公司|.网络|.name";
        if (domain.StartsWith("http://")) domain = domain.Replace("http://", "");
        if (domain.StartsWith("https://")) domain = domain.Replace("https://", "");
        if (domain.StartsWith("www.")) domain = domain.Replace("www.", "");
        //safsd.asdfasdf.baidu.com.cn/ssssd/s/b/d/hhh.html?domain=sfsdf.com.cn&id=1
        if (domain.IndexOf("/") > 0)
            domain = domain.Substring(0, domain.IndexOf("/"));
        //safsd.asdfasdf.baidu.com.cn
        foreach (string item in rootDomain.Split('|'))
        {
            if (domain.EndsWith(item))
            {
                domain = domain.Replace(item, "");
                if (domain.LastIndexOf(".") > 0)//adfasd.asdfas.cn
                {
                    domain = domain.Replace(domain.Substring(0, domain.LastIndexOf(".") + 1), "");
                }
                return domain + item;
            }
            continue;
        }
        return "";

    }
    bool IsIP(string ip)
    {
        return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
    }
}