using Qrcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qrcms.Web.adminusers.Redpacket
{
    public partial class Redpacket_loading : Web.UI.UsersPage
    {

        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("Redpacket_loading", DTEnums.ActionEnum.View.ToString()); //检查权限
                //RptBind(" getdate()<publish_date" + CombSqlTxt(keywords), " create_time desc ");
                RptBind("1=1" + CombSqlTxt(keywords), " create_time desc ");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.auction bll = new BLL.auction();
            this.rptList.DataSource = bll.GetList1(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("Redpacket_loading.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            strTemp.Append(" and getdate()<publish_date");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (title like  '%" + _keywords + "%' or article_title like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("Redpacket_loading_page_size", "QrcmsPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #region 获取操作

        public string GetOperator(string avg_status, string no, string article_id, string avg)
        {
            string res = "<a href='Redpacket_comment_list.aspx?no=" + no + "&goodid=" + article_id + "'>查看评论</a>";

            switch (avg_status)
            {
                case "0":
                    res += " | <a href='Redpacket_edit.aspx?no=" + no + "&action=" + DTEnums.ActionEnum.Edit + "'>修改</a>";
                    break;
                case "1":
                case "2":
                    //查询评价价之下之上人数
                    int low = 0, high = 0;
                    DataSet ds = new BLL.auction_order().GetList("price<=" + avg + " and a_no='" + no + "'");
                    DataTable dt = ds.Tables[0];
                    low = dt.Rows.Count;
                    ds = new BLL.auction_order().GetList("price>" + avg + " and a_no='" + no + "'");
                    dt = ds.Tables[0];
                    high = dt.Rows.Count;
                    res += " | <a href=\"javascript:update_price('" + no + "','" + low + "','" + high + "')\">修改平均价</a>";
                    break;
            }
            return res;
        }

        #endregion
        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("Redpacket_loading.aspx", "keywords={0}", txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("Redpacket_loading_page_size", "QrcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("Redpacket_loading.aspx", "keywords={0}", this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("Redpacket_loading", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.auction bll = new BLL.auction();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((HiddenField)rptList.Items[i].FindControl("hidId")).Value;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("Redpacket_loading.aspx", "keywords={0}", this.keywords));
        }

        /// <summary>
        /// 进行状态
        /// </summary>
        /// <param name="create_time">开始时间</param>
        /// <param name="end_date">截止时间</param>
        /// <param name="publish_date">揭晓时间</param>
        /// <returns></returns>
        protected string GetOrderType(DateTime create_time, DateTime end_date, DateTime publish_date)
        {
            string Type = "";
            DateTime DayTime = DateTime.Now;
            if (DateTime.Compare(DayTime, create_time) < 0)
            {
                Type = "等待中";
            }
            else if (DateTime.Compare(create_time, DayTime) < 0 && DateTime.Compare(DayTime, end_date) < 0)
            {
                Type = "竞拍中";
            }
            else if (DateTime.Compare(end_date, DayTime) < 0 && DateTime.Compare(DayTime, publish_date) < 0)
            {
                Type = "揭晓倒计时";
            }
            else if (DateTime.Compare(publish_date, DayTime) < 0)
            {
                Type = "已结束";
            }
            return Type;
        }

        /// <summary>
        /// 查看用户
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public string GetOperatorLook(string no)
        {
            string res = "<a href='Redpacket_order_list.aspx?a_no=" + no + "'>查看</a>";
            return res;
        }
    }
}