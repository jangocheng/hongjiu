﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;
using System.Text;
using System.Data;

namespace Qrcms.Web.admin.auction
{
    public partial class auction_order_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int status;
        protected int winstatus;
        protected int ordertype;
        protected string starttime = "";
        protected string endtime = "";
        protected string keywords = string.Empty;
        protected string a_no = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            this.status = DTRequest.GetQueryInt("status");
            this.winstatus = DTRequest.GetQueryInt("winstatus");
            this.starttime = DTRequest.GetString("starttime");
            this.endtime = DTRequest.GetString("endtime");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.a_no = DTRequest.GetString("a_no");
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("auction_order_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind(CombSqlTxt(this.status, this.winstatus, this.starttime, this.endtime, this.keywords, this.a_no), "status asc,payment_time desc,order_no desc");
            }
        }
        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (this.status > 0)
            {
                this.ddlStatus.SelectedValue = this.status.ToString();
            }
            if (this.winstatus > 0)
            {
                this.ddlWinStatus.SelectedValue = this.winstatus.ToString();
            }
            txtStartTime.Text = this.starttime;
            txtEndTime.Text = this.endtime;
            txtKeywords.Text = this.keywords;
            _strWhere = "1 = 1" + _strWhere;
            BLL.orders bll = new BLL.orders();
            //DataTable dt = bll.GetList1(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount).Tables[0];
            this.rptList.DataSource = bll.GetList1(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            DataTable dt = bll.GetList1(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount).Tables[0];
            double sumperformance = 0;
            double suncovercharge = 0;
            foreach(DataRow dr in dt.Rows)
            {
                sumperformance = sumperformance + Convert.ToDouble(dr["performance"]);
                suncovercharge = suncovercharge + Convert.ToDouble(dr["cover_charge"]);
            }
            lblperformance.Text = sumperformance.ToString();
            //lblcovercharge.Text = suncovercharge.ToString();

            

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("auction_order_list.aspx", "status={0}&winstatus={1}&keywords={2}&page={3}&a_no={4}&starttime={5}&endtime={6}",
                this.status.ToString(), this.winstatus.ToString(), this.keywords, "__id__", this.a_no, this.starttime, this.endtime);
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int status, int winstatus, string _starttime, string _endtime, string _keywords, string _a_no)
        {
            StringBuilder strTemp = new StringBuilder();
            status -= 1;
            winstatus -= 1;
            _keywords = _keywords.Replace("'", "");
            strTemp.Append(" and Order_type=1");
            if (status >= 0)
            {
                strTemp.Append("and status=" + status);
            }
            if (winstatus >= 0)
            {
                strTemp.Append("and quiz_result=" + winstatus);
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and ([goods_title] like  '%" + _keywords + "%' or [order_no] like '%" + _keywords + "%'or user_name like'%" + keywords + "%')");
            }
            if (!string.IsNullOrEmpty(_a_no))
            {
                strTemp.Append(" and auction_no ='" + _a_no + "'");
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
            if (int.TryParse(Utils.GetCookie("auction_order_list_page_size", "QrcmsPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("auction_order_list.aspx", "keywords={0}&a_no={1}&starttime={2}&endtime={3}", txtKeywords.Text, this.a_no, txtStartTime.Text, txtEndTime.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("auction_order_list_page_size", "QrcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("auction_order_list.aspx", "keywords={0}&a_no={1}&starttime={2}&endtime={3}", this.keywords, this.a_no, this.starttime, this.endtime));
        }


        /// <summary>
        /// 订单状态
        /// </summary>
        /// <param name="cardid"></param>
        /// <returns></returns>
        protected string GetOrderType(int type)
        {
            if (type == 0)
            {
                return "已付款";
            }
            else if (type == 1)
            {
                return "待发货";
            }
            else if (type == 2)
            {
                return "已发货";
            }
            else if (type == 3)
            {
                return "已完成";
            }
            else
            {
                return "";
            }
        }

        #region 中奖状态=============================
        protected string GetOrderStatus(int win_status)
        {
            if (win_status == 0)
            {
                return "待开奖";
            }
            else if (win_status == 1)
            {
                return "已中奖";
            }
            else if (win_status == 2)
            {
                return "未中奖";
            }
            else
            {
                return "";
            }
        }
        #endregion

        /// <summary>
        /// 订单状态、中奖状态
        /// </summary>
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("auction_order_list.aspx", "status={0}&winstatus={1}&keywords={2}&ordertype={3}&a_no={4}&starttime={5}&endtime={6}", ddlStatus.SelectedValue, ddlWinStatus.SelectedValue, this.keywords, ddlStatus.SelectedValue.Trim(), this.a_no, this.starttime, this.endtime));
        }
        protected string GetStatus(int _id)
        {
            string _title = string.Empty;
            Model.orders model = new BLL.orders().GetModel(_id);
            switch (model.status)
            {
                case 1: //如果是线下支付，支付状态为0，如果是线上支付，支付成功后会自动改变订单状态为已确认
                    if (model.payment_status > 0)
                    {
                        _title = "待付款";
                    }
                    else
                    {
                        _title = "待确认";
                    }
                    break;
                case 2: //如果订单为已确认状态，则进入发货状态
                    if (model.express_status > 1)
                    {
                        _title = "已发货";
                    }
                    else
                    {
                        if (model.accept_name == "")
                        {
                            _title = "已付款";
                        }
                        else
                        {
                            _title = "待发货";
                        }
                    }
                    break;
                case 3:
                    _title = "交易完成";
                    break;
                case 4:
                    _title = "已取消";
                    break;
                case 5:
                    _title = "已作废";
                    break;
            }
            //switch (model.status)
            //{
            //    case 1: //如果是线下支付，支付状态为0，如果是线上支付，支付成功后会自动改变订单状态为已确认
            //        if (model.payment_status > 0)
            //        {
            //            _title = "待付款";
            //        }
            //        else
            //        {
            //            _title = "待确认";
            //        }
            //        break;
            //    case 2: //如果订单为已确认状态，则进入发货状态
            //        if (model.express_status > 1)
            //        {
            //            _title = "已发货";
            //        }
            //        else
            //        {
            //            _title = "待发货";
            //        }
            //        break;
            //    case 3:
            //        _title = "交易完成";
            //        break;
            //    case 4:
            //        _title = "已取消";
            //        break;
            //    case 5:
            //        _title = "已作废";
            //        break;
            //}

            return _title;
        }
        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("auction_order_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.orders bll = new BLL.orders();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((HiddenField)rptList.Items[i].FindControl("hidId")).Value;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(Utils.StrToInt(id, 0)))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除订单成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("auction_order_list.aspx", "status={0}&winstatus={1}&keywords={2}&ordertype={3}&a_no={4}&starttime={5}&endtime={6}",
                this.status.ToString(), this.winstatus.ToString(), this.keywords, this.ordertype.ToString(), this.a_no, this.starttime, this.endtime));
        }
    }
}