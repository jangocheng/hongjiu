using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;

namespace Qrcms.Web.admin.users
{
    public partial class recharge_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string starttime = "";
        protected string endtime = "";
        protected string keywords = string.Empty;
        protected int zt;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");
            this.starttime = DTRequest.GetString("starttime");
            this.endtime = DTRequest.GetString("endtime");
            if (DTRequest.GetQueryString("zt") != "")
            {
                this.zt =Convert.ToInt32( DTRequest.GetQueryString("zt"));
            }
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("user_recharge_log", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind("id>0" + CombSqlTxt(this.keywords, zt, this.starttime, this.endtime), "add_time desc,id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            txtStartTime.Text = this.starttime;
            txtEndTime.Text = this.endtime;
            ddlPaymentStatus.SelectedValue = this.zt.ToString();
            BLL.user_recharge bll = new BLL.user_recharge();
            DataTable dt = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount).Tables[0];
            if (dt.Rows.Count > 0)
            {
                double sumperformance = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    sumperformance = sumperformance + Convert.ToDouble(dr["amount"]);
                }
                lblperformance.Text = sumperformance.ToString();
            }
            this.rptList.DataSource = dt;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("recharge_list.aspx", "keywords={0}&page={1}&zt={2}&starttime={3}&endtime={4}", this.keywords, "__id__", ddlPaymentStatus.SelectedValue, txtStartTime.Text, txtEndTime.Text);
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords, int _zt, string _starttime, string _endtime)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_zt != 2)
            {
                strTemp.Append(" and  status = '" + _zt + "'");

            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (user_name='" + _keywords + "' or recharge_no like '%" + _keywords + "%')");
            }
            if (!string.IsNullOrEmpty(_starttime))
            {
                strTemp.Append(" and DATEDIFF(day,'" + _starttime + "',add_time) >=0");
            }
            if (!string.IsNullOrEmpty(_endtime))
            {
                strTemp.Append(" and DATEDIFF(day,'" + _endtime + "',add_time) <=0");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("user_recharge_log_page_size", "QrcmsPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("recharge_list.aspx", "keywords={0}&zt={1}&starttime={2}&endtime={3}", txtKeywords.Text, ddlPaymentStatus.SelectedValue, txtStartTime.Text, txtEndTime.Text));
        }
        protected void ddlPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("recharge_list.aspx", "keywords={0}&zt={1}&starttime={2}&endtime={3}", txtKeywords.Text, ddlPaymentStatus.SelectedValue, txtStartTime.Text, txtEndTime.Text));
        }
        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("user_recharge_log_page_size", "QrcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("recharge_list.aspx", "keywords={0}&zt={1}&starttime={2}&endtime={3}", this.keywords, this.zt.ToString(), this.starttime, this.endtime));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("user_recharge_log", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.user_recharge bll = new BLL.user_recharge();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
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
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除充值记录成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("recharge_list.aspx", "keywords={0}&zt={1}&starttime={2}&endtime={3}", this.keywords, this.zt.ToString(), this.starttime, this.endtime));
        }

    }
}