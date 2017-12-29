using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;


namespace Qrcms.Web.adminusers.users
{
    public partial class users_xiaji : Web.UI.UsersPage
    {
            protected int totalCount;
            protected int page;
            protected int pageSize;
            protected Model.users admin_info; //管理员信息
            protected int group_id;
            protected string keywords = string.Empty;
            protected Model.users model = new Model.users();
            protected void Page_Load(object sender, EventArgs e)
            {
                ChkAdminLevel("users_xiaji", DTEnums.ActionEnum.View.ToString()); //检查权限
                this.group_id = DTRequest.GetQueryInt("group_id");
                this.keywords = DTRequest.GetQueryString("keywords");

                this.pageSize = GetPageSize(10); //每页数量
                if (!Page.IsPostBack)
                {
                    TreeBind("is_lock=0"); //绑定类别
                    admin_info = GetAdminInfo();
                    RptBind("level!=0  ", " fn_Getchildlist.user_name desc", this.txtKeywords.Text.Trim());
                    
                }
            }

            #region 返回用户状态=============================
            protected string GetUserStatus(int status)
            {
                string result = string.Empty;
                switch (status)
                {
                    case 0:
                        result = "正常";
                        break;
                    case 1:
                        result = "待验证";
                        break;
                    case 2:
                        result = "待审核";
                        break;
                    case 3:
                        result = "已禁用";
                        break;
                }
                return result;
            }
            #endregion
            #region 绑定组别=================================
            private void TreeBind(string strWhere)
            {
                BLL.user_groups bll = new BLL.user_groups();
                DataTable dt = bll.GetList(0, strWhere, "id desc").Tables[0];

                this.ddlGroupId.Items.Clear();
                this.ddlGroupId.Items.Add(new ListItem("所有会员组", ""));
                foreach (DataRow dr in dt.Rows)
                {
                    this.ddlGroupId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
                }
            }
            #endregion
            #region 数据绑定=================================
            private void RptBind(string _strWhere, string _orderby, string _user_name)
            {
                this.page = DTRequest.GetQueryInt("page", 1);
                this.txtKeywords.Text = this.keywords;
                _user_name = this.keywords;
                if (this.group_id > 0)
                {
                    this.ddlGroupId.SelectedValue = this.group_id.ToString();
                }
                    admin_info = GetAdminInfo();
                    _user_name = admin_info.user_name;
                if (group_id > 0)
                {
                   _strWhere+=" and group_id=" + group_id;
                }
                if (keywords.ToString() != "")
                {
                    _strWhere += " and fn_Getchildlist.user_name in ( select user_name from  fn_Getchildlist('" + keywords + "')) ";

                }
                BLL.users bll = new BLL.users();
                this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount, _user_name);
                this.rptList.DataBind();

                //绑定页码
                txtPageNum.Text = this.pageSize.ToString();
                string pageUrl = Utils.CombUrlTxt("users_xiaji.aspx", "group_id={0}&keywords={1}&page={2}",
                    this.group_id.ToString(), this.keywords, "__id__");
                PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            }
            #endregion


            #region 返回用户每页数量=========================
            private int GetPageSize(int _default_size)
            {
                int _pagesize;
                if (int.TryParse(Utils.GetCookie("users_xiaji_page_size", "QrcmsPage"), out _pagesize))
                {
                    if (_pagesize > 0)
                    {
                        return _pagesize;
                    }
                }
                return _default_size;
            }
            #endregion

            public string kkz(object username)
            {
                BLL.users bll = new BLL.users();
                int oid = 0;
                object idd=DBUtility.DbHelperSQL.GetSingle(" select id from dt_users where user_name='"+username+"'");
                if(idd!=null)
                {
                    oid = Convert.ToInt32(Utils.ObjToInt(idd));
                }
                model = bll.GetModel(oid);
                return model.nick_name;
            
            }

            public string time(object username)
            {
                BLL.users bll = new BLL.users();
                int oid = 0;
                object idd = DBUtility.DbHelperSQL.GetSingle(" select id from dt_users where user_name='" + username + "'");
                if (idd != null)
                {
                    oid = Convert.ToInt32(Utils.ObjToInt(idd));
                }
                model = bll.GetModel(oid);
                return model.reg_time.ToString();

            }
            //关健字查询
            protected void btnSearch_Click(object sender, EventArgs e)
            {
                Response.Redirect(Utils.CombUrlTxt("users_xiaji.aspx", "group_id={0}&keywords={1}",
                    this.group_id.ToString(), txtKeywords.Text));
            }

            //设置分页数量
            protected void txtPageNum_TextChanged(object sender, EventArgs e)
            {
                int _pagesize;
                if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
                {
                    if (_pagesize > 0)
                    {
                        Utils.WriteCookie("users_xiaji_page_size", "QrcmsPage", _pagesize.ToString(), 14400);
                    }
                }
                Response.Redirect(Utils.CombUrlTxt("users_xiaji.aspx", "group_id={0}&keywords={1}",
                    this.group_id.ToString(), this.keywords));
            }
            //筛选类别
            protected void ddlGroupId_SelectedIndexChanged(object sender, EventArgs e)
            {
                Response.Redirect(Utils.CombUrlTxt("users_xiaji.aspx", "group_id={0}&keywords={1}",
                    ddlGroupId.SelectedValue, this.keywords));
            }
        
    }
}