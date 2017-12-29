﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using Qrcms.Web.UI;
using Qrcms.Common;
using Qrcms.DBUtility;

namespace Qrcms.Web.tools
{
    /// <summary>
    /// submit_ajax 的摘要说明
    /// </summary>
    public class submit_ajax : IHttpHandler, IRequiresSessionState
    {
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        Model.userconfig userConfig = new BLL.userconfig().loadConfig();

        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = DTRequest.GetQueryString("action");

            switch (action)
            {
                case "comment_add": //提交评论
                    comment_add(context);
                    break;
                case "comment_list": //评论列表
                    comment_list(context);
                    break;
                case "validate_username": //验证用户名
                    validate_username(context);
                    break;
                case "user_login": //用户登录
                    user_login(context);
                    break;
                case "user_check_login": //检查用户是否登录
                    user_check_login(context);
                    break;
                case "user_oauth_bind": //绑定第三方登录账户
                    user_oauth_bind(context);
                    break;
                case "user_oauth_register": //注册第三方登录账户
                    user_oauth_register(context);
                    break;
                case "user_register": //用户注册
                    user_register(context);
                    break;
                case "user_verify_smscode": //发送手机短信验证码
                    user_verify_smscode(context);
                    break;
                case "user_verify_email": //发送注册验证邮件
                    user_verify_email(context);
                    break;
                case "user_info_edit": //修改用户资料
                    user_info_edit(context);
                    break;
                case "user_avatar_crop": //确认裁剪用户头像
                    user_avatar_crop(context);
                    break;
                case "user_password_edit": //修改密码
                    user_password_edit(context);
                    break;
                case "user_getpassword": //用户取回密码
                    user_getpassword(context);
                    break;
                case "user_repassword": //用户重设密码
                    user_repassword(context);
                    break;
                case "user_invite_code": //申请邀请码
                    user_invite_code(context);
                    break;
                case "user_point_convert": //用户兑换积分
                    user_point_convert(context);
                    break;
                case "user_amount_recharge": //用户在线充值
                    user_amount_recharge(context);
                    break;
                case "user_message_add": //发布站内短消息
                    user_message_add(context);
                    break;
                case "user_address_edit": //编辑用户收货地址
                    user_address_edit(context);
                    break;
                case "user_address_default": //设置用户默认收货地址
                    user_address_default(context);
                    break;
                case "user_point_delete": //删除用户积分明细
                    user_point_delete(context);
                    break;
                case "user_amount_delete": //删除用户收支明细
                    user_amount_delete(context);
                    break;
                case "user_recharge_delete": //删除用户充值记录
                    user_recharge_delete(context);
                    break;
                case "user_message_delete": //删除短信息
                    user_message_delete(context);
                    break;
                case "user_address_delete": //删除用户收货地址
                    user_address_delete(context);
                    break;
                case "get_article_goods_info": //商品信息
                    get_article_goods_info(context);
                    break;
                case "cart_goods_add": //加入结帐商品
                    cart_goods_add(context);
                    break;
                case "cart_goods_buy": //购物车结账商品
                    cart_goods_buy(context);
                    break;
                case "cart_goods_update": //购物车修改商品
                    cart_goods_update(context);
                    break;
                case "cart_goods_delete": //购物车删除商品
                    cart_goods_delete(context);
                    break;
                case "order_save": //保存购物订单
                    order_save(context);
                    break;
                case "order_cancel": //用户取消订单
                    order_cancel(context);
                    break;
                case "view_article_click": //统计及输出阅读次数
                    view_article_click(context);
                    break;
                case "view_comment_count": //输出评论总数
                    view_comment_count(context);
                    break;
                case "view_attach_count": //输出附件下载总数
                    view_attach_count(context);
                    break;
                case "view_cart_count": //输出当前购物车总数
                    view_cart_count(context);
                    break;
                case "order_orders_th"://退货
                    order_orders_th(context);
                    break;
                case "order_orders_sj"://升级
                    order_orders_sj(context);
                    break;
                case "order_orders_auction"://猜奇偶查询
                    order_orders_auction(context);
                    break;
                case "order_orders_auction_add"://猜奇偶添加(重庆时时彩API接口)
                    order_orders_auction_add(context);
                    break;
                case "order_orders_hb"://猜红包
                    order_orders_hb(context);
                    break;
                case "order_save2": //保存购物订单
                    order_save2(context);
                    break;
                case "order_orders_dz"://地址(合并提货)
                    order_orders_dz(context);
                    break;
                case "bankcard_add"://银行卡添加
                    bankcard_add(context);
                    break;
                case "bankcard_delete"://银行卡删除
                    bankcard_delete(context);
                    break;
                case "bankcard_select"://银行卡查询
                    bankcard_select(context);
                    break;
                case "bankcard_selectid"://银行卡查询根据ID
                    bankcard_selectid(context);
                    break;
                case "bankcard_update"://银行卡修改
                    bankcard_update(context);
                    break;
                case "user_real"://银行卡修改
                    user_real(context);
                    break;
                case "txjl_add"://提现记录添加
                    txjl_add(context);
                    break;
                case "txjl_select"://提现记录查询
                    txjl_select(context);
                    break;
                case "txjl_pass"://提现审核通过
                    txjl_pass(context);
                    break;
                case "txjl_reject"://提现拒审
                    txjl_reject(context);
                    break;
                case "user_commision_log"://佣金记录查询
                    user_commision_log(context);
                    break;
                case "order_tikuan"://中奖提醒
                    order_tikuan(context);
                    break;
                case "orders_parent_select":///业绩查询
                    orders_parent_select(context);
                    break;
                case "orders_yjfwf_select":///业绩和服务费查询
                    orders_yjfwf_select(context);
                    break;
                case "orders_yjfwf_xq":///业绩和服务费详情
                    orders_yjfwf_xq(context);
                    break;
            }
        }

