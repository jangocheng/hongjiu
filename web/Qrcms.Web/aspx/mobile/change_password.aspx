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

	templateBuilder.Append("<!doctype html>\r\n<html>\r\n\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<title>修改密码</title>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<style type=\"text/css\">\r\n			.mui-toast-container{\r\n				bottom: 50%;\r\n			}\r\n		</style>\r\n	</head>\r\n\r\n	<body>\r\n		<div class=\"mui-content modify-password\">\r\n		   <form id=\"changePwd_form\">\r\n		   	 <div class=\"mui-input-group\">\r\n		        <div class=\"mui-input-row\">\r\n		            <input type=\"password\" id=\"txtOldPassword\" name=\"txtOldPassword\"  class=\"mui-input-clear\" placeholder=\"请输入旧密码\">\r\n		        </div>\r\n		        <div class=\"mui-input-row\">\r\n		            <input type=\"password\" id=\"txtPassword\" name=\"txtPassword\" class=\"mui-input-clear\" placeholder=\"请输入新密码\">\r\n		        </div>\r\n		        <div class=\"mui-input-row\">\r\n		            <input type=\"password\" id=\"txtPassword1\" name=\"txtPassword1\" class=\"mui-input-clear\" placeholder=\"请再次输入新密码\">\r\n		        </div>\r\n		    </div>\r\n		  \r\n		   </form>\r\n		    <button id=\"edit_submit\" type=\"button\" class=\"mui-btn mui-btn-blue mui-btn-block\">提交修改</button>\r\n		</div>\r\n		<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n		<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n		<script type=\"text/javascript\">\r\n			mui.init()\r\n			mui('body').on('tap','#edit_submit',function(){\r\n				if(document.getElementById('txtPassword').value != document.getElementById('txtPassword1').value){\r\n					mui.toast(\"两次密码输入不一致\")\r\n				}else if(document.getElementById('txtOldPassword').value == \"\"){\r\n					mui.toast(\"旧密码不能为空\")\r\n				}else if(document.getElementById('txtPassword1').value ==\"\"){\r\n					mui.toast(\"新密码不能为空\")\r\n				}else{\r\n					mui.ajax(\"/tools/submit_ajax.ashx?action=user_password_edit\",{\r\n						data:{\r\n							txtOldPassword:document.getElementById('txtOldPassword').value,\r\n							txtPassword:document.getElementById('txtPassword').value,\r\n							txtPassword1:document.getElementById('txtPassword1').value\r\n						},\r\n						dataType:\"json\",\r\n						type:\"post\",\r\n						success:function(data){\r\n						\r\n							if(data.status == 1){\r\n								mui.toast(data.msg);\r\n								setTimeout(function(){\r\n									window.location.href = 'person_zl.aspx';\r\n								},1000)\r\n							}else{\r\n								mui.toast(data.msg);\r\n							}\r\n						},\r\n						error:function(a,b,c){\r\n							console.log(a+\",\"+b+\",\"+c)\r\n						}\r\n					})\r\n				}\r\n			})\r\n		</");
	templateBuilder.Append("script>\r\n	</body>\r\n\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
