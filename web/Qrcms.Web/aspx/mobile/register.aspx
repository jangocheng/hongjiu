<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.register" ValidateRequest="false" %>
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

	templateBuilder.Append("<!doctype html>\r\n<html>\r\n\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<title>注册账号</title>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" rel=\"stylesheet\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" />\r\n		<style type=\"text/css\">\r\n			.mui-toast-container{\r\n				bottom: 15%;\r\n			}\r\n			.register .mui-input-row > div, .wj_password .mui-input-row > div{\r\n				display: inline-block;\r\n    padding:0 10px ;\r\n    height:30px;\r\n   \r\n    border: 1px solid #7D0000;\r\n    color: #fff;\r\n    background: #7D0000;\r\n    border-radius: 5px;\r\n    font-size: 12px;\r\n    text-align: center;\r\n    float: right;\r\n    margin-top: 11px;\r\n    margin-right: 12px;\r\n			}\r\n		</style>\r\n	</head>\r\n\r\n	<body style=\"min-height: 100%;background: #F2F2F2;\">\r\n		<div class=\"mui-content register\">\r\n		    <div class=\"mui-input-group\">\r\n		    	<form id=\"register_form\">\r\n\r\n                    <input type=\"hidden\" name=\"openid\" id=\"openid\" value=\"");
	templateBuilder.Append(Qrcms.Common.DTRequest.GetString("openid").ToString());

	templateBuilder.Append("\" />\r\n		    		\r\n			        <div class=\"mui-input-row\">\r\n			            <input type=\"tel\" name=\"txtMobile\" id=\"txtPhone\" datatype=\"phone\" errormsg=\"请输入正确的手机号！\" class=\"mui-input-clear\" placeholder=\"请输入手机号码\">\r\n			            <div id=\"getCode\">获取验证码</div>\r\n			        </div>\r\n			        <div class=\"mui-input-row\">\r\n			            <input type=\"password\" name=\"txtCode\" id=\"txtCode\" class=\"mui-input-clear\" datatype=\"notnull\" errormsg=\"请输入验证码！\" placeholder=\"请输入手机验证码\">\r\n			        </div>\r\n			        <div class=\"mui-input-row\">\r\n			            <input type=\"password\" name=\"txtPassword\" id=\"txtPassword\" datatype=\"notnull\" errormsg=\"请输入密码！\" class=\"mui-input-clear\" placeholder=\"请设置登陆密码\">\r\n			        </div>\r\n			         <div class=\"mui-input-row\">\r\n			            <input type=\"password\" name=\"QRcodestate\" id=\"QRcodestate\"  errormsg=\"请输入邀请码！\" class=\"mui-input-clear\" placeholder=\"请输入邀请码\">\r\n			        </div>\r\n			        <div class=\"mui-input-row\">\r\n			         \r\n			            <input type=\"hidden\" name=\"txtUserName\" value=\"test\" id=\"txtUserName\"/>\r\n			            <input type=\"hidden\" name=\"txtPassword1\" id=\"txtPassword1\"/>\r\n			        </div>\r\n		        </form>\r\n		    </div>\r\n		    <button id=\"register_submit\" type=\"button\" class=\"mui-btn mui-btn-blue mui-btn-block regbtn\">立即注册</button>\r\n		    <p>注册即同意<a href=\"\">《用户协议》</a></p>\r\n		</div>\r\n		\r\n	\r\n		\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n		/*向手机发送验证码*/\r\n		mui('body').on('tap','#getCode',function(){\r\n			sendSMS('#getCode','#txtPhone','/tools/submit_ajax.ashx?action=user_verify_smscode&site=mobile');\r\n		});\r\n		\r\n		\r\n		/*提交用户注册的相关数据*/\r\n		mui('body').on('tap','#register_submit',function(){\r\n			var password_val=$(\"#txtPassword\").val();\r\n		\r\n			$(\"#txtPassword1\").val(password_val);\r\n			var formdata = serialize(document.getElementById('register_form'));\r\n			console.log(formdata);\r\n			if(getValid('register_form')){\r\n				\r\n				mui.ajax(\"/tools/submit_ajax.ashx?action=user_register&site=mobile\",{\r\n					data:{\r\n						\"txtUserName\":document.getElementById('txtPhone').value,\r\n						\"txtPassword1\":document.getElementById('txtPassword1').value,\r\n						'txtMobile':document.getElementById('txtPhone').value,\r\n						'txtCode':document.getElementById('txtCode').value,\r\n						'txtPassword': document.getElementById('txtPassword').value,\r\n						'QRcodestate':document.getElementById('QRcodestate').value,\r\n						'openid':document.getElementById('openid').value\r\n					},\r\n					dataType:'json',\r\n					type:\"post\",\r\n					async:false,\r\n					success:function(data){\r\n						if(data.status == \"1\"){\r\n								mui.toast(data.msg)\r\n								\r\n								setTimeout(function(){\r\n									window.location.href = data.url;\r\n								},1000)\r\n							}else{\r\n								mui.toast(data.msg)\r\n							}\r\n					}\r\n					\r\n				})\r\n			}\r\n		})\r\n		/**/\r\n	</");
	templateBuilder.Append("script>\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
