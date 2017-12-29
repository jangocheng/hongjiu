using System;
using System.Collections.Generic;
using System.Text;

namespace Qrcms.Web.UI.Page
{
    public partial class article : Web.UI.BasePage
    {
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsUserLogin())
            {
                //跳转URL
                System.Web.HttpContext.Current.Response.Redirect(linkurl("login"));
                return;
            }
        }
    }
}
