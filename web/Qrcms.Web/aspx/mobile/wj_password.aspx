<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.repassword" ValidateRequest="false" %>
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

	templateBuilder.Append("\r\n<!doctype html>\r\n<html>\r\n\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<title>忘记密码</title>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" rel=\"stylesheet\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" />\r\n		<style>\r\n			.wj_password .mui-input-row > div{\r\n				display: inline-block;\r\n    padding:0 10px ;\r\n    height:30px;\r\n   \r\n    border: 1px solid #7D0000;\r\n    color: #fff;\r\n    background: #7D0000;\r\n    border-radius: 5px;\r\n    font-size: 12px;\r\n    text-align: center;\r\n    float: right;\r\n    margin-top: 11px;\r\n    margin-right: 12px;\r\n			}\r\n		</style>\r\n	</head>\r\n\r\n	<body style=\"min-height: 100%; background: #F2F2F2;\">\r\n		<div class=\"mui-content wj_password\">\r\n		    <div class=\"mui-input-group\">\r\n		    	<form id=\"form1\">\r\n		    		 <input type=\"hidden\" name=\"txtType\" value=\"mobile\" />\r\n		    		  <div class=\"mui-input-row\">\r\n			        	  <input id=\"txtCode\" name=\"txtCode\" type=\"text\" class=\"input code\" placeholder=\"输入验证码\" datatype=\"s4-20\" nullmsg=\"请输入右边显示的验证码\" sucmsg=\" \" />\r\n			        </div>\r\n			        <div class=\"mui-input-row\">\r\n			        	 <a class=\"send\" title=\"点击切换验证码\" href=\"javascript:;\" onclick=\"ToggleCode(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx');return false;\">\r\n              <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx\" width=\"80\" height=\"22\" />\r\n          			  </a>\r\n			        </div>\r\n		    		  <div class=\"mui-input-row\">\r\n			            <input type=\"text\" name=\"txtUserName\" id=\"txtPhone\" datatype=\"phone\" errormsg=\"请输入用户名！\" class=\"mui-input-clear\" placeholder=\"请输入用户名\" style=\"width: 70%;\">\r\n			            <div id=\"getCode\">获取验证码</div>\r\n			        </div>\r\n		    	</form>\r\n		    	<form id=\"wjpwd_form\">\r\n			      \r\n			        <div class=\"mui-input-row\">\r\n			            <input type=\"text\" name=\"hideCode\" id=\"hideCode\" class=\"mui-input-clear\" datatype=\"notnull\" errormsg=\"请输入验证码！\" placeholder=\"请输入手机验证码\">\r\n			        </div>\r\n			        <div class=\"mui-input-row\">\r\n			            <input type=\"password\" name=\"txtPassword\" id=\"txtPassword\" datatype=\"notnull\" errormsg=\"请输入密码！\" class=\"mui-input-clear\" placeholder=\"请设置登录密码\">\r\n			        </div>\r\n			         <div class=\"mui-input-row\">\r\n			            <input type=\"password\" datatype=\"notnull\" errormsg=\"请输入密码！\" class=\"mui-input-clear\" name=\"txtPassword1\" id=\"txtPwdAgain\" placeholder=\"请再次输入登录密码\">\r\n			        </div>\r\n			      \r\n			       \r\n			        <input type=\"hidden\" name=\"txtUserName\" id=\"txtUserName\" value=\"13586322035\" />\r\n			       \r\n		        </form>\r\n		    </div>\r\n		    <button id=\"pwdagain_submit\" type=\"button\" class=\"mui-btn mui-btn-blue mui-btn-block regbtn\">确认修改</button>\r\n		  \r\n		</div>\r\n		<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n		<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n		<!--<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n		-->\r\n		<script>\r\n			\r\n			/*MUI初始化*/\r\n			mui.init();\r\n			/*向手机发送验证码*/\r\n//		mui('body').on('tap','#getCode',function(){\r\n//			sendSMS('#getCode','#txtPhone','/tools/submit_ajax.ashx?action=user_verify_smscode&site=mobile');\r\n//		});\r\n		\r\n			\r\n			/*向用户的手机发送验证码*/\r\n//			mui('body').on('tap','#getCode',function(){\r\n//				SendSMS('#getCode','#txtPhone','/tools/submit_ajax.ashx?action=user_verify_smscode&site=main\r\n//');\r\n//			});\r\n		//切换验证码\r\nfunction ToggleCode(obj, codeurl) {\r\n    $(obj).children(\"img\").eq(0).attr(\"src\", codeurl + \"?time=\" + Math.random());\r\n	return false;\r\n}\r\n		//向用户手机发送验证码\r\n			mui('body').on('tap','#getCode',function(){\r\n				\r\n				var formdata1 = $('#form1').serialize();\r\n				console.log(formdata1);\r\n				mui.ajax('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_getpassword&site=mobile',{\r\n					datatype:'json',\r\n					data:formdata1,\r\n					type:'post',\r\n					success:function(data){\r\n						data = JSON.parse(data);\r\n						console.log(data);\r\n						if(data.status == 1){\r\n							mui.toast('验证码获取成功');\r\n						}\r\n					}\r\n				})\r\n			});\r\n			/*提交用户修改密码的相关数据*/\r\n			mui('body').on('tap','#pwdagain_submit',function(){\r\n				console.log('开始提交');\r\n				var formdata = $('#wjpwd_form').serialize();\r\n				console.log(formdata);\r\n				if(document.getElementById('txtPassword').value != document.getElementById('txtPwdAgain').value ){\r\n					mui.toast('两次密码不一致');\r\n				}else{\r\n				\r\n						mui.ajax('/tools/submit_ajax.ashx?action=user_repassword&site=mobile',{\r\n							datatype:'json',\r\n							type:'post',\r\n							data:formdata,\r\n							success:function(data){\r\n								data = JSON.parse(data);\r\n								if(data.status ==1){\r\n									mui.toast(data.msg);\r\n									setTimeout(function(){\r\n									//	alert(1);\r\n										window.location.href ='login.aspx'\r\n									},2000)\r\n								}else{\r\n									mui.toast(data.msg)\r\n								}\r\n							},\r\n							error:function(data){\r\n								mui.toast('失败');\r\n							}\r\n						})\r\n				\r\n				}\r\n				\r\n			})\r\n		</");
	templateBuilder.Append("script>\r\n	</body>\r\n\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
