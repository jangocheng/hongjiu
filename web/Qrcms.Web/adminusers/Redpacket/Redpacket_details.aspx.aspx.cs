using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;

namespace Qrcms.Web.adminusers.Redpacket
{
    public partial class Redpacket_details_aspx : Web.UI.UsersPage
    {
        private string no = null;
        protected Model.auction_order model = new Model.auction_order();
        protected Model.auction model2 = new Model.auction();
        protected string type = "";
        protected string typedes = "";
        public string shangjiamingcheng = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.no = DTRequest.GetQueryString("no");
            if (string.IsNullOrEmpty(no))
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (!new BLL.auction_order().Exists1("no='" + this.no + "'"))
            {
                JscriptMsg("记录不存在或已被删除！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("Redpacket_details", DTEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo(this.no);
            }
        }
        #region 赋值操作=================================
        private void ShowInfo(string no)
        {
            //查询订单商品表
            BLL.auction_order bll = new BLL.auction_order();
            model = bll.GetModelbya_no(no);

            //查询竞拍订单表
            BLL.auction bll2 = new BLL.auction();
            model2 = bll2.GetModel(model.a_no);

            bll = new BLL.auction_order();


            //绑定商品列表
            this.rptList.DataSource = bll.GetList(1, "no = '" + no + "'", "createdate desc");
            this.rptList.DataBind();
            //获得会员信息
            if (string.IsNullOrEmpty(model.user_name))
            {
                Model.users user_info = new BLL.users().GetModel(model.user_name);
                if (user_info != null)
                {
                    Model.user_groups group_info = new BLL.user_groups().GetModel(user_info.group_id);
                    if (group_info != null)
                    {
                        dlUserInfo.Visible = true;
                        lbUserName.Text = user_info.user_name;
                        lbUserGroup.Text = group_info.title;
                        //lbUserDiscount.Text = group_info.discount.ToString() + " %";
                        lbUserAmount.Text = user_info.amount.ToString();
                        lbUserPoint.Text = user_info.point.ToString();
                    }
                }
            }
            //根据订单状态，显示各类操作按钮
            switch (model.win_status)
            {
                case 0://待开奖 无按钮

                    break;
                case 1: //中奖 完成订单 按钮
                    switch (model.status)
                    {
                        case 3://待发货
                            btnComplete.Visible = false;
                            break;
                        default://已发货
                            btnComplete.Visible = true;
                            break;
                    }
                    break;
                case 2://未中奖
                    switch (model.status)
                    {
                        case 1://待发货
                            btnExpress.Visible = true;
                            break;
                        case 2://已发货
                            btnComplete.Visible = true;
                            break;
                    }
                    break;
            }

            //根据订单状态和物流单号跟踪物流信息
            if (model.status == 2)
            {
                Model.express modelt = new BLL.express().GetModel(model.express_id);
                Model.orderconfig orderConfig = new BLL.orderconfig().loadConfig();
                if (modelt != null && modelt.express_code.Trim().Length > 0 && orderConfig.kuaidiapi != "")
                {
                    string apiurl = orderConfig.kuaidiapi + "?id=" + orderConfig.kuaidikey + "&com=" + modelt.express_code + "&nu=" + model.express_no + "&show=" + orderConfig.kuaidishow + "&muti=" + orderConfig.kuaidimuti + "&order=" + orderConfig.kuaidiorder;
                    string detail = Utils.HttpGet(@apiurl);
                    if (detail != null)
                    {
                        litExpressDetail.Text = Utils.ToHtml(detail);
                    }
                }
            }

        }
        #endregion


        #region 运送方式=================================
        protected string Express(int id)
        {
            if (id == 5)
            {
                return "京东物流";
            }
            else if (id == 7)
            {
                return "EMS";
            }
            else if (id == 8)
            {
                return "申通快递";
            }
            else if (id == 10)
            {
                return "圆通快递";
            }
            else if (id == 11)
            {
                return "中通物流";
            }
            else if (id == 12)
            {
                return "汇通快递(百世)";
            }
            else if (id == 13)
            {
                return "天天快递";
            }
            else if (id == 15)
            {
                return "德邦物流";
            }
            else if (id == 17)
            {
                return "韵达";
            }
            else if (id == 18)
            {
                return "安能快递";
            }
            else if (id == 19)
            {
                return "远成物流";
            }
            else if (id == 20)
            {
                return "顺丰";
            }
            else
            {
                return "";
            }
        }
        #endregion


        #region 支付总额=================================
        protected decimal Count()
        {
            decimal sum = model.amount + model.express_fee;
            return sum;
        }
        #endregion
    }

}