<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.article_list" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Qrcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by DTcms Template Engine at 2017-10-31 17:31:22.
		本页面代码由DTcms模板引擎生成于 2017-10-31 17:31:22. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	const string channel = "goods";
	const int pagesize = 10;

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" /\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/swiper-3.4.2.min.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/iconfont.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/products.css\" />\r\n		<title>升级</title>\r\n		<style type=\"text/css\">\r\n			.mui-bar-tab .mui-tab-item.mui-active {\r\n    color: #902626;\r\n}\r\n			.mui-scroll-wrapper{\r\n				top: 40%;\r\n			}\r\n			\r\n			.pro_list{\r\n				width: 100%;\r\n				background: rgb(125,0,0);\r\n				padding: 0 2.5%;\r\n				padding-bottom: 50px;\r\n			\r\n			}\r\n    \r\n			\r\n			\r\n		</style>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content pro_sj\" style=\"padding-top: 220px;\">\r\n		\r\n				\r\n						<div class=\"pro_list\" >\r\n					");
	DataTable iud = get_article_list(channel, category_id,10, page, "status=0 and is_upgrade=1", out totalcount, out pagelist, "sj_products", category_id, "__id__");

	int ths__loop__id=0;
	foreach(DataRow ths in iud.Rows)
	{
		ths__loop__id++;


	templateBuilder.Append("\r\n				<div class=\"pro_common\">\r\n					<div class=\"sj_icon\"></div>\r\n					\r\n					<ul class=\"mui-clearfix\">\r\n						\r\n					\r\n						<li>\r\n							<a class='goodsh' href=\"goods_show.aspx?id=" + Utils.ObjectToStr(ths["id"]) + "&play=");
	templateBuilder.Append(Qrcms.Common.DTRequest.GetString("play").ToString());

	templateBuilder.Append("\">\r\n								<div class=\"sj_proimg\">\r\n									<img src=\"" + Utils.ObjectToStr(ths["img_url"]) + "\">\r\n								</div>\r\n								<p>" + Utils.ObjectToStr(ths["title"]) + "</p>\r\n								<p>" + Utils.ObjectToStr(ths["sub_title"]) + "</p>\r\n								\r\n							</a>\r\n							<div class=\"sj_icon2\">\r\n									<p>市场价</p>\r\n									<span>" + Utils.ObjectToStr(ths["sell_price"]) + "</span>\r\n									<i>元</i>\r\n							</div>\r\n						</li>\r\n							\r\n						<li>\r\n							<a href=\"javascript:void(0)\">\r\n								<div class=\"sj_proimg\">\r\n									<img src=\"");
	templateBuilder.Append(get_filed(channel,"img_url","id="+Utils.ObjToInt(ths["big_upgrade"],0)).ToString());

	templateBuilder.Append("\r\n\">\r\n\r\n								</div>\r\n								<p>");
	templateBuilder.Append(get_filed(channel,"title","id="+Utils.ObjToInt(ths["big_upgrade"],0)).ToString());

	templateBuilder.Append("</p>\r\n								<p></p>\r\n							</a>\r\n							<div class=\"sj_icon2\">\r\n									<p>优购价</p>\r\n									<span>");
	templateBuilder.Append(get_filed(channel,"sell_price","id="+Utils.ObjToInt(ths["big_upgrade"],0)).ToString());

	templateBuilder.Append("</span>\r\n									<i>元</i>\r\n							</div>\r\n						</li>\r\n					</ul>\r\n				\r\n				</div>\r\n					 ");
	}	//end for if

	templateBuilder.Append("\r\n				<!--<div class=\"pro_common\">\r\n					<div class=\"sj_icon\"></div>\r\n					<ul class=\"mui-clearfix\">\r\n						<li>\r\n							<a href=\"\">\r\n								<div class=\"sj_proimg\">\r\n									<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/sjpro.png\">\r\n								</div>\r\n								<p>长城·星级系列</p>\r\n								<p>三星赤霞珠干红1瓶装</p>\r\n							</a>\r\n							<div class=\"sj_icon2\">\r\n									<p>市场价</p>\r\n									<span>199</span>\r\n									<i>元</i>\r\n							</div>\r\n						</li>\r\n						<li>\r\n							<a href=\"\">\r\n								<div class=\"sj_proimg\">\r\n									<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/sjpro2.png\">\r\n								</div>\r\n								<p>长城·星级系列</p>\r\n								<p>三星赤霞珠干红1瓶装</p>\r\n							</a>\r\n							<div class=\"sj_icon2\">\r\n									<p>优购价</p>\r\n									<span>599</span>\r\n									<i>元</i>\r\n							</div>\r\n						</li>\r\n					</ul>\r\n				</div>-->\r\n			\r\n			\r\n				</div>\r\n		</div>\r\n		<nav class=\"mui-bar mui-bar-tab\" style=\"margin-top: 20px;\">\r\n		    <a href=\"index.aspx\" class=\"mui-tab-item\">\r\n		        <span class=\"mui-icon iconfont icon-home\"></span>\r\n		        <span class=\"mui-tab-label\">首页</span>\r\n		    </a>\r\n		    <a href=\"paihang.aspx\" class=\"mui-tab-item\">\r\n		        <span class=\"mui-icon iconfont icon-un-class\"></span>\r\n		        <span class=\"mui-tab-label\">排行榜</span>\r\n		    </a>\r\n		    <!--<a href=\"shop_cart.aspx\" class=\"mui-tab-item\">\r\n		        <span class=\"mui-icon iconfont icon-un-car\"></span>\r\n		        <span class=\"mui-tab-label\">购物车</span>\r\n		    </a>-->\r\n		    <a href=\"usercenter.aspx\" class=\"mui-tab-item\" id=\"my_usercenter\">\r\n		        <span class=\"mui-icon iconfont icon-My\"></span>\r\n		        <span class=\"mui-tab-label\">个人中心</span>\r\n		    </a>\r\n		</nav>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
    templateBuilder.Append("script>\r\n	<script>\r\n     function getElementsByClassName(n) {var classElements = [],allElements = document.getElementsByTagName('*');for (var i=0; i< allElements.length; i++ ){ if (allElements[i].className == n ) {classElements[classElements.length] = allElements[i];  }}   return classElements;}	 function getQueryString(name) { var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', 'i'); var r = window.location.search.substr(1).match(reg); if (r != null) { return unescape(r[2]); } return null;} debugger;   if (getQueryString('Type') == '1') { for (var i in document.getElementsByClassName('goodsh')) {document.getElementsByClassName('goodsh')[i].href =  document.getElementsByClassName('goodsh')[i].href + '&Type=1'  }     } else if (getQueryString('Type') == '2') { for (var i in document.getElementsByClassName('goodsh')) {document.getElementsByClassName('goodsh')[i].href = document.getElementsByClassName('goodsh')[i].href + '&Type=2'  }}  	mui.init();\r\n		\r\n		mui('.mui-bar-tab').on('tap','a',function(){\r\n			document.location.href = this.href;\r\n		});\r\n		mui('body').on('tap','.pro_list ul li a',function(){\r\n			location.href = this.href ;\r\n		});\r\n		\r\n			(function($){\r\n		    $(\".mui-scroll-wrapper\").scroll({\r\n		        //bounce: false,//滚动条是否有弹力默认是true\r\n		        //indicators: false, //是否显示滚动条,默认是true\r\n		    });\r\n    \r\n		})(mui);\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
