<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.payment" ValidateRequest="false" %>
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
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" />\r\n		<title>充值</title>\r\n		<style>\r\n			.mui-toast-container{\r\n				bottom: 50%;\r\n			}\r\n			.wrap-box {\r\n				font-size: 14px;\r\n			}\r\n			.wrap-box dl{\r\n				height: 1rem;\r\n				line-height: 1rem;\r\n				position: relative;\r\n			}\r\n			.wrap-box dl:after{\r\n				position: absolute;\r\n				height: 1px;\r\n				background: #e5e5e5;\r\n				bottom: 0;\r\n				left: 12px;\r\n				width: 100%;\r\n				content: '';\r\n			}\r\n			.wrap-box dl dt,.wrap-box dl dd{\r\n				width: 50%;\r\n				float: left;\r\n			}\r\n			.wrap-box dl dt{\r\n				padding-left: 12px;\r\n				\r\n			}\r\n			.wrap-box dl dd{\r\n				padding-right: 12px;\r\n				text-align: right;\r\n			}\r\n			.pay .mui-btn{\r\n				background: #7D0000;\r\n				border: 1px solid #7D0000;\r\n			}\r\n			\r\n			.wrap-box h2{\r\n				padding-top: 30px;\r\n				text-align: center;\r\n				color: #333;\r\n				font-weight: normal;\r\n			}\r\n			.wrap-box .tip{\r\n				width: 100%;\r\n				padding-left: 12px;\r\n				margin-top: 20px;\r\n			}\r\n			.wrap-box .tip p{\r\n				line-height: 30px;\r\n				\r\n				\r\n			}\r\n		</style>\r\n	</head>\r\n	<body>\r\n        ");
	if (action=="confirm")
	{

	templateBuilder.Append("\r\n        <form id=\"pay_form\" name=\"pay_form\" method=\"get\" action=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("api/payment/");
	templateBuilder.Append(Utils.ObjectToStr(payModel.api_path));
	templateBuilder.Append("/index.aspx\" target=\"_blank\">\r\n            <input id=\"pay_order_no\" name=\"pay_order_no\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(order_no));
	templateBuilder.Append("\" />\r\n            <input id=\"pay_order_amount\" name=\"pay_order_amount\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(order_amount));
	templateBuilder.Append("\" />\r\n            <input id=\"pay_user_name\" name=\"pay_user_name\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
	templateBuilder.Append("\" />\r\n            <dd class=\"wrap-box\">\r\n                <dl class=\"mui-clearfix\">\r\n                    <dt>支付金额</dt>\r\n                    <dd>￥");
	templateBuilder.Append(Utils.ObjectToStr(order_amount));
	templateBuilder.Append("</dd>\r\n                </dl>\r\n                <dl class=\"mui-clearfix\">\r\n                    <dt>支付方式</dt>\r\n\r\n                    <dd>\r\n                        ");
	templateBuilder.Append(Utils.ObjectToStr(payModel.title));
	templateBuilder.Append("\r\n                    </dd>\r\n\r\n                </dl>\r\n                <input id=\"pay_subject\" name=\"pay_subject\" type=\"hidden\" value=\"购买商品\" />\r\n\r\n                <div style=\"padding:0 0 15px 0;margin-top: 15px;\" class=\"pay\">\r\n                    <input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" value=\"确认付款\" class=\"mui-btn mui-btn-block \" />\r\n                </div>\r\n        </form>\r\n\r\n        ");
	}	//end for if

	if (action=="succeed")
	{

	templateBuilder.Append("\r\n        <!--支付成功-->\r\n        <div class=\"wrap-box\">\r\n            <h2>支付成功</h2>\r\n            <div class=\"tip\">\r\n                <span class=\"icon check\"></span>\r\n                <p>恭喜您，您的支付已经成功！</p>\r\n                <p>您可以点击这里进入<a name=\"");
	templateBuilder.Append("<%linkurl(\" usercenter\",\"index\")%>");
	templateBuilder.Append("\" data-ignore=\"true\">会员中心</a>查看订单状态！</p>\r\n                <p>如有其它问题，请立即与我们客服人员联系。</p>\r\n            </div>\r\n        </div>\r\n        <!--/支付成功-->\r\n        ");
	}	//end for if

	if (action=="error")
	{

	templateBuilder.Append("\r\n        <!--支付出错-->\r\n        <div class=\"wrap-box\">\r\n            <h2>支付失败</h2>\r\n            <div class=\"tip\">\r\n                <span class=\"icon close\"></span>\r\n                <p>支付过程中发生意处错误！</p>\r\n                <p>您可以点击这里进入<a name=\"");
	templateBuilder.Append("<%linkurl(\" usercenter\",\"index\")%>");
	templateBuilder.Append("\" data-ignore=\"true\">会员中心</a>查看订单状态！</p>\r\n                <p>如您确实已经支付，请与我们客服人员联系。</p>\r\n            </div>\r\n        </div>\r\n        <!--/支付出错-->\r\n        ");
	}	//end for if

	if (action=="login")
	{

	templateBuilder.Append("\r\n        <!--用户未登录-->\r\n        <div class=\"wrap-box\">\r\n            <h2>会员登录</h2>\r\n            <div class=\"tip\">\r\n                <span class=\"icon info\"></span>\r\n                <p>您尚未登录或已经超时啦！</p>\r\n                <p>已是会员用户，请<a name=\"");
	templateBuilder.Append("<%linkurl(\" login\")%>");
	templateBuilder.Append("\" data-ignore=\"true\">点击这里登录</a>。</p>\r\n                <p>尚未注册会员，请<a name=\"");
	templateBuilder.Append("<%linkurl(\" register\")%>");
	templateBuilder.Append("\" data-ignore=\"true\">点击这里注册</a>。</p>\r\n            </div>\r\n        </div>\r\n        <!--/用户未登录-->\r\n        ");
	}	//end for if

	if (action=="recharge")
	{

	templateBuilder.Append("\r\n        <!--用户余额不足-->\r\n        <div class=\"wrap-box\">\r\n            <h2>余额不足</h2>\r\n            <div class=\"tip\">\r\n                <span class=\"icon warning\"></span>\r\n                <p>对不起，您的余额不足本次支付！</p>\r\n                <p>如余额不足，请<a class=\"close-popup\" name=\"");
	templateBuilder.Append("<%linkurl(\" userwallet\")%>");
	templateBuilder.Append("\" data-ignore=\"true\">点击这里充值</a>后进行支付！</p>\r\n                <p>如果有任何问题，请与我们客服取得联系。</p>\r\n            </div>\r\n        </div>\r\n        <!--/用户余额不足-->\r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		//MUI框架初始化\r\n		mui.init();\r\n		\r\n	\r\n		\r\n		\r\n</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
