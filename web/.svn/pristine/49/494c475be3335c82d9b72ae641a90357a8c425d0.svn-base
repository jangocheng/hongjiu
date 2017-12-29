using Qrcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qrcms.Web.adminusers.auction
{
    public partial class auction_detail : Web.UI.UsersPage
    {
        private string no;

        //页面加载事件
        protected void Page_Load(object sender, EventArgs e)
        {

            this.no = DTRequest.GetQueryString("no");
            if (string.IsNullOrEmpty(this.no))
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (!new BLL.auction().Exists(this.no))
            {
                JscriptMsg("信息不存在或已被删除！", "back");
                return;
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("auction_list", DTEnums.ActionEnum.View.ToString()); //检查权限               

                ShowInfo(this.no);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(string _no)
        {
            BLL.auction bll = new BLL.auction();
            Model.auction model = bll.GetModel(_no);

            good_id.Value = model.article_id.ToString();
            goodimg.Text = model.article_img;
            name.Text = model.article_title;
            banner.Text = model.banner;
            gooddesc.Value = model.describe;
            endtime.Text = model.end_date.ToString("yyyy-MM-dd HH:mm:ss");
            highprice.Text = model.high_price.ToString();
            lowprice.Text = model.low_price.ToString();
            count.Value = model.layer.ToString();
            remark.Value = model.remark;
            txtTitle.Text = model.title;
            saleprice.Text = model.sale_price.ToString();
            float_num.Text = model.float_num.ToString();

            if (model.recommend == 1)
            {
                cblItem.Items[0].Selected = true;
            }
        }
        #endregion
    }
}