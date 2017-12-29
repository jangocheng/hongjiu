<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.error" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" rel=\"stylesheet\" />\r\n<title>提示信息</title>\r\n<style>\r\n	.wrap-box h2{\r\n		font-size:14px;\r\n		text-align: center;\r\n		position: absolute;\r\n		top: 50%;\r\n		width: 100%;\r\n		height: 1rem;\r\n		line-height: 1rem;\r\n		color: #333;\r\n		left: 0;\r\n	}\r\n</style>\r\n\r\n</head>\r\n\r\n<body>\r\n\r\n \r\n\r\n\r\n      \r\n     <div class=\"mui-content\">\r\n     	 <div class=\"wrap-box\">\r\n        <h2>出错啦！</h2>\r\n        <div class=\"tip\">\r\n          <span class=\"icon close\"></span>\r\n          <p>");
	templateBuilder.Append(Utils.ObjectToStr(msg));
	templateBuilder.Append("</p>\r\n        </div>\r\n      </div>\r\n     </div>\r\n    \r\n	\r\n      \r\n  \r\n\r\n<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
