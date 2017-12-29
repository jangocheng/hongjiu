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

	templateBuilder.Append("<!doctype html>\r\n<html>\r\n\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<title>绑定银行卡</title>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" rel=\"stylesheet\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n	</head>\r\n	<style type=\"text/css\">\r\n		.bindbankcard {font-size: 14px;}\r\n		.bindbankcard input{font-size: 14px;}\r\n		.mui-toast-container{\r\n			bottom: 30%;\r\n		}\r\n	</style>\r\n	<body>\r\n		<div class=\"mui-content my-bankcard\">\r\n		    <div class=\"bindbankcard\">\r\n					<div class=\"mui-input-group\">\r\n						<form id=\"bank_form\">\r\n			    	    <div class=\"mui-input-row\">\r\n			    	        <label>开户银行</label>\r\n			    	        <input type=\"text\" name=\"bank_name\" id=\"Bankmc\" datatype=\"notnull\" errormsg=\"请输入开户银行!\" class=\"mui-input-clear\" placeholder=\"选择开户银行\">\r\n			    	        <input type=\"hidden\" value=\"\" name=\"id\" id=\"BankId\" />\r\n			    	    </div>\r\n			    	    <div class=\"mui-input-row\">\r\n			    	        <label>户名</label>\r\n			    	        <input type=\"text\" name=\"bank_username\" id=\"BankTrueName\" datatype=\"name\" errormsg=\"请输入开户名!\" class=\"mui-input-clear\" placeholder=\"填写银行卡户名\">\r\n			    	    </div>\r\n			    	    <div class=\"mui-input-row\">\r\n			    	        <label>卡号</label>\r\n			    	        <input type=\"text\" name=\"bank_card\" id=\"BankCardNo\" datatype=\"bankcard\" errormsg=\"请输入正确的银行卡号!\" class=\"mui-input-clear\" placeholder=\"填写银行卡卡号\">\r\n			    	    </div>\r\n			    	    <div class=\"mui-input-row mui-hidden\">\r\n			    	        <label>支行</label>\r\n			    	        <input type=\"text\" name=\"zhihang\" id=\"zhihang\" datatype=\"notnull\" errormsg=\"请输入银行支行!\" class=\"mui-input-clear\" placeholder=\"填写银行支行\" value=\"1\">\r\n			    	    </div>\r\n			    	    </form>\r\n		    	   </div>\r\n			    	<p>注：<br>\r\n			    	1.请确认所填写的银行卡信息无误后进行提交，不可更改。<br>\r\n					2.绑定的银行卡,如丢失请及时挂失补卡,\r\n					以免因账户逾期对您个人征信造成不良影响.\r\n			    	</p>\r\n			    	<button id=\"submit\" type=\"button\" class=\"mui-btn mui-btn-blue mui-btn-block\">确认提交</button>\r\n			    </div>\r\n		</div>\r\n		<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\"></");
	templateBuilder.Append("script>\r\n		<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n		<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n		<script type=\"text/javascript\">\r\n			mui.init();\r\n			\r\n		\r\n			\r\n			var id = getQueryString('id');\r\n			console.log(id);\r\n			function getinfo(id){\r\n				$.ajax({\r\n						type:\"get\",\r\n						url:\"/tools/submit_ajax.ashx?action=bankcard_selectid\",\r\n						async:true,\r\n						data:{\r\n							id:id\r\n						},\r\n						dataType:\"json\",\r\n						success:function(data){\r\n							if(data.status == 1){\r\n//								$(\"#fbbus_customername\").val(data.rows[0].subname);\r\n								$('#BankId').val(data.Rows[0].id);\r\n								$('#Bankmc').val(data.Rows[0].bank_name);\r\n								$('#BankTrueName').val(data.Rows[0].bank_username);\r\n								$('#BankCardNo').val(data.Rows[0].bank_card);\r\n								\r\n							}else{\r\n								//layer.msg(data.msg);\r\n								\r\n							}\r\n						},\r\n						error:function(){\r\n						//	layer.msg(data.msg);\r\n						}\r\n					});\r\n			}\r\n			if(id){\r\n				getinfo(id);\r\n			}\r\n			\r\n			\r\n			var action ='';\r\n			if(id){\r\n				action='bankcard_update'\r\n			}else{\r\n				action ='bankcard_add'\r\n			}\r\n			\r\n			//提交银行卡\r\n			mui('body').on('tap','#submit',function(){\r\n				if(getValid('bank_form')){\r\n					console.log(\"准备提交！\");\r\n				\r\n					\r\n					mui.ajax('/tools/submit_ajax.ashx?action='+action,{\r\n						data:{\r\n							'id':document.getElementById('BankId').value,\r\n							'bank_name':document.getElementById('Bankmc').value,\r\n							'bank_username':document.getElementById('BankTrueName').value,\r\n							'bank_card':document.getElementById('BankCardNo').value\r\n						},\r\n						dataType:'json',\r\n						type:'post',\r\n						async:true,\r\n						success:function(data){\r\n							//data = JSON.parse(data);\r\n							if(data.status ==1){\r\n								//mui.toast(2);\r\n								mui.toast(data.msg);\r\n								setTimeout(function(){\r\n									window.location.href = 'usercenter.aspx';\r\n								},2000)\r\n							}else{\r\n								mui.toast(data.msg);\r\n							}\r\n						},\r\n						error:function(data){\r\n							mui.toast(1);\r\n							mui.toast(data.msg);\r\n						}\r\n					})\r\n				}else{\r\n					\r\n				}\r\n			});\r\n		</");
	templateBuilder.Append("script>\r\n	</body>\r\n\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
