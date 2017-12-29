using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;

namespace Qrcms.Web.admin.order
{
    public partial class order_yj_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string starttime = "";
        protected string endtime = "";
        protected int status;
        protected int payment_status;
        protected int express_status;
        protected int if_upgrade;
        protected string quizresult;
        protected string keywords = string.Empty;
        protected string dlsmz = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.starttime = DTRequest.GetString("starttime");
            this.endtime = DTRequest.GetString("endtime");
            this.status = DTRequest.GetQueryInt("status");
            this.payment_status = DTRequest.GetQueryInt("payment_status");
            this.express_status = DTRequest.GetQueryInt("express_status");
            this.if_upgrade = DTRequest.GetQueryInt("if_upgrade");
            this.quizresult = DTRequest.GetQueryString("quizresult");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.dlsmz = DTRequest.GetQueryString("dls");
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("order_yj_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (dlsmz.Trim() != "")
                {
                    RptBind("dt_orders.id>0" + CombSqlTxt(this.status, this.payment_status, this.express_status, this.if_upgrade, this.starttime, this.endtime, this.keywords, this.dlsmz), "status asc,add_time desc,dt_orders.id desc");
                }
                else
                {
                    RptBind("dt_orders.id>0 and 1>2" + CombSqlTxt(this.status, this.payment_status, this.express_status, this.if_upgrade, this.starttime, this.endtime, this.keywords, this.dlsmz), "status asc,add_time desc,dt_orders.id desc");

                }
            }
        }
        protected string getUp(int up)
        {
            if (up == 1)
            {
                return "升级";

            }
            if (up == 2)
            {
                return "红包";

            }
            return "";

        }
        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (this.status > 0)
            {
                this.ddlStatus.SelectedValue = this.status.ToString();
            }
            if (this.payment_status > 0)
            {
                this.ddlPaymentStatus.SelectedValue = this.payment_status.ToString();
            }
            if (this.express_status > 0)
            {
                this.ddlExpressStatus.SelectedValue = this.express_status.ToString();
            }
            if (this.if_upgrade > 0)
            {
                this.ddlifupgrade.SelectedValue = this.if_upgrade.ToString();
            }
            if (this.quizresult != "中奖状态" && this.quizresult != "" && this.quizresult != "0")
            {
                this.ddlquizresult.SelectedValue = this.quizresult.ToString();
            }
            txtStartTime.Text = this.starttime;
            txtEndTime.Text = this.endtime;
            txtKeywords.Text = this.keywords;
            Txtdls.Text = this.dlsmz;
            BLL.orders bll = new BLL.orders();
            Session["page"] = this.page;
            this.rptList.DataSource = bll.GetList2(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            DataTable dt = bll.GetList2(_strWhere).Tables[0];
            Session["_strWhere"] = _strWhere;
            double sumperformance = 0;
            double suncovercharge = 0;
            double zczje = 0;
            double sumperformance2 = 0;
            double suncovercharge2 = 0;
            double sumperformance3 = 0;
            double suncovercharge3 = 0;
            int sl = 0;
            double sxf = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sumperformance = sumperformance + Convert.ToDouble(dr["performance"]);
                //suncovercharge = suncovercharge + Convert.ToDouble(dr["cover_charge"]);
                zczje = zczje + Convert.ToDouble(dr["order_amount"]);
                sl = sl + Convert.ToInt32(dr["quantity"]);
                if (dr["order_type"].ToString() == "1")
                {
                    sxf = sxf + Convert.ToDouble(dr["order_amount"]) * 0.05;
                    sumperformance2 = sumperformance2 + Convert.ToDouble(dr["performance"]);
                    //suncovercharge2 = suncovercharge2 + Convert.ToDouble(dr["cover_charge"]);
                }
                else if (dr["order_type"].ToString() == "2")
                {
                    sumperformance3 = sumperformance3 + Convert.ToDouble(dr["performance"]);
                    //suncovercharge3 = suncovercharge3 + Convert.ToDouble(dr["cover_charge"]);
                    
                }
                //if (Convert.ToInt32(dr["order_type"]) == 2) 
               
            }
            lblperformance.Text = sumperformance.ToString("0.00");
            //lblcovercharge.Text = suncovercharge.ToString("0.00");
            Label1.Text = zczje.ToString("0.00");
            Lbsj.Text = sumperformance2.ToString("0.00");
            //Lbsjfw.Text = suncovercharge2.ToString("0.00");
            lbhb.Text = sumperformance3.ToString("0.00");
            //lbhbfw.Text = suncovercharge3.ToString("0.00");
            Label2.Text = sl.ToString("0.00");
            Label4.Text = sxf.ToString("0.0");
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("order_yj_list.aspx", "status={0}&payment_status={1}&express_status={2}&if_upgrade={3}&keywords={4}&page={5}&starttime={6}&endtime={7}&dls={8}&quizresult={9}",
                this.status.ToString(), this.payment_status.ToString(), this.express_status.ToString(), this.if_upgrade.ToString(), this.keywords, "__id__", this.starttime, this.endtime, this.dlsmz, this.quizresult.ToString());
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _status, int _payment_status, int _express_status, int _if_upgrade, string _starttime, string _endtime, string _keywords, string dls)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_status > 0)
            {
                strTemp.Append(" and status=" + _status);
            }
            if (dls != "")//dls
            {
                strTemp.Append(" and user_name in ( select user_name FROM fn_Getchildlist ('" + dls + "') ) ");
            }
            if (_payment_status > 0)
            {
                strTemp.Append(" and payment_status=" + _payment_status);
            }
            if (quizresult != "中奖状态" && this.quizresult != "" && this.quizresult != "0")
            {
                strTemp.Append(" and quiz_result=" + Convert.ToString(Convert.ToInt32(quizresult) - 1));
            }
            if (_express_status > 0)
            {
                strTemp.Append(" and isnull(accept_name,'')!='' and express_status=" + _express_status);
            }
            if (!string.IsNullOrEmpty(_starttime))
            {
                strTemp.Append(" and DATEDIFF(day,'" + _starttime + "',add_time) >=0");
            }
            if (!string.IsNullOrEmpty(_endtime))
            {
                strTemp.Append(" and DATEDIFF(day,'" + _endtime + "',add_time) <=0");
            }
            if (_if_upgrade > 0)
            {
                if (_if_upgrade != 3)
                {
                    strTemp.Append(" and order_type=" + _if_upgrade);
                }
                else
                {
                    strTemp.Append(" and order_type=0");
                }
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (order_no like '%" + _keywords + "%' or user_name like '%" + _keywords + "%' or goods_title like '%" + _keywords + "%' or accept_name like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("order_yj_list_page_size", "QrcmsPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #region 返回订单状态=============================
        protected string GetOrderStatus(int _id)
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

            return _title;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("order_yj_list.aspx", "status={0}&payment_status={1}&express_status={2}&if_upgrade={3}&keywords={4}&starttime={5}&endtime={6}&dls={7}&quizresult={8}",
                this.status.ToString(), this.payment_status.ToString(), this.express_status.ToString(), this.if_upgrade.ToString(), txtKeywords.Text, txtStartTime.Text, txtEndTime.Text, Txtdls.Text, ddlquizresult.SelectedValue));
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            BLL.orders bll = new BLL.orders();
            int pages = 0;
            if (Session["page"] != null)
            {
                pages = Utils.ObjToInt(Session["page"].ToString(), 0);
            }
            DataTable dt2 = bll.GetListdc(Session["_strWhere"].ToString()).Tables[0];
            if (dt2.Rows.Count > 0)
            {
                double sumperformance = 0;
                double suncovercharge = 0;
                double sumperformance2 = 0;
                double suncovercharge2 = 0;
                double sumperformance3 = 0;
                double suncovercharge3 = 0;
                double zczje = 0;
                int sl = 0;
                foreach (DataRow dr in dt2.Rows)
                {
                    dr["总金额"] = dr["总金额"].ToString();
                    sumperformance = sumperformance + Convert.ToDouble(dr["业绩"]);
                    //suncovercharge = suncovercharge + Convert.ToDouble(dr["服务费"]);
                    zczje = zczje + Convert.ToDouble(dr["总金额"]);
                    sl = sl + Convert.ToInt32(dr["数量"]);
                    if (dr["是否升级"].ToString().Trim() == "升级")
                    {
                        sumperformance2 = sumperformance2 + Convert.ToDouble(dr["业绩"]);
                        // suncovercharge2 = suncovercharge2 + Convert.ToDouble(dr["服务费"]);

                    }
                    else if (dr["是否升级"].ToString().Trim() == "红包")
                    {
                        sumperformance3 = sumperformance3 + Convert.ToDouble(dr["业绩"]);
                        //suncovercharge3 = suncovercharge3 + Convert.ToDouble(dr["服务费"]);
                    }

                }
                DataRow dr2 = dt2.NewRow();
                dr2["订单号"] = "业绩汇总：" + sumperformance.ToString("0.00") + " 元";
                dr2["是否升级"] = "升级业绩汇总：" + sumperformance2.ToString("0.00") + " 元";
                dr2["订单状态"] = " 红包业绩汇总：" + sumperformance3.ToString("0.00") + " 元" + " 总金额汇总：" + zczje.ToString("0.00") + " 元" + " 商品数量统计：" + sl.ToString("0.00") + " ";
                dt2.Rows.Add(dr2);
                dt2.Columns.RemoveAt(0);
            }
            if (dt2 != null)
            {
                if (dlsmz.Trim() != "")
                {
                    try
                    {
                        NPOIHelper.ExportToExcel(dt2);
                    }
                    catch
                    {
                        JscriptMsg("导出失败！", "back");
                        return;
                    }
                }
            }
        }
        //订单状态
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("order_yj_list.aspx", "status={0}&payment_status={1}&express_status={2}&if_upgrade={3}&keywords={4}&starttime={5}&endtime={6}&dls={7}&quizresult={8}",
               ddlStatus.SelectedValue, this.payment_status.ToString(), this.express_status.ToString(), this.if_upgrade.ToString(), txtKeywords.Text, txtStartTime.Text, txtEndTime.Text, Txtdls.Text, ddlquizresult.SelectedValue));
        }

        //支付状态
        protected void ddlPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("order_yj_list.aspx", "status={0}&payment_status={1}&express_status={2}&if_upgrade={3}&keywords={4}&starttime={5}&endtime={6}&dls={7}&quizresult={8}",
                              this.status.ToString(), ddlPaymentStatus.SelectedValue, this.express_status.ToString(), this.if_upgrade.ToString(), txtKeywords.Text, txtStartTime.Text, txtEndTime.Text, Txtdls.Text, ddlquizresult.SelectedValue));
        }

        //发货状态
        protected void ddlExpressStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("order_yj_list.aspx", "status={0}&payment_status={1}&express_status={2}&if_upgrade={3}&keywords={4}&starttime={5}&endtime={6}&quizresult={7}&dls={8}",
                this.status.ToString(), this.payment_status.ToString(), ddlExpressStatus.SelectedValue, this.if_upgrade.ToString(), this.keywords, this.starttime, this.endtime, this.ddlquizresult.SelectedValue, Txtdls.Text));
        }

        //升级状态
        protected void ddlifupgrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if_upgrade = Convert.ToInt32(ddlifupgrade.SelectedValue); ;
            Response.Redirect(Utils.CombUrlTxt("order_yj_list.aspx", "status={0}&payment_status={1}&express_status={2}&if_upgrade={3}&keywords={4}&starttime={5}&endtime={6}&dls={7}&quizresult={8}",
                this.status.ToString(), this.payment_status.ToString(), this.express_status.ToString(), this.if_upgrade.ToString(), txtKeywords.Text, txtStartTime.Text, txtEndTime.Text, Txtdls.Text, ddlquizresult.SelectedValue));
        }
        //中奖状态
        protected void ddlquizresult_SelectedIndexChanged(object sender, EventArgs e)
        {

            Response.Redirect(Utils.CombUrlTxt("order_yj_list.aspx", "status={0}&payment_status={1}&express_status={2}&if_upgrade={3}&keywords={4}&starttime={5}&endtime={6}&quizresult={7}&dls={8}",
                   this.status.ToString(), this.payment_status.ToString(), ddlExpressStatus.SelectedValue, this.if_upgrade.ToString(), this.keywords, this.starttime, this.endtime, ddlquizresult.SelectedValue, Txtdls.Text));

        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("order_yj_list_page_size", "QrcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("order_yj_list.aspx", "status={0}&payment_status={1}&express_status={2}&if_upgrade={3}&keywords={4}&starttime={5}&endtime={6}&dls={7}&quizresult={8}",
               this.status.ToString(), this.payment_status.ToString(), this.express_status.ToString(), this.if_upgrade.ToString(), txtKeywords.Text, txtStartTime.Text, txtEndTime.Text, Txtdls.Text, ddlquizresult.SelectedValue));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("order_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.orders bll = new BLL.orders();
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
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除订单成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("order_yj_list.aspx", "status={0}&payment_status={1}&express_status={2}&if_upgrade={3}&keywords={4}&starttime={5}&endtime={6}&dls={7}&quizresult={8}",
                this.status.ToString(), this.payment_status.ToString(), this.express_status.ToString(), this.if_upgrade.ToString(), this.keywords, this.starttime, this.endtime, Txtdls.Text, ddlquizresult.SelectedValue));
        }


    }
}