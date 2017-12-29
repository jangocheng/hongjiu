using Qrcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qrcms.Web.admin.Redpacket
{
    public partial class Redpacket_comment_add : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private string no;
        private int goodid;
        private int id;

        //页面加载事件
        protected void Page_Load(object sender, EventArgs e)
        {

            string _action = DTRequest.GetQueryString("action");

            //如果是编辑或复制则检查信息是否存在
            this.action = _action;//修改或复制类型
            this.no = DTRequest.GetQueryString("no");
            this.goodid = DTRequest.GetQueryInt("goodid", 0);

            if (string.IsNullOrEmpty(this.no))
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (this.goodid == 0)
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (this.action != DTEnums.ActionEnum.Add.ToString())
            {
                this.id = DTRequest.GetQueryInt("id", 0);
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("Redpacket_list", DTEnums.ActionEnum.View.ToString()); //检查权限               

                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo();
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            BLL.auction_comment bll = new BLL.auction_comment();
            Model.auction_comment model = bll.GetModel(this.id);
            name.Text = model.user_name;
            txtTitle.Text = model.title;
            remark.InnerText = model.content;

        }
        #endregion


        #region 增加操作=================================
        private void DoAdd()
        {
            Model.auction_comment model = new Model.auction_comment();
            BLL.auction_comment bll = new BLL.auction_comment();

            model.add_time = DateTime.Now;
            model.article_id = this.goodid;
            model.auction_no = this.no;
            model.content = remark.Value;
            model.title = txtTitle.Text;
            model.user_name = name.Text;

            Model.users user = new BLL.users().GetModel(model.user_name);
            if (user == null)
            {
                JscriptMsg("不存在此会员！", string.Empty);
                return;
            }

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加评论内容:" + model.title); //记录日志
                JscriptMsg("添加成功！", "Redpacket_comment_list.aspx?no=" + this.no + "&goodid=" + this.goodid);
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", string.Empty);
            }
        }
        #endregion

        #region 修改操作=================================
        private void DoEdit()
        {
            BLL.auction_comment bll = new BLL.auction_comment();
            Model.auction_comment model = bll.GetModel(this.id);

            model.content = remark.Value;
            model.title = txtTitle.Text;
            model.user_name = name.Text;

            Model.users user = new BLL.users().GetModel(model.user_name);
            if (user == null)
            {
                JscriptMsg("不存在此会员！", string.Empty);
                return;
            }

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改评论内容:" + model.title); //记录日志
                JscriptMsg("修改信息成功！", "Redpacket_comment_list.aspx?no=" + this.no + "&goodid=" + this.goodid);
            }
            else
            {
                JscriptMsg("保存过程中发生错误啦！", string.Empty);
            }
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("Redpacket_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                DoEdit();
            }
            else //添加
            {
                ChkAdminLevel("Redpacket_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                DoAdd();
            }
        }
    }

}