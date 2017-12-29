using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Qrcms.Common;

namespace Qrcms.Web.admin
{
    public partial class adv_view : Qrcms.Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Build.ToString (); //操作类型
        protected int id = 0;
        protected Model.advert model = new Model.advert();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id", 0);
            string _action = DTRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Build.ToString())
            {
                this.action = DTEnums.ActionEnum.Build.ToString();//修改类型
            }

            if (this.id < 1)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!new BLL.advert().Exists(this.id))
            {
                JscriptMsg("信息不存在或已被删除！", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                model = new BLL.advert().GetModel(this.id);
                BLL.advert_banner bbll = new BLL.advert_banner();
                DataSet ds = bbll.GetList("is_lock=0 and datediff(day,start_time,getdate())>=0 and datediff(day,end_time,getdate())<=0 and aid=" + this.id);
                txtCopyUrl.Value = GetAdvStr(model.type, ds);

                //if (action == DTEnums.ActionEnum.Build.ToString()) //修改
                //{
                //    //输出该广告位下的广告条,不显示未开始、过期、暂停广告
                //    BLL.advert_banner bbll = new BLL.advert_banner();
                //    DataSet ds = bbll.GetList("is_lock=0 and datediff('d',start_time,Now())>=0 and datediff('d',end_time,Now())<=0 and aid=" + this.id);
                //    if (ds.Tables[0].Rows.Count < 1)
                //    {
                //        JscriptMsg("该广告位下暂无广告内容！", "back", "Error");
                //        return;
                //    }

                //    //=================判断广告位类别,获得广告代码，输出广告条======================
                //    string path = Server.MapPath("~") + "\\plugins" + "\\advert\\js\\" + this.id + ".JS";
                //    StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8);
                //    string s = GetAdvStr(model.type, ds);
                //    sw.Write("document.write(\"" + s + "\");");
                //    sw.Flush();
                //    sw.Close();
                //    JscriptMsg("生成成功！", "back", "Success");
                //}
            }
        }

        #region 显示广告类型=================================
        protected string GetTypeName(int typeId)
        {
            switch (typeId)
            {
                case 1:
                    return "文字";
                case 2:
                    return "图片";
                case 3:
                    return "幻灯片";
                case 4:
                    return "动画";
                case 5:
                    return "FLV视频";
                case 6:
                    return "代码";
                default:
                    return "其它";
            }
        }
        #endregion


        #region 获得广告代码=================================
        protected string GetAdvStr(int typeId, DataSet ds)
        {
            //新增，取得站点配置信息
            Qrcms.Model.siteconfig siteConfig = new Qrcms.BLL.siteconfig().loadConfig();

            StringBuilder adhtml = new StringBuilder();
            switch (typeId)
            {
                case 1: //文字
                    adhtml.Append("<%set DataTable advert_banner=get_advert_banner_list(" + this.id + ")%>\n");
                    adhtml.Append("<ul>\n");
                    adhtml.Append("<%foreach(DataRow dr in advert_banner.Rows)%>\n");
                    adhtml.Append("<li>");
                    adhtml.Append("<a title=\"{dr[title]}\" target=\"" + model.target + "\" href=\"{dr[link_url]}\">{dr[title]}</a>");
                    adhtml.Append("</li>\n");
                    adhtml.Append("<%/foreach%>\n");
                    
                    adhtml.Append("</ul>\n");
                    return adhtml.ToString();
                case 2: //图片
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        adhtml.Append("<%set DataTable advert_banner=get_advert_banner_list(" + this.id + ")%>\n");
                        adhtml.Append("<a title=\"{dr[title]}\" target=" + model.target + " href=\"{dr[link_url]}\"><img src=\"{dr[file_path]}\" width=" + model.view_width + " height=" + model.view_height + " border=0 /></a>");
                    }
                    else
                    {
                        adhtml.Append("<%set DataTable advert_banner=get_advert_banner_list(" + this.id + ")%>\n");
                        adhtml.Append("<ul>\n");
                        adhtml.Append("<%foreach(DataRow dr in advert_banner.Rows)%>\n");
                        adhtml.Append("<li>");
                        adhtml.Append("<a title=\"{dr[title]}\" target=" + model.target + " href=\"{dr[link_url]}\"><img src=\"{dr[file_path]}\" width=" + model.view_width + " height=" + model.view_height + " border=0 /></a>");
                        adhtml.Append("</li>\n");
                        adhtml.Append("<%/foreach%>\n");
                        adhtml.Append("</ul>\n");
                    }
                    return adhtml.ToString();
                case 3: //幻灯片
                    StringBuilder picTitle = new StringBuilder();
                    StringBuilder picUrl = new StringBuilder();
                    StringBuilder picLink = new StringBuilder();
                    adhtml.Append("<%set DataTable advert_banner=get_advert_banner_list(" + this.id + ")%>\n");
                    adhtml.Append("<div id=\"slider\" class=\"nivoSlider\">\n");
                    adhtml.Append("<%foreach(DataRow dr in advert_banner.Rows)%>\n");
                    adhtml.Append("<a title=\"{dr[title]}\" target=" + model.target + " href=\"{dr[link_url]}\"><img src=\"{dr[file_path]}\" width=" + model.view_width + " height=" + model.view_height + " border=0 /></a>\n");
                    adhtml.Append("<%/foreach%>\n");
                    adhtml.Append("</div");
                    
                    

                    //adhtml.Append("document.write('<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" d=scriptmain name=scriptmain codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0\" width=\"" + model.view_width + "\" height=\"" + model.view_height + "\">');\n");
                    //adhtml.Append("document.write('<param name=\"movie\" value=\"" + siteConfig.webpath + "plugins/advert/focus.swf?width=" + model.view_width + "&height=" + model.view_height + "&bigSrc=" + picUrl + "&href=" + picLink + "\">');\n");
                    //adhtml.Append("document.write('<param name=\"quality\" value=\"high\">');\n");
                    //adhtml.Append("document.write('<param name=\"loop\" value=\"false\">');\n");
                    //adhtml.Append("document.write('<param name=\"menu\" value=\"false\">');\n");
                    //adhtml.Append("document.write('<param name=\"wmode\" value=\"transparent\">');\n");
                    //adhtml.Append("document.write('<embed src=\"" + siteConfig.webpath + "plugins/advert/focus.swf?width=" + model.view_width + "&height=" + model.view_height + "&bigSrc=" + picUrl + "&href=" + picLink + "\" width=\"" + model.view_width + "\" height=\"" + model.view_height + "\" loop=\"false\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" type=\"application/x-shockwave-flash\" wmode=\"transparent\" menu=\"false\"></embed>');\n");
                    //adhtml.Append("document.write('</object>');\n");
                    return adhtml.ToString();
                case 4: //动画
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        adhtml.Append("<%set DataTable advert_banner=get_advert_banner_list(" + this.id + ")%>\n");
                        adhtml.Append("<object classid=\"clsid:D27CDB6E-AE6D-11CF-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0\" width=\"" + model.view_width + "\" height=\"" + model.view_height + "\">\n");
                        adhtml.Append("<param name=\"movie\" value=\"{dr[file_path]}\">\n");
                        adhtml.Append("<param name=\"quality\" value=\"high\">\n");
                        adhtml.Append("<param name=\"wmode\" value=\"transparent\">\n");
                        adhtml.Append("<param name=\"menu\" value=\"false\">\n");
                        adhtml.Append("<embed src=\"{dr[file_path]} pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"" + model.view_width + "\" height=\"" + model.view_height + "\" quality=\"High\" wmode=\"transparent\">\n");
                        adhtml.Append("</embed>\n");
                        adhtml.Append("</object>\n");
                    }
                    else
                    {
                        adhtml.Append("<%set DataTable advert_banner=get_advert_banner_list(" + this.id + ")%>\n");
                        adhtml.Append("<ul>\n");
                        adhtml.Append("<%foreach(DataRow dr in advert_banner.Rows)%>\n");
                        adhtml.Append("<li>");
                        adhtml.Append("<object classid=\"clsid:D27CDB6E-AE6D-11CF-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0\" width=\"" + model.view_width + "\" height=\"" + model.view_height + "\">\n");
                        adhtml.Append("<param name=\"movie\" value=\"{dr[file_path]}\">\n");
                        adhtml.Append("<param name=\"quality\" value=\"high\">\n");
                        adhtml.Append("<param name=\"wmode\" value=\"transparent\">\n");
                        adhtml.Append("<param name=\"menu\" value=\"false\">\n");
                        adhtml.Append("<embed src=\"{dr[file_path]}\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"" + model.view_width + "\" height=\"" + model.view_height + "\" quality=\"High\" wmode=\"transparent\">\n");
                        adhtml.Append("</embed>\n");
                        adhtml.Append("</object>\n");
                        adhtml.Append("</li>\n");
                        adhtml.Append("<%/foreach%>\n");
                        adhtml.Append("</ul>\n");
                    }
                    return adhtml.ToString();
                case 5://视频
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //如果超出限制广告数量，则退出循环
                        if (i >= 1)
                            break;
                        DataRow dr = ds.Tables[0].Rows[i];
                        adhtml.Append("document.write('<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0\" width=" + model.view_width + " height=" + model.view_height + " viewastext>');\n");
                        adhtml.Append("document.write('<param name=\"movie\" value=\"" + siteConfig.webpath + "plugins/advert/player.swf\" />');\n");
                        adhtml.Append("document.write('<param name=\"quality\" value=\"high\" />');\n");
                        adhtml.Append("document.write('<param name=\"allowFullScreen\" value=\"true\" />');\n");
                        adhtml.Append("document.write('<param name=\"FlashVars\" value=\"vcastr_file=" + dr["file_path"].ToString() + "&LogoText=www.auto.cn&BarTransparent=30&BarColor=0xffffff&IsAutoPlay=1&IsContinue=1\" />');\n");
                        adhtml.Append("document.write('</object>');\n");
                    }
                    return adhtml.ToString();
                case 6://代码
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //如果超出限制广告数量，则退出循环
                        if (i >= 1)
                            break;
                        DataRow dr = ds.Tables[0].Rows[i];
                        StringBuilder sb = new StringBuilder(dr["content"].ToString());
                        sb.Replace("&lt;", "<");
                        sb.Replace("&gt;", ">");
                        sb.Replace("\"", "'");
                        adhtml.Append(sb.ToString() + "\")");
                    }
                    return adhtml.ToString();
            }
            return adhtml.ToString();
        }
        #endregion
    }
}