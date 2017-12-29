using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Qrcms.Common;

namespace Qrcms.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        #region 广告位标签======================================
        /// <summary>
        /// 获得广告内容列表
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>DataTable</returns>
        protected Model .advert  get_advert(int aid)
        {
            Model.advert model = new Model.advert();
            BLL.advert bll = new BLL.advert();
            model = bll.GetModel(aid);

            return model;
        }

        #endregion

    }
}
