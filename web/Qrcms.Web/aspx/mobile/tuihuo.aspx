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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" rel=\"stylesheet\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" />\r\n		<title>退货须知</title>\r\n		<style type=\"text/css\">\r\n			body{\r\n				font-size: 12px;\r\n				background: #F2F2F2;\r\n			}\r\n			.wenzhang h3{\r\n				margin-bottom: 15px;\r\n				font-size: 18px;\r\n				font-weight: normal;\r\n			}\r\n			.wenzhang{\r\n				padding: 15px;\r\n			}\r\n			.wenzhang h4{\r\n				font-size: 16px;\r\n				line-height: 24px;\r\n				font-weight: normal;\r\n				\r\n			}\r\n			.wenzhang p{\r\n				line-height: 24px;\r\n				color: #333;\r\n			}\r\n			.mui-content{\r\n				background: #F4F4F4 !important;\r\n			}\r\n		</style>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content wenzhang\">\r\n			\r\n			<h3>退货须知</h3>\r\n			<p>				1.时间</p>\r\n			<p>若因质量问题请在收到之日起3个工作日内联系客服进行换货。申请退货金额将在1-3个工作日退回至客户账户。</p>\r\n			<p>2.换货原因</p>\r\n			<p>商品质量问题。收到商品与商城详情不符。</p>\r\n			<p>3.换货流程</p>\r\n			<p>首先确认需换货商品为非人为损坏。将附件、购物凭证、包装礼盒、商品及捆绑的赠品一并返回我司办理换货手续。\r\n如果顾客在使用时对商品质量表示质疑，须出具书面鉴定，商城将按照国家法律规定予以处理。</p>\r\n			<p>4.注意事项</p>\r\n			<p>如有缺失附件无法更换。红酒已开瓶等不予换货。包装含防伪码的商品防伪码一经刮开不予换货。</p>\r\n			<p>5.退货须知</p>\r\n			<p>满足底下任意要求，即可自行选择点击无理由退货。购买商城中任意商品，未参与升级促销及申请提货的，可直接在“我的订单”中申请退货。\r\n升级成功的商品在未提货的前提下可直接在“我的订单”中申请提款。\r\n</p>\r\n			<p style=\"color: #7D0000;\">温馨提示:</p>\r\n			<p style=\"color: #7D0000;\">请您认真并完全理解，同意上述的退货要须知与操作流程，如您不能完全理解或同意本退货须知，您可以选择不操作商品退货的申请。</p>\r\n		</div>\r\n	</body>\r\n	\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
