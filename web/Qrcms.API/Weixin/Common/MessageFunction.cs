using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Diagnostics;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities;
using System.Text;
using System.Net;
using System.IO;
using Qrcms.Common;

namespace Qrcms.API.Weixin.Common
{
    /// <summary>
    /// 处理事件的方法
    /// </summary>
    public partial class MessageFunction
    {
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //站点配置

        #region 处理关注/取消/默认回复方法===========================
        /// <summary>
        /// 定阅事件的统一处理
        /// </summary>
        public IResponseMessageBase EventSubscribe(int type, RequestMessageEventBase requestMessage)
        {
            
            int accountId = GetAccountId(); //取得公众账户ID
            string EventName = "";
            if (requestMessage is IRequestMessageEventKey)
            {
                EventName += (requestMessage as IRequestMessageEventKey).EventKey;
            }
            else
            {
                EventName = requestMessage.Event.ToString();
            }
            if (!ExistsOriginalId(accountId, requestMessage.ToUserName))
            {
                //验证接收方是否为我们系统配置的帐号，即验证微帐号与微信原始帐号id是否一致，如果不一致，说明【1】配置错误，【2】数据来源有问题
                new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "none", "未取到关键词对应的数据", requestMessage.ToUserName);
                return GetResponseMessageTxtByContent(requestMessage, "验证微帐号与微信原始帐号id不一致，可能原因【1】系统配置错误，【2】非法的数据来源", accountId);
            }
           
            int responseType = 0;
            int ruleId = 0;
            
            ruleId = new BLL.weixin_request_rule().GetRuleIdAndResponseType(accountId, "request_type=" + type, out responseType);
            if (ruleId <= 0 || responseType <= 0)
            {
                new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "none", "未取到关键词对应的数据", requestMessage.ToUserName);
                return null;
            }

            /*
             * 如果有上级会员
             */
            string parendid = "";
            if (requestMessage is IRequestMessageEventKey)
            {
                parendid = (requestMessage as IRequestMessageEventKey).EventKey; 
            }
            parendid = parendid.Replace("qrscene_", "");
            parendid = parendid.Replace("SCENE_", "");
            
            
            string title = voidupdate(requestMessage.FromUserName, requestMessage.ToUserName, parendid, accountId);
           
