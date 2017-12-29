using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;

namespace Qrcms.Web.adminusers
{
    public partial class center : Web.UI.UsersPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Model.users admin_info = GetAdminInfo(); //管理员信息
                //登录信息
                if (admin_info != null)
                {
                    BLL.user_login_log bll = new BLL.user_login_log();
                    Model.user_login_log model1 = bll.GetModel(admin_info.user_name);
                    if (model1 != null)
                    {
                        //本次登录
                        litIP.Text = model1.login_ip;
                    }
                    Model.user_login_log model2 = bll.GetModel(admin_info.user_name);
                    if (model2 != null)
                    {
                        //上一次登录
                        litBackIP.Text = model2.login_ip;
                        litBackTime.Text = model2.login_time.ToString();
                    }
                }
            }
        }
    }
}