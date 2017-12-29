using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;
using System.Data;
using Qrcms.DBUtility;
using System.Data.OleDb;


namespace Qrcms.Web.admin.users
{
    public partial class tixian : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string starttime = "";
        protected string endtime = "";
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");

            this.starttime = DTRequest.GetString("starttime");
            this.endtime = DTRequest.GetString("endtime");
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("tixian", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind("1=1" + CombSqlTxt(this.keywords, this.starttime, this.endtime), " createtime desc ");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            txtStartTime.Text = this.starttime;
            txtEndTime.Text = this.endtime;
            BLL.txjl bll = new BLL.txjl();
            DataTable dt = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount).Tables[0];
            if (dt.Rows.Count > 0)
            {
                double sumperformance = 0;
                double suncovercharge = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    sumperformance = sumperformance + Convert.ToDouble(dr["money"]);
                    suncovercharge = suncovercharge + Convert.ToDouble(dr["sxf"]);
                }
                lblperformance.Text = sumperformance.ToString();
                lblcovercharge.Text = suncovercharge.ToString();
            }
            this.rptList.DataSource = dt;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("tixian.aspx", "keywords={0}&page={1}&starttime={2}&endtime={3}", this.keywords, "__id__", this.starttime, this.endtime);
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords, string _starttime, string _endtime)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and  user_name like '" + _keywords + "' ");
            }
            if (!string.IsNullOrEmpty(_starttime))
            {
                strTemp.Append(" and DATEDIFF(day,'" + _starttime + "',createtime) >=0");
            }
            if (!string.IsNullOrEmpty(_endtime))
            {
                strTemp.Append(" and DATEDIFF(day,'" + _endtime + "',createtime) <=0");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("tixian_page_size", "QrcmsPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("tixian.aspx", "keywords={0}&starttime={1}&endtime={2}", txtKeywords.Text, txtStartTime.Text, txtEndTime.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("tixian_page_size", "QrcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("tixian.aspx", "keywords={0}&starttime={1}&endtime={2}", txtKeywords.Text, txtStartTime.Text, txtEndTime.Text));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("tixian", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.txjl bll = new BLL.txjl();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Utils.StrToInt(((HiddenField)rptList.Items[i].FindControl("hidId")).Value, 0);
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
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("tixian.aspx", "keywords={0}&starttime={1}&endtime={2}", txtKeywords.Text, txtStartTime.Text, txtEndTime.Text));
        }


        /// <summary>
        /// 提现状态
        /// </summary>
        /// <param name="quiz_result"></param>
        /// <returns></returns>
        protected string Getstatus(int status)
        {
            string Type = "";
            if (status == 0)
            {
                Type = "待审核";
            }
            else if (status == 1)
            {
                Type = "已审核";
            }
            else if (status == 2)
            {
                Type = "拒审";
            }
            return Type;
        }


        protected string GetAudit(int status,int id)
        {
            string res = "";
            if (status == 0)
            {
                res = "<a href=\"javascript:pass('" + id + "')\">通过</a> | <a href=\"javascript:reject('" + id + "')\">拒审</a>";
            }
            else
            {
                res = "";
            }
            return res;
        }
    }
}