            IResponseMessageBase reponseMessage = null;
            switch (responseType)
            {
                case 1:
                    //发送纯文字
                    reponseMessage = GetResponseMessageTxt(requestMessage, ruleId, accountId, title);
                    break;
                case 2:
                    //发送多图文
                    reponseMessage = GetResponseMessageNews(requestMessage, ruleId, accountId, title);
                    break;
                case 3:
                    //发送语音
                    reponseMessage = GetResponseMessageeMusic(requestMessage, ruleId, accountId);
                    break;
                default:
                    break;
            }
            return reponseMessage;
        }
        #endregion

        #region 请求为文本的处理=====================================
        /// <summary>
        /// 推送纯文字
        /// </summary>
        public IResponseMessageBase GetResponseMessageTxt(RequestMessageText requestMessage, int ruleId, int accountId, string title)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            responseMessage.Content = new BLL.weixin_request_content().GetContent(ruleId);
            new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), title + requestMessage.Content, "text", responseMessage.Content, requestMessage.ToUserName);
            return responseMessage;
        }

        /// <summary>
        /// 推送纯文字
        /// </summary>
        public IResponseMessageBase GetResponseMessageTxtByContent(RequestMessageText requestMessage, string content, int accountId)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = content;
            new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "text", "文字请求，推送纯粹文字，内容为：" + content, requestMessage.ToUserName);
            return responseMessage;
        }

        /// <summary>
        /// 处理语音请求
        /// </summary>
        public IResponseMessageBase GetResponseMessageeMusic(RequestMessageText requestMessage, int ruleId, int accountId)
        {
            string EventName = "";
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageMusic>(requestMessage);
            Model.weixin_request_content model = new BLL.weixin_request_content().GetModel(ruleId);
            if (model == null)
            {
                new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "music", "-1", requestMessage.ToUserName);
            }
            else
            {
                if (model.media_url.Contains("http://"))
                {
                    responseMessage.Music.MusicUrl = model.media_url;

                }
                else
                {
                    //因为安装目录是以/开头，所以去掉，以免出现双斜杆
                    responseMessage.Music.MusicUrl = siteConfig.weburl + "/" + siteConfig.webpath.Replace("/", "") + model.media_url;
                }
                responseMessage.Music.Title = model.title;
                responseMessage.Music.Description = model.content;
                new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "music", "音乐链接：" + model.media_url + "|标题：" + model.title + "|描述：" + model.content, requestMessage.ToUserName);

            }
            return responseMessage;
        }
        public string voidupdate(string openid, string ToUserName, string parendid, int accountId)
        {
            try
            {
                string title = "";

                CRMComm.Writebug("会员parendid：" + parendid + "|");
                CRMComm comm = new CRMComm();
                string error = "";
                string access_token = comm.GetAccessToken(accountId, out error);
                CRMComm.Writebug("access_token：" + access_token + "|");
                OAuthUser OAuthUser_Model = CRMComm.Get_UserInfo(access_token, openid);
                if (OAuthUser_Model.openid != null && OAuthUser_Model.openid != "")  //已获取得openid及其他信息
                {
                    CRMComm.Writebug("sex：" + OAuthUser_Model.sex + "|");
                    string sex = "男";
                    if (OAuthUser_Model.sex == "2")
                    {
                        sex = "女";
                    }
                    CRMComm.Writebug("会员IDddcc：" + OAuthUser_Model.openid + "|");
                    CRMComm.Writebug(JsonHelper.ObjectToJSON(OAuthUser_Model));
                    string picurl = OAuthUser_Model.headimgurl;
                    CRMComm.Writebug("picurl：" + OAuthUser_Model.headimgurl + "|");
                    string newpicurl = "";
                    if (!string.IsNullOrEmpty(picurl))
                    {
                        newpicurl = CRMComm.downRemoteImg("upload/", picurl);
                    }

                    CRMComm.Writebug("会员newpicurl：" + newpicurl + "|");

                    BLL.users bll = new BLL.users();
                    Model.users model = bll.GetModelopenid(OAuthUser_Model.openid);

                    if (model != null)
                    {
                        CRMComm.Writebug("会员model：111|");
                        bll.UpdateField(model.id, "avatar='" + newpicurl + "',nick_name='" + OAuthUser_Model.nickname + "',sex='" + sex + "'");
                        title = "欢迎您回来，" + OAuthUser_Model.nickname + ",";
                    }
                    else
                    {
                        BLL.fensi fensibll = new BLL.fensi();
                        if (fensibll.Exists(openid))
                        {
                            Model.fensi fensiModel = fensibll.GetModel(openid);
                            if (fensiModel != null)
                            {
                                fensiModel.headimg = newpicurl;
                                fensiModel.nickname = OAuthUser_Model.nickname;
                                if (string.IsNullOrEmpty(fensiModel.parentid))
                                {
                                    fensiModel.parentid = parendid;
                                }
                                fensibll.Update(fensiModel);
                            }
                        }
                        else
                        {
                            Model.fensi fensiModel = new Model.fensi();
                            fensiModel.headimg = newpicurl;
                            fensiModel.nickname = OAuthUser_Model.nickname;
                            fensiModel.openid = openid;
                            fensiModel.parentid = parendid;
                            fensibll.Add(fensiModel);
                        }
                   
                    }

                }

                return title;
            }
            catch (Exception exce) { CRMComm.Writebug(exce.ToString() + "----messagefunction"); return ""; }
        }


        /// <summary>
        /// 推送多图文
        /// </summary>
        public IResponseMessageBase GetResponseMessageNews(RequestMessageText requestMessage, int ruleId, int accountId, string title)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();

            Article article;
            List<Article> artList = new List<Article>();
            IList<Model.weixin_request_content> twList = new BLL.weixin_request_content().GetModelList(10, ruleId, string.Empty);
            foreach (Model.weixin_request_content modelt in twList)
            {
                article = new Article();
                article.Title = title + modelt.title;
                article.Description = modelt.content;
                article.Url = GetWXApiUrl(modelt.link_url, token, openid);
                if (string.IsNullOrEmpty(modelt.img_url))
                {
                    article.PicUrl = string.Empty;
                }
                else
                {
                    if (modelt.img_url.Contains("http://"))
                    {
                        article.PicUrl = modelt.img_url;

                    }
                    else
                    {
                        //因为安装目录是以/开头，所以去掉，以免出现双斜杆
                        article.PicUrl = siteConfig.weburl + "/" + siteConfig.webpath.Replace("/", "") + modelt.img_url;
                    }
                }
                artList.Add(article);
            }

            if (artList.Count == 0)
            {
                new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "txtpic", "-1", requestMessage.ToUserName);
            }
            else
            {
                new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.Content, "txtpic", "这次发了" + artList.Count + "条图文", requestMessage.ToUserName);
            }
            responseMessage.Articles.AddRange(artList);
            return responseMessage;
        }
        #endregion

        #region 请求为事件的处理=====================================
        /// <summary>
        /// 推送纯文字
        /// </summary>
        public IResponseMessageBase GetResponseMessageTxt(RequestMessageEventBase requestMessage, int ruleId, int accountId, string title)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();
            responseMessage.Content = new BLL.weixin_request_content().GetContent(ruleId);

            string EventName = "";
            if (requestMessage is IRequestMessageEventKey)
            {
                EventName += (requestMessage as IRequestMessageEventKey).EventKey;
            }
            else
            {
                EventName = requestMessage.Event.ToString();
            }

            new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "text", responseMessage.Content, requestMessage.ToUserName);

            return responseMessage;
        }

        /// <summary>
        /// 推送纯文字
        /// </summary>
        public IResponseMessageBase GetResponseMessageTxtByContent(RequestMessageEventBase requestMessage, string content, int accountId)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            var locationService = new LocationService();
            responseMessage.Content = content;
            string EventName = "";
            if (requestMessage is IRequestMessageEventKey)
            {
                EventName += (requestMessage as IRequestMessageEventKey).EventKey;
            }
            else
            {
                EventName = requestMessage.Event.ToString();
            }
            new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "text", "事件：推送纯粹的文字，内容为:" + content, requestMessage.ToUserName);

            return responseMessage;
        }

        /// <summary>
        /// 处理语音请求
        /// </summary>
        public IResponseMessageBase GetResponseMessageeMusic(RequestMessageEventBase requestMessage, int ruleId, int accountId)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageMusic>(requestMessage);
            string EventName = "";
            if (requestMessage is IRequestMessageEventKey)
            {
                EventName += (requestMessage as IRequestMessageEventKey).EventKey;
            }
            else
            {
                EventName = requestMessage.Event.ToString();
            }
            Model.weixin_request_content model = new BLL.weixin_request_content().GetModel(ruleId);
            if (model == null)
            {

                new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "music", "-1", requestMessage.ToUserName);
            }
            else
            {
                if (model.media_url.Contains("http://"))
                {
                    responseMessage.Music.MusicUrl = model.media_url;

                }
                else
                {
                    //因为安装目录是以/开头，所以去掉，以免出现双斜杆
                    responseMessage.Music.MusicUrl = siteConfig.weburl + "/" + siteConfig.webpath.Replace("/", "") + model.media_url;
                }
                responseMessage.Music.Title = model.title;
                responseMessage.Music.Description = model.content;
                new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "music", "音乐链接：" + model.media_url + "|标题：" + model.title + "|描述：" + model.content, requestMessage.ToUserName);
            }
            return responseMessage;
        }

        /// <summary>
        /// 推送多图文
        /// </summary>
        public IResponseMessageBase GetResponseMessageNews(RequestMessageEventBase requestMessage, int ruleId, int accountId, string title)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
            string openid = requestMessage.FromUserName;
            string token = ConvertDateTimeInt(DateTime.Now).ToString();

            Article article;
            List<Article> artList = new List<Article>();
            IList<Model.weixin_request_content> twList = new BLL.weixin_request_content().GetModelList(10, ruleId, string.Empty);
            foreach (Model.weixin_request_content modelt in twList)
            {
                article = new Article();
                article.Title = title + modelt.title;
                article.Description = modelt.content;
                article.Url = GetWXApiUrl(modelt.link_url, token, openid);
                if (string.IsNullOrEmpty(modelt.img_url))
                {
                    article.PicUrl = string.Empty;
                }
                else
                {
                    if (modelt.img_url.Contains("http://"))
                    {
                        article.PicUrl = modelt.img_url;

                    }
                    else
                    {
                        //因为安装目录是以/开头，所以去掉，以免出现双斜杆
                        article.PicUrl = siteConfig.weburl + "/" + siteConfig.webpath.Replace("/", "") + modelt.img_url;
                    }
                }
                artList.Add(article);
            }

            string EventName = "";
            if (requestMessage is IRequestMessageEventKey)
            {
                EventName += (requestMessage as IRequestMessageEventKey).EventKey;
            }
            else
            {
                EventName = requestMessage.Event.ToString();
            }

            if (artList.Count == 0)
            {
                new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "txtpic", "-1", requestMessage.ToUserName);
            }
            else
            {
                new BLL.weixin_response_content().Add(accountId, requestMessage.FromUserName, requestMessage.MsgType.ToString(), EventName, "txtpic", "这次发了" + artList.Count + "条图文", requestMessage.ToUserName);
            }
            responseMessage.Articles.AddRange(artList);
            return responseMessage;
        }
        #endregion

        #region 获取验证公众账户ID===================================
        /// <summary>
        /// 获取公众账户的ID
        /// </summary>
        public int GetAccountId()
        {
            int uid = 0;
            BLL.weixin_account bll = new BLL.weixin_account();
            DataTable dt = bll.GetList("").Tables[0];
            if (dt.Rows.Count > 0)
            {
                uid = Convert.ToInt32(dt.Rows[0]["id"]);
            }
            return uid;
        }

        /// <summary>
        /// 验证公众账户原始ID是否一致
        /// </summary>
        public bool ExistsOriginalId(int accountId, string originalId)
        {
            return new BLL.weixin_account().ExistsOriginalId(accountId, originalId);
        }
        #endregion

        #region 常用的方法封装=======================================
        /// <summary>
        /// 拼接微信URL地址参数
        /// </summary>
        public string GetWXApiUrl(string url, string token, string openid)
        {
            if (url.Contains("?"))
            {
                return url + "&token=" + token + "&openid=" + openid;
            }
            return url + "?token=" + token + "&openid=" + openid;
        }

        /// <summary>
        /// 设置微信url地址的后缀
        /// </summary>
        /// <returns></returns>
        public string GetWxUrlSuffix()
        {
            return "wxref=mp.weixin.qq.com";
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        public long ConvertDateTimeInt(System.DateTime time)
        {
            long intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (long)(time - startTime).TotalSeconds;
            return intResult;
        }
        #endregion
        /*
        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="ToUserName"></param>
        /// <param name="parendid"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        private string addUserInfo(string openid, string ToUserName, string parendid, int accountId)
        {
            try
            {
                string title = "";
                
                CRMComm comm = new CRMComm();
                string error = "";
                string access_token = comm.GetAccessToken(accountId, out error);
                OAuthUser OAuthUser_Model = CRMComm.Get_UserInfo(access_token, openid);
                if (OAuthUser_Model.openid != null && OAuthUser_Model.openid != "")  //已获取得openid及其他信息
                {
                    string sex = "男";
                    if (OAuthUser_Model.sex == "2")
                    {
                        sex = "女";
                    }
                   
                    string picurl = OAuthUser_Model.headimgurl;
                    string newpicurl = "";
                    if (!string.IsNullOrEmpty(picurl))
                    {
                        newpicurl = CRMComm.downRemoteImg("upload/", picurl);
                    }
                    BLL.users bll = new BLL.users();
                    Model.users model = bll.GetModelopenid(OAuthUser_Model.openid);

                    if (model != null)
                    {
                        bll.UpdateField(model.id, "avatar='" + newpicurl + "',nick_name='" + OAuthUser_Model.nickname + "',sex='" + sex + "'");
                        title = "欢迎您回来，" + OAuthUser_Model.nickname + ",";
                    }
                    else
                    {
                        BLL.fensi fensibll = new BLL.fensi();
                        if (fensibll.Exists(openid))
                        {
                            Model.fensi fensiModel = fensibll.GetModel(openid);
                            if (fensiModel != null)
                            {
                                fensiModel.headimg = newpicurl;
                                fensiModel.nickname = OAuthUser_Model.nickname;
                                fensiModel.parentid = parendid;
                                fensibll.Update(fensiModel);
                            }
                        }
                        else
                        {
                            Model.fensi fensiModel = new Model.fensi();
                            fensiModel.headimg = newpicurl;
                            fensiModel.nickname = OAuthUser_Model.nickname;
                            fensiModel.openid = openid;
                            fensiModel.parentid = parendid;
                            fensibll.Add(fensiModel);
                        }
                       
                        //检查默认组别是否存在
                        //Model.user_groups modelGroup = new BLL.user_groups().GetDefault();
                        //if (modelGroup != null)
                        //{
                        //    string sqll = "select openid from dt_users where openid='" + OAuthUser_Model.openid + "'";
                        //    DataTable dtt = DbHelperSQL.Query(sqll).Tables[0];
                        //    if (dtt.Rows.Count == 0)
                        //    {
                        //        CRMComm.Writebug("会员model：4444|");
                        //        Model.userconfig userConfig = new BLL.userconfig().loadConfig();
                        //        Model.users modeluser = new Model.users();
                        //        modeluser.group_id = modelGroup.id;
                        //        CRMComm.Writebug("会员model：77777|");
                        //        modeluser.user_name = bll.SCMemberID();
                        //        modeluser.openid = OAuthUser_Model.openid;
                        //        modeluser.nick_name = OAuthUser_Model.nickname;
                        //        modeluser.salt = Utils.GetCheckCode(6); //获得6位的salt加密字符串
                        //        string password = "123456a";
                        //        CRMComm.Writebug("会员model：88888|");
                        //        modeluser.password = DESEncrypt.Encrypt(password, modeluser.salt);
                        //        modeluser.email = "";
                        //        modeluser.avatar = newpicurl;
                        //        modeluser.mobile = "";
                        //        modeluser.parentid = shengjiusername;
                        //        CRMComm.Writebug("会员model：99999|");
                        //        modeluser.reg_ip = DTRequest.GetIP();
                        //        modeluser.reg_time = DateTime.Now;
                        //        //设置用户状态
                        //        if (userConfig.regstatus == 3)
                        //        {
                        //            modeluser.status = 1; //待验证
                        //        }
                        //        else if (userConfig.regverify == 1)
                        //        {
                        //            modeluser.status = 2; //待审核
                        //        }
                        //        else
                        //        {
                        //            modeluser.status = 0; //正常
                        //        }
                        //        CRMComm.Writebug("会员model：555555|");
                        //        //开始写入数据库
                        //        int id = bll.Add(modeluser);
                        //        title = "欢迎您" + OAuthUser_Model.nickname + "，您是第 " + id + " 个会员,";
                        //        CRMComm.Writebug("会员model：666666666|");

                        //        if (parendid != null && parendid != "" && shangjiQr_openid != null && shangjiQr_openid != "")
                        //        {

                        //            tuisongshangji(modeluser.user_name, modeluser.nick_name, access_token);
                        //        }
                        //    }
                        //}
                    }

                }



                return title;
            }
            catch (Exception exce) { CRMComm.Writebug(exce.ToString() + "----messagefunction"); return ""; }
        }

    */
    /*
     * 推送
        public void tuisongshangji(string user_name, string nickname, string access_token)
        {


            string sql = "select * from  Qr_jiangjinconfig where groupid=2 order by ceng asc";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    GetTeamListByFloor(user_name, Convert.ToInt32(dt.Rows[i]["ceng"]), 0, nickname, user_name, access_token);


                }
            }



        }
        /// <summary>
        /// 返回会员号为UserCode的指定层的下级人员列表，Floor是指要求的层数，InitFloor是指递归开始的层数，一般都是0
        /// 调用方法为GetTeamListByfloor（UserCode,5,0）,返回结果为"111,222,33,4444"
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="Floor"></param>
        /// <param name="CurFloor"></param>
        /// <returns></returns>
        string GetTeamListByFloor(string UserCode, int Floor, int CurFloor, string nickname, string userid, string access_token)
        {
            string s = "";
            int n = 1;
            CurFloor = CurFloor + 1;

            string ssql = "select parentid,group_id from dt_users where user_name='" + UserCode + "'";
            DataTable dt = DbHelperSQL.Query(ssql).Tables[0];


            if (CurFloor == Floor)
            {
                huifuparend(dt.Rows[0]["parentid"].ToString(), nickname, userid, access_token);

                s = dt.Rows[0]["parentid"].ToString();
            }
            else
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["parentid"].ToString()))
                {
                    s = GetTeamListByFloor(dt.Rows[0]["parentid"].ToString(), Floor, CurFloor, nickname, userid, access_token);
                }
                else
                {
                    s = "";
                }
            }


            return s;
        }
        private void huifuparend(string parentid, string nickname, string userid, string access_token)
        {
            try
            {
                BLL.users bll = new BLL.users();
                Model.users user = bll.GetModel(parentid);
                CRMComm.Writebug("test0");
                BLL.weixin_account bllaccount = new BLL.weixin_account();
                DataTable dt = bllaccount.GetList("").Tables[0];
                CRMComm.Writebug("test1");
                if (dt.Rows.Count > 0)
                {
                    CRMComm.Writebug("test2");
                    string muban1 = dt.Rows[0]["muban1"].ToString();


                    Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
                    string respText = "";
                    string erweimaJson = " {\"touser\":\"" + user.openid + "\",\"template_id\":\"" + muban1 + "\",\"url\":\"" + siteConfig.weburl + "/mobile/weixin_login.aspx\",\"data\":{\"first\": {\"value\":\" 恭喜您，你有新成员" + nickname + "加入\",\"color\":\"#173177\"},\"keyword1\":{\"value\":\"" + userid + "\",\"color\":\"#173177\"},\"keyword2\": {\"value\":\"" + DateTime.Now + "\",\"color\":\"#173177\"},\"remark\":{\"value\":\"感谢您的努力！\",\"color\":\"#173177\"}}}";
                    string postUrl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";
                    string url = string.Format(postUrl, access_token);
                    byte[] requestBytes = Encoding.UTF8.GetBytes(erweimaJson);

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = requestBytes.Length;
                    CRMComm.Writebug("test3");
                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(requestBytes, 0, requestBytes.Length);
                        reqStream.Flush();
                        reqStream.Close();
                    }
                    CRMComm.Writebug("test4");
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();//返回来自inertnet的响应

                    using (Stream resStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(resStream, Encoding.Default);
                        respText = reader.ReadToEnd();
                        resStream.Close();
                    }
                    CRMComm.Writebug("test5");
                }
            }
            catch (Exception exe)
            {
                CRMComm.Writebug(exe.ToString() + " ---huifuparend");
            }


        }
        */

    }

}