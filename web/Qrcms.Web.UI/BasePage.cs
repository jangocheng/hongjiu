using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Configuration;
using Qrcms.Common;
using System.Xml;

namespace Qrcms.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected internal Model.siteconfig config = new BLL.siteconfig().loadConfig();
        protected internal Model.userconfig uconfig = new BLL.userconfig().loadConfig();
        protected internal Model.channel_site site = new Model.channel_site();
        /// <summary>
        /// 父类的构造函数
        /// </summary>
        public BasePage()
        {
           
            //是否关闭网站
            if (config.webstatus == 0)
            {
                HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode(config.webclosereason)));
                return;
            }
            setSSC();
            //取得站点信息
            site = GetSiteModel();
            //抛出一个虚方法给继承重写
            ShowPage();
        }

        /// <summary>
        /// 页面处理虚方法
        /// </summary>
        protected virtual void ShowPage()
        {
            //虚方法代码
        }

        #region 页面通用方法==========================================
        /// <summary>
        /// 返回站点信息
        /// </summary>
        protected Model.channel_site GetSiteModel()
        {
            string requestDomain = HttpContext.Current.Request.Url.Authority.ToLower(); //获得来源域名含端口号
            string requestPath = HttpContext.Current.Request.RawUrl.ToLower(); //当前的URL地址
            string sitePath = GetSitePath(requestPath, requestDomain);
            Model.channel_site modelt = SiteDomains.GetSiteDomains().SiteList.Find(p => p.build_path == sitePath);
            return modelt;
        }

        /// <summary>
        /// 返回URL重写统一链接地址
        /// </summary>
        public string linkurl(string _key, params object[] _params)
        {
            Hashtable ht = new BLL.url_rewrite().GetList(); //获得URL配置列表
            Model.url_rewrite model = ht[_key] as Model.url_rewrite; //查找指定的URL配置节点

            //如果不存在该节点则返回空字符串
            if (model == null)
            {
                return string.Empty;
            }

            string requestDomain = HttpContext.Current.Request.Url.Authority.ToLower(); //获得来源域名含端口号
            string requestPath = HttpContext.Current.Request.RawUrl.ToLower(); //当前的URL地址
            string linkStartString = GetLinkStartString(requestPath, requestDomain); //链接前缀

            //如果URL字典表达式不需要重写则直接返回
            if (model.url_rewrite_items.Count == 0)
            {
                //检查网站重写状态
                if (config.staticstatus > 0)
                {
                    if (_params.Length > 0)
                    {
                        return linkStartString + GetUrlExtension(model.page, config.staticextension) + string.Format("{0}", _params);
                    }
                    else
                    {
                        return linkStartString + GetUrlExtension(model.page, config.staticextension);
                    }
                }
                else
                {
                    if (_params.Length > 0)
                    {
                        return linkStartString + model.page + string.Format("{0}", _params);
                    }
                    else
                    {
                        return linkStartString + model.page;
                    }
                }
            }
            //否则检查该URL配置节点下的子节点
            foreach (Model.url_rewrite_item item in model.url_rewrite_items)
            {
                //如果参数个数匹配
                if (IsUrlMatch(item, _params))
                {
                    //检查网站重写状态
                    if (config.staticstatus > 0)
                    {
                        return linkStartString + string.Format(GetUrlExtension(item.path, config.staticextension), _params);
                    }
                    else
                    {
                        string queryString = Regex.Replace(string.Format(item.path, _params), item.pattern, item.querystring, RegexOptions.None | RegexOptions.IgnoreCase);
                        if (queryString.Length > 0)
                        {
                            queryString = "?" + queryString;
                        }
                        return linkStartString + model.page + queryString;
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 根据站点目录和已生成的链接重新组合(实际访问页面用到)
        /// </summary>
        /// <param name="sitepath">站点目录</param>
        /// <param name="urlpath">URL链接</param>
        /// <returns>String</returns>
        public string getlink(string sitepath, string urlpath)
        {
            if (string.IsNullOrEmpty(sitepath) || string.IsNullOrEmpty(urlpath))
            {
                return urlpath;
            }
            string requestDomain = HttpContext.Current.Request.Url.Authority.ToLower(); //获取来源域名含端口号
            Dictionary<string, string> dic = SiteDomains.GetSiteDomains().Paths; //获取站点键值对
            //如果当前站点为默认站点则直接返回
            if (SiteDomains.GetSiteDomains().DefaultPath == sitepath.ToLower())
            {
                return urlpath;
            }
            //如果当前域名存在于域名列表则直接返回
            if (dic.ContainsKey(sitepath.ToLower()) && dic.ContainsValue(requestDomain))
            {
                return urlpath;
            }
            int indexNum = config.webpath.Length; //安装目录长度
            if (urlpath.StartsWith(config.webpath))
            {
                urlpath = urlpath.Substring(indexNum);
            }
            //安装目录+站点目录+URL
            return config.webpath + sitepath.ToLower() + "/" + urlpath;
        }

        /// <summary>
        /// 返回分页字符串
        /// </summary>
        /// <param name="pagesize">页面大小</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="totalcount">记录总数</param>
        /// <param name="_key">URL映射Name名称</param>
        /// <param name="_params">传输参数</param>
        protected string get_page_link(int pagesize, int pageindex, int totalcount, string _key, params object[] _params)
        {
            return Utils.OutPageList(pagesize, pageindex, totalcount, linkurl(_key, _params), 8);
        }

        /// <summary>
        /// 返回分页字符串
        /// </summary>
        /// <param name="pagesize">页面大小</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="totalcount">记录总数</param>
        /// <param name="linkurl">链接地址</param>
        protected string get_page_link(int pagesize, int pageindex, int totalcount, string linkurl)
        {
            return Utils.OutPageList(pagesize, pageindex, totalcount, linkurl, 8);
        }
        #endregion

        #region 会员用户方法==========================================
        /// <summary>
        /// 判断用户是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsUserLogin()
        {
            //如果Session为Null
            if (HttpContext.Current.Session[DTKeys.SESSION_USER_INFO] != null)
            {
                return true;
            }
            else
            {
                //检查Cookies
                string username = Utils.GetCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "Qrcms");
                string password = Utils.GetCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "Qrcms");
                if (username != "" && password != "")
                {
                    BLL.users bll = new BLL.users();
                    Model.users model = bll.GetModel(username, password, 0, 0, false);
                    if (model != null)
                    {
                        HttpContext.Current.Session[DTKeys.SESSION_USER_INFO] = model;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsWeiChat()
        {
            string userAgent = HttpContext.Current.Request.UserAgent;
            if (string.IsNullOrWhiteSpace(userAgent))
            {
                return false;
            }
            if (userAgent.IndexOf("MicroMessenger") > -1)// Nokia phones and emulators   
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool is_mobile()
        {

            string osPat = "mozilla|m3gate|winwap|openwave|Windows NT|Windows 3.1|95|Blackcomb|98|ME|X Window|Longhorn|ubuntu|AIX|Linux|AmigaOS|BEOS|HP-UX|OpenBSD|FreeBSD|NetBSD|OS/2|OSF1|SUN";
            string uAgent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            if (string.IsNullOrEmpty(uAgent))
                uAgent = "";
            Regex reg = new Regex(osPat);
            if (reg.IsMatch(uAgent))
            {
                osPat = "MI-ONE|juc|series|kjava|berry|mobile|htc|android|symbian|mtk|brew|Mobile|htc|Android|Symbian|CE|MTK|Brew|iPhone|MeeGo|Bada|Berry|Plam|Kjava|Series|JUC";
                Regex reg1 = new Regex(osPat);

                if (reg1.IsMatch(uAgent))
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 取得用户信息
        /// </summary>
        public Model.users GetUserInfo()
        {
            if (IsUserLogin())
            {
                Model.users model = HttpContext.Current.Session[DTKeys.SESSION_USER_INFO] as Model.users;
                if (model != null)
                {
                    //为了能查询到最新的用户信息，必须查询最新的用户资料
                    model = new BLL.users().GetModel(model.id);
                    return model;
                }
            }
            return null;
        }
        #endregion

        #region 辅助方法(私有)========================================
        /// <summary>
        /// 获取当前页面包含的站点目录
        /// </summary>
        private string GetFirstPath(string requestPath)
        {
            int indexNum = config.webpath.Length; //安装目录长度
            //如果包含安装目录和aspx目录也要过滤掉
            if (requestPath.StartsWith(config.webpath + DTKeys.DIRECTORY_REWRITE_ASPX + "/"))
            {
                indexNum = (config.webpath + DTKeys.DIRECTORY_REWRITE_ASPX + "/").Length;
            }
            string requestFirstPath = requestPath.Substring(indexNum);
            if (requestFirstPath.IndexOf("/") > 0)
            {
                requestFirstPath = requestFirstPath.Substring(0, requestFirstPath.IndexOf("/"));
            }
            if (requestFirstPath != string.Empty && SiteDomains.GetSiteDomains().Paths.ContainsKey(requestFirstPath))
            {
                return requestFirstPath;
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取链接的前缀
        /// </summary>
        /// <param name="requestPath">当前的URL地址</param>
        /// <param name="requestDomain">获得来源域名含端口号</param>
        /// <returns>String</returns>
        private string GetLinkStartString(string requestPath, string requestDomain)
        {
            string requestFirstPath = GetFirstPath(requestPath);//获得二级目录(不含站点安装目录)

            //检查是否与绑定的域名或者与默认频道分类的目录匹配
            if (SiteDomains.GetSiteDomains().Paths.ContainsValue(requestDomain))
            {
                return "/";
            }

            else if (requestFirstPath == string.Empty || requestFirstPath == SiteDomains.GetSiteDomains().DefaultPath)
            {
                return config.webpath;
            }
            else
            {
                return config.webpath + requestFirstPath + "/";
            }
        }

        /// <summary>
        /// 获取站点的目录
        /// </summary>
        /// <param name="requestPath">获取的页面，包含目录</param>
        /// <param name="requestDomain">获取的域名(含端口号)</param>
        /// <returns>String</returns>
        private string GetSitePath(string requestPath, string requestDomain)
        {
            //当前域名是否存在于站点目录列表
            if (SiteDomains.GetSiteDomains().Paths.ContainsValue(requestDomain))
            {
                return SiteDomains.GetSiteDomains().Domains[requestDomain];
            }

            // 获取当前页面包含的站点目录
            string pagePath = GetFirstPath(requestPath);
            if (pagePath != string.Empty)
            {
                return pagePath;
            }
            return SiteDomains.GetSiteDomains().DefaultPath;
        }

        /// <summary>
        /// 参数个数是否匹配
        /// </summary>
        private bool IsUrlMatch(Model.url_rewrite_item item, params object[] _params)
        {
            int strLength = 0;
            if (!string.IsNullOrEmpty(item.querystring))
            {
                strLength = item.querystring.Split('&').Length;
            }
            if (strLength == _params.Length)
            {
                //注意__id__代表分页页码，所以须替换成数字才成进行匹配
                if (Regex.IsMatch(string.Format(item.path, _params).Replace("__id__", "1"), item.pattern, RegexOptions.None | RegexOptions.IgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 替换扩展名
        /// </summary>
        private string GetUrlExtension(string urlPage, string staticExtension)
        {
            return Utils.GetUrlExtension(urlPage, staticExtension);
        }

        #endregion

        /// <summary>
        /// 设置时时彩
        /// </summary>
        public void setSSC()
        {

            if (HttpContext.Current.Application["ssc"] != null)
            {
                DateTime tm = Utils.ObjectToDateTime(HttpContext.Current.Application["ssc"]);
                DateTime now = DateTime.Now;
                if (now >= tm.AddSeconds(240))//超过
                {
                    //过时
                    doSSC();
                }
            }
            else
            {
                doSSC();
            }
        }
        public void doSSC()
        {

            BLL.auction aucBLL = new BLL.auction();
            DateTime dt = aucBLL.GetMaxDate();//获取最大的
            DateTime now = DateTime.Now;
           
            int day =Utils.StrToInt(now.ToString("yyyyMMdd"),0) - Utils.StrToInt(dt.ToString("yyyyMMdd"),0);
            pageHelper.WriteLog(day + "============天==============dt====="+dt.ToString()+"=========now======="+now.ToString());
            for (int d = 0; d <= day; d++)
            {
                //必须升序
                string url = "http://api.kaijiangtong.com/lottery/?name=cqssc&format=xml&date=" + dt.AddDays(d).ToString("yyyyMMdd") + "&order=sort&uid=" + config.ssc_uid + "&token=" + config.ssc_token;

                pageHelper.WriteLog(url);
                try
                {

                    string content =  Utils.HttpGet(url);

                   // pageHelper.WriteLog(content);
                    XmlDocument xd = new XmlDocument();
                    xd.Normalize();
                    xd.LoadXml(content);
                    //pageHelper.WriteLog(xd.SelectNodes("/item").Count + "");
                    //pageHelper.WriteLog(xd.SelectNodes("/root").Count + "");
                    //pageHelper.WriteLog(xd.SelectNodes("/root/item").Count + "");

                    //var xroot = xd.SelectSingleNode("/root");
                    //if (xroot != null)
                    //{
                    //  pageHelper.WriteLog("11111111111");
                    var items = xd.SelectNodes("/root/item");// xroot.SelectNodes("/item ");
                    pageHelper.WriteLog("items=" + items.Count);
                    for (int m = 0; m < items.Count; m++)
                    {
                        try
                        {
                            var item = items[m];
                            string id = item.Attributes["id"].Value;
                            string dateline = item.Attributes["dateline"].Value;
                            string value = item.InnerText;
                            value = value.Replace(",", "");
                            int _v = Utils.StrToInt(value.Substring(value.Length - 1), -1);
                            int _r = 0;
                            string play1 = "0", play2 = "3", play3 = "7";//1-j 2-o
                            if (_v > -1)
                            {
                                if (_v % 2 == 0)
                                {
                                    play1 = "2";
                                }
                                else
                                {
                                    play1 = "1";
                                }
                                char[] ch_num = value.Trim().ToCharArray();
                                int last_num = Convert.ToInt32(ch_num[ch_num.Length - 1].ToString());
                                if (last_num >= 0 && last_num <= 3)  //玩法2（大中小）
                                {
                                    play2 = "3";
                                }
                                else if (last_num <= 4 && last_num >= 6)
                                {
                                    play2 = "4";
                                }
                                else
                                {
                                    play2 = "5";
                                }
                                for (int p = 0; p < ch_num.Length - 1; p++) //玩法3（牛牛）
                                {
                                    if (play3 == "6") { break; }
                                    for (int j = p + 1; j < ch_num.Length; j++)
                                    {
                                        if (play3 == "6")
                                        {
                                            break;
                                        }
                                        for (int k = j + 1; k < ch_num.Length; k++)
                                        {
                                            int temp = Convert.ToInt32(ch_num[p].ToString()) + Convert.ToInt32(ch_num[j].ToString()) + Convert.ToInt32(ch_num[k].ToString());
                                            if (temp == 0 || temp == 10 || temp == 20)
                                            {
                                                play3 = "6";
                                                break;
                                            }
                                        }
                                    }
                                }
                                _r = Convert.ToInt32(play1 + play2 + play3);                               
                            }
                            else
                            {
                                //出错了
                                pageHelper.WriteLog("=========================时时彩计算失败！========================\r\n value=" + value + " \r\n=" + id);
                                continue;
                            }
                            pageHelper.WriteLog(id + "=====id");
                            if (!string.IsNullOrEmpty(id) && !aucBLL.ExitTitle(id))
                            {
                                int dm = aucBLL.AddNew(new Model.auction() { title = id, quiz_no = Utils.ObjToInt(value), quiz_result = _r, quiz_date = Utils.ObjectToDateTime(dateline), no = id, create_time = DateTime.Now, create_user = value });
                                pageHelper.WriteLog("dm=" + dm);
                            }
                        }
                        catch (Exception ee)
                        {
                            //出错了
                            pageHelper.WriteLog("=========================时时彩获取ITEM失败！========================\r\n content=" + content + " \r\n url=" + url + "\r\n " + ee.ToString());
                        }
                    }
                    // }
                }
                catch (Exception e)
                {
                    //出错了
                    pageHelper.WriteLog("=========================时时彩获取失败！========================\r\n url=" + url + " \r\n msg=" + e.ToString());
                }
            }
            HttpContext.Current.Application["ssc"] = DateTime.Now;

        }
    }
}
