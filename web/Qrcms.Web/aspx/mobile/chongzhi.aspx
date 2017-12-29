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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		\r\n		<meta charset=\"UTF-8\">\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n	\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" rel=\"stylesheet\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" />\r\n		<title>充值</title>\r\n		<style>\r\n			.mui-toast-container{\r\n				bottom: 50%;\r\n			}\r\n		</style>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content chongzhi\">\r\n			<form id=\"cz_form\">\r\n				<div class=\"mui-input-group\">\r\n					<div class=\"mui-input-row\">\r\n						<input type=\"text\" name=\"order_amount\" id=\"money_num\" placeholder=\"请输入充值金额\" datatype=\"n\" errormsg=\"请输入充值金额\"/>\r\n					</div>				\r\n				</div>\r\n			</form>\r\n			\r\n			<p class=\"kscz\">快速充值</p>\r\n			<div class=\"cz_moneybox mui-clearfix\" id=\"cz_money\">\r\n					<label><span>200.18</span>元</label>\r\n					<label><span>300.66</span>元</label>\r\n					<label><span>500.68</span>元</label>\r\n					<label><span>1000.46</span>元</label>\r\n					<label><span>3000.56</span>元</label>\r\n					<label><span>5000.45</span>元</label>\r\n			</div>\r\n			<p class=\"kscz\">支付方式</p>\r\n\r\n            ");
	DataTable paymentList = get_payment_list(0, "is_lock=0 and (is_mobile=2)");

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n            ");
	int dr1__loop__id=0;
	foreach(DataRow dr1 in paymentList.Rows)
	{
		dr1__loop__id++;


	templateBuilder.Append("\r\n\r\n            <p class=\"wxpay mui-clearfix\">\r\n                " + Utils.ObjectToStr(dr1["title"]) + "\r\n                <span class=\"mui-checkbox mui-clearfix\"><input type=\"radio\" style='height:18px;width:18px' name=\"wxPay\" value=\"" + Utils.ObjectToStr(dr1["id"]) + "\"></span>\r\n            </p>\r\n           \r\n            ");
	}	//end for if

    templateBuilder.Append("\r\n\r\n			<div class=\"goto_paybox\" style='background:white;bottom:0px;border-top: 0.1px solid #e6dddd;'>\r\n				<p>点击去充值，即表示阅读并同意<span>充值协议</span></p>\r\n				<p>玖方商城不会以任何形式要求您输入银行账户和密码</p>\r\n				<button id=\"chongzhi_submit\" class=\"mui-btn mui-btn-block colorfff\">去充值</button>\r\n			</div>\r\n		</div>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		//MUI框架初始化\r\n		mui.init();\r\n		\r\n	\r\n	\r\n		//获取用户选择的充值金额\r\n		 var chongzhiBox = document.getElementById('cz_money');\r\n		 var label = chongzhiBox.getElementsByTagName('label');\r\n		 var money = '';\r\n		 for(var i = 0; i<label.length;i++){\r\n		 	label[i].onclick = function(){		 		\r\n		 		money = $(this).children().text();\r\n		 		console.log(money);\r\n		 		$(this).siblings().removeClass('active');\r\n		 		$(this).addClass('active');\r\n		 		\r\n		 		\r\n		 		$(\"#money_num\").val(money);\r\n		 		\r\n		 		\r\n		 	}\r\n		 }\r\n	\r\n		\r\n		//用户提交相关数据\r\n		mui('body').on('tap','#chongzhi_submit',function(){\r\n			var money_num = document.getElementById('money_num').value;\r\n			var pay_id = $(\"input[name='wxPay']:checked\").val();\r\n			if(money == 0 && money_num ==\"\"){\r\n			    mui.toast('请输入或者选择充值金额');\r\n			    return false;\r\n			}\r\n			if (!pay_id) {\r\n			    mui.toast('请选择支付方式！');\r\n			    return false;\r\n			}\r\n			else {\r\n					mui.ajax(\"/tools/submit_ajax.ashx?action=user_amount_recharge&site=mobile\",{\r\n						data:{\r\n							order_amount:document.getElementById('money_num').value,\r\n							payment_id:pay_id\r\n						},\r\n						dataType:\"json\",\r\n						type:\"post\",\r\n						success:function(data){\r\n							if(data.status == \"1\"){\r\n								mui.toast(data.msg);\r\n								setTimeout(function(){\r\n									window.location.href = data.url;\r\n								},1000)\r\n							}else{\r\n								mui.toast(data.msg);\r\n							}\r\n						}\r\n					})\r\n			 	}\r\n			\r\n			\r\n			\r\n		})\r\n		\r\n		$('.wxpay').eq(1).hide();\r\n</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
