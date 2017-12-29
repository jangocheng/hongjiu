﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;

namespace Qrcms.Web.adminusers.users
{
    public partial class oauth_app_edit : Web.UI.UsersPage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.user_oauth_app().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("user_oauth", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.user_oauth_app bll = new BLL.user_oauth_app();
            Model.user_oauth_app model = bll.GetModel(_id);
            txtTitle.Text = model.title;
            if (model.is_lock == 0)
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            rblIsMobile.SelectedValue = model.is_mobile.ToString();
            txtSortId.Text = model.sort_id.ToString();
            txtApiPath.Text = model.api_path;
            txtAppId.Text = model.app_id;
            txtAppKey.Text = model.app_key;
            txtImgUrl.Text = model.img_url;
            txtRemark.Text = model.remark;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.user_oauth_app model = new Model.user_oauth_app();
            BLL.user_oauth_app bll = new BLL.user_oauth_app();

            model.title = txtTitle.Text.Trim();
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.is_mobile = Utils.StrToInt(rblIsMobile.SelectedValue, 0);
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.api_path = txtApiPath.Text.Trim();
            model.app_id = txtAppId.Text.Trim();
            model.app_key = txtAppKey.Text.Trim();
            model.img_url = txtImgUrl.Text.Trim();
            model.remark = txtRemark.Text;
            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加OAuth信息:" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.user_oauth_app bll = new BLL.user_oauth_app();
            Model.user_oauth_app model = bll.GetModel(_id);

            model.title = txtTitle.Text.Trim();
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.is_mobile = Utils.StrToInt(rblIsMobile.SelectedValue, 0);
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.api_path = txtApiPath.Text.Trim();
            model.app_id = txtAppId.Text.Trim();
            model.app_key = txtAppKey.Text.Trim();
            model.img_url = txtImgUrl.Text.Trim();
            model.remark = txtRemark.Text;
            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改OAuth信息:" + model.title); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("user_oauth", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", string.Empty);
                    return;
                }
                JscriptMsg("修改OAuth应用成功！", "oauth_app_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("user_oauth", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", string.Empty);
                    return;
                }
                JscriptMsg("添加OAuth应用成功！", "oauth_app_list.aspx");
            }
        }

    }
}