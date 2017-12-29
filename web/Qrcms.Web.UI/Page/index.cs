using System;
using System.Collections.Generic;
using System.Text;

namespace Qrcms.Web.UI.Page
{
    public partial class index : Web.UI.BasePage
    {
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
