<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.usercenter" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />	\r\n		<title>实名认证成功</title>\r\n	</head>\r\n	<body>\r\n        ");
	        if(string.IsNullOrEmpty(userModel.real_name) || string.IsNullOrEmpty(userModel.idcard))
	        {
	        Response.Redirect("/mobile/realname_rz.aspx");
	        }
	        string str=userModel.idcard;
	        str = str.Remove((str.Length < 8 ? 8:str.Length)-8);
	        str=str+"********";
	        

	templateBuilder.Append("\r\n		<div class=\"mui-content shiming_cg\">\r\n			<div class=\"shiming_head\">\r\n				<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/shiming1.png\">\r\n				<p>更安全、更便捷的购物新体验</p>\r\n			</div>\r\n			<div class=\"mui-card\">\r\n				<p>本人姓名<span>");
	templateBuilder.Append(Utils.ObjectToStr(userModel.real_name));
	templateBuilder.Append("</span></p>\r\n			</div>\r\n			<div class=\"mui-card\">\r\n				<p>身份证号<span>");
	templateBuilder.Append(Utils.ObjectToStr(str));
	templateBuilder.Append("</span></p>\r\n			</div>\r\n		</div>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n		//数据模拟，加载数据\r\n//		function loadsj(){\r\n//			$.ajax({\r\n//				url:'js/shiming.json',\r\n//				type:'get',\r\n//				datatype:'json',\r\n//				success:function(data){\r\n//					console.log('成功进来');\r\n//					var idcardstr = data.people[0].idcard;\r\n//					console.log(idcardstr);\r\n//					var idcard_tou = idcardstr.substring(0,6);\r\n//					console.log(idcard_tou);\r\n//					var idcard_wei = idcardstr.substr(idcardstr.length - 4,4);\r\n//					console.log(idcard_wei);\r\n//					var html =\"\";\r\n//					html += '<div class=\"mui-card\"><p>本人姓名<span>'+data.people[0].realName+'</span></p></div>';\r\n//					html += '<div class=\"mui-card\"><p>身份证号<span>'+idcard_tou+'&nbsp;&nbsp;'+'****'+'****'+'&nbsp;&nbsp;'+idcard_wei+'</span></p></div>'\r\n//					console.log(html);\r\n//					$('.shiming_cg').append(html);\r\n//				}\r\n//			})\r\n//		}\r\n//		loadsj();\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
