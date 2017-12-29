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

namespace Qrcms.Web.admin.Redpacket
{
    public partial class Redpacket_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        protected string no = "";

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

                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.no);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(string _no)
        {
            BLL.auction bll = new BLL.auction();
            Model.auction model = bll.GetModel(_no);

            good_id.Value = model.article_id.ToString();
            goodimg.Text = model.article_img;
            name.Text = model.article_title;
            banner.Text = model.banner;
            gooddesc.Value = model.describe;
            endtime.Text = model.end_date.ToString("yyyy-MM-dd HH:mm:ss");
            highprice.Text = model.high_price.ToString();
            lowprice.Text = model.low_price.ToString();
            count.Value = model.layer.ToString();
            remark.Value = model.remark;
            txtTitle.Text = model.title;
            saleprice.Text = model.sale_price.ToString();
            float_num.Text = model.float_num.ToString();

            if (model.recommend == 1)
            {
                cblItem.Items[0].Selected = true;
            }
        }
        #endregion


        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.auction model = new Model.auction();
            BLL.auction bll = new BLL.auction();

            model.no = new Qrcms.BLL.siteconfig().getcodebh("U", "dt_auction", "no");
            model.article_id = Utils.StrToInt(good_id.Value, 0);
            model.article_img = goodimg.Text;
            model.article_title = name.Text;
            model.banner = banner.Text;
            model.create_time = DateTime.Now;
            model.create_user = GetAdminInfo().user_name; //获得当前登录用户名

            //是否将编辑器远程图片保存到本地
            if (siteConfig.fileremote == 1)
            {
                model.describe = AutoRemoteImageSave(gooddesc.Value);
            }
            else
            {
                model.describe = gooddesc.Value;
            }
            model.end_date = Utils.StrToDateTime(endtime.Text);
            model.high_price = Utils.StrToDecimal(highprice.Text, 0);
            model.low_price = Utils.StrToDecimal(lowprice.Text, 0);
            model.layer = Utils.StrToInt(count.Value, 0);
            model.publish_date = model.end_date.AddHours(1);
            model.recommend = 0;
            if (cblItem.Items[0].Selected)
            {
                model.recommend = 1;
            }
            model.remark = remark.Value;
            model.sale_price = Utils.StrToDecimal(saleprice.Text, 0);
            model.title = txtTitle.Text;
            model.float_num = Utils.StrToDecimal(float_num.Text, 0);


            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加竞拍成功:" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion
        #region 保存远程图片到本地=======================
        private string AutoRemoteImageSave(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return string.Empty;
            }
            Web.UI.UpLoad upload = new UI.UpLoad();
            Regex reg = new Regex("IMG[^>]*?src\\s*=\\s*(?:\"(?<1>[^\"]*)\"|'(?<1>[^\']*)')", RegexOptions.IgnoreCase);
            MatchCollection m = reg.Matches(content);
            foreach (Match math in m)
            {
                string imgUri = math.Groups[1].Value;
                if (imgUri.StartsWith("http"))
                {
                    string newImgPath = upload.remoteSaveAs(imgUri);
                    if (newImgPath != string.Empty)
                    {
                        content = content.Replace(imgUri, newImgPath);
                    }
                }
            }
            return content;
        }
        #endregion
        #region 修改操作=================================
        private bool DoEdit(string _no)
        {
            bool result = false;

            BLL.auction bll = new BLL.auction();
            Model.auction model = bll.GetModel(_no);

            model.article_id = Utils.StrToInt(good_id.Value, 0);
            model.article_img = goodimg.Text;
            model.article_title = name.Text;
            model.banner = banner.Text;
            model.create_time = DateTime.Now;
            model.create_user = GetAdminInfo().user_name; //获得当前登录用户名
            model.describe = gooddesc.InnerText;
            //是否将编辑器远程图片保存到本地
            if (siteConfig.fileremote == 1)
            {
                model.describe = AutoRemoteImageSave(gooddesc.Value);
            }
            else
            {
                model.describe = gooddesc.Value;
            }
            model.end_date = Utils.StrToDateTime(endtime.Text);
            model.high_price = Utils.StrToDecimal(highprice.Text, 0);
            model.low_price = Utils.StrToDecimal(lowprice.Text, 0);
            model.layer = Utils.StrToInt(count.Value, 0);
            model.publish_date = model.end_date.AddHours(1);
            model.recommend = 0;
            if (cblItem.Items[0].Selected)
            {
                model.recommend = 1;
            }
            model.remark = remark.Value;
            model.sale_price = Utils.StrToDecimal(saleprice.Text, 0);
            model.title = txtTitle.Text;
            model.float_num = Utils.StrToDecimal(float_num.Text, 0);

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改竞拍内容:" + model.title); //记录日志
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
                ChkAdminLevel("auction_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.no))
                {
                    JscriptMsg("保存过程中发生错误啦！", string.Empty);
                    return;
                }
                JscriptMsg("修改信息成功！", "auction_list.aspx");
            }
            else //添加
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
}