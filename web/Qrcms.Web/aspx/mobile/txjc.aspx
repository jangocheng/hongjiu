<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.article" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" rel=\"stylesheet\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" />\r\n		<title>充值提现教程</title>\r\n		<style type=\"text/css\">\r\n			body{\r\n				font-size: 12px;\r\n				background: #F2F2F2;\r\n			}\r\n			.wenzhang h3{\r\n				margin-bottom: 15px;\r\n				font-size: 18px;\r\n				font-weight: normal;\r\n			}\r\n			.wenzhang{\r\n				padding: 15px;\r\n			}\r\n			.wenzhang h4{\r\n				font-size: 16px;\r\n				line-height: 24px;\r\n				font-weight: normal;\r\n				\r\n			}\r\n			.wenzhang p{\r\n				line-height: 24px;\r\n				color: #333;\r\n			}\r\n			.mui-content{\r\n				background: #fff !important;\r\n			}\r\n.wenzhang img{width:100%;}\r\n		</style>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content wenzhang\">\r\n			<img src=\"/images/txjc/1.png\"/>\r\n<img src=\"/images/txjc/2.png\"/>\r\n<img src=\"/images/txjc/3.png\"/>\r\n<img src=\"/images/txjc/4.png\"/>\r\n<img src=\"/images/txjc/5.png\"/>\r\n<img src=\"/images/txjc/6.png\"/>\r\n<img src=\"/images/txjc/7.png\"/>\r\n<img src=\"/images/txjc/8.png\"/>\r\n<img src=\"/images/txjc/9.png\"/>\r\n		</div>\r\n	</body>\r\n	\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
