<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.article_list" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Qrcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by DTcms Template Engine at 2017/10/31 14:39:40.
		本页面代码由DTcms模板引擎生成于 2017/10/31 14:39:40. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	const string channel = "goods";
	const int pagesize = 6;

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n	\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" />	\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<title>兑换专区</title>\r\n		<style>\r\n			.page-list>span:first-child{\r\n				display: none;\r\n			}\r\n			.page-list{\r\n				text-align: center;\r\n				margin: 20px 0;\r\n				margin-left: 15%;\r\n			}\r\n			.page-list a,.page-list span {\r\n			    display: block;\r\n			    float: left;\r\n			    margin: 2px 0 0 -1px;\r\n			    padding: 4px 12px;			    \r\n			    height: 30px;\r\n			    border: 1px solid #e1e1e1;\r\n			    background: #fff;\r\n			    color: #333;\r\n			    text-decoration: none;\r\n			    font-size: 14px;\r\n			}\r\n			.page-list .current{\r\n				color: #fff;\r\n			    background: #BF0A0A;\r\n			    border-color: #BF0A0A;\r\n			}\r\n		</style>\r\n		\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content duihuan\">\r\n			<div class=\"duihuan_head\">\r\n					<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/jf1.png\">\r\n			</div>\r\n			<div class=\"duihuan_list\">	\r\n				\r\n				<div class=\"mui-scroll-wrapper\" id=\"duihuan_pro_wrap\">\r\n					<div class=\"mui-scroll\">\r\n						<ul class=\"clearfix\" id=\"duihuan_proul\">\r\n						");
	DataTable iud = get_article_list(channel, 66,10, page, "status=0", out totalcount, out pagelist, "duihuan_zq", category_id, "__id__");

	int ths__loop__id=0;
	foreach(DataRow ths in iud.Rows)
	{
		ths__loop__id++;


	templateBuilder.Append("\r\n							<li>\r\n								<a href=\"duihuan_show.aspx?id=" + Utils.ObjectToStr(ths["id"]) + "\">\r\n									<p>" + Utils.ObjectToStr(ths["title"]) + "</p>\r\n									<p><span class=\"point\">" + Utils.ObjectToStr(ths["point"]) + "</span>积分</p>\r\n									<img src=\"" + Utils.ObjectToStr(ths["img_url"]) + "\">\r\n								</a>\r\n							</li>\r\n							\r\n						 ");
	}	//end for if

	templateBuilder.Append("\r\n						</ul>\r\n							<div class=\"page-list mui-clearfix\">");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("</div>\r\n					</div>\r\n				</div>\r\n			</div>\r\n		</div>\r\n	\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/layer/layer.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/laytpl/laytpl.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/laypage/laypage.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		//MUI框架初始化\r\n		mui.init();\r\n		\r\n		function quchu(){\r\n			var point = document.getElementsByClassName('point');\r\n			for(var i = 0; i<point.length;i++){\r\n				//console.log(point.length);\r\n				var str = point[i].innerText;\r\n				console.log(str);\r\n				var str2 = str.substr(1,str.length);\r\n				console.log(str2);\r\n				point[i].innerText = str2;\r\n			}\r\n		}\r\n		\r\n		quchu();\r\n		\r\n		\r\n	\r\n		\r\n		//页面滚动\r\n		(function($){\r\n		    $(\".mui-scroll-wrapper\").scroll({\r\n		        //bounce: false,//滚动条是否有弹力默认是true\r\n		        //indicators: false, //是否显示滚动条,默认是true\r\n		    });\r\n    \r\n		})(mui);\r\n		\r\n		//页面跳转\r\n//		mui('body').on('tap','#duihuan_proul li a',function(){\r\n//			\r\n//			window.location.href = this.href;\r\n//		})\r\n		\r\n			\r\n			\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
