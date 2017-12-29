using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;

namespace Qrcms.Web.admin.dialog
{
    public partial class dialog_article : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                RptBind("", "sort_id asc,id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            BLL.article bll = new BLL.article();
            this.rptList.DataSource = bll.GetList(0, 0, this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("dialog_article.aspx", "page={0}", "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);            
        }
        #endregion

        #region 赋值操作=================================
        protected void rptGroupPrice_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //判断里层repeater处于外层repeater的哪个位置（ AlternatingItemTemplate，FooterTemplate，  
            //HeaderTemplate，，ItemTemplate，SeparatorTemplate）  
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("rptspeclist") as Repeater;//找到里层的repeater对象  
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项   
                int goodsid = Convert.ToInt32(rowv["id"]); //获取填充子类的id   
                rep.DataSource = new BLL.article_goods().GetList( goodsid);
                rep.DataBind();
            }
        }
        #endregion   

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("dialog_article_page_size", "QrcmsPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion
   
        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("dialog_article_page_size", "QrcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect("dialog_article.aspx");
        }      

    }
}