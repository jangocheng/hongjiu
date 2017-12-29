using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using Qrcms.Common;

namespace Qrcms.Web.adminusers
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUserName.Text = Utils.GetCookie("DTRememberName");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string userPwd = txtPassword.Text.Trim();

            if (userName.Equals("") || userPwd.Equals(""))
            {
                msgtip.InnerHtml = "请输入用户名或密码";
                return;
            }

            #region //////////验证码

            string CheckCode = string.Empty;
            if (Request.Cookies["CheckCode"] != null)
            {
                CheckCode = Request.Cookies["CheckCode"].Value;
            }
            if (string.IsNullOrEmpty(CheckCode))
            {
                msgtip.InnerHtml = "请输入验证码!";
                return;
            }
            if (CheckCode.ToLower() != txtQaptach.Text.ToLower())
            {
                msgtip.InnerHtml = "验证码错误!";
                return;
            }

            #endregion
            if (Session["AdminLoginSun"] == null)
            {
                Session["AdminLoginSun"] = 1;
            }
            else
            {
                Session["AdminLoginSun"] = Convert.ToInt32(Session["AdminLoginSun"]) + 1;
            }
            //判断登录错误次数
            if (Session["AdminLoginSun"] != null && Convert.ToInt32(Session["AdminLoginSun"]) > 5)
            {
                msgtip.InnerHtml = "错误超过5次，关闭浏览器重新登录！";
                return;
            }
            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(userName, userPwd,1,1, true);
            if (model == null)
            {
                msgtip.InnerHtml = "用户名或密码有误，请重试！";
                return;
            }
            Session[DTKeys.SESSION_ADMIN_INFO] = model;
            Session.Timeout = 45;
            //写入登录日志
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            if (siteConfig.logstatus > 0)
            {
                new BLL.user_login_log().Add(model.id, model.user_name, "用户登录");
            }
            //写入Cookies
            Utils.WriteCookie("DTRememberName", model.user_name, 14400);
            Utils.WriteCookie("AdminName", "Qrcms", model.user_name);
            Utils.WriteCookie("AdminPwd", "Qrcms", model.password);
            Response.Redirect("index.aspx");
            return;
        }

    }
}