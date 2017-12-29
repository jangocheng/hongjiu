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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" />	\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<title>更换银行卡</title>\r\n		\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content\" id=\"bank_page\">\r\n        	\r\n			<div class=\"mui-page-content my-bankcard  mtp\">\r\n				<div class=\"mui-scroll-wrapper\" id=\"bankcard_list\">\r\n					<div class=\"mui-scroll\">\r\n						<ul id=\"bank_list\">\r\n							\r\n						</ul>\r\n						<div id=\"cardbox\">\r\n		    	\r\n		    			</div>\r\n						 <a id=\"add_bankcardBtn\" href=\"add-bankcard.html\" class=\"mui-btn mui-btn-blue mui-btn-block\">添加银行卡</a>\r\n					</div>\r\n				</div>\r\n				\r\n			</div>\r\n        </div>\r\n        <script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\"></");
	templateBuilder.Append("script>\r\n       <script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n       <script>\r\n       	mui.init();\r\n       	\r\n       		//获取银行卡\r\n		function banklist(){\r\n			mui.ajax('/tools/submit_ajax.ashx?action=bankcard_select',{\r\n				datatype:'string',\r\n				type:'get',\r\n				success:function(data){\r\n				//	alert(9);\r\n				data = JSON.parse(data);\r\n				console.log(data);\r\n						//console.log(JSON.stringify(data));\r\n					if(data.status == 1){\r\n						\r\n						var html ='';\r\n						for(var i=0;i<data.Rows.length;i++){\r\n							\r\n							//html +=\"<li><a href='add_bankcard'><div class='mui-card'><p>\"+data.Rows[i].bank_name+'</p><span>'+data.Rows[i].bank_card+'</span></div></a></li>';\r\n							html += '<li><a class=\"xz_bank\" data-id='+data.Rows[i].id+'>';\r\n							html +=\"<div class='mui-card'><p>\"+data.Rows[i].bank_name +\"</p><span>\";\r\n							html += data.Rows[i].bank_card + \"</span></div></a>\";\r\n							html +=\"<p class='mui-clearfix'><a href='add_bankcard.aspx?id=\"+data.Rows[i].id+\"'>编辑</a><a href='javascript:void(0)'  class='del_bank' data-id='\"+data.Rows[i].id+\"'>删除</a></p></li>\";\r\n						}\r\n						$('#bank_list').append(html);\r\n					}\r\n				}\r\n			})\r\n		}\r\n\r\n		banklist();\r\n		\r\n		mui('body').on('tap','.xz_bank',function(){\r\n			var bankId = $('.xz_bank').attr('data-id');\r\n			console.log(bankId);\r\n			setTimeout(function(){\r\n				window.location.href = 'tixian.apsx?id='+bankId;\r\n			},2000)\r\n		})\r\n       </");
	templateBuilder.Append("script>\r\n	</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
