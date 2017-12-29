﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.cart" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Qrcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by Qrcms Template Engine at 2015-5-27 23:17:06.
		本页面代码由Qrcms模板引擎生成于 2015-5-27 23:17:06. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);

	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<title>购物车－");
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</title>\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/icons.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/af.ui.base.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/ui-dialog.css\" />\r\n<!--jqMobi主JS-->\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery-1.11.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/jq.appframework.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/ui/appframework.ui.js\"></");
	templateBuilder.Append("script>\r\n<!--jqMobi插件-->\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/plugins/jq.slidemenu.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/dialog-plus-min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/cart.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n	$(document).ready(function(e) {\r\n		$(\"#main_footer a.basket\").addClass(\"pressed\");\r\n    });\r\n</");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n\r\n	<div id=\"mainPanel\" class=\"panel\" data-footer=\"main_footer\" style=\"padding-bottom:0;\">\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>购物车</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n\r\n      <!--购物车-->\r\n      <div>\r\n        <ul class=\"car-list\">\r\n          ");
	foreach(Qrcms.Model.cart_items modelt in goodsList)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <input type=\"checkbox\" id=\"checkId-");
	templateBuilder.Append(Utils.ObjectToStr(modelt.article_id));
	templateBuilder.Append("\" class=\"checkall\" onclick=\"selectCart();\" />\r\n            <label class=\"select\" for=\"checkId-");
	templateBuilder.Append(Utils.ObjectToStr(modelt.article_id));
	templateBuilder.Append("\"></label>\r\n            <input name=\"hideArticleId\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.article_id));
	templateBuilder.Append("\" />\r\n            <input name=\"hideGoodsId\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.goods_id));
	templateBuilder.Append("\" />\r\n            <input name=\"hideStockQuantity\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.stock_quantity));
	templateBuilder.Append("\" />\r\n            <input name=\"hideGoodsPrice\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.user_price));
	templateBuilder.Append("\" />\r\n            <input name=\"hidePoint\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.point));
	templateBuilder.Append("\" />\r\n            <a href=\"");
	templateBuilder.Append(linkurl("goods_show",modelt.article_id));

	templateBuilder.Append("\" class=\"img-box\" data-ignore=\"true\" style=\"margin-left:35px;\">\r\n              <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.img_url));
	templateBuilder.Append("\" />\r\n            </a>\r\n            <h2>");
	templateBuilder.Append(Utils.ObjectToStr(modelt.title));
	templateBuilder.Append("</h2>\r\n            ");
	if (modelt.spec_text!="")
	{

	templateBuilder.Append("\r\n            <p class=\"stxt\">");
	templateBuilder.Append(Utils.ObjectToStr(modelt.spec_text));
	templateBuilder.Append("</p>\r\n            ");
	}	//end for if

	templateBuilder.Append("\r\n            <div class=\"note\" style=\"margin-left:110px;\">\r\n                <div class=\"btn-list\">\r\n                  <a href=\"javascript:;\" onclick=\"updateCart(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("', -1);\">-</a>\r\n                  <input name=\"goodsQuantity\" type=\"text\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.quantity));
	templateBuilder.Append("\" readonly />\r\n                  <a href=\"javascript:;\" onclick=\"updateCart(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("', 1);\">+</a>\r\n                  <a href=\"javascript:;\" class=\"del\" onclick=\"deleteCart('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("', this);\">删除</a>\r\n                </div>\r\n                <i class=\"price\">￥");
	templateBuilder.Append(Utils.ObjectToStr(modelt.user_price));
	templateBuilder.Append("</i>\r\n            </div>\r\n          </li>\r\n          ");
	}	//end for if

	if (goodsList.Count<1)
	{

	templateBuilder.Append("\r\n          <div class=\"nodata\">\r\n            <h1></h1>\r\n            <p>购物车暂无商品</p>\r\n          </div>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      \r\n      ");
	if (goodsList.Count>0)
	{

	templateBuilder.Append("\r\n      <div class=\"car-total\">\r\n        <div class=\"btn-list\">\r\n          <input id=\"jsondata\" name=\"jsondata\" type=\"hidden\" />\r\n          <button class=\"btn orange\" onclick=\"formSubmit(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("', '");
	templateBuilder.Append(linkurl("shopping"));

	templateBuilder.Append("');\">去结算</button>\r\n        </div>\r\n        <div class=\"note\">\r\n          <h3>总计(不含运费)：</h3>\r\n          <p>\r\n            已选择商品<b id=\"totalQuantity\">0</b>件，\r\n            共计：￥<b id=\"totalAmount\">0</b>元\r\n          </p>\r\n        </div>\r\n      </div>\r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n      \r\n      <!--版权信息-->\r\n      ");

	templateBuilder.Append("      <div class=\"copyright\">\r\n        <p><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">触屏版</a> | <a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("?m2w\" data-ignore=\"true\">电脑版</a> | <a href=\"javascript:;\" onclick=\"$.ui.scrollToTop('mainPanel')\">返回顶部</a></p>\r\n        <address>版权所有 深圳市动力启航软件有限公司 版本号 V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append("</address></p>\r\n      </div>");


	templateBuilder.Append("\r\n      <!--/版权信息-->\r\n	</div>\r\n  \r\n    <!--底部导航-->\r\n    ");

	templateBuilder.Append("    <footer id=\"main_footer\">\r\n      <a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" class=\"icon home\" data-ignore=\"true\">首页</a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\" class=\"icon user\" data-ignore=\"true\">会员</a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("cart"));

	templateBuilder.Append("\" class=\"icon basket\" data-ignore=\"true\">购物车 <span class=\"af-badge lr\"><script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=view_cart_count\"></");
	templateBuilder.Append("script></span></a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("\" class=\"icon magnifier\" data-ignore=\"true\">搜索</a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\" class=\"icon phone\" data-ignore=\"true\">电话</a>\r\n    </footer>");


	templateBuilder.Append("\r\n    <!--/底部导航-->\r\n	\r\n    <!--左侧导航-->\r\n    ");

	templateBuilder.Append("    <nav>\r\n      <ul class=\"list\">\r\n        <li class=\"divider\">网站导航</li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" class=\"icon home\" data-ignore=\"true\">网站首页</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("news"));

	templateBuilder.Append("\" class=\"icon tv\" data-ignore=\"true\">新闻资讯</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("goods"));

	templateBuilder.Append("\" class=\"icon basket\" data-ignore=\"true\">购物商城</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("video"));

	templateBuilder.Append("\" class=\"icon camera\" data-ignore=\"true\">视频专区</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("photo"));

	templateBuilder.Append("\" class=\"icon picture\" data-ignore=\"true\">图片分享</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("down"));

	templateBuilder.Append("\" class=\"icon download\" data-ignore=\"true\">资源下载</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\" class=\"icon user\" data-ignore=\"true\">会员中心</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("content","about"));

	templateBuilder.Append("\" class=\"icon info\" data-ignore=\"true\">关于我们</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("mfeedback"));

	templateBuilder.Append("\" class=\"icon message\" data-ignore=\"true\">在线留言</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\" class=\"icon phone\" data-ignore=\"true\">联系我们</a></li>\r\n      </ul>\r\n    </nav>");


	templateBuilder.Append("\r\n    <!--/左侧导航-->\r\n      \r\n  </div>\r\n</div>\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
