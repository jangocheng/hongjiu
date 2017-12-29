using System;
using System.Xml;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qrcms.Common;

namespace Qrcms.Web.adminusers.order
{
    public partial class payment_edit : Web.UI.UsersPage
    {
        private int id = 0;
        protected Model.payment model = new Model.payment();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");
            if (this.id == 0)
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (!new BLL.payment().Exists(this.id))
            {
                JscriptMsg("支付方式不存在或已删除！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("order_payment", DTEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo(this.id);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.payment bll = new BLL.payment();
            model = bll.GetModel(_id);
            txtTitle.Text = model.title;
            rblType.SelectedValue = model.type.ToString();
            rblType.Enabled = false;
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
            rblPoundageType.SelectedValue = model.poundage_type.ToString();
            txtPoundageAmount.Text = model.poundage_amount.ToString();
            txtImgUrl.Text = model.img_url;
            txtRemark.Text = model.remark;
            if (model.api_path.ToLower() == "alipaypc")
            {
                //支付宝
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/alipaypc.config"));
                txtAlipayPartner.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
                txtAlipayKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
                txtAlipaySellerEmail.Text = doc.SelectSingleNode(@"Root/email").InnerText;
                rblAlipayType.SelectedValue = doc.SelectSingleNode(@"Root/type").InnerText;
            }
            else if (model.api_path.ToLower() == "alipaywap")
            {
                //支付宝
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/alipaywap.config"));
                txtAlipayPartner.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
                txtAlipayKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
                txtAlipaySellerEmail.Text = doc.SelectSingleNode(@"Root/email").InnerText;
                rblAlipayType.SelectedValue = doc.SelectSingleNode(@"Root/type").InnerText;
            }
            else if (model.api_path.ToLower() == "tenpaypc")
            {
                //财付通
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/tenpaypc.config"));
                txtTenpayBargainorId.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
                txtTenpayKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
                rblTenpayType.SelectedValue = doc.SelectSingleNode(@"Root/type").InnerText;
            }
            else if (model.api_path.ToLower() == "chinabankpc")
            {
                //网银在线
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/chinabankpc.config"));
                txtChinaBankPartner.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
                txtChinaBankKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
            }
            else if (model.api_path.ToLower() == "weixinwap")
            {
                //微信支付
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixinwap.config"));
                TxtAppID.Text = doc.SelectSingleNode(@"Root/appid").InnerText;
                TxtAppSecret.Text = doc.SelectSingleNode(@"Root/appsecret").InnerText;
                Txtmechid.Text = doc.SelectSingleNode(@"Root/mechid").InnerText;
                Txtmechkay.Text = doc.SelectSingleNode(@"Root/mechkay").InnerText;
            }
            else if (model.api_path.ToLower() == "weixinkj")
            {
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixinkj.config"));
                txt_mch_id.Text = doc.SelectSingleNode(@"Root/mch_id").InnerText;
                txt_key.Text = doc.SelectSingleNode(@"Root/key").InnerText;
                txt_req_url.Text = doc.SelectSingleNode(@"Root/req_url").InnerText;
                txt_notify_url.Text = doc.SelectSingleNode(@"Root/notify_url").InnerText;
                txt_version.Text = doc.SelectSingleNode(@"Root/version").InnerText;
                
            }
            else if (model.api_path.ToLower() == "weixinsm")
            {
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixinsm.config"));
                Txtservice.Text = doc.SelectSingleNode(@"Root/service").InnerText;
                Txtkey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
                TxtmerchantCode.Text = doc.SelectSingleNode(@"Root/merchantCode").InnerText;
                Txtshmc.Text = doc.SelectSingleNode(@"Root/shmc").InnerText;

            }
            else if (model.api_path.ToLower() == "weixinzf")
            {
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixinzf.config"));
                Txtmch_id.Text = doc.SelectSingleNode(@"Root/mch_id").InnerText;
                Txtmch_number.Text = doc.SelectSingleNode(@"Root/mch_number").InnerText;
                Txtzf_key.Text = doc.SelectSingleNode(@"Root/zf_key").InnerText;

            }
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.payment bll = new BLL.payment();
            Model.payment model = bll.GetModel(_id);

            model.title = txtTitle.Text.Trim();
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.is_mobile = int.Parse(rblIsMobile.SelectedValue);
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.poundage_type = int.Parse(rblPoundageType.SelectedValue);
            model.poundage_amount = decimal.Parse(txtPoundageAmount.Text.Trim());
            model.img_url = txtImgUrl.Text.Trim();
            model.remark = txtRemark.Text;
            if (model.api_path.ToLower() == "alipaypc")
            {
                //支付宝
                string alipayFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/alipaypc.config");
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/partner", txtAlipayPartner.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/key", txtAlipayKey.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/email", txtAlipaySellerEmail.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/type", rblAlipayType.SelectedValue);
            }
            else if (model.api_path.ToLower() == "alipaywap")
            {
                //支付宝
                string alipayFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/alipaywap.config");
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/partner", txtAlipayPartner.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/key", txtAlipayKey.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/email", txtAlipaySellerEmail.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/type", rblAlipayType.SelectedValue);
            }
            else if (model.api_path.ToLower() == "tenpaypc")
            {
                //财付通
                string tenpayFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/tenpaypc.config");
                XmlHelper.UpdateNodeInnerText(tenpayFilePath, @"Root/partner", txtTenpayBargainorId.Text);
                XmlHelper.UpdateNodeInnerText(tenpayFilePath, @"Root/key", txtTenpayKey.Text);
                XmlHelper.UpdateNodeInnerText(tenpayFilePath, @"Root/type", rblTenpayType.SelectedValue);
            }
            else if (model.api_path.ToLower().StartsWith("chinabankpc"))
            {
                //网银在线
                string chinaBankFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/chinabankpc.config");
                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/partner", txtChinaBankPartner.Text);
                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/key", txtChinaBankKey.Text);
            }
            else if (model.api_path.ToLower().StartsWith("weixinwap"))
            {
                //微信支付
                string chinaBankFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixinwap.config");
                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/appid", TxtAppID.Text);
                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/appsecret", TxtAppSecret.Text);
                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/mechid", Txtmechid.Text);
                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/mechkay", Txtmechkay.Text);
            }
            else if (model.api_path.ToLower() == "weixinkj")
            {

                string chinaBankFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixinkj.config");

                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/mch_id", txt_mch_id.Text);
                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/key", txt_key.Text);
                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/req_url", txt_req_url.Text);
                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/notify_url", txt_notify_url.Text);
                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/version", txt_version.Text);
       

            }
            else if (model.api_path.ToLower() == "weixinsm")
            {
                string weixinsmFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixinsm.config");
                XmlHelper.UpdateNodeInnerText(weixinsmFilePath, @"Root/service", Txtservice.Text);
                XmlHelper.UpdateNodeInnerText(weixinsmFilePath, @"Root/key", Txtkey.Text);
                XmlHelper.UpdateNodeInnerText(weixinsmFilePath, @"Root/merchantCode", TxtmerchantCode.Text);
                XmlHelper.UpdateNodeInnerText(weixinsmFilePath, @"Root/shmc", Txtshmc.Text);

            }
            else if (model.api_path.ToLower() == "weixinzf")
            {
                string weixinsmFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/weixinzf.config");
                XmlHelper.UpdateNodeInnerText(weixinsmFilePath, @"Root/mch_id", Txtmch_id.Text);
                XmlHelper.UpdateNodeInnerText(weixinsmFilePath, @"Root/zf_key", Txtzf_key.Text);
                XmlHelper.UpdateNodeInnerText(weixinsmFilePath, @"Root/mch_number", Txtmch_number.Text);

            }
            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改支付方式:" + model.title); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("order_payment", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            if (!DoEdit(this.id))
            {
                JscriptMsg("保存过程中发生错误！", string.Empty);
                return;
            }
            JscriptMsg("修改配置成功！", "payment_list.aspx");
        }

    }
}