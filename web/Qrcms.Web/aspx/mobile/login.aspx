<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.login" ValidateRequest="false" %>
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

	templateBuilder.Append("<!doctype html>\r\n<html>\r\n\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<title>登录</title>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" rel=\"stylesheet\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" />\r\n		<style type=\"text/css\">\r\n			.mui-toast-container{\r\n				bottom: 15%;\r\n			}\r\n		</style>\r\n		\r\n	</head>\r\n\r\n	<body style=\"min-height: 100%;background: #F2F2F2;\">\r\n		<div class=\"mui-content login \">\r\n		    <div class=\"mui-input-group \" >\r\n		     \r\n		    	<form id=\"login_form\" class=\"login_form\">\r\n                    <input type=\"hidden\" name=\"openid\" id=\"openid\" value=\"");
	templateBuilder.Append(Qrcms.Common.DTRequest.GetString("openid").ToString());

	templateBuilder.Append("\" />\r\n			        <div class=\"mui-input-row\">\r\n			            <input type=\"text\" name=\"txtUserName\" id=\"txtPhone\" datatype=\"phone\" errormsg=\"请填写正确的手机号码！\" class=\"mui-input-clear\" placeholder=\"请输入手机号码\">\r\n			        </div>\r\n			        <div class=\"mui-input-row\">\r\n			            <input type=\"password\" name=\"txtPassword\" id=\"txtPassword\" datatype=\"notnull\" errormsg=\"请输入密码！\" class=\"mui-input-clear\" placeholder=\"请输入密码\">\r\n			         <a href=\"wj_password.aspx\" id=\"forget-password\" >忘记密码</a>\r\n			        </div>\r\n		        </form>\r\n		  \r\n		    </div>\r\n		     <button id=\"login_submit\" type=\"button\" class=\"mui-btn mui-btn-blue mui-btn-block loginbtn\">立即登录</button>\r\n		    <p>没有账号？<a id=\"register\" href=\"/mobile/register.aspx?openid=");
	templateBuilder.Append(Qrcms.Common.DTRequest.GetString("openid").ToString());

	templateBuilder.Append("\">立即注册</a></p>\r\n		   \r\n		</div>\r\n		\r\n		\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	\r\n	<script>\r\n		mui.init();\r\n		\r\n		/*用户登录提交手机号码和密码*/\r\n		mui('body').on('tap','#login_submit',function(){\r\n			//mui.toast(1);\r\n			//var formdata = serialize(document.getElementById('login_form'));//获取登录数据\r\n			var formdata = $('#login_form').serialize();\r\n			console.log(formdata);\r\n			//mui.toast(formdata);\r\n				mui.ajax('/tools/submit_ajax.ashx?action=user_login&site=mobile',{\r\n					data:formdata,\r\n					datatype:'string',\r\n					type:'post',\r\n					async:false,\r\n					success:function(data){\r\n						console.log('成功');\r\n						//alert(1);\r\n						//mui.toast(2);\r\n						data = JSON.parse(data);\r\n						if(data.status ==1){\r\n							\r\n							location.href ='usercenter.aspx';\r\n						}else{\r\n							mui.toast('手机号或者密码错误');\r\n						}\r\n					},\r\n					error:function(data){\r\n						//data = JSON.stringify(data);\r\n						//mui.toast(data);\r\n						//location.href ='usercenter.aspx';\r\n						mui.toast('登录失败');\r\n					}\r\n				})\r\n			\r\n		})\r\n		\r\n		\r\n		/*页面跳转*/\r\n//		mui('body').on('tap','a',function(){\r\n//			\r\n//			window.location.href = this.href;\r\n//			\r\n//		})\r\n//		mui('body').on('tap','#register',function(){\r\n//			\r\n//			window.location.href = this.href;\r\n//			\r\n//		});\r\n//		mui('body').on('tap','#forget-password',function(){\r\n//			alert(1)\r\n//			window.location.href = \"wj_password.aspx\";\r\n//			\r\n//		});\r\n		mui('body').on('tap','a',function(){\r\n			//alert(1);\r\n			location.href = this.href;\r\n		});\r\n\r\n		mui('body').on('tap','#register',function(){\r\n			location.href = this.href ;\r\n		})\r\n		\r\n		\r\n//		\r\n		//用户登录提交相关数据\r\n		\r\n	</");
	templateBuilder.Append("script>\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
