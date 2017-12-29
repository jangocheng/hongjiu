using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Qrcms.Common;

namespace Qrcms.Web.UI
{
    public class UsersPage : System.Web.UI.Page
    {
            protected internal Model.siteconfig siteConfig;

            public UsersPage()
            {
                this.Load += new EventHandler(ManagePage_Load);
                siteConfig = new BLL.siteconfig().loadConfig();
            }

            private void ManagePage_Load(object sender, EventArgs e)
            {
                //判断管理员是否登录
                if (!IsAdminLogin())
                {
                    Response.Write("<script>parent.location.href='" + siteConfig.webpath + "adminusers"+ "/login.aspx'</script>");
                    Response.End();
                }
            }

            #region 管理员============================================
            /// <summary>
            /// 判断管理员是否已经登录(解决Session超时问题)
            /// </summary>
            public bool IsAdminLogin()
            {
                //如果Session为Null
                if (Session[DTKeys.SESSION_ADMIN_INFO] != null)
                {
                    return true;
                }
                else
                {
                    //检查Cookies
                    string adminname = Utils.GetCookie("AdminName", "Qrcms");
                    string adminpwd = Utils.GetCookie("AdminPwd", "Qrcms");
                    if (adminname != "" && adminpwd != "")
                    {
                        BLL.users bll = new BLL.users();
                        Model.users model = bll.GetModel(adminname, adminpwd);
                        if (model != null)
                        {
                            Session[DTKeys.SESSION_ADMIN_INFO] = model;
                            return true;
                        }
                    }
                }
                return false;
            }

            /// <summary>
            /// 取得管理员信息
            /// </summary>
            public Model.users GetAdminInfo()
            {
                if (IsAdminLogin())
                {
                    Model.users model = Session[DTKeys.SESSION_ADMIN_INFO] as Model.users;
                    if (model != null)
                    {
                        return model;
                    }
                }
                return null;
            }

            /// <summary>
            /// 检查管理员权限
            /// </summary>
            /// <param name="nav_name">菜单名称</param>
            /// <param name="action_type">操作类型</param>
            public void ChkAdminLevel(string nav_name, string action_type)
            {
                //Model.users model = GetAdminInfo();
                //BLL.user_groups bll = new BLL.user_groups();
                //bool result = bll.Exists(model.group_id, nav_name, action_type);

                //if (!result)
                //{
                //    string msgbox = "parent.jsdialog(\"错误提示\", \"您没有管理该页面的权限，请勿非法进入！\", \"back\")";
                //    Response.Write("<script type=\"text/javascript\">" + msgbox + "</script>");
                //    Response.End();
                //}
            }

            /// <summary>
            /// 写入管理日志
            /// </summary>
            /// <param name="action_type"></param>
            /// <param name="remark"></param>
            /// <returns></returns>
            public bool AddAdminLog(string action_type, string remark)
            {
                if (siteConfig.logstatus > 0)
                {
                    Model.users model = GetAdminInfo();
                    int newId = new BLL.user_login_log().Add(model.id, model.user_name, remark);
                    if (newId > 0)
                    {
                        return true;
                    }
                }
                return false;
            }

            #endregion

            #region JS提示============================================
            /// <summary>
            /// 添加编辑删除提示
            /// </summary>
            /// <param name="msgtitle">提示文字</param>
            /// <param name="url">返回地址</param>
            protected void JscriptMsg(string msgtitle, string url)
            {
                string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\")";
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
            }
            /// <summary>
            /// 带回传函数的添加编辑删除提示
            /// </summary>
            /// <param name="msgtitle">提示文字</param>
            /// <param name="url">返回地址</param>
            /// <param name="callback">JS回调函数</param>
            protected void JscriptMsg(string msgtitle, string url, string callback)
            {
                string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", " + callback + ")";

                ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
            }
            #endregion

        }

    }
