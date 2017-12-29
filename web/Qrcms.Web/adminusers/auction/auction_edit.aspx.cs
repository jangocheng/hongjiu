using Qrcms.API.Weixin.Common;
using Qrcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qrcms.Web.adminusers.auction
{
    public partial class auction_edit : Web.UI.UsersPage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        protected string no="";

        //页面加载事件
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");

            //如果是编辑或复制则检查信息是否存在
            if (_action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = _action;//修改或复制类型
                this.no = DTRequest.GetQueryString("no");
                if (string.IsNullOrEmpty(this.no))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.auction().Exists(this.no))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("auction_list", DTEnums.ActionEnum.View.ToString()); //检查权限               
            }
        }



        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.auction model = new Model.auction();
            BLL.auction bll = new BLL.auction();

            model.no = new Qrcms.BLL.siteconfig().getcodebh("U", "dt_auction", "no");
            model.title = txtTitle.Text.Trim();
            model.quiz_no = Utils.StrToInt(txtQuiz_no.Text.Trim(), 0);
            int i = Utils.StrToInt(txtQuiz_no.Text.Trim(), 0);
            string play1 = "0",play2="3",play3="7";
            if (i % 2 == 0) //玩法1（奇偶）
            {
                play1 = "2";
            }
            else
            {
                play1 = "1";
            }            
            char[] ch_num = txtQuiz_no.Text.Trim().ToCharArray();
            int last_num =Convert.ToInt32(ch_num[ch_num.Length-1].ToString());
            if (last_num >= 0 && last_num <= 3)  //玩法2（大中小）
            {
                play2 = "3";
            }
            else if (last_num <= 4 && last_num >= 6)
            {
                play2 = "4";
            }
            else
            {
                play2 = "5";
            }
            for (int p = 0; p < ch_num.Length - 1; p++) //玩法3（牛牛）
            {
                if (play3 == "6") { break; }              
                for (int j = p + 1; j < ch_num.Length; j++)
                {
                    if (play3 == "6")
                    {
                        break;
                    }
                    for (int k = j + 1; k < ch_num.Length; k++)
                    {
                        int temp = Convert.ToInt32(ch_num[p].ToString()) + Convert.ToInt32(ch_num[j].ToString()) + Convert.ToInt32(ch_num[k].ToString());
                        if (temp == 0 || temp == 10 || temp == 20)
                        {
                            play3 = "6";
                            break;
                        }
                    }
                }
            }
            model.quiz_result =Convert.ToInt32(play1 + play2 + play3);
            model.quiz_date = Utils.StrToDateTime(txtQuiz_date.Text.Trim());
            model.create_time = DateTime.Now;
            model.create_user = GetAdminInfo().user_name; //获得当前登录用户名

            if (bll.AddNew(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加竞拍成功:" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion
       

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("auction_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
            if (!DoAdd())
            {
                JscriptMsg("保存过程中发生错误！", string.Empty);
                return;
            }
            JscriptMsg("添加信息成功！", "auction_list.aspx");
        }
        
    }
}