        private void order_tikuan(HttpContext context)
        {
            string order_no = DTRequest.GetString("order_no");

            var orderBLL = new BLL.orders();
            Model.orders orderModel = orderBLL.GetModel(order_no);
            Model.users userModel = new Qrcms.Web.UI.UserPage().GetUserInfo();
            if (userModel == null)
            {

                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，用户未登录！\"}");
                return;
            }
            if (userModel.user_name != orderModel.user_name)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，订单不属于改用户！\"}");
                return;
            }
            if (orderModel.quiz_result != 1 || orderModel.status > 2)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，订单不能提款！\"}");
                return;
            }
            //Model.siteconfig config = new BLL.siteconfig().loadConfig();
            decimal jj = orderModel.order_zjtkbl * orderModel.payable_amount;
            //中奖提款，状态已完成
            orderBLL.UpdateField(orderModel.id, " status=3 ");
            //给会员增加积分检查升级
            if (orderModel.user_id > 0 && orderModel.point > 0)
            {
                new BLL.user_point_log().Add(orderModel.user_id, orderModel.user_name, orderModel.point, "购物获得积分，订单号：" + orderModel.order_no, false);
            }
            new BLL.user_amount_log().Add(userModel.id, userModel.user_name, jj + orderModel.payable_amount, "中奖提款，中奖订单：" + orderModel.order_no);

            context.Response.Write("{\"status\":1, \"msg\": \"提款成功！\"}");
        }

        #region 提交评论的处理方法===========================
        private void comment_add(HttpContext context)
        {
            StringBuilder strTxt = new StringBuilder();
            BLL.article_comment bll = new BLL.article_comment();
            Model.article_comment model = new Model.article_comment();

            string code = DTRequest.GetFormString("txtCode");
            int article_id = DTRequest.GetQueryInt("article_id");
            string _content = DTRequest.GetFormString("txtContent");
            //校检验证码
            string result = verify_code(context, code);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            if (article_id == 0)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，参数传输有误！\"}");
                return;
            }
            if (string.IsNullOrEmpty(_content))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，请输入评论的内容！\"}");
                return;
            }
            //检查该文章是否存在
            Model.article artModel = new BLL.article().GetModel(article_id);
            if (artModel == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，主题不存在或已删除！\"}");
                return;
            }
            //检查用户是否登录
            int user_id = 0;
            string user_name = "匿名用户";
            Model.users userModel = new Web.UI.BasePage().GetUserInfo();
            if (userModel != null)
            {
                user_id = userModel.id;
                user_name = userModel.user_name;
            }
            model.channel_id = artModel.channel_id;
            model.article_id = artModel.id;
            model.content = Utils.ToHtml(_content);
            model.user_id = user_id;
            model.user_name = user_name;
            model.user_ip = DTRequest.GetIP();
            model.is_lock = siteConfig.commentstatus; //审核开关
            model.add_time = DateTime.Now;
            model.is_reply = 0;
            if (bll.Add(model) > 0)
            {
                context.Response.Write("{\"status\": 1, \"msg\": \"恭喜您，留言提交成功！\"}");
                return;
            }
            context.Response.Write("{\"status\": 0, \"msg\": \"对不起，保存过程中发生错误！\"}");
            return;
        }
        #endregion

        #region 取得评论列表方法=============================
        private void comment_list(HttpContext context)
        {
            int article_id = DTRequest.GetQueryInt("article_id");
            int page_index = DTRequest.GetQueryInt("page_index");
            int page_size = DTRequest.GetQueryInt("page_size");
            int totalcount;
            StringBuilder strTxt = new StringBuilder();

            if (article_id == 0 || page_size == 0)
            {
                context.Response.Write("获取失败，传输参数有误！");
                return;
            }

            BLL.article_comment bll = new BLL.article_comment();
            DataSet ds = bll.GetList(page_size, page_index, string.Format("is_lock=0 and article_id={0}", article_id.ToString()), "add_time asc", out totalcount);
            //如果记录存在
            if (ds.Tables[0].Rows.Count > 0)
            {
                strTxt.Append("[");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    strTxt.Append("{");
                    strTxt.Append("\"user_id\":" + dr["user_id"]);
                    strTxt.Append(",\"user_name\":\"" + dr["user_name"] + "\"");
                    if (Convert.ToInt32(dr["user_id"]) > 0)
                    {
                        Model.users userModel = new BLL.users().GetModel(Convert.ToInt32(dr["user_id"]));
                        if (userModel != null)
                        {
                            strTxt.Append(",\"avatar\":\"" + userModel.avatar + "\"");
                        }
                    }
                    strTxt.Append("");
                    strTxt.Append(",\"content\":\"" + Microsoft.JScript.GlobalObject.escape(dr["content"]) + "\"");
                    strTxt.Append(",\"add_time\":\"" + dr["add_time"] + "\"");
                    strTxt.Append(",\"is_reply\":" + dr["is_reply"]);
                    if (Convert.ToInt32(dr["is_reply"]) == 1)
                    {
                        strTxt.Append(",\"reply_content\":\"" + Microsoft.JScript.GlobalObject.escape(dr["reply_content"]) + "\"");
                        strTxt.Append(",\"reply_time\":\"" + dr["reply_time"] + "\"");
                    }
                    strTxt.Append("}");
                    //是否加逗号
                    if (i < ds.Tables[0].Rows.Count - 1)
                    {
                        strTxt.Append(",");
                    }

                }
                strTxt.Append("]");
            }
            context.Response.Write(strTxt.ToString());
        }
        #endregion

        #region 验证用户名是否可用===========================
        private void validate_username(HttpContext context)
        {
            string username = DTRequest.GetString("param");
            //如果为Null，退出
            if (string.IsNullOrEmpty(username))
            {
                context.Response.Write("{ \"info\":\"用户名不可为空\", \"status\":\"n\" }");
                return;
            }
            //过滤注册用户名字符
            string[] strArray = userConfig.regkeywords.Split(',');
            foreach (string s in strArray)
            {
                if (s.ToLower() == username.ToLower())
                {
                    context.Response.Write("{ \"info\":\"该用户名不可用\", \"status\":\"n\" }");
                    return;
                }
            }
            BLL.users bll = new BLL.users();
            //查询数据库
            if (!bll.Exists(username.Trim()))
            {
                context.Response.Write("{ \"info\":\"该用户名可用\", \"status\":\"y\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"该用户名已被注册\", \"status\":\"n\" }");
            return;
        }
        #endregion

        #region 用户登录=====================================
        private void user_login(HttpContext context)
        {
            string sitepath = DTRequest.GetQueryString("site");
            string username = DTRequest.GetFormString("txtUserName");
            string password = DTRequest.GetFormString("txtPassword");
            string remember = DTRequest.GetFormString("chkRemember");

            string openid = DTRequest.GetFormString("openid");
            openid = string.IsNullOrEmpty(openid) ? Utils.GetCookie("openid") : openid;
            //检查站点目录
            if (string.IsNullOrEmpty(sitepath))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误提示：站点传输参数不正确！\"}");
                return;
            }
            //检查用户名密码
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"温馨提示：请输入用户名或密码！\"}");
                return;
            }

            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(username, password, userConfig.emaillogin, userConfig.mobilelogin, true);
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"错误提示：用户名或密码错误，请重试！\"}");
                return;
            }
            //检查用户是否通过验证
            if (model.status == 1) //待验证
            {
                if (userConfig.regverify == 1)
                {
                    context.Response.Write("{\"status\":1, \"url\":\""
                        + new Web.UI.BasePage().getlink(sitepath, new Web.UI.BasePage().linkurl("register", "?action=sendmail&username=" + Utils.UrlEncode(model.user_name))) + "\", \"msg\":\"会员尚未通过验证！\"}");
                }
                else
                {
                    context.Response.Write("{\"status\":1, \"url\":\"" +
                        new Web.UI.BasePage().getlink(sitepath, new Web.UI.BasePage().linkurl("register", "?action=sendsms&username=" + Utils.UrlEncode(model.user_name))) + "\", \"msg\":\"会员尚未通过验证！\"}");
                }
                return;
            }
            else if (model.status == 2) //待审核
            {
                context.Response.Write("{\"status\":1, \"url\":\""
                    + new Web.UI.BasePage().getlink(sitepath, new Web.UI.BasePage().linkurl("register", "?action=verify&username=" + Utils.UrlEncode(model.user_name))) + "\", \"msg\":\"会员尚未通过审核！\"}");
                return;
            }
            //检查用户每天登录是否获得积分
            if (!new BLL.user_login_log().ExistsDay(model.user_name) && userConfig.pointloginnum > 0)
            {
                new BLL.user_point_log().Add(model.id, model.user_name, userConfig.pointloginnum, "每天登录获得积分", true); //增加用户登录积分
                model = bll.GetModel(username, password, userConfig.emaillogin, userConfig.mobilelogin, true); //更新一下用户信息
            }
            context.Session[DTKeys.SESSION_USER_INFO] = model;
            context.Session.Timeout = 45;
            //记住登录状态下次自动登录
            if (remember.ToLower() == "true")
            {
                Utils.WriteCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "Qrcms", model.user_name, 43200);
                Utils.WriteCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "Qrcms", model.password, 43200);
            }
            else
            {
                //防止Session提前过期
                Utils.WriteCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "Qrcms", model.user_name);
                Utils.WriteCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "Qrcms", model.password);
            }
            if (!string.IsNullOrEmpty(openid))
            {
                if (!bll.ExistsOpenid(openid))
                {
                    Model.fensi fenModel = new BLL.fensi().GetModel(openid);
                    if (fenModel != null)
                    {
                        string prent_user = "";
                        int pid = Utils.StrToInt(fenModel.parentid, 0);
                        if (pid > 0)
                        {
                            prent_user = bll.GetUserName(pid);
                        }
                        new BLL.users().UpdateField(model.id, " openid='" + openid + "',avatar='" + fenModel.headimg + "',nick_name='" + fenModel.nickname + "',parent_user='" + prent_user + "'");
                        Utils.WriteCookie("openid", "");
                    }
                    else
                    {
                        context.Response.Write("{\"status\":0, \"msg\":\"关注已失效，请重新关注！\"}");
                        return;
                    }
                }
            }
            //写入登录日志
            new BLL.user_login_log().Add(model.id, model.user_name, "会员登录");
            //返回URL
            context.Response.Write("{\"status\":1, \"msg\":\"会员登录成功！\"}");
            return;
        }
        #endregion

        #region 检查用户是否登录=============================
        private void user_check_login(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"username\":\"匿名用户\"}");
                return;
            }
            context.Response.Write("{\"status\":1, \"username\":\"" + model.user_name + "\"}");
        }
        #endregion

        #region 绑定第三方登录账户===========================
        private void user_oauth_bind(HttpContext context)
        {
            //检查URL参数
            if (context.Session["oauth_name"] == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误提示：授权参数不正确！\"}");
                return;
            }
            //获取授权信息
            string result = Utils.UrlExecute(siteConfig.webpath + "api/oauth/" + context.Session["oauth_name"].ToString() + "/result_json.aspx");
            if (result.Contains("error"))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误提示：请检查URL是否正确！\"}");
                return;
            }
            //反序列化JSON
            Dictionary<string, object> dic = JsonHelper.DataRowFromJSON(result);
            if (dic["ret"].ToString() != "0")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误代码：" + dic["ret"] + "，描述：" + dic["msg"] + "\"}");
                return;
            }

            //检查用户名密码
            string username = DTRequest.GetString("txtUserName");
            string password = DTRequest.GetString("txtPassword");
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"温馨提示：请输入用户名或密码！\"}");
                return;
            }
            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(username, password, userConfig.emaillogin, userConfig.mobilelogin, true);
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"错误提示：用户名或密码错误！\"}");
                return;
            }
            //开始绑定
            Model.user_oauth oauthModel = new Model.user_oauth();
            oauthModel.oauth_name = dic["oauth_name"].ToString();
            oauthModel.user_id = model.id;
            oauthModel.user_name = model.user_name;
            oauthModel.oauth_access_token = dic["oauth_access_token"].ToString();
            oauthModel.oauth_openid = dic["oauth_openid"].ToString();
            int newId = new BLL.user_oauth().Add(oauthModel);
            if (newId < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"错误提示：绑定过程中出错，请重新获取！\"}");
                return;
            }
            context.Session[DTKeys.SESSION_USER_INFO] = model;
            context.Session.Timeout = 45;
            //记住登录状态，防止Session提前过期
            Utils.WriteCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "Qrcms", model.user_name);
            Utils.WriteCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "Qrcms", model.password);
            //写入登录日志
            new BLL.user_login_log().Add(model.id, model.user_name, "会员登录");
            //返回URL
            context.Response.Write("{\"status\":1, \"msg\":\"会员登录成功！\"}");
            return;
        }
        #endregion

        #region 注册第三方登录账户===========================
        private void user_oauth_register(HttpContext context)
        {
            //检查URL参数
            if (context.Session["oauth_name"] == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误提示：授权参数不正确！\"}");
                return;
            }
            //获取授权信息
            string result = Utils.UrlExecute(siteConfig.webpath + "api/oauth/" + context.Session["oauth_name"].ToString() + "/result_json.aspx");
            if (result.Contains("error"))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误提示：请检查URL是否正确！\"}");
                return;
            }
            string password = DTRequest.GetFormString("txtPassword").Trim();
            string email = Utils.ToHtml(DTRequest.GetFormString("txtEmail").Trim());
            string mobile = Utils.ToHtml(DTRequest.GetFormString("txtMobile").Trim());
            string userip = DTRequest.GetIP();
            //反序列化JSON
            Dictionary<string, object> dic = JsonHelper.DataRowFromJSON(result);
            if (dic["ret"].ToString() != "0")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误代码：" + dic["ret"] + "，" + dic["msg"] + "\"}");
                return;
            }
            BLL.users bll = new BLL.users();
            Model.users model = new Model.users();
            //如果开启手机登录要验证手机
            if (userConfig.mobilelogin == 1 && !string.IsNullOrEmpty(mobile))
            {
                if (bll.ExistsMobile(mobile))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该手机号码已被使用！\"}");
                    return;
                }
            }
            //如果开启邮箱登录要验证邮箱
            if (userConfig.emaillogin == 1 && !string.IsNullOrEmpty(email))
            {
                if (bll.ExistsEmail(email))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该电子邮箱已被使用！\"}");
                    return;
                }
            }
            //检查默认组别是否存在
            Model.user_groups modelGroup = new BLL.user_groups().GetDefault();
            if (modelGroup == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"用户尚未分组，请联系管理员！\"}");
                return;
            }
            //保存注册信息
            model.group_id = modelGroup.id;
            model.user_name = bll.GetRandomName(10); //随机用户名
            model.salt = Utils.GetCheckCode(6); //获得6位的salt加密字符串
            model.password = DESEncrypt.Encrypt(password, model.salt);
            model.email = email;
            model.mobile = mobile;
            if (!string.IsNullOrEmpty(dic["nick"].ToString()))
            {
                model.nick_name = dic["nick"].ToString();
            }
            if (dic["avatar"].ToString().StartsWith("http://"))
            {
                model.avatar = dic["avatar"].ToString();
            }
            if (!string.IsNullOrEmpty(dic["sex"].ToString()))
            {
                model.sex = dic["sex"].ToString();
            }
            if (!string.IsNullOrEmpty(dic["birthday"].ToString()))
            {
                model.birthday = Utils.StrToDateTime(dic["birthday"].ToString());
            }
            model.reg_ip = userip;
            model.reg_time = DateTime.Now;
            model.status = 0; //设置为正常状态
            model.id = bll.Add(model); //保存数据
            if (model.id < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"注册失败，请联系网站管理员！\"}");
                return;
            }
            //赠送积分金额
            if (modelGroup.point > 0)
            {
                new BLL.user_point_log().Add(model.id, model.user_name, modelGroup.point, "注册赠送积分", false);
            }
            if (modelGroup.amount > 0)
            {
                new BLL.user_amount_log().Add(model.id, model.user_name, modelGroup.amount, "注册赠送金额");
            }
            //判断是否发送欢迎消息
            if (userConfig.regmsgstatus == 1) //站内短消息
            {
                new BLL.user_message().Add(1, "", model.user_name, "欢迎您成为本站会员", userConfig.regmsgtxt);
            }
            else if (userConfig.regmsgstatus == 2) //发送邮件
            {
                //取得邮件模板内容
                Model.mail_template mailModel = new BLL.mail_template().GetModel("welcomemsg");
                if (mailModel != null)
                {
                    //替换标签
                    string mailTitle = mailModel.maill_title;
                    mailTitle = mailTitle.Replace("{username}", model.user_name);
                    string mailContent = mailModel.content;
                    mailContent = mailContent.Replace("{webname}", siteConfig.webname);
                    mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);
                    mailContent = mailContent.Replace("{webtel}", siteConfig.webtel);
                    mailContent = mailContent.Replace("{username}", model.user_name);
                    //发送邮件
                    DTMail.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                        siteConfig.emailfrom, model.email, mailTitle, mailContent, siteConfig.emailport);
                }
            }
            else if (userConfig.regmsgstatus == 3 && mobile != "") //发送短信
            {
                Model.sms_template smsModel = new BLL.sms_template().GetModel("welcomemsg"); //取得短信内容
                if (smsModel != null)
                {
                    //替换标签
                    string msgContent = smsModel.content;
                    msgContent = msgContent.Replace("{webname}", siteConfig.webname);
                    msgContent = msgContent.Replace("{weburl}", siteConfig.weburl);
                    msgContent = msgContent.Replace("{webtel}", siteConfig.webtel);
                    msgContent = msgContent.Replace("{username}", model.user_name);
                    //发送短信
                    string tipMsg = string.Empty;
                    new BLL.sms_message().Send(model.mobile, msgContent, 2, out tipMsg);
                }
            }
            //绑定到对应的授权类型
            Model.user_oauth oauthModel = new Model.user_oauth();
            oauthModel.oauth_name = dic["oauth_name"].ToString();
            oauthModel.user_id = model.id;
            oauthModel.user_name = model.user_name;
            oauthModel.oauth_access_token = dic["oauth_access_token"].ToString();
            oauthModel.oauth_openid = dic["oauth_openid"].ToString();
            new BLL.user_oauth().Add(oauthModel);

            context.Session[DTKeys.SESSION_USER_INFO] = model;
            context.Session.Timeout = 45;
            //记住登录状态，防止Session提前过期
            Utils.WriteCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "Qrcms", model.user_name);
            Utils.WriteCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "Qrcms", model.password);
            //写入登录日志
            new BLL.user_login_log().Add(model.id, model.user_name, "会员登录");
            //返回URL
            context.Response.Write("{\"status\":1, \"msg\":\"会员登录成功！\"}");
            return;
        }
        #endregion

        #region 用户注册=====================================
        private void user_register(HttpContext context)
        {
            pageHelper.WriteLog("注册 =========\r");
            string site = DTRequest.GetQueryString("site").Trim(); //当前站点
            string code = DTRequest.GetFormString("txtCode").Trim();
            string username = Utils.ToHtml(DTRequest.GetFormString("txtUserName").Trim());
            string password = DTRequest.GetFormString("txtPassword").Trim();
            string email = Utils.ToHtml(DTRequest.GetFormString("txtEmail").Trim());
            string mobile = Utils.ToHtml(DTRequest.GetFormString("txtMobile").Trim());
            string QRcodestateNew = Utils.ToHtml(DTRequest.GetFormString("QRcodestate").Trim());//邀请码

            string openid = DTRequest.GetFormString("openid");
            openid = string.IsNullOrEmpty(openid) ? Utils.GetCookie("openid") : openid;
            string userip = DTRequest.GetIP();

            #region 验证各种参数信息
            //检查站点目录是否正确
            if (string.IsNullOrEmpty(site))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，网站传输参数有误！\"}");
                return;
            }
            if (string.IsNullOrEmpty(QRcodestateNew))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入邀请码！\"}");
                return;
            }
            //检查是否开启会员功能
            if (siteConfig.memberstatus == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，会员功能已关闭，无法注册！\"}");
                return;
            }
            if (userConfig.regstatus == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，系统暂不允许注册新用户！\"}");
                return;
            }
            //检查用户输入信息是否为空
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户名和密码不能为空！\"}");
                return;
            }
            //如果开启手机注册则要验证手机
            if (userConfig.regstatus == 2 && string.IsNullOrEmpty(mobile))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"错误：手机号码不能为空！\"}");
                return;
            }
            //如果开启邮箱注册则要验证邮箱
            if (userConfig.regstatus == 3 && string.IsNullOrEmpty(email))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，电子邮箱不能为空！\"}");
                return;
            }
            //检查用户名
            BLL.users bll = new BLL.users();
            if (bll.Exists(username))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，该用户名已经存在！\"}");
                return;
            }
            //如果开启手机登录要验证手机
            if (userConfig.mobilelogin == 1 && !string.IsNullOrEmpty(mobile))
            {
                if (bll.ExistsMobile(mobile))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该手机号码已被使用！\"}");
                    return;
                }
            }
            //如果开启邮箱登录要验证邮箱
            if (userConfig.emaillogin == 1 && !string.IsNullOrEmpty(email))
            {
                if (bll.ExistsEmail(email))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该电子邮箱已被使用！\"}");
                    return;
                }
            }
            //检查同一IP注册时隔
            if (userConfig.regctrl > 0)
            {
                if (bll.Exists(userip, userConfig.regctrl))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，同IP在" + userConfig.regctrl + "小时内禁止重复注册！\"}");
                    return;
                }
            }
            //检查默认组别是否存在
            Model.user_groups modelGroup = new BLL.user_groups().GetDefault();
            if (modelGroup == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"用户尚未分组，请联系网站管理员！\"}");
                return;
            }

            #endregion

            #region 判断会员组
            DataTable dt = new DataTable();//会员组dt
            int group_idNew = 0;//会员组id
            int is_QRcodestateNew = 0;//是否生成邀请码，0否，1是
            string parent_user = "";
            BLL.user_groups bllgroups = new BLL.user_groups();
            if (string.IsNullOrEmpty(QRcodestateNew))//是否输入邀请码
            {
                //没邀请码，默认最低价会员
                dt = bllgroups.GetList(1, "", " grade ASC").Tables[0];
                group_idNew = Utils.StrToInt(dt.Rows[0]["id"].ToString(), 0);
                is_QRcodestateNew = Utils.StrToInt(dt.Rows[0]["is_QRcodestate"].ToString(), 0);
            }
            else
            {
                //有邀请码，先查询邀请码是谁的，和他的会员组
                int groupid = Utils.StrToInt(Utils.ObjectToStr(bll.GetList("group_id", " QRcodestate='" + QRcodestateNew + "'")), 0);
                parent_user = Utils.ObjectToStr(bll.GetList("user_name", " QRcodestate='" + QRcodestateNew + "'"));
                if (groupid != 0)//邀请码正确
                {
                    //获得邀请码的会员组
                    dt = bllgroups.GetList(1, " id=" + groupid + " ", " grade ASC").Tables[0];
                    //邀请码会员组的下级，重新获得会员组
                    dt = bllgroups.GetList(1, " grade<" + dt.Rows[0]["grade"].ToString() + " ", " grade DESC").Tables[0];
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        //
                        group_idNew = modelGroup.id;
                        is_QRcodestateNew = 0;
                    }
                    else
                    {
                        group_idNew = Utils.StrToInt(dt.Rows[0]["id"].ToString(), 0);
                        is_QRcodestateNew = Utils.StrToInt(dt.Rows[0]["is_QRcodestate"].ToString(), 0);
                    }
                }
                else//邀请码错误
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，输入邀请码错误！\"}");
                    return;
                }
            }
            #endregion

            //检查验证码是否正确
            switch (userConfig.regstatus)
            {
                case 1: //验证网页验证码
                    string result1 = verify_code(context, code);
                    if (result1 != "success")
                    {
                        context.Response.Write(result1);
                        return;
                    }
                    break;
                case 2: //验证手机验证码
                    string result2 = verify_sms_code(context, code);
                    if (result2 != "success")
                    {
                        context.Response.Write(result2);
                        return;
                    }
                    break;
                case 4: //验证邀请码
                    pageHelper.WriteLog("验证邀请码 =========\r");
                    //string result4 = verify_invite_reg(username, code);
                    //if (result4 != "success")
                    //{
                    //    context.Response.Write(result4);
                    //    return;
                    //}

                    string result4 = verify_sms_code(context, code);
                    if (result4 != "success")
                    {
                        context.Response.Write(result4);
                        return;
                    }
                    break;
            }

            #region 生成邀请码
            string QRcodestate = "";
            //if (is_QRcodestateNew == 1)//要生成邀请码
            //{
            QRcodestate = yzQRcodestate("");
            //}
            #endregion


            #region 保存用户注册信息
            Model.users model = new Model.users();
            //model.group_id = modelGroup.id;
            model.group_id = group_idNew;
            model.QRcodestate = QRcodestate;
            model.user_name = username;
            model.parent_user = parent_user;
            model.salt = Utils.GetCheckCode(6); //获得6位的salt加密字符串
            model.password = DESEncrypt.Encrypt(password, model.salt);
            model.email = email;
            model.mobile = mobile;
            model.reg_ip = userip;
            model.reg_time = DateTime.Now;
            //设置用户状态
            if (userConfig.regstatus == 3)
            {
                model.status = 1; //待验证
            }
            else if (userConfig.regverify == 1)
            {
                model.status = 2; //待审核
            }
            else
            {
                model.status = 0; //正常
            }
            //开始写入数据库
            model.id = bll.Add(model);
            if (model.id < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"系统故障，请联系网站管理员！\"}");
                return;
            }

            if (!string.IsNullOrEmpty(openid))
            {
                if (!bll.ExistsOpenid(openid))
                {
                    Model.fensi fenModel = new BLL.fensi().GetModel(openid);
                    if (fenModel != null)
                    {
                        model.openid = openid;
                        model.avatar = fenModel.headimg;
                        model.nick_name = fenModel.nickname;
                        if (string.IsNullOrEmpty(model.parent_user))
                        {
                            int pid = Utils.ObjToInt(fenModel.parentid, 0);
                            if (pid > 0)
                            {
                                int groupid = Utils.StrToInt(bll.GetList("group_id", " id=" + pid + "").ToString(), 0);
                                parent_user = bll.GetList("user_name", " id=" + pid + "").ToString();
                                if (groupid != 0)//邀请码正确
                                {
                                    //获得邀请码的会员组
                                    dt = bllgroups.GetList(1, " id=" + groupid + " ", " grade ASC").Tables[0];
                                    //邀请码会员组的下级，重新获得会员组
                                    dt = bllgroups.GetList(1, " grade<" + dt.Rows[0]["grade"].ToString() + " ", " grade DESC").Tables[0];
                                    if (dt == null || dt.Rows.Count <= 0)
                                    {
                                        //
                                        group_idNew = modelGroup.id;
                                        is_QRcodestateNew = 0;
                                    }
                                    else
                                    {
                                        group_idNew = Utils.StrToInt(dt.Rows[0]["id"].ToString(), 0);
                                        is_QRcodestateNew = Utils.StrToInt(dt.Rows[0]["is_QRcodestate"].ToString(), 0);
                                    }
                                }
                                model.parent_user = parent_user;
                                model.group_id = group_idNew;
                            }
                        }

                        Utils.WriteCookie("openid", "");
                    }
                    else
                    {
                        context.Response.Write("{\"status\":0, \"msg\":\"关注已失效，请重新关注！\"}");
                        return;
                    }
                }
                else
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"微信帐号已注册！\"}");
                    return;
                }
            }
            //检查用户组是否需要赠送积分
            if (modelGroup.point > 0)
            {
                new BLL.user_point_log().Add(model.id, model.user_name, modelGroup.point, "注册赠送积分", false);
            }
            //检查用户组是否需要赠送金额
            if (modelGroup.amount > 0)
            {
                new BLL.user_amount_log().Add(model.id, model.user_name, modelGroup.amount, "注册赠送金额");
            }
            #endregion

            #region 是否发送欢迎消息
            if (userConfig.regmsgstatus == 1) //站内短消息
            {
                new BLL.user_message().Add(1, string.Empty, model.user_name, "欢迎您成为本站会员", userConfig.regmsgtxt);
            }
            else if (userConfig.regmsgstatus == 2 && !string.IsNullOrEmpty(email)) //发送邮件
            {
                //取得邮件模板内容
                Model.mail_template mailModel = new BLL.mail_template().GetModel("welcomemsg");
                if (mailModel != null)
                {
                    //替换标签
                    string mailTitle = mailModel.maill_title;
                    mailTitle = mailTitle.Replace("{username}", model.user_name);
                    string mailContent = mailModel.content;
                    mailContent = mailContent.Replace("{webname}", siteConfig.webname);
                    mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);
                    mailContent = mailContent.Replace("{webtel}", siteConfig.webtel);
                    mailContent = mailContent.Replace("{username}", model.user_name);
                    //发送邮件
                    DTMail.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                        siteConfig.emailfrom, model.email, mailTitle, mailContent, siteConfig.emailport);
                }
            }
            else if (userConfig.regmsgstatus == 3 && !string.IsNullOrEmpty(mobile)) //发送短信
            {
                Model.sms_template smsModel = new BLL.sms_template().GetModel("welcomemsg"); //取得短信内容
                if (smsModel != null)
                {
                    //替换标签
                    string msgContent = smsModel.content;
                    msgContent = msgContent.Replace("{webname}", siteConfig.webname);
                    msgContent = msgContent.Replace("{weburl}", siteConfig.weburl);
                    msgContent = msgContent.Replace("{webtel}", siteConfig.webtel);
                    msgContent = msgContent.Replace("{username}", model.user_name);
                    //发送短信
                    string tipMsg = string.Empty;
                    new BLL.sms_message().Send(model.mobile, msgContent, 2, out tipMsg);
                }
            }
            #endregion

            //需要Email验证
            if (userConfig.regstatus == 3)
            {
                string result2 = send_verify_email(site, model); //发送验证邮件
                if (result2 != "success")
                {
                    context.Response.Write(result2);
                    return;
                }
                context.Response.Write("{\"status\":1, \"msg\":\"注册成功，请进入邮箱验证激活账户！\", \"url\":\""
                    + new Web.UI.BasePage().getlink(site, new Web.UI.BasePage().linkurl("register", "?action=sendmail&username=" + Utils.UrlEncode(model.user_name))) + "\"}");
            }
            //需要人工审核
            else if (userConfig.regverify == 1)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"注册成功，请等待审核通过！\", \"url\":\""
                    + new Web.UI.BasePage().getlink(site, new Web.UI.BasePage().linkurl("register", "?action=verify&username=" + Utils.UrlEncode(model.user_name))) + "\"}");
            }
            else
            {
                context.Session[DTKeys.SESSION_USER_INFO] = model;
                context.Session.Timeout = 45;
                //防止Session提前过期
                Utils.WriteCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "Qrcms", model.user_name);
                Utils.WriteCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "Qrcms", model.password);
                //写入登录日志
                new BLL.user_login_log().Add(model.id, model.user_name, "会员登录");
                context.Response.Write("{\"status\":1, \"msg\":\"注册成功，欢迎成为本站会员！\", \"url\":\""
                    + new Web.UI.BasePage().getlink(site, new Web.UI.BasePage().linkurl("usercenter", "index")) + "\"}");
            }
            return;
        }
        #endregion

        #region 生成邀请码===========================
        /// 生成邀请码是否数据库有
        /// </summary>
        /// <param name="QRcodestate"></param>
        /// <returns></returns>
        private string yzQRcodestate(string QRcodestate)
        {
            BLL.users bll = new BLL.users();
            string QRcodestateNew = "";
            if (Utils.StrToInt(bll.GetList("Count(*)", " QRcodestate='" + QRcodestate + "'").ToString(), 0) == 0 && !string.IsNullOrEmpty(QRcodestate))
            {
                QRcodestateNew = QRcodestate;
            }
            else
            {
                Random rd = new Random();
                string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string result = "";
                for (int i = 0; i < 6; i++)
                {
                    result += str[rd.Next(str.Length)];
                }
                QRcodestateNew = yzQRcodestate(result);
            }
            return QRcodestateNew;
        }
        #endregion

        #region 发送手机短信验证码===========================
        private void user_verify_smscode(HttpContext context)
        {
            string mobile = Utils.ToHtml(DTRequest.GetString("mobile"));
            //检查手机
            if (string.IsNullOrEmpty(mobile))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"发送失败，请填写手机号码！\"}");
            }
            string result = send_verify_sms_code(context, mobile);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            context.Response.Write("{\"status\":1, \"time\":\"" + userConfig.regsmsexpired + "\", \"msg\":\"手机验证码发送成功！\"}");
            return;
        }
        #endregion

        #region 发送注册验证邮件=============================
        private void user_verify_email(HttpContext context)
        {
            string site = DTRequest.GetString("site");
            string username = Utils.ToHtml(DTRequest.GetFormString("username"));

            if (string.IsNullOrEmpty(site))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"网站传输参数有误！\"}");
                return;
            }
            if (string.IsNullOrEmpty(username))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请检查用户名是否正确！\"}");
                return;
            }
            //检查邮件是否过快
            string cookie = Utils.GetCookie(DTKeys.COOKIE_USER_EMAIL);
            if (cookie == username)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"邮件发送间隔为二十分钟，请稍候再提交吧！\"}");
                return;
            }
            Model.users model = new BLL.users().GetModel(username);
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"该用户不存在或已删除！\"}");
                return;
            }
            if (model.status != 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"该用户不需要邮箱验证！\"}");
                return;
            }
            string result = send_verify_email(site, model);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            context.Response.Write("{\"status\":1, \"msg\":\"邮件已发送，请进入邮箱查看！\"}");
            Utils.WriteCookie(DTKeys.COOKIE_USER_EMAIL, username, 20); //20分钟内无重复发送
            return;
        }
        #endregion

        #region 修改用户信息=================================
        private void user_info_edit(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string nick_name = Utils.ToHtml(DTRequest.GetFormString("txtNickName"));
            string sex = DTRequest.GetFormString("rblSex");
            string birthday = DTRequest.GetFormString("txtBirthday");
            string email = Utils.ToHtml(DTRequest.GetFormString("txtEmail"));
            string mobile = Utils.ToHtml(DTRequest.GetFormString("txtMobile"));
            string telphone = Utils.ToHtml(DTRequest.GetFormString("txtTelphone"));
            string qq = Utils.ToHtml(DTRequest.GetFormString("txtQQ"));
            string msn = Utils.ToHtml(DTRequest.GetFormString("txtMsn"));
            string province = Utils.ToHtml(DTRequest.GetFormString("txtProvince"));
            string city = Utils.ToHtml(DTRequest.GetFormString("txtCity"));
            string area = Utils.ToHtml(DTRequest.GetFormString("txtArea"));
            string address = Utils.ToHtml(context.Request.Form["txtAddress"]);
            //检查昵称
            if (string.IsNullOrEmpty(nick_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您的姓名昵称！\"}");
                return;
            }
            //检查省市区
            if (string.IsNullOrEmpty(province) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(area))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请选择您所在的省市区！\"}");
                return;
            }
            BLL.users bll = new BLL.users();
            //检查手机，如开启手机注册或使用手机登录需要检查
            if (userConfig.regstatus == 2 || userConfig.mobilelogin == 1)
            {
                if (string.IsNullOrEmpty(mobile))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您的手机号码！\"}");
                    return;
                }
                if (model.mobile != mobile && bll.ExistsMobile(mobile))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该手机号码已被使用！\"}");
                    return;
                }
            }
            //检查邮箱，如开启邮箱注册或使用邮箱登录需要检查
            if (userConfig.regstatus == 3 || userConfig.emaillogin == 1)
            {
                if (string.IsNullOrEmpty(email))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您的电子邮箱！\"}");
                    return;
                }
                if (model.email != email && bll.ExistsEmail(email))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该电子邮箱已被使用！\"}");
                    return;
                }
            }

            //开始写入数据库
            model.nick_name = nick_name;
            model.sex = sex;
            DateTime _birthday;
            if (DateTime.TryParse(birthday, out _birthday))
            {
                model.birthday = _birthday;
            }
            model.email = email;
            model.mobile = mobile;
            model.telphone = telphone;
            model.qq = qq;
            model.msn = msn;
            model.area = province + "," + city + "," + area;
            model.address = address;

            bll.Update(model);
            context.Response.Write("{\"status\":1, \"msg\":\"账户资料已修改成功！\"}");
            return;
        }
        #endregion

        #region 确认裁剪用户头像=============================
        private void user_avatar_crop(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string fileName = DTRequest.GetFormString("hideFileName");
            int x1 = DTRequest.GetFormInt("hideX1");
            int y1 = DTRequest.GetFormInt("hideY1");
            int w = DTRequest.GetFormInt("hideWidth");
            int h = DTRequest.GetFormInt("hideHeight");
            //检查是否图片

            //检查参数
            if (!Utils.FileExists(fileName) || w == 0 || h == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请先上传一张图片！\"}");
                return;
            }
            //取得保存的新文件名
            UpLoad upFiles = new UpLoad();
            bool result = upFiles.cropSaveAs(fileName, fileName, 180, 180, w, h, x1, y1);
            if (!result)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"图片裁剪过程中发生意外错误！\"}");
                return;
            }
            //删除原用户头像
            Utils.DeleteFile(model.avatar);
            model.avatar = fileName;
            //修改用户头像
            new BLL.users().UpdateField(model.id, "avatar='" + model.avatar + "'");
            context.Response.Write("{\"status\": 1, \"msg\": \"头像上传成功！\", \"avatar\": \"" + model.avatar + "\"}");
            return;
        }
        #endregion

        #region 修改登录密码=================================
        private void user_password_edit(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            int user_id = model.id;
            string oldpassword = DTRequest.GetFormString("txtOldPassword");
            string password = DTRequest.GetFormString("txtPassword");
            //检查输入的旧密码
            if (string.IsNullOrEmpty(oldpassword))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入您的旧登录密码！\"}");
                return;
            }
            //检查输入的新密码
            if (string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入您的新登录密码！\"}");
                return;
            }
            //旧密码是否正确
            if (model.password != DESEncrypt.Encrypt(oldpassword, model.salt))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您输入的旧密码不正确！\"}");
                return;
            }
            //执行修改操作
            model.password = DESEncrypt.Encrypt(password, model.salt);
            new BLL.users().Update(model);
            context.Response.Write("{\"status\":1, \"msg\":\"您的密码已修改成功，请记住新密码！\"}");
            return;
        }
        #endregion

        #region 用户取回密码=================================
        private void user_getpassword(HttpContext context)
        {
            string site = DTRequest.GetQueryString("site");
            string code = DTRequest.GetFormString("txtCode");
            string type = DTRequest.GetFormString("txtType");
            string username = DTRequest.GetFormString("txtUserName").Trim();
            //检查站点目录
            if (string.IsNullOrEmpty(site))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，网站传输参数有误！\"}");
                return;
            }
            //检查用户名
            if (string.IsNullOrEmpty(username))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户名不可为空！\"}");
                return;
            }
            //检查取回密码类型
            if (string.IsNullOrEmpty(type))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请选择取回密码类型！\"}");
                return;
            }
            //校检验证码
            string result = verify_code(context, code);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            //检查用户信息
            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(username);
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您输入的用户名不存在！\"}");
                return;
            }
            //发送取回密码的短信或邮件
            if (type.ToLower() == "mobile") //使用手机取回密码
            {
                #region 发送短信==================
                if (string.IsNullOrEmpty(model.mobile))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"您尚未绑定手机号码，无法取回密码！\"}");
                    return;
                }
                Model.sms_template smsModel = new BLL.sms_template().GetModel("usercode"); //取得短信内容
                if (smsModel == null)
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"发送失败，短信模板不存在，请联系管理员！\"}");
                }
                string strcode = Utils.Number(4); //随机验证码
                //检查是否重复提交
                BLL.user_code codeBll = new BLL.user_code();
                Model.user_code codeModel;
                codeModel = codeBll.GetModel(username, DTEnums.CodeEnum.RegVerify.ToString(), "d");
                if (codeModel == null)
                {
                    codeModel = new Model.user_code();
                    //写入数据库
                    codeModel.user_id = model.id;
                    codeModel.user_name = model.user_name;
                    codeModel.type = DTEnums.CodeEnum.Password.ToString();
                    codeModel.str_code = strcode;
                    codeModel.eff_time = DateTime.Now.AddMinutes(userConfig.regsmsexpired);
                    codeModel.add_time = DateTime.Now;
                    codeBll.Add(codeModel);
                }
                //替换标签
                string msgContent = smsModel.content;
                msgContent = msgContent.Replace("{webname}", siteConfig.webname);
                msgContent = msgContent.Replace("{weburl}", siteConfig.weburl);
                msgContent = msgContent.Replace("{webtel}", siteConfig.webtel);
                msgContent = msgContent.Replace("{code}", codeModel.str_code);
                msgContent = msgContent.Replace("{valid}", userConfig.regsmsexpired.ToString());
                //发送短信
                string tipMsg = string.Empty;
                bool result1 = new BLL.sms_message().Send(model.mobile, msgContent, 1, out tipMsg);
                if (!result1)
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"发送失败，" + tipMsg + "\"}");
                    return;
                }
                context.Response.Write("{\"status\":1, \"msg\":\"手机验证码发送成功！\", \"url\":\""
                    + new BasePage().getlink(site, new BasePage().linkurl("repassword", "?action=mobile&username=" + Utils.UrlEncode(model.user_name))) + "\"}");
                return;
                #endregion
            }
            else if (type.ToLower() == "email") //使用邮箱取回密码
            {
                #region 发送邮件==================
                if (string.IsNullOrEmpty(model.email))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"您尚未绑定邮箱，无法取回密码！\"}");
                    return;
                }
                //生成随机码
                string strcode = Utils.GetCheckCode(20);
                //获得邮件内容
                Model.mail_template mailModel = new BLL.mail_template().GetModel("getpassword");
                if (mailModel == null)
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"邮件发送失败，邮件模板内容不存在！\"}");
                    return;
                }
                //检查是否重复提交
                BLL.user_code codeBll = new BLL.user_code();
                Model.user_code codeModel;
                codeModel = codeBll.GetModel(username, DTEnums.CodeEnum.RegVerify.ToString(), "d");
                if (codeModel == null)
                {
                    codeModel = new Model.user_code();
                    //写入数据库
                    codeModel.user_id = model.id;
                    codeModel.user_name = model.user_name;
                    codeModel.type = DTEnums.CodeEnum.Password.ToString();
                    codeModel.str_code = strcode;
                    codeModel.eff_time = DateTime.Now.AddDays(userConfig.regemailexpired);
                    codeModel.add_time = DateTime.Now;
                    codeBll.Add(codeModel);
                }
                //替换模板内容
                string titletxt = mailModel.maill_title;
                string bodytxt = mailModel.content;
                titletxt = titletxt.Replace("{webname}", siteConfig.webname);
                titletxt = titletxt.Replace("{username}", model.user_name);
                bodytxt = bodytxt.Replace("{webname}", siteConfig.webname);
                bodytxt = bodytxt.Replace("{weburl}", siteConfig.weburl);
                bodytxt = bodytxt.Replace("{webtel}", siteConfig.webtel);
                bodytxt = bodytxt.Replace("{valid}", userConfig.regemailexpired.ToString());
                bodytxt = bodytxt.Replace("{username}", model.user_name);
                bodytxt = bodytxt.Replace("{linkurl}", "http://" + HttpContext.Current.Request.Url.Authority.ToLower()
                    + new BasePage().getlink(site, new BasePage().linkurl("repassword", "?action=email&code=" + codeModel.str_code)));
                //发送邮件
                try
                {
                    DTMail.sendMail(siteConfig.emailsmtp,
                        siteConfig.emailssl,
                        siteConfig.emailusername,
                        DESEncrypt.Decrypt(siteConfig.emailpassword),
                        siteConfig.emailnickname,
                        siteConfig.emailfrom,
                        model.email,
                        titletxt, bodytxt, siteConfig.emailport);
                }
                catch
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"邮件发送失败，请联系本站管理员！\"}");
                    return;
                }
                context.Response.Write("{\"status\":1, \"msg\":\"邮件发送成功，请登录邮箱查看邮件！\"}");
                return;
                #endregion
            }
            context.Response.Write("{\"status\":0, \"msg\":\"发生未知错误，请检查参数是否正确！\"}");
            return;
        }
        #endregion

        #region 用户重设密码=================================
        private void user_repassword(HttpContext context)
        {
            string strcode = DTRequest.GetFormString("hideCode"); //取回密码字符串
            string password = DTRequest.GetFormString("txtPassword"); //重设后的密码

            //检查验证字符串
            if (string.IsNullOrEmpty(strcode))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，校检码字符串不能为空！\"}");
                return;
            }
            //检查输入的新密码
            if (string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您的新密码！\"}");
                return;
            }

            BLL.user_code codeBll = new BLL.user_code();
            Model.user_code codeModel = codeBll.GetModel(strcode);
            if (codeModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，校检码不存在或已过期！\"}");
                return;
            }
            //验证用户是否存在
            BLL.users userBll = new BLL.users();
            if (!userBll.Exists(codeModel.user_id))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，该用户不存在或已被删除！\"}");
                return;
            }
            Model.users userModel = userBll.GetModel(codeModel.user_id);
            //执行修改操作
            userModel.password = DESEncrypt.Encrypt(password, userModel.salt);
            userBll.Update(userModel);
            //更改验证字符串状态
            codeModel.count = 1;
            codeModel.status = 1;
            codeBll.Update(codeModel);
            context.Response.Write("{\"status\":1, \"msg\":\"修改密码成功，请记住新密码！\"}");
            return;
        }
        #endregion

        #region 申请邀请码===================================
        private void user_invite_code(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            //检查是否开启邀请注册
            if (userConfig.regstatus != 4)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，系统不允许通过邀请注册！\"}");
                return;
            }
            BLL.user_code codeBll = new BLL.user_code();
            //检查申请是否超过限制
            if (userConfig.invitecodenum > 0)
            {
                int result = codeBll.GetCount("user_name='" + model.user_name + "' and type='" + DTEnums.CodeEnum.Register.ToString() + "' and datediff(d,add_time,getdate())=0");
                if (result >= userConfig.invitecodenum)
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，您申请邀请码的数量已超过每天限制！\"}");
                    return;
                }
            }
            //删除过期的邀请码
            codeBll.Delete("type='" + DTEnums.CodeEnum.Register.ToString() + "' and status=1 or datediff(d,eff_time,getdate())>0");
            //随机取得邀请码
            string str_code = Utils.GetCheckCode(8);
            Model.user_code codeModel = new Model.user_code();
            codeModel.user_id = model.id;
            codeModel.user_name = model.user_name;
            codeModel.type = DTEnums.CodeEnum.Register.ToString();
            codeModel.str_code = str_code;
            codeModel.user_ip = DTRequest.GetIP();
            if (userConfig.invitecodeexpired > 0)
            {
                codeModel.eff_time = DateTime.Now.AddDays(userConfig.invitecodeexpired);
            }
            else
            {
                codeModel.eff_time = DateTime.Now.AddDays(1);
            }
            codeBll.Add(codeModel);
            context.Response.Write("{\"status\":1, \"msg\":\"恭喜您，申请邀请码已成功！\"}");
            return;
        }
        #endregion

        #region 用户兑换积分=================================
        private void user_point_convert(HttpContext context)
        {
            //检查系统是否启用兑换积分功能
            if (userConfig.pointcashrate == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，网站未开启兑换积分功能！\"}");
                return;
            }
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            int amout = DTRequest.GetFormInt("txtAmount");
            string password = DTRequest.GetFormString("txtPassword");
            if (model.amount < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您账户上的余额不足！\"}");
                return;
            }
            if (amout < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，最小兑换金额为1元！\"}");
                return;
            }
            if (amout > model.amount)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您兑换的金额大于账户余额！\"}");
                return;
            }
            if (password == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您账户的密码！\"}");
                return;
            }
            //验证密码
            if (DESEncrypt.Encrypt(password, model.salt) != model.password)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您输入的密码不正确！\"}");
                return;
            }
            //计算兑换后的积分值
            int convertPoint = (int)(Convert.ToDecimal(amout) * userConfig.pointcashrate);
            //扣除金额
            int amountNewId = new BLL.user_amount_log().Add(model.id, model.user_name, amout * -1, "用户兑换积分");
            //增加积分
            if (amountNewId < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"转换过程中发生错误，请重新提交！\"}");
                return;
            }
            int pointNewId = new BLL.user_point_log().Add(model.id, model.user_name, convertPoint, "用户兑换积分", true);
            if (pointNewId < 1)
            {
                //返还金额
                new BLL.user_amount_log().Add(model.id, model.user_name, amout, "用户兑换积分失败，返还金额");
                context.Response.Write("{\"status\":0, \"msg\":\"转换过程中发生错误，请重新提交！\"}");
                return;
            }

            context.Response.Write("{\"status\":1, \"msg\":\"恭喜您，积分兑换成功！\"}");
            return;
        }
        #endregion

        #region 用户在线充值=================================
        private void user_amount_recharge(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string sitepath = DTRequest.GetQueryString("site"); //站点目录
            decimal amount = DTRequest.GetFormDecimal("order_amount", 0);
            int payment_id = DTRequest.GetFormInt("payment_id");
            //检查站点目录
            if (string.IsNullOrEmpty(sitepath))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误提示：站点传输参数不正确！\"}");
                return;
            }
            if (amount == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入正确的充值金额！\"}");
                return;
            }
            if (payment_id == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请选择正确的支付方式！\"}");
                return;
            }
            if (!new BLL.payment().Exists(payment_id))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，支付方式不存在或已删除！\"}");
                return;
            }
            //生成订单号
            string order_no = "R" + Utils.GetOrderNumber(); //订单号R开头为充值订单

            //Model.user_recharge recharge = new Model.user_recharge()
            //{
            //    amount = amount,
            //    complete_time = DateTime.Now,
            //    user_id = model.id,
            //    user_name = model.user_name,
            //    recharge_no = order_no,
            //    status = 1,
            //    payment_id = payment_id,
            //};

            new BLL.user_recharge().Add(model.id, model.user_name, order_no, payment_id, amount);
            //new BLL.user_recharge().Add(recharge);


            //保存成功后返回订单号
            context.Response.Write("{\"status\":1, \"msg\":\"订单保存成功！\", \"url\":\""
                + new Web.UI.BasePage().getlink(sitepath, new Web.UI.BasePage().linkurl("payment", "?action=confirm&order_no=" + order_no)) + "\"}");
            return;

        }
        #endregion

        #region 发布站内短消息===============================
        private void user_message_add(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string code = context.Request.Form["txtCode"];
            string send_save = DTRequest.GetFormString("sendSave");
            string user_name = Utils.ToHtml(DTRequest.GetFormString("txtUserName"));
            string title = Utils.ToHtml(DTRequest.GetFormString("txtTitle"));
            string content = Utils.ToHtml(DTRequest.GetFormString("txtContent"));
            //校检验证码
            string result = verify_code(context, code);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            //检查用户名
            if (string.IsNullOrEmpty(user_name) || !new BLL.users().Exists(user_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，该用户不存在或已删除！\"}");
                return;
            }
            //检查标题
            if (string.IsNullOrEmpty(title))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入短消息标题！\"}");
                return;
            }
            //检查内容
            if (string.IsNullOrEmpty(content))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入短消息内容！\"}");
                return;
            }
            //保存数据
            Model.user_message modelMessage = new Model.user_message();
            modelMessage.type = 2;
            modelMessage.post_user_name = model.user_name;
            modelMessage.accept_user_name = user_name;
            modelMessage.title = title;
            modelMessage.content = Utils.ToHtml(content);
            new BLL.user_message().Add(modelMessage);
            if (send_save == "true") //保存到收件箱
            {
                modelMessage.type = 3;
                new BLL.user_message().Add(modelMessage);
            }
            context.Response.Write("{\"status\":1, \"msg\":\"发布短信息成功！\"}");
            return;
        }
        #endregion

        #region 编辑用户收货地址=============================
        private void user_address_edit(HttpContext context)
        {
            //检查用户是否登录
            Model.users userModel = new BasePage().GetUserInfo();
            Model.user_addr_book model = new Model.user_addr_book();
            BLL.user_addr_book bll = new BLL.user_addr_book();
            if (userModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            int id = DTRequest.GetQueryInt("id", 0);
            if (id > 0)
            {
                if (!bll.Exists(id, userModel.user_name))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，收货地址不存在或已删除！\"}");
                    return;
                }
                model = bll.GetModel(id);
            }
            string code = DTRequest.GetFormString("txtCode");
            string accept_name = DTRequest.GetFormString("txtAcceptName");
            string province = Utils.ToHtml(DTRequest.GetFormString("txtProvince"));
            string city = Utils.ToHtml(DTRequest.GetFormString("txtCity"));
            string area = Utils.ToHtml(DTRequest.GetFormString("txtArea"));
            string address = Utils.ToHtml(context.Request.Form["txtAddress"]);
            string mobile = Utils.ToHtml(DTRequest.GetFormString("txtMobile"));
            string telphone = Utils.ToHtml(DTRequest.GetFormString("txtTelphone"));
            string email = Utils.ToHtml(DTRequest.GetFormString("txtEmail"));
            string post_code = Utils.ToHtml(DTRequest.GetFormString("txtPostCode"));

            //校检验证码
            string result = verify_code(context, code);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            //检查收件人
            if (string.IsNullOrEmpty(accept_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入收件人姓名！\"}");
                return;
            }
            //检查省市区
            if (string.IsNullOrEmpty(province) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(area))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请选择您所在的省市区！\"}");
                return;
            }
            //检查手机
            if (string.IsNullOrEmpty(mobile))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入收件人的手机！\"}");
                return;
            }
            //保存数据
            model.user_id = userModel.id;
            model.user_name = userModel.user_name;
            model.accept_name = accept_name;
            model.area = province + "," + city + "," + area;
            model.address = address;
            model.mobile = mobile;
            model.telphone = telphone;
            model.email = email;
            model.post_code = post_code;
            if (id > 0)
            {
                new BLL.user_addr_book().Update(model);
                context.Response.Write("{\"status\":1, \"msg\":\"修改收货地址成功！\"}");
            }
            else
            {
                new BLL.user_addr_book().Add(model);
                context.Response.Write("{\"status\":1, \"msg\":\"新增收货地址成功！\"}");
            }
            return;
        }
        #endregion

        #region 用户设置默认收货地址=========================
        private void user_address_default(HttpContext context)
        {
            //检查用户是否登录
            Model.users userModel = new BasePage().GetUserInfo();
            if (userModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            int id = DTRequest.GetQueryInt("id", 0);
            BLL.user_addr_book bll = new BLL.user_addr_book();
            if (bll.Exists(id, userModel.user_name))
            {
                bll.SetDefault(id, userModel.user_name);
                context.Response.Write("{\"status\":1, \"msg\":\"默认收货地址设置成功！\"}");
                return;
            }
            context.Response.Write("{\"status\":0, \"msg\":\"对不起，该记录不存在或已删除！\"}");
            return;
        }
        #endregion

        #region 删除用户积分明细=============================
        private void user_point_delete(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string check_id = DTRequest.GetFormString("checkId");
            if (string.IsNullOrEmpty(check_id))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"删除失败，请检查传输参数！\"}");
                return;
            }
            string[] arrId = check_id.Split(',');
            for (int i = 0; i < arrId.Length; i++)
            {
                int id = Utils.StrToInt(arrId[i], 0);
                if (id > 0)
                {
                    new BLL.user_point_log().Delete(id, model.user_name);
                }
            }
            context.Response.Write("{\"status\":1, \"msg\":\"积分明细删除成功！\"}");
            return;
        }
        #endregion

        #region 删除用户收支明细=============================
        private void user_amount_delete(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string check_id = DTRequest.GetFormString("checkId");
            if (string.IsNullOrEmpty(check_id))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"删除失败，请检查传输参数！\"}");
                return;
            }
            string[] arrId = check_id.Split(',');
            for (int i = 0; i < arrId.Length; i++)
            {
                int id = Utils.StrToInt(arrId[i], 0);
                if (id > 0)
                {
                    new BLL.user_amount_log().Delete(id, model.user_name);
                }
            }
            context.Response.Write("{\"status\":1, \"msg\":\"收支明细删除成功！\"}");
            return;
        }
        #endregion

        #region 删除用户充值记录=============================
        private void user_recharge_delete(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string check_id = DTRequest.GetFormString("checkId");
            if (string.IsNullOrEmpty(check_id))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"删除失败，请检查传输参数！\"}");
                return;
            }
            string[] arrId = check_id.Split(',');
            for (int i = 0; i < arrId.Length; i++)
            {
                int id = Utils.StrToInt(arrId[i], 0);
                if (id > 0)
                {
                    new BLL.user_recharge().Delete(id, model.user_name);
                }
            }
            context.Response.Write("{\"status\":1, \"msg\":\"充值记录删除成功！\"}");
            return;
        }
        #endregion

        #region 删除短消息===================================
        private void user_message_delete(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string check_id = DTRequest.GetFormString("checkId");
            if (string.IsNullOrEmpty(check_id))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"删除失败，请检查传输参数！\"}");
                return;
            }
            string[] arrId = check_id.Split(',');
            for (int i = 0; i < arrId.Length; i++)
            {
                int id = Utils.StrToInt(arrId[i], 0);
                if (id > 0)
                {
                    new BLL.user_message().Delete(id, model.user_name);
                }
            }
            context.Response.Write("{\"status\":1, \"msg\":\"删除短消息成功！\"}");
            return;
        }
        #endregion

        #region 删除用户收货地址=============================
        private void user_address_delete(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string check_id = DTRequest.GetFormString("checkId");
            if (string.IsNullOrEmpty(check_id))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"删除失败，请检查传输参数！\"}");
                return;
            }
            string[] arrId = check_id.Split(',');
            for (int i = 0; i < arrId.Length; i++)
            {
                int id = Utils.StrToInt(arrId[i], 0);
                if (id > 0)
                {
                    new BLL.user_addr_book().Delete(id, model.user_name);
                }
            }
            context.Response.Write("{\"status\":1, \"msg\":\"删除收货地址成功！\"}");
            return;
        }
        #endregion

        #region 获取对应的商品信息===========================
        private void get_article_goods_info(HttpContext context)
        {
            int article_id = DTRequest.GetInt("article_id", 0);
            string spec_ids = DTRequest.GetString("ids");
            if (article_id == 0)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，传输参数不正确！\"}");
                return;
            }
            if (string.IsNullOrEmpty(spec_ids))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，传输参数不正确！\"}");
                return;
            }
            //查询商品信息
            Model.article_goods goodsModel = new BLL.article_goods().GetModel(article_id, spec_ids);
            if (goodsModel == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，暂无查到商品信息！\"}");
                return;
            }
            //查询是否登录，有则查询会员价格
            Model.users userModel = new Web.UI.BasePage().GetUserInfo();
            if (userModel != null)
            {
                //查询会员组价格
                Model.user_group_price userPriceModel = new BLL.user_group_price().GetModel(goodsModel.id, userModel.group_id);
                if (userPriceModel != null)
                {
                    goodsModel.sell_price = userPriceModel.price;
                }
                else
                {
                    //查询会员组折扣
                    Model.user_groups groupModel = new BLL.user_groups().GetModel(userModel.group_id);
                    if (groupModel != null)
                    {
                        goodsModel.sell_price = goodsModel.sell_price * groupModel.discount / 100;
                    }
                }
            }
            //以JSON格式输出商品信息
            context.Response.Write("{\"status\": \"1\", \"id\": \"" + goodsModel.id + "\", \"article_id\": \"" + goodsModel.article_id + "\", \"goods_id\": \"" + goodsModel.id
                + "\", \"goods_no\": \"" + goodsModel.goods_no + "\", \"spec_ids\": \"" + goodsModel.spec_ids + "\", \"spec_text\": \"" + goodsModel.spec_text
                + "\", \"stock_quantity\": \"" + goodsModel.stock_quantity + "\", \"market_price\": \"" + goodsModel.market_price + "\", \"sell_price\": \"" + goodsModel.sell_price + "\"}");
        }
        #endregion

        #region 购物车加入商品===============================
        private void cart_goods_add(HttpContext context)
        {
            int article_id = DTRequest.GetFormInt("article_id", 0);
            int goods_id = DTRequest.GetFormInt("goods_id", 0);
            int quantity = DTRequest.GetFormInt("quantity", 1);
            if (article_id == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
                return;
            }
            //检查商品是否正确
            if (goods_id > 0 && !new BLL.article_goods().Exists(article_id, goods_id))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
                return;
            }
            //查找会员组
            int group_id = 0;
            Model.users groupModel = new Web.UI.BasePage().GetUserInfo();
            if (groupModel != null)
            {
                group_id = groupModel.group_id;
            }
            //统计购物车
            Web.UI.ShopCart.Add(article_id, goods_id, quantity);
            Model.cart_total cartModel = Web.UI.ShopCart.GetTotal(group_id);
            context.Response.Write("{\"status\":1, \"msg\":\"商品已成功添加到购物车！\", \"quantity\":" + cartModel.total_quantity + ", \"amount\":" + cartModel.real_amount + "}");
            return;
        }
        #endregion

        #region 加入结账商品=================================
        private void cart_goods_buy(HttpContext context)
        {
            string jsonData = DTRequest.GetFormString("jsondata");
            if (string.IsNullOrEmpty(jsonData))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"商品传输参数不正确！\"}");
                return;
            }
            List<Model.cart_keys> ls = (List<Model.cart_keys>)JsonHelper.JSONToObject<List<Model.cart_keys>>(jsonData);
            if (ls != null)
            {
                Utils.WriteCookie(DTKeys.COOKIE_SHOPPING_BUY, jsonData); //暂放在清单
                context.Response.Write("{\"status\":1, \"msg\":\"商品已成功加入购物清单！\"}");
                return;
            }
            context.Response.Write("{\"status\":0, \"msg\":\"商品数据传输不正确！\"}");
            return;
        }
        #endregion

        #region 修改购物车商品===============================
        private void cart_goods_update(HttpContext context)
        {
            int article_id = DTRequest.GetFormInt("article_id", 0);
            int goods_id = DTRequest.GetFormInt("goods_id", 0);
            int quantity = DTRequest.GetFormInt("quantity", 0);
            if (article_id == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
                return;
            }
            if (quantity == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"购买数量不能小于1！\"}");
                return;
            }
            Model.cart_keys model = Web.UI.ShopCart.Update(article_id, goods_id, quantity);
            if (model != null)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"商品数量修改成功！\", \"article_id\":" + model.article_id + ", \"goods_id\":" + model.goods_id + ", \"quantity\":" + model.quantity + "}");
                return;
            }
            context.Response.Write("{\"status\":0, \"msg\":\"更新失败，请检查操作是否有误！\"}");
            return;
        }
        #endregion

        #region 删除购物车商品===============================
        private void cart_goods_delete(HttpContext context)
        {
            int clear = DTRequest.GetFormInt("clear", 0);
            int article_id = DTRequest.GetFormInt("article_id", 0);
            int goods_id = DTRequest.GetFormInt("goods_id", 0);
            if (clear == 1)
            {
                Web.UI.ShopCart.Clear(); //清空购物车
                context.Response.Write("{\"status\":1, \"msg\":\"购物车清空成功！\"}");
                return;
            }
            if (article_id == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
                return;
            }
            Web.UI.ShopCart.Clear(article_id, goods_id);
            context.Response.Write("{\"status\":1, \"msg\":\"商品移除成功！\"}");
            return;
        }
        #endregion

        #region 保存购物订单=================================
        private void order_save(HttpContext context)
        {
            //获取传参信息===================================
            string hideGoodsJson = Utils.GetCookie(DTKeys.COOKIE_SHOPPING_BUY); //获取商品JSON数据
            string sitepath = DTRequest.GetQueryString("site"); //站点目录
            int book_id = DTRequest.GetFormInt("book_id", 1);
            int payment_id = DTRequest.GetFormInt("payment_id");
            int express_id = DTRequest.GetFormInt("express_id");
            int is_invoice = DTRequest.GetFormInt("is_invoice", 0);
            string accept_name = Utils.ToHtml(DTRequest.GetFormString("accept_name"));
            string province = Utils.ToHtml(DTRequest.GetFormString("province"));
            string city = Utils.ToHtml(DTRequest.GetFormString("city"));
            string area = Utils.ToHtml(DTRequest.GetFormString("area"));
            string address = Utils.ToHtml(DTRequest.GetFormString("address"));
            string telphone = Utils.ToHtml(DTRequest.GetFormString("telphone"));
            string mobile = Utils.ToHtml(DTRequest.GetFormString("mobile"));
            string email = Utils.ToHtml(DTRequest.GetFormString("email"));
            string post_code = Utils.ToHtml(DTRequest.GetFormString("post_code"));
            string message = Utils.ToHtml(DTRequest.GetFormString("message"));
            string invoice_title = Utils.ToHtml(DTRequest.GetFormString("invoice_title"));
            Model.orderconfig orderConfig = new BLL.orderconfig().loadConfig(); //获取订单配置

            //检查传参信息===================================
            if (string.IsNullOrEmpty(hideGoodsJson))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，无法获取商品信息！\"}");
                return;
            }
            //检查站点目录
            if (string.IsNullOrEmpty(sitepath))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误提示：站点传输参数不正确！\"}");
                return;
            }
            if (express_id == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请选择配送方式！\"}");
                return;
            }
            if (payment_id == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请选择支付方式！\"}");
                return;
            }
            Model.express expModel = new BLL.express().GetModel(express_id);
            if (expModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，配送方式不存在或已删除！\"}");
                return;
            }
            //检查支付方式
            Model.payment payModel = new BLL.payment().GetModel(payment_id);
            if (payModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，支付方式不存在或已删除！\"}");
                return;
            }
            //检查收货人
            if (string.IsNullOrEmpty(accept_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入收货人姓名！\"}");
                return;
            }
            //检查手机和电话
            if (string.IsNullOrEmpty(telphone) && string.IsNullOrEmpty(mobile))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入收货人联系电话或手机！\"}");
                return;
            }
            //检查地区
            if (string.IsNullOrEmpty(province) && string.IsNullOrEmpty(city))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请选择您所在的省市区！\"}");
                return;
            }
            //检查地址
            if (string.IsNullOrEmpty(address))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入详细的收货地址！\"}");
                return;
            }
            //如果开启匿名购物则不检查会员是否登录
            int user_id = 0;
            int user_group_id = 0;
            string user_name = string.Empty;
            //检查用户是否登录
            Model.users userModel = new Web.UI.BasePage().GetUserInfo();
            if (userModel != null)
            {
                user_id = userModel.id;
                user_group_id = userModel.group_id;
                user_name = userModel.user_name;
                //检查是否需要添加会员地址
                if (book_id == 0)
                {
                    Model.user_addr_book addrModel = new Model.user_addr_book();
                    addrModel.user_id = userModel.id;
                    addrModel.user_name = userModel.user_name;
                    addrModel.accept_name = accept_name;
                    addrModel.area = province + "," + city + "," + area;
                    addrModel.address = address;
                    addrModel.mobile = mobile;
                    addrModel.telphone = telphone;
                    addrModel.email = email;
                    addrModel.post_code = post_code;
                    new BLL.user_addr_book().Add(addrModel);
                }
            }
            if (orderConfig.anonymous == 0 && userModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            //获取商品信息==================================
            List<Model.cart_keys> iList = (List<Model.cart_keys>)JsonHelper.JSONToObject<List<Model.cart_keys>>(hideGoodsJson);
            List<Model.cart_items> goodsList = ShopCart.ToList(iList, user_group_id); //商品列表
            Model.cart_total goodsTotal = ShopCart.GetTotal(goodsList); //商品统计
            if (goodsList == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，商品为空，无法结算！\"}");
                return;
            }
            //保存订单=======================================
            Model.orders model = new Model.orders();
            model.order_no = "B" + Utils.GetOrderNumber(); //订单号B开头为商品订单
            model.user_id = user_id;
            model.user_name = user_name;
            model.payment_id = payment_id;
            model.express_id = express_id;
            model.accept_name = accept_name;
            model.area = province + "," + city + "," + area; //省市区以逗号相隔
            model.address = address;
            model.telphone = telphone;
            model.mobile = mobile;
            model.message = message;
            model.email = email;
            model.post_code = post_code;
            model.is_invoice = is_invoice;
            model.payable_amount = goodsTotal.payable_amount;
            model.real_amount = goodsTotal.real_amount;
            model.express_status = 1;
            model.express_fee = expModel.express_fee; //物流费用
            //是否先款后货
            if (payModel.type == 1)
            {
                model.payment_status = 1; //标记未付款
                if (payModel.poundage_type == 1 && payModel.poundage_amount > 0) //百分比
                {
                    model.payment_fee = model.real_amount * payModel.poundage_amount / 100;
                }
                else //固定金额
                {
                    model.payment_fee = payModel.poundage_amount;
                }
            }
            //是否开具发票
            if (model.is_invoice == 1)
            {
                model.invoice_title = invoice_title;
                if (orderConfig.taxtype == 1 && orderConfig.taxamount > 0) //百分比
                {
                    model.invoice_taxes = model.real_amount * orderConfig.taxamount / 100;
                }
                else //固定金额
                {
                    model.invoice_taxes = orderConfig.taxamount;
                }
            }
            //订单总金额=实付商品金额+运费+支付手续费+税金
            model.order_amount = model.real_amount + model.express_fee + model.payment_fee + model.invoice_taxes;
            //购物积分,可为负数
            model.point = goodsTotal.total_point;
            model.add_time = DateTime.Now;
            //商品详细列表
            List<Model.order_goods> gls = new List<Model.order_goods>();
            foreach (Model.cart_items item in goodsList)
            {
                gls.Add(new Model.order_goods
                {
                    article_id = item.article_id,
                    goods_id = item.goods_id,
                    goods_no = item.goods_no,
                    goods_title = item.title,
                    img_url = item.img_url,
                    spec_text = item.spec_text,
                    goods_price = item.sell_price,
                    real_price = item.user_price,
                    quantity = item.quantity,
                    point = item.point
                });
            }
            model.order_goods = gls;
            int result = new BLL.orders().Add(model);
            if (result < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"订单保存发生错误，请联系管理员！\"}");
                return;
            }
            //扣除积分
            if (model.point < 0)
            {
                new BLL.user_point_log().Add(model.user_id, model.user_name, model.point, "积分换购，订单号：" + model.order_no, false);
            }
            //删除购物车对应的商品
            Web.UI.ShopCart.Clear(iList);
            //清空结账清单
            Utils.WriteCookie(DTKeys.COOKIE_SHOPPING_BUY, "");
            //提交成功，返回URL
            context.Response.Write("{\"status\":1, \"url\":\""
                + new Web.UI.BasePage().getlink(sitepath, new Web.UI.BasePage().linkurl("payment", "?action=confirm&order_no=" + model.order_no)) + "\", \"msg\":\"恭喜您，订单已成功提交！\"}");
            return;
        }
        #endregion

        #region 用户取消订单=================================
        private void order_cancel(HttpContext context)
        {
            //检查用户是否登录
            Model.users userModel = new BasePage().GetUserInfo();
            if (userModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            //检查订单是否存在
            string order_no = DTRequest.GetQueryString("order_no");
            Model.orders orderModel = new BLL.orders().GetModel(order_no);
            if (order_no == "" || orderModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，订单号不存在或已删除！\"}");
                return;
            }
            //检查是否自己的订单
            if (userModel.id != orderModel.user_id)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，不能取消别人的订单状态！\"}");
                return;
            }
            //检查订单状态
            if (orderModel.status > 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，订单不是生成状态，不能取消！\"}");
                return;
            }
            bool result = new BLL.orders().UpdateField(order_no, "status=4");
            if (!result)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，操作过程中发生不可遇知的错误！\"}");
                return;
            }
            //如果是积分换购则返还积分
            if (orderModel.point < 0)
            {
                new BLL.user_point_log().Add(orderModel.user_id, orderModel.user_name, -1 * orderModel.point, "取消订单，返还换购积分，订单号：" + orderModel.order_no, false);
            }
            context.Response.Write("{\"status\":1, \"msg\":\"取消订单成功！\"}");
            return;
        }
        #endregion

        #region 统计及输出阅读次数===========================
        private void view_article_click(HttpContext context)
        {
            int article_id = DTRequest.GetInt("id", 0);
            int click = DTRequest.GetInt("click", 0);
            int hide = DTRequest.GetInt("hide", 0);
            int count = 0;
            if (article_id > 0)
            {
                BLL.article bll = new BLL.article();
                count = bll.GetClick(article_id);
                if (click > 0)
                {
                    bll.UpdateField(article_id, "click=click+1");
                }
            }
            if (hide == 0)
            {
                context.Response.Write("document.write('" + count + "');");
            }
        }
        #endregion

        #region 输出评论总数=================================
        private void view_comment_count(HttpContext context)
        {
            int article_id = DTRequest.GetInt("id", 0);
            int count = 0;
            if (article_id > 0)
            {
                count = new BLL.article_comment().GetCount("is_lock=0 and article_id=" + article_id);
            }
            context.Response.Write("document.write('" + count + "');");
        }
        #endregion

        #region 输出附件下载总数=============================
        private void view_attach_count(HttpContext context)
        {
            int id = DTRequest.GetInt("id", 0);
            string view = DTRequest.GetString("view");
            int count = 0;
            if (id > 0)
            {
                if (view.ToLower() == "count")
                {
                    count = new BLL.article_attach().GetCountNum(id);
                }
                else
                {
                    count = new BLL.article_attach().GetDownNum(id);
                }
            }
            context.Response.Write("document.write('" + count + "');");
        }
        #endregion

        #region 输出购物车总数===============================
        private void view_cart_count(HttpContext context)
        {
            context.Response.Write("document.write('" + Web.UI.ShopCart.GetQuantityCount() + "');");
        }
        #endregion

        #region 通用外理方法=================================

        #region 校检网站验证码===============================
        private string verify_code(HttpContext context, string strcode)
        {
            if (string.IsNullOrEmpty(strcode))
            {
                return "{\"status\":0, \"msg\":\"对不起，请输入验证码1！\"}";
            }
            //if (context.Session[DTKeys.SESSION_CODE] == null)
            //{
            //    return "{\"status\":0, \"msg\":\"对不起，验证码超时或已过期1！\"}";
            //}
            //if (strcode.ToLower() != (context.Session[DTKeys.SESSION_CODE].ToString()).ToLower())
            //{
            //    return "{\"status\":0, \"msg\":\"您输入的验证码与系统的不一致1！\"}";
            //}
            context.Session[DTKeys.SESSION_CODE] = null;
            return "success";
        }
        #endregion

        #region 校检手机验证码===============================
        private string verify_sms_code(HttpContext context, string strcode)
        {
            if (string.IsNullOrEmpty(strcode))
            {
                return "{\"status\":0, \"msg\":\"对不起，请输入验证码！\"}";
            }
            //if (context.Session[DTKeys.SESSION_SMS_CODE] == null)
            //{
            //    return "{\"status\":0, \"msg\":\"对不起，验证码超时或已过期！\"}";
            //}
            //if (strcode.ToLower() != (context.Session[DTKeys.SESSION_SMS_CODE].ToString()).ToLower())
            //{
            //    return "{\"status\":0, \"msg\":\"您输入的验证码与系统的不一致！\"}";
            //}
            context.Session[DTKeys.SESSION_SMS_CODE] = null;
            return "success";
        }
        #endregion

        #region 邀请注册处理方法=============================
        private string verify_invite_reg(string user_name, string invite_code)
        {

            if (string.IsNullOrEmpty(invite_code))
            {
                return "{\"status\":0, \"msg\":\"邀请码不能为空！\"}";
            }
            BLL.user_code codeBll = new BLL.user_code();
            Model.user_code codeModel = codeBll.GetModel(invite_code);
            if (codeModel == null)
            {
                return "{\"status\":0, \"msg\":\"邀请码不正确或已过期！\"}";
            }
            if (userConfig.invitecodecount > 0)
            {
                if (codeModel.count >= userConfig.invitecodecount)
                {
                    codeModel.status = 1;
                    return "{\"status\":0, \"msg\":\"该邀请码已经被使用！\"}";
                }
            }
            //检查是否给邀请人增加积分
            if (userConfig.pointinvitenum > 0)
            {
                new BLL.user_point_log().Add(codeModel.user_id, codeModel.user_name, userConfig.pointinvitenum, "邀请用户【" + user_name + "】注册获得积分", true);
            }
            //更改邀请码状态
            codeModel.count += 1;
            codeBll.Update(codeModel);
            return "success";
        }
        #endregion

        #region 发送手机短信验证码===========================
        private string send_verify_sms_code(HttpContext context, string mobile)
        {
            context.Session.Timeout = 45;
            
            //检查手机
            if (string.IsNullOrEmpty(mobile))
            {
                return "{\"status\":0, \"msg\":\"发送失败，请填写手机号码！\"}";
            }
            //检查是否过期
            string cookie = Utils.GetCookie(DTKeys.COOKIE_USER_MOBILE);
            if (cookie == mobile)
            {
                return "{\"status\":1, \"time\":\"" + userConfig.regsmsexpired + "\", \"msg\":\"已发送短信，" + userConfig.regsmsexpired + "分钟后再试！\"}";
            }
            Model.sms_template smsModel = new BLL.sms_template().GetModel("usercode"); //取得短信内容
            if (smsModel == null)
            {
                return "{\"status\":0, \"msg\":\"发送失败，短信模板不存在，请联系管理员！\"}";
            }
            string strcode = Utils.Number(4); //随机验证码
            //替换标签
            string msgContent = smsModel.content;
            msgContent = msgContent.Replace("{webname}", siteConfig.webname);
            msgContent = msgContent.Replace("{weburl}", siteConfig.weburl);
            msgContent = msgContent.Replace("{webtel}", siteConfig.webtel);
            msgContent = msgContent.Replace("{code}", strcode);
            msgContent = msgContent.Replace("{valid}", userConfig.regsmsexpired.ToString());
            //发送短信
            string tipMsg = string.Empty;
            bool result = new BLL.sms_message().Send(mobile, msgContent, 1, out tipMsg);
            if (!result)
            {
                return "{\"status\":0, \"msg\":\"发送失败，" + tipMsg + "\"}";
            }
            //写入SESSION，保存验证码
            context.Session[DTKeys.SESSION_SMS_CODE] = strcode;
            Utils.WriteCookie(DTKeys.COOKIE_USER_MOBILE, mobile, userConfig.regsmsexpired); //规定时间内无重复发送
            return "success";
        }
        #endregion

        #region Email验证发送邮件============================
        private string send_verify_email(string site, Model.users userModel)
        {
            //生成随机码
            string strcode = Utils.GetCheckCode(20);
            BLL.user_code codeBll = new BLL.user_code();
            Model.user_code codeModel;
            //检查是否重复提交
            codeModel = codeBll.GetModel(userModel.user_name, DTEnums.CodeEnum.RegVerify.ToString(), "d");
            if (codeModel == null)
            {
                codeModel = new Model.user_code();
                codeModel.user_id = userModel.id;
                codeModel.user_name = userModel.user_name;
                codeModel.type = DTEnums.CodeEnum.RegVerify.ToString();
                codeModel.str_code = strcode;
                codeModel.eff_time = DateTime.Now.AddDays(userConfig.regemailexpired);
                codeModel.add_time = DateTime.Now;
                new BLL.user_code().Add(codeModel);
            }
            //获得邮件内容
            Model.mail_template mailModel = new BLL.mail_template().GetModel("regverify");
            if (mailModel == null)
            {
                return "{\"status\":0, \"msg\":\"邮件发送失败，邮件模板内容不存在！\"}";
            }
            //替换模板内容
            string titletxt = mailModel.maill_title;
            string bodytxt = mailModel.content;
            titletxt = titletxt.Replace("{webname}", siteConfig.webname);
            titletxt = titletxt.Replace("{username}", userModel.user_name);
            bodytxt = bodytxt.Replace("{webname}", siteConfig.webname);
            bodytxt = bodytxt.Replace("{webtel}", siteConfig.webtel);
            bodytxt = bodytxt.Replace("{weburl}", siteConfig.weburl);
            bodytxt = bodytxt.Replace("{username}", userModel.user_name);
            bodytxt = bodytxt.Replace("{valid}", userConfig.regemailexpired.ToString());
            bodytxt = bodytxt.Replace("{linkurl}", "http://" + HttpContext.Current.Request.Url.Authority.ToLower()
                + new Web.UI.BasePage().getlink(site, new Web.UI.BasePage().linkurl("register", "?action=checkmail&code=" + codeModel.str_code)));
            //发送邮件
            try
            {
                DTMail.sendMail(siteConfig.emailsmtp, siteConfig.emailssl,
                    siteConfig.emailusername,
                    DESEncrypt.Decrypt(siteConfig.emailpassword),
                    siteConfig.emailnickname,
                    siteConfig.emailfrom,
                    userModel.email,
                    titletxt, bodytxt, siteConfig.emailport);
            }
            catch
            {
                return "{\"status\":0, \"msg\":\"邮件发送失败，请联系本站管理员！\"}";
            }
            return "success";
        }
        #endregion

        #endregion END通用方法===============================

        #region 退货===========================================
        public void order_orders_th(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }

            string order_no = DTRequest.GetString("order_no");//订单号
            if (order_no == "" && order_no == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，订单号为空！\"}");
                return;
            }
            else
            {
                BLL.orders bll = new BLL.orders();
                if (!bll.Exists(order_no))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，订单号不存在！\"}");
                    return;
                }
                else
                {
                    Model.orders modelNew = bll.GetModel(order_no);
                    modelNew.status = 4;
                    if (bll.Update(modelNew))
                    {
                        string subject = "退款返回余额，订单号：" + order_no;
                        int result = new BLL.user_amount_log().Add(model.id, model.user_name, 1 * modelNew.payable_amount, subject);
                        if (modelNew.point != 0)
                        {
                            new BLL.user_point_log().Add(model.id, model.user_name, -1 * modelNew.point, "退款返回积分，订单号：" + order_no, false);
                        }
                        if (result > 0)
                        {
                            context.Response.Write("{\"status\":1, \"msg\":\"退货成功！\"}");
                        }
                        else
                        {
                            context.Response.Write("{\"status\":0, \"msg\":\"退款失败！\"}");
                            return;
                        }
                    }
                    else
                    {
                        context.Response.Write("{\"status\":0, \"msg\":\"退货失败！\"}");
                        return;
                    }

                }
            }
        }
        #endregion

        #region 升级===========================================
        public void order_orders_sj(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }

            string order_no = DTRequest.GetFormString("order_no");//订单号
            int quiz = DTRequest.GetFormInt("quiz", 0);//竞猜
            if (quiz <= 0)
            {
                string type = DTRequest.GetFormString("type");
                if (type == "1")
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"请选择奇偶！\"}");
                }
                else if (type == "2")
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"请选择大中小！\"}");
                }
                else
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"请选择有牛或没有牛！\"}");
                }
                return;
            }
            if (order_no == "" && order_no == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，订单号为空！\"}");
                return;
            }
            else
            {
                BLL.orders bll = new BLL.orders();
                if (!bll.Exists(order_no))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，订单号不存在！\"}");
                    return;
                }
                else
                {
                    Model.orders modelNew = bll.GetModel(order_no);
                    if (modelNew.status < 3 && modelNew.quiz == 0)
                    {
                        decimal tack_commision = modelNew.payable_amount * 5 / 100;
                        if (model.amount < tack_commision)
                        {
                            context.Response.Write("{\"status\":0, \"msg\":\"账户余额不足！\"}");
                            return;
                        }
                        if (new BLL.user_amount_log().Add(model.id, model.user_name, -1 * tack_commision, "升级佣金，订单号：" + modelNew.order_no) > 0)
                        {
                            modelNew.Order_type = 1;
                            modelNew.quiz = (quiz);
                            if (bll.UpdateField(modelNew.order_no, " quiz_time=getdate(),order_type=1 ,quiz=" + quiz))
                            {
                                context.Response.Write("{\"status\":1, \"msg\":\"升级成功！请耐心等待开奖！\"}");
                            }
                            else
                            {
                                new BLL.user_amount_log().Add(model.id, model.user_name, 1 * tack_commision, "升级佣金失败，订单号：" + modelNew.order_no);
                                context.Response.Write("{\"status\":0, \"msg\":\"升级失败！\"}");
                                return;
                            }
                        }
                    }
                    else
                    {
                        context.Response.Write("{\"status\":0, \"msg\":\"对不起，该订单不能升级！\"}");
                        return;
                    }
                }
            }
        }
        #endregion

        #region 猜奇偶添加(重庆时时彩API接口)===========================
        public void order_orders_auction_add(HttpContext context)
        {
            BLL.auction bll = new BLL.auction();
            DateTime AddDateTime_latest = Utils.StrToDateTime(bll.GetFilter("create_time", " 1=1 order by create_time desc"));

        }

        #endregion

        #region 红包===========================================
        public void order_orders_hb(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }

            string order_no = DTRequest.GetFormString("order_no");//订单号
            if (order_no == "" && order_no == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，订单号为空！\"}");
                return;
            }
            else
            {
                BLL.orders bll = new BLL.orders();
                if (!bll.Exists(order_no))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，订单号不存在！\"}");
                    return;
                }
                else
                {
                    Model.orders modelNew = bll.GetModel(order_no);
                    if (modelNew.status < 3 && modelNew.quiz_result == 0)
                    {
                        modelNew.Order_type = 2;
                        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
                        decimal zj = Utils.StrToDecimal(siteConfig.winrate, 0);
                        zj = zj * 100;
                        Random rd = new Random();
                        int SjNumber = rd.Next(0, 100);
                        string r_mes = "";
                        if (SjNumber <= zj)
                        {
                            r_mes = "{\"status\":1, \"msg\":\"恭喜你！抢到红包了！\"}";
                            modelNew.quiz_result = 1;
                        }
                        else
                        {
                            r_mes = "{\"status\":0, \"msg\":\"很遗憾，您本次未抢到红包！下次说不定有机会哦\"}";
                            modelNew.quiz_result = 2;
                        }
                        string str = "";
                        decimal cover_charge = siteConfig.cover_charge;
                        decimal performance = modelNew.payable_amount;//业绩
                        if (modelNew.order_goods != null && modelNew.order_goods.Count > 0)
                        {
                            var goods = modelNew.order_goods[0];

                            if (modelNew.quiz_result == 1)
                            {
                                decimal om = modelNew.real_amount;

                                //中奖
                                cover_charge = 0;
                                var bllArticle = new BLL.article();
                                //中奖
                                //大升级
                                var modelArticle = bllArticle.GetModel(Utils.ObjToInt(bllArticle.GetFiled("goods", "big_upgrade", " id=" + goods.article_id)));
                                if (modelArticle != null)
                                {
                                    //更新订单商品
                                    decimal sell_price = Utils.StrToDecimal(modelArticle.fields["sell_price"], 0);
                                    om = sell_price * goods.quantity;
                                    performance = (sell_price * goods.quantity) - (goods.real_price * goods.quantity);
                                    DbHelperSQL.ExecuteSql("update dt_order_goods set article_id=" + modelArticle.id + ",goods_title='" + modelArticle.title + "',img_url='" + modelArticle.img_url + "',goods_price=" + sell_price + ",real_price=" + sell_price + "  where id=" + goods.id);
                                }



                                str += " order_amount=" + (om + modelNew.express_fee + modelNew.payment_fee + modelNew.invoice_taxes + modelNew.invoice_taxes) + ",";
                            }
                            else
                            {
                                performance = goods.real_price * goods.quantity - cover_charge;
                                performance = performance > 0 ? performance * -1 : performance;
                            }
                        }
                        if (bll.UpdateField(modelNew.order_no, str + " performance=" + performance + ",cover_charge=" + cover_charge + ",order_type=2 , quiz_result= " + modelNew.quiz_result))
                        {
                            context.Response.Write(r_mes);
                        }
                        else
                        {
                            context.Response.Write("{\"status\":0, \"msg\":\"抢红包失败！\"}");
                            return;
                        }
                    }
                    else
                    {
                        context.Response.Write("{\"status\":0, \"msg\":\"对不起，该订单不能抢红包！\"}");
                        return;
                    }
                }
            }
        }
        #endregion

        #region 保存购物订单2===========================
        private void order_save2(HttpContext context)
        {
            int id = DTRequest.GetFormInt("id");//商品ID
            int quantity = DTRequest.GetFormInt("quantity");//数量
            int is_invoice = 0;
            int express_id = 1;
            int payment_id = 2;
            string message = "";
            string invoice_title = "";
            string title = "";
            string img_url = "";
            int point = 0;
            int is_upgrade = 0;
            Model.orderconfig orderConfig = new BLL.orderconfig().loadConfig(); //获取订单配置

            Model.express expModel = new BLL.express().GetModel(express_id);
            if (expModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，配送方式不存在或已删除！\"}");
                return;
            }
            //检查支付方式
            Model.payment payModel = new BLL.payment().GetModel(payment_id);
            if (payModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，支付方式不存在或已删除！\"}");
                return;
            }

            //如果开启匿名购物则不检查会员是否登录
            int user_id = 0;
            int user_group_id = 0;
            string user_name = string.Empty;
            //检查用户是否登录
            Model.users userModel = new Web.UI.BasePage().GetUserInfo();
            if (userModel != null)
            {
                user_id = userModel.id;
                user_group_id = userModel.group_id;
                user_name = userModel.user_name;

            }
            if (orderConfig.anonymous == 0 && userModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            decimal zjtkbl = 0;
            BLL.article GoodsBll = new BLL.article();
            DataTable dt = GoodsBll.GetList("goods", 1, "id=" + id, "id desc").Tables[0];
            decimal dj = 0;
            if (dt.Rows.Count > 0)
            {
                dj = Utils.ObjToDecimal(dt.Rows[0]["sell_price"], 0);
                img_url = Utils.ObjectToStr(dt.Rows[0]["img_url"]);
                title = Utils.ObjectToStr(dt.Rows[0]["title"]);
                point = Utils.ObjToInt(dt.Rows[0]["point"], 0);
                is_upgrade = Utils.ObjToInt(dt.Rows[0]["is_upgrade"]);
                zjtkbl = Utils.StrToDecimal(dt.Rows[0]["zjtkbl"].ToString(), 0);
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，没有该商品！\"}");
                return;
            }
            //保存订单=======================================
            Model.orders model = new Model.orders();
            model.order_no = "B" + Utils.GetOrderNumber(); //订单号B开头为商品订单
            model.user_id = user_id;
            model.user_name = user_name;
            model.payment_id = payment_id;
            model.express_id = express_id;
            model.accept_name = ""; ;
            model.area = ""; ; //省市区以逗号相隔
            model.address = ""; ;
            model.telphone = ""; ;
            model.mobile = ""; ;
            model.message = message;
            model.email = ""; ;
            model.post_code = "";
            model.is_invoice = 0;
            model.payable_amount = (dj * (quantity));
            model.real_amount = (dj * (quantity));
            model.express_status = 1;
            model.express_fee = 0;// expModel.express_fee; //物流费用
            model.is_upgrade = is_upgrade;
            model.order_user = userModel.parent_user;
            model.order_zjtkbl = zjtkbl;
            //是否开具发票
            if (model.is_invoice == 1)
            {
                model.invoice_title = invoice_title;
                if (orderConfig.taxtype == 1 && orderConfig.taxamount > 0) //百分比
                {
                    model.invoice_taxes = model.real_amount * orderConfig.taxamount / 100;
                }
                else //固定金额
                {
                    model.invoice_taxes = orderConfig.taxamount;
                }
            }
            //订单总金额=实付商品金额+运费+支付手续费+税金
            model.order_amount = model.real_amount + model.express_fee + model.payment_fee + model.invoice_taxes;
            //购物积分,可为负数
            model.point = point * quantity;
            model.add_time = DateTime.Now;

            //商品详细列表
            List<Model.order_goods> gls = new List<Model.order_goods>();
            gls.Add(new Model.order_goods() { article_id = id, goods_id = 0, goods_no = "", goods_price = dj, img_url = img_url, goods_title = title, order_id = 0, point = point * quantity, quantity = quantity, real_price = dj, spec_text = "" });
            model.order_goods = gls;
            if (userModel.amount < model.order_amount)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"账户余额不足！\"}");
                return;
            }
            int typedd = model.Order_type;
            if (model.order_amount > 5000)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"最大单笔下单金额为" + siteConfig.Maximumamount + "元，" + siteConfig.Maximumamountremark + "！\"}");
                return;

            }
            if (model.point < 0 && (model.point * -1) > userModel.point)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"账户积分不足！\"}");
                return;
            }
            if (new BLL.user_amount_log().Add(userModel.id, userModel.user_name, -(1 * model.order_amount), "商城消费，订单号：" + model.order_no) > 0)
            {
                model.status = 2;
                model.payment_status = 2;
                model.payment_time = DateTime.Now;
                int result = new BLL.orders().Add(model);
                if (result < 1)
                {

                    new BLL.user_amount_log().Add(userModel.id, userModel.user_name, 1 * model.order_amount, "商城消费失败，订单号：" + model.order_no);
                    context.Response.Write("{\"status\":0, \"msg\":\"订单保存发生错误，请联系管理员！\"}");
                    return;
                }
                //扣除积分
                if (model.point < 0)
                {
                    new BLL.user_point_log().Add(model.user_id, model.user_name, model.point, "积分换购，订单号：" + model.order_no, false);
                }
                //提交成功，返回URL
                context.Response.Write("{\"status\":1, \"order_no\":\""
                    + model.order_no + "\", \"msg\":\"恭喜您，订单已成功提交！\"}");
                return;
            }
            context.Response.Write("{\"status\":0, \"msg\":\"订单保存发生错误，请重试！\"}");
            return;
        }
        #endregion

        #region 地址===========================================
        public void order_orders_dz(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            int succeed = 0;//修改成功数量
            string order_no = DTRequest.GetString("order_no");//订单号
            int add_id = DTRequest.GetInt("id", 0);//地址簿ID
            if (order_no == "" || order_no == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，订单号为空！\"}");
                return;
            }
            else
            {
                BLL.orders bll = new BLL.orders();//订单
                //Model.orders modelNew = bll.GetModel(order_no);
                BLL.user_addr_book blluser = new BLL.user_addr_book();//地址
                Model.user_addr_book modeluser = new Model.user_addr_book();
                //Model.express expModel = new BLL.express().GetModel(1);//快递
                modeluser = blluser.GetModel(add_id);
                string[] order_nosz;
                string order_noWhere = "";
                order_nosz = order_no.Split(',');//订单数组
                for (int i = 0; i < order_nosz.Length; i++)
                {
                    order_noWhere += "'" + order_nosz[i] + "',";
                }
                order_noWhere = order_noWhere.Substring(0, order_noWhere.Length - 1);
                pageHelper.WriteLog("order_no in (" + order_noWhere + ") and status<3 and isnull(accept_name,'') =''");
                if (bll.GetCount(" order_no in (" + order_noWhere + ") and status<3 and isnull(accept_name,'') ='' ") < order_nosz.Length)
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，有订单号不存在或者有订单已经不能修改地址！！\"}");
                    return;
                }
                else if (bll.GetCount(" order_no in (" + order_noWhere + ") and status<3") == order_nosz.Length)
                {
                    List<Model.orders> oList = new List<Model.orders>();
                    decimal count_express_fee = 0;

                    for (int i = 0; i < order_nosz.Length; i++)
                    {
                        Model.orders modelNew = bll.GetModel(order_nosz[i]);
                        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
                        decimal dj = siteConfig.dj_freight;
                        decimal dz = siteConfig.dz_freight;
                        decimal express_fee = 0;
                        int quantity = Convert.ToInt32(DbHelperSQL.GetSingle("select  quantity  from  [dbo].[dt_order_goods] where  order_id='" + modelNew.id + "'"));
                        if (i == 0)
                        {
                            express_fee = (quantity - 1) * dz + dj;
                        }
                        else
                        {
                            express_fee = quantity * dz;
                        }
                        modelNew.accept_name = modeluser.accept_name;
                        modelNew.mobile = modeluser.mobile;
                        modelNew.area = modeluser.area;
                        modelNew.address = modeluser.address;
                        modelNew.post_code = modeluser.post_code;
                        modelNew.express_fee = express_fee;
                        decimal yj = Convert.ToDecimal(DBUtility.DbHelperSQL.GetSingle("select performance from dt_orders where order_no='" + order_nosz[i] + "' "));
                        modelNew.performance = yj;
                        oList.Add(modelNew);
                        count_express_fee += express_fee;
                        //if (bll.Update(modelNew))
                        //{
                        //    succeed++;
                        //}
                    }
                    ////string monery = DbHelperSQL.GetSingle("select sum(express_fee) from  [dt_orders] where  order_no in (" + order_noWhere + ")").ToString();
                    //// = Utils.StrToDecimal(monery, 0);
                    if (count_express_fee > model.amount)
                    {
                        context.Response.Write("{\"status\":0, \"msg\":\"账户余额不足！\"}");
                        return;
                    }
                    foreach (var mo in oList)
                    {
                        bll.Update(mo);
                        succeed++;
                    }
                    new BLL.user_amount_log().Add(model.id, model.user_name, -1 * count_express_fee, "订单提货扣除运费，订单号：" + order_no);
                    if (succeed == order_nosz.Length)
                    {
                        context.Response.Write("{\"status\":1, \"msg\":\"设置收货地址成功！\"}");
                        return;
                    }
                    else
                    {
                        context.Response.Write("{\"status\":0, \"msg\":\"设置收货地址失败！\"}");
                        return;
                    }
                }
                else
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该订单不能设置收货地址！\"}");
                    return;
                }
            }
        }

        #endregion

        #region 银行卡添加===========================================
        public void bankcard_add(HttpContext context)
        {
            string bank_name = DTRequest.GetString("bank_name");//银行名称
            string bank_card = DTRequest.GetString("bank_card");//银行卡号
            string bank_username = DTRequest.GetString("bank_username");//开户人
            string zhihang = DTRequest.GetString("zhihang");//支行
            if (string.IsNullOrEmpty(bank_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入银行名称！\"}");
                return;
            }
            if (string.IsNullOrEmpty(bank_card))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入银行卡号！\"}");
                return;
            }
            if (string.IsNullOrEmpty(bank_username))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入开户人！\"}");
                return;
            }
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            DateTime createtime = DateTime.Now;
            BLL.bankcard bll = new BLL.bankcard();
            int sl = bll.GetUserCount(model.user_name);
            if (sl >= 5)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，一个用户只能添加5张银行卡！\"}");
                return;
            }
            Model.bankcard modelbd = new Model.bankcard();
            modelbd.user_name = model.user_name;
            modelbd.bank_name = bank_name;
            modelbd.bank_card = bank_card;
            modelbd.bank_username = bank_username;
            modelbd.createtime = createtime;
            if (bll.Add(modelbd) > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"银行卡添加成功！\"}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，银行卡添加失败！\"}");
                return;
            }
        }

        #endregion

        #region 银行卡删除===========================================
        public void bankcard_delete(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            int id = DTRequest.GetInt("id", 4);//操作id
            if (id == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请选择要删除的银行卡！\"}");
                return;
            }
            BLL.bankcard bll = new BLL.bankcard();

            string Where = " 1=1 and id=" + id + " and user_name='" + model.user_name + "'";
            if (bll.DeleteNew(Where))
            {
                context.Response.Write("{\"status\":1, \"msg\":\"银行卡删除成功！\"}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，银行卡删除失败！\"}");
                return;
            }
        }

        #endregion

        #region 银行卡查询===========================================
        public void bankcard_select(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            BLL.bankcard bll = new BLL.bankcard();
            DataTable dt = bll.Select("*", " user_name='" + model.user_name + "'");
            if (dt.Rows.Count > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"查询成功！\",\"Rows\":" + JsonHelper.DataTableToJSON(dt) + "}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，该用户未添加银行卡！\"}");
                return;
            }

        }
        #endregion

        #region 银行卡查询===========================================
        public void bankcard_selectid(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            int id = DTRequest.GetInt("id", 4);//操作id
            BLL.bankcard bll = new BLL.bankcard();
            DataTable dt = bll.Select("*", " user_name='" + model.user_name + "' and id=" + id);
            if (dt.Rows.Count > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"查询成功！\",\"Rows\":" + JsonHelper.DataTableToJSON(dt) + "}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，该用户未添加银行卡！\"}");
                return;
            }

        }
        #endregion

        #region 银行卡修改===========================================
        public void bankcard_update(HttpContext context)
        {
            int id = DTRequest.GetInt("id", 4);//操作id
            string bank_name = DTRequest.GetString("bank_name");//银行名称
            string bank_card = DTRequest.GetString("bank_card");//银行卡号
            string bank_username = DTRequest.GetString("bank_username");//开户人
            if (id == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请选择要修改的银行卡！\"}");
                return;
            }
            if (string.IsNullOrEmpty(bank_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入银行名称！\"}");
                return;
            }
            if (string.IsNullOrEmpty(bank_card))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入银行卡号！\"}");
                return;
            }
            if (string.IsNullOrEmpty(bank_username))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入开户人！\"}");
                return;
            }
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            DateTime createtime = DateTime.Now;
            BLL.bankcard bll = new BLL.bankcard();
            Model.bankcard modelbd = new Model.bankcard();
            modelbd.user_name = model.user_name;
            modelbd.bank_name = bank_name;
            modelbd.bank_card = bank_card;
            modelbd.bank_username = bank_username;
            modelbd.createtime = createtime;
            modelbd.id = id;
            if (bll.Update(modelbd) == true)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"银行卡修改成功！\"}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"银行卡修改失败！\"}");
                return;
            }
        }
        #endregion

        #region 实名认证===========================================
        public void user_real(HttpContext context)
        {
            string real_name = DTRequest.GetString("real_name");//真实姓名
            string idcard = DTRequest.GetString("idcard");//身份证
            if (string.IsNullOrEmpty(real_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入真实姓名！\"}");
                return;
            }
            if (string.IsNullOrEmpty(idcard))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入身份证！\"}");
                return;
            }
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            BLL.users bll = new BLL.users();

            if (bll.UpdateField(model.id, " real_name='" + real_name + "',idcard='" + idcard + "'") > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"实名认证成功成功！\"}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"实名认证失败！\"}");
                return;
            }
        }
        #endregion

        #region 提现记录添加===========================================
        public void txjl_add(HttpContext context)
        {
            string bank_name = DTRequest.GetString("bank_name");//银行名称
            string bank_card = DTRequest.GetString("bank_card");//银行卡号
            string bank_username = DTRequest.GetString("bank_username");//开户人
            double money = Convert.ToDouble(DTRequest.GetString("money"));//提现金额
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            double sxbl = Convert.ToDouble(siteConfig.withdraw_deposit);
            double sxf = money + sxbl;
            string ss = bank_name + "," + bank_card + "," + bank_username + "," + money + ",";
            if (string.IsNullOrEmpty(bank_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入银行名称！\"}");
                return;
            }
            if (string.IsNullOrEmpty(bank_card))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入银行卡号！\"}");
                return;
            }
            if (string.IsNullOrEmpty(bank_username))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入开户人！\"}");
                return;
            }
            if (money == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入提现金额！\"}");
                return;
            }
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            double yue = Convert.ToDouble(model.amount);
            if (money > yue)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户余额不足！\"}");
                return;
            }
            BLL.txjl bll = new BLL.txjl();
            Model.txjl modelbd = new Model.txjl();

            modelbd.user_name = model.user_name;
            modelbd.bank_name = bank_name;
            modelbd.bank_card = bank_card;
            modelbd.bank_username = bank_username;
            modelbd.money = money;
            modelbd.sxf = sxf;
            modelbd.status = 0;
            modelbd.createtime = DateTime.Now;
            string subject = "提现";
            decimal txje = Convert.ToDecimal(money - sxf);
            int result = new BLL.user_amount_log().Add(model.id, model.user_name, (decimal)(-1 * sxf), subject);
            if (bll.Add(modelbd) > 0)
            {
                if (result > 0)
                {
                    context.Response.Write("{\"status\":1, \"msg\":\"提现成功！\"}");
                }
                else
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，提现失败\"}");
                    return;
                }
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，提现失败\"}");
                return;
            }
        }

        #endregion

        #region 提现记录查询===========================================
        public void txjl_select(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }

            int pagesize = DTRequest.GetInt("pagesize", 10);
            int pageindex = DTRequest.GetInt("pageindex", 1);
            int totalCount = 0;
            string where = " user_name='" + model.user_name + "'";

            DataSet ds = new BLL.txjl().GetList(pagesize, pageindex, where, "createtime desc", out totalCount);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"查询成功！\",\"Rows\":" + JsonHelper.DataTableToJSON(dt) + "}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"该用户无提现操作！\"}");
                return;
            }
        }

        #endregion

        #region 提现记录审核通过===========================================
        public void txjl_pass(HttpContext context)
        {
            int id = Utils.StrToInt(DTRequest.GetString("id"), 0);//记录ID
            string audit_remark = DTRequest.GetString("reson");//审核理由
            if (id == 0)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，该笔提现记录不存在！\"}");
                return;
            }
            Model.txjl model = new Model.txjl();
            BLL.txjl bll = new BLL.txjl();
            model = bll.GetModel(id);
            model.status = 1;
            model.audit_remark = audit_remark;
            model.audit_time = DateTime.Now;
            if (bll.Update(model) == true)
            {
                context.Response.Write("{\"status\": 1, \"msg\": \"恭喜您，审核成功！\"}");
                return;
            }
            context.Response.Write("{\"status\": 0, \"msg\": \"对不起，审核过程中发生错误！\"}");
        }

        #endregion

        #region 提现记录审核拒审===========================================
        public void txjl_reject(HttpContext context)
        {
            int id = Utils.StrToInt(DTRequest.GetString("id"), 0);//记录ID
            string audit_remark = DTRequest.GetString("reson");//审核理由
            if (id == 0)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，该笔提现记录不存在！\"}");
                return;
            }
            if (string.IsNullOrEmpty(audit_remark))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，请填写拒审说明！\"}");
                return;
            }
            Model.txjl model = new Model.txjl();
            BLL.txjl bll = new BLL.txjl();
            model = bll.GetModel(id);
            model.status = 2;
            model.audit_remark = audit_remark;
            model.audit_time = DateTime.Now;
            //double money = model.money;//退回金额
            double moneyz = model.sxf;//退回金额
            string subject = "提现失败，返回余额";
            decimal txje = Convert.ToDecimal(moneyz);
            int userid = Convert.ToInt32(DBUtility.DbHelperSQL.GetSingle(" select id from dt_users where user_name='" + model.user_name.Trim() + "'"));
            int result = new BLL.user_amount_log().Add(userid, model.user_name, 1 * txje, subject);
            if (bll.Update(model) == true)
            {
                if (result > 0)
                {
                    context.Response.Write("{\"status\": 1, \"msg\": \"恭喜您，拒审成功！\"}");
                    return;
                }
                else
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"对不起，审核过程中发生错误！\"}");
                }
            }
            context.Response.Write("{\"status\": 0, \"msg\": \"对不起，审核过程中发生错误！\"}");
        }

        #endregion

        #region 猜奇偶查询===========================================
        public void order_orders_auction(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            BLL.auction bll = new BLL.auction();
            string where = " DateDiff(day,create_time,getdate())=0";
            string filedOrder = " create_time desc";
            DataTable dt = bll.GetList(where, filedOrder).Tables[0];
            if (dt.Rows.Count > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"查询成功！\",\"Rows\":" + JsonHelper.DataTableToJSON(dt) + "}");
            }
            else
            {
                string type = DTRequest.GetQueryString("type");
                if (type == "1")
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，当天还无猜奇偶活动！\"}");
                }
                else if (type == "2")
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，当天还无猜大中小活动！\"}");
                }
                else if (type == "3")
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，当天还无猜牛牛活动！\"}");
                }
                else
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，当天还无活动！\"}");
                }
                return;
            }

        }
        #endregion

        #region 佣金记录查询===========================================
        public void user_commision_log(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }

            int pagesize = DTRequest.GetInt("pagesize", 10);
            int pageindex = DTRequest.GetInt("pageindex", 1);
            int totalCount = 0;
            string where = " user_name='" + model.user_name + "'";

            DataSet ds = new BLL.user_commision_log().GetList(pagesize, pageindex, where, "add_time desc", out totalCount);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"查询成功！\",\"Rows\":" + JsonHelper.DataTableToJSON(dt) + "}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"该用户佣金操作！\"}");
                return;
            }
        }

        #endregion

        #region 业绩查询===========================================
        public void orders_parent_select(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            int pagesize = DTRequest.GetInt("pagesize", 10);
            int pageindex = DTRequest.GetInt("pageindex", 1);
            int totalCount = 0;
            string where = " status<=3 and Order_type=1 and quiz_result!=0 and order_user='" + model.user_name + "'";

            DataSet ds = new BLL.orders().GetList(pagesize, pageindex, where, " id ", out totalCount);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"查询成功！\",\"Rows\":" + JsonHelper.DataTableToJSON(dt) + "}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"该用户无业绩！\"}");
                return;
            }
        }

        #endregion

        #region 业绩和服务费查询===========================================
        public void orders_yjfwf_select(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string kaitime = DTRequest.GetString("starttime");
            string jietime = DTRequest.GetString("endtime");

            string where = " status<=3 and Order_type!=0  ";
            where += "  and user_name in (select user_name from [dbo].[fn_Getchildlist] ('" + model.user_name + "'))";
            if (!string.IsNullOrEmpty(kaitime))
            {
                where += " and DATEDIFF(day,'" + kaitime + "',add_time) >=0";
            }
            if (!string.IsNullOrEmpty(jietime))
            {
                where += " and DATEDIFF(day,'" + jietime + "',add_time) <=0";
            }

            where += " group by user_name";
            DataSet ds = new BLL.orders().GetList("user_name,sum(performance) as performance,sum(cover_charge) as cover_charge", where, "user_name asc");
            DataTable dt = ds.Tables[0];
            decimal yj = 0;
            decimal fwf = 0;
            foreach (DataRow dr in dt.Rows)
            {
                yj = yj + Convert.ToDecimal(dr["performance"]);
                fwf = fwf + Convert.ToDecimal(dr["cover_charge"]);
            }

            DataRow dr1 = dt.NewRow();
            dr1["user_name"] = "合计：";
            dr1["performance"] = yj;
            dr1["cover_charge"] = fwf;
            dt.Rows.Add(dr1);

            if (dt.Rows.Count > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"查询成功！\",\"Rows\":" + JsonHelper.DataTableToJSON(dt) + "}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"该用户和该用户下级都无无业绩和服务费！\"}");
                return;
            }
        }

        #endregion

        #region 业绩和服务费查询详情===========================================
        public void orders_yjfwf_xq(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string kaitime = DTRequest.GetString("starttime");
            string jietime = DTRequest.GetString("endtime");
            string user_name = DTRequest.GetString("user_name");

            string where = " status<=3 and Order_type!=0  and user_name='" + user_name + "' ";
            // where += "  and user_name in (select user_name from [dbo].[fn_Getchildlist] ('" + model.user_name + "'))";
            if (!string.IsNullOrEmpty(kaitime))
            {
                where += " and DATEDIFF(day,'" + kaitime + "',add_time) >=0";
            }
            if (!string.IsNullOrEmpty(jietime))
            {
                where += " and DATEDIFF(day,'" + jietime + "',add_time) <=0";
            }

            where += " group by user_name,order_no,performance,cover_charge";
            DataSet ds = new BLL.orders().GetList("user_name,order_no,performance,cover_charge", where, "user_name asc");
            DataTable dt = ds.Tables[0];
            decimal yj = 0;
            decimal fwf = 0;
            foreach (DataRow dr in dt.Rows)
            {
                yj = yj + Convert.ToDecimal(dr["performance"]);
                fwf = fwf + Convert.ToDecimal(dr["cover_charge"]);
            }

            DataRow dr1 = dt.NewRow();
            dr1["user_name"] = "合计：";
            dr1["order_no"] = "*";
            dr1["performance"] = yj;
            dr1["cover_charge"] = fwf;
            dt.Rows.Add(dr1);
            if (dt.Rows.Count > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"查询成功！\",\"Rows\":" + JsonHelper.DataTableToJSON(dt) + "}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"该用户和该用户下级都无无业绩和服务费！\"}");
                return;
            }
        }

        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}