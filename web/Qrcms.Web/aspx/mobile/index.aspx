<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.index" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Qrcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by DTcms Template Engine at 2017/10/31 14:39:39.
		本页面代码由DTcms模板引擎生成于 2017/10/31 14:39:39. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />		\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/swiper-3.4.2.min.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/iconfont.css\" />\r\n		<title>首页</title>\r\n		<style type=\"text/css\">\r\n			.shengji{\r\n				padding:  0.2rem;\r\n			}\r\n			.shengji .cp_img{\r\n				margin-bottom: 10px;\r\n			}\r\n			.shengji2{\r\n				width: 100%;\r\n			}\r\n			.shengji2 .cp_img{\r\n				width: 100%;\r\n				float: left;\r\n				margin-bottom: 10px;\r\n			}\r\n			.shengji2 .cp_img a img {\r\n			    width: 100%;\r\n			    height: 2.5rem;\r\n			    margin-right: .2rem;\r\n}\r\n			.chaye{\r\n				padding: 0.2rem;\r\n			}\r\n		</style>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content home\">\r\n			<div class=\"layout\">\r\n				<header class=\"mui-bar mui-bar-nav home_head\">  \r\n	     			<a href=\"usercenter.aspx\" class=\"mui-icon  mui-pull-left mui-icon-contact colorfff\"></a>\r\n	        		<h1 class=\"mui-title mytitle colorfff\">玖方商城</h1>  \r\n	    		</header>  \r\n				<!--\r\n	            	轮播图\r\n	            -->\r\n	           	<div class=\"mui-slider\">\r\n					<div class=\"mui-slider-group mui-slider-loop\">\r\n						");
	DataTable advert_banner = get_advert_banner_list(6);

	foreach(DataRow dr in advert_banner.Rows)
	{

	templateBuilder.Append("\r\n					    <!--支持循环，需要重复图片节点-->\r\n					    <div class=\"mui-slider-item mui-slider-item-duplicate\"><a href=\"#\"><img src=\"" + Utils.ObjectToStr(dr["file_path"]) + "\" /></a></div>\r\n					    <div class=\"mui-slider-item\"><a href=\"#\"><img src=\"" + Utils.ObjectToStr(dr["file_path"]) + "\" /></a></div>\r\n					    <div class=\"mui-slider-item\"><a href=\"#\"><img src=\"" + Utils.ObjectToStr(dr["file_path"]) + "\" /></a></div>\r\n					    <div class=\"mui-slider-item\"><a href=\"#\"><img src=\"" + Utils.ObjectToStr(dr["file_path"]) + "\" /></a></div>\r\n					    <div class=\"mui-slider-item\"><a href=\"#\"><img src=\"" + Utils.ObjectToStr(dr["file_path"]) + "\" /></a></div>\r\n					    <!--支持循环，需要重复图片节点-->\r\n					   <div class=\"mui-slider-item mui-slider-item-duplicate\"><a href=\"#\"><img src=\"" + Utils.ObjectToStr(dr["file_path"]) + "\" /></a></div>\r\n					   ");
	}	//end for if

	templateBuilder.Append("\r\n					</div>\r\n					<!--<div class=\"mui-slider-indicator\">\r\n						<div class=\"mui-indicator mui-active\"></div>\r\n						<div class=\"mui-indicator\"></div>\r\n						<div class=\"mui-indicator\"></div>\r\n						<div class=\"mui-indicator\"></div>\r\n					</div>-->\r\n				</div>\r\n				<!--\r\n	            	轮播图结束\r\n	            -->\r\n	            <!--\r\n                	升级换礼\r\n                -->\r\n               \r\n				<div class=\"common_block shengji\">\r\n					<div class=\"head_sjimg\">\r\n						<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/home2.png\">\r\n					</div>\r\n					  ");
	DataTable sj = get_category_list("goods", 57);

	int sjhl__loop__id=0;
	foreach(DataRow sjhl in sj.Rows)
	{
		sjhl__loop__id++;


	if (sjhl__loop__id==1)
	{

	templateBuilder.Append("\r\n					<div class=\"cp_img\">\r\n						<a href=\"sj_products.aspx?category_id=58&Type=1\">\r\n							<img src=\"" + Utils.ObjectToStr(sjhl["img_url"]) + "\">\r\n						</a>\r\n					</div>\r\n			\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n				<div class=\"common_block shengji2\">\r\n					<div class=\"cp_img clearfix\" >\r\n						 \r\n");
	if (sjhl__loop__id==2)
	{

        templateBuilder.Append("\r\n						<a href=\"sj_products.aspx?category_id=68&Type=2\">\r\n							<img src=\"" + Utils.ObjectToStr(sjhl["img_url"]) + "\">\r\n						</a>\r\n				");
	}	//end for if

	if (sjhl__loop__id==3)
	{

	templateBuilder.Append("\r\n						<a href=\"sj_products.aspx?category_id=62\">\r\n							<img src=\"" + Utils.ObjectToStr(sjhl["img_url"]) + "\">\r\n						</a>\r\n				");
	}	//end for if

	templateBuilder.Append("\r\n					</div>\r\n				</div>\r\n");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n				</div>\r\n			\r\n				<!--\r\n                	品牌茶叶\r\n                -->\r\n				<div class=\"common_block chaye\">\r\n					<div class=\"head_cyimg\">\r\n						<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/home3.png\">\r\n					</div>\r\n					  ");
	DataTable zt = get_category_list("goods", 60);

	int brand__loop__id=0;
	foreach(DataRow brand in zt.Rows)
	{
		brand__loop__id++;


	if (brand__loop__id==1)
	{

	templateBuilder.Append("\r\n					<div class=\"cp_img\">\r\n						<a href=\"brand_zt.aspx?category_id=65\">\r\n							<img src=\"" + Utils.ObjectToStr(brand["img_url"]) + "\">\r\n						</a>\r\n					</div>\r\n				");
	}	//end for if

	if (brand__loop__id==2)
	{

	templateBuilder.Append("\r\n					<div class=\"cp_img\">\r\n						<a href=\"brand_zt.aspx?category_id=64\">\r\n							<img src=\"" + Utils.ObjectToStr(brand["img_url"]) + "\">\r\n						</a>\r\n					</div>\r\n					");
	}	//end for if

	if (brand__loop__id==3)
	{

	templateBuilder.Append("\r\n					<div class=\"cp_img\">\r\n						<a href=\"brand_zt.aspx?category_id=63\">\r\n							<img src=\"" + Utils.ObjectToStr(brand["img_url"]) + "\">\r\n						</a>\r\n					</div>\r\n					");
	}	//end for if

	if (brand__loop__id==4)
	{

	templateBuilder.Append("\r\n					<div class=\"cp_img\">\r\n						<a href=\"brand_zt.aspx?category_id=61\">\r\n							<img src=\"" + Utils.ObjectToStr(brand["img_url"]) + "\">\r\n						</a>\r\n					</div>\r\n					");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n					\r\n				</div>\r\n			</div>\r\n		</div>\r\n		<nav class=\"mui-bar mui-bar-tab\">\r\n		    <a href=\"index.aspx\" class=\"mui-tab-item mui-active\">\r\n		        <span class=\"mui-icon iconfont icon-home\"></span>\r\n		        <span class=\"mui-tab-label\">首页</span>\r\n		    </a>\r\n		    <a href=\"paihang.aspx\" class=\"mui-tab-item\">\r\n		        <span class=\"mui-icon iconfont icon-un-class\"></span>\r\n		        <span class=\"mui-tab-label\">排行榜</span>\r\n		    </a>\r\n		    <!--<a href=\"shop_cart.aspx\" class=\"mui-tab-item\">\r\n		        <span class=\"mui-icon iconfont icon-un-car\"></span>\r\n		        <span class=\"mui-tab-label\">购物车</span>\r\n		    </a>-->\r\n		    <a href=\"usercenter.aspx\" class=\"mui-tab-item\" id=\"my_usercenter\">\r\n		        <span class=\"mui-icon iconfont icon-My\"></span>\r\n		        <span class=\"mui-tab-label\">个人中心</span>\r\n		    </a>\r\n		</nav>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	\r\n  	<script>\r\n  		/*底部导航跳转*/\r\n		mui('.mui-bar-tab').on('tap','a',function(){\r\n			document.location.href = this.href;\r\n		});\r\n		\r\n		/*轮播*/\r\n		mui(\".mui-slider\").slider({interval:3000});\r\n\r\n  	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
