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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" rel=\"stylesheet\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" />\r\n		<title>实名认证</title>\r\n		<style type=\"text/css\">\r\n			.mui-toast-container{\r\n				bottom:30% !important;\r\n			}\r\n			\r\n		</style>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content realname_rz\">\r\n			 <div class=\"mui-input-group\">\r\n		       <form id=\"rz_form\">\r\n		       		<div class=\"mui-input-row\">\r\n		         		<span>用户名</span><input type=\"text\"  value='");
	templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
	templateBuilder.Append("'>\r\n		       		</div>\r\n			        <div class=\"mui-input-row\">\r\n			           <span>真实姓名</span><input class=\"mui-input-clear\" type=\"text\" placeholder=\"请输入真实姓名\" id=\"realName\" name=\"real_name\"  datatype=\"name\"  errormsg=\"请输入真实姓名\"/>\r\n			        </div>\r\n			        <div class=\"mui-input-row\">\r\n			           <span>手机号码</span><input type=\"tel\" class=\"mui-input-clear\"  placeholder=\"请输入手机号码\" name=\"txtMobile\" id=\"txtPhone\" datatype=\"phone\" errormsg=\"请输入正确的手机号码\"/>\r\n			        </div>\r\n			        <div class=\"mui-input-row rz_yzm\">\r\n			           <span>验证码</span><input type=\"tel\" class=\"mui-input-clear\"  placeholder=\"请输入验证码\" id=\"yzcode\" name=\"yzcode\"/><div class=\"get_yzm\" id=\"getCode\" style=\"line-height: 30px;\">获取验证码</div>\r\n			        </div>\r\n			        <div class=\"mui-input-row\">\r\n			        	<span>身份证号码</span><input type=\"tel\" class=\"mui-input-clear\"  placeholder=\"请输入身份证号码\" id=\"idcard\" name=\"idcard\" <!--datatype=\"sfz\" errormsg=\"请输入正确的身份证号码\"-->\r\n			        </div>\r\n		       </form>\r\n		    </div>\r\n		    <p class=\"rz_notice\">注：请保证您输入的信息与微信实名绑定的姓名、身份证号信息一 致，否则将有可能会影响您的退货申请</p>\r\n		    <button class=\"mui-btn mui-btn-block colorfff\" id=\"rz_submit\">提交审核</button>\r\n		</div>\r\n		\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		\r\n		//MUI框架初始化\r\n		mui.init();\r\n		\r\n		//向用户手机发送验证码\r\n		mui('body').on('tap','#getCode',function(){\r\n			\r\n			sendSMS('#getCode','#txtPhone','/tools/submit_ajax.ashx?action=user_verify_smscode&site=mobile');\r\n		})\r\n		\r\n		//用户提交资料实名认证\r\n		mui('body').on('tap','#rz_submit',function(){\r\n			 checkid();\r\n			//打包用户提交认证的数据\r\n			//var formdata = serialize(document.getElementById('rz_form'));\r\n			var formdata = $('#rz_form').serialize();\r\n			\r\n			console.log(formdata);\r\n			if(getValid('rz_form')){\r\n				$.ajax({\r\n					type:\"post\",\r\n					url:\"/tools/submit_ajax.ashx?action=user_real\",\r\n					async:true,\r\n					data:formdata,\r\n					datatype:'string',\r\nsuccess: function(data){\r\n	data = JSON.parse(data);	\r\n	if(data.status == 1){\r\n		mui.toast(data.msg)\r\n		setTimeout(function(){\r\n			window.location.href=\"usercenter.aspx\"\r\n		},2000)\r\n		\r\n	}else{\r\n		mui.toast(\"认证失败\")\r\n	}\r\n\r\n}\r\n});\r\n}\r\n})\r\n/*身份验证*/\r\n   var  arr2  =   [7,  9,  10,  5,  8,  4,  2,  1,  6,  3,  7,  9,  10,  5,  8,  4,  2];        \r\nvar  arr3  =   [1,  0,  'X',  9,  8,  7,  6,  5,  4,  3,  2];\r\n\r\nfunction  checkid()  {            \r\n	var  t  =  document.getElementById(\"idcard\").value;            \r\n	if (t.length  ==  18)  {                \r\n		console.log('11');                \r\n		var  arr  =  t.split('');                \r\n		var  s;                \r\n		var  reg  =  /^\\d+$/;                \r\n		var  pd  =  0;                \r\n		for (i  =  0;  i  <  17;  i++)  {                    \r\n			if (reg.test(arr[i]))  {                        \r\n				s  =  true;                        \r\n				pd  =  arr[i]  *  arr2[i]  +  pd;                    \r\n			} \r\n			else  {                        \r\n				s  =  false;                        \r\n				break;                    \r\n			}                \r\n		}                \r\n		if (s  =  true)  {                    \r\n			var  r  =  pd  %  11;                    \r\n			if (arr[17]  ==  arr3[r])  {\r\n				mui.toast(\"身份证号合法  尾号为：\"  +  arr3[r])                        \r\n				                    \r\n			} \r\n			else  {     \r\n				mui.toast( \"非合法身份证号\");                   \r\n				         \r\n			}                \r\n		}\r\n\r\n		            \r\n	} \r\n	else  {\r\n		mui.toast( \"非合法身份证号\");             \r\n		    \r\n	}        \r\n}    </");
	templateBuilder.Append("script>\r\n</head>\r\n		\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
