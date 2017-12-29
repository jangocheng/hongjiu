using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Qrcms.Common;

namespace Qrcms.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        #region 列表标签======================================
        /// <summary>
        /// 获得广告内容列表
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>DataTable</returns>
        protected DataTable get_advert_banner_list(int aid)
        {
            DataTable dt = new DataTable();
            dt = new Qrcms.BLL.advert_banner().GetList("is_lock=0 and datediff(day,start_time,getdate())>=0 and datediff(day,end_time,getdate())<=0 and aid=" + aid).Tables[0];
            
            return dt;
        }

        #endregion

    }
}
