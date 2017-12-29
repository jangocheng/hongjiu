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
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" />\r\n		<title>活动说明</title>\r\n		<style type=\"text/css\">\r\n			body{\r\n				font-size: 12px;\r\n				background: #F2F2F2;\r\n			}\r\n			.wenzhang h3{\r\n				margin-bottom: 15px;\r\n				font-size: 18px;\r\n				font-weight: normal;\r\n			}\r\n			.wenzhang{\r\n				padding: 15px;\r\n			}\r\n			.wenzhang h4{\r\n				font-size: 16px;\r\n				line-height: 24px;\r\n				font-weight: normal;\r\n				\r\n			}\r\n			.wenzhang p{\r\n				line-height: 24px;\r\n				color: #333;\r\n			}\r\n			.mui-content{\r\n				background: #F4F4F4 !important;\r\n			}\r\n		</style>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content wenzhang\">\r\n			<h3>活动说明</h3>\r\n			<h4>\r\n				一、在升级区购买指定的升级商品后，<span style=\"color: #7D0000;\">可获得一次商品价值增值换购的机会</span>。\r\n			</h4>\r\n			<h4>二、购买成功后，可在商城升级定单界面查看定购的商品。您可以进行升级或立即提货，点击升级跳转到升级活动页面。</h4>\r\n			<h4>三、在升级区活动页面可按您的意向选择动“猜奇偶”或“拆红包”选项。</h4>\r\n			<div>\r\n				<p>1. “猜奇偶”<span style=\"color: #7D0000;\">将根据当期开奖的时时彩公布最后一位尾数的奇偶结果作为是否升级成功的评判标准，竞猜正确则升级成功，反之则升级失败。</span></p>\r\n				<p style=\"color: #7D0000;\">猜奇偶时间：周一至周日上午10：00-凌晨02:00</p>\r\n				<p>2.“拆红包”将根据买家竞猜的<span style=\"color: #7D0000;\">卡片翻牌之后的结果“升级成功”或“升级失败”生成定单</span>，当买家竞猜成功时，买家享受商城给予该商品的特价价格生成定单优惠件，当买家竞猜失败时，商城则以该商品的原价生成定单；</p>\r\n				<p style=\"color: #7D0000;\">拆红包时间：周一至周日09:00am-02:00am</p>\r\n				\r\n			</div>\r\n			<h4>四、游戏结束升级结果</h4>\r\n			<p>\r\n				1.升级成功：<span style=\"color: #7D0000;\">客户购买的商品即可享受升级为更高价值的商品，此商品可在我的订单中查看，选择“提货”或者 “提款”。</span>\r\n			</p>\r\n			<p>\r\n				2.升级失败： 客户购买的商品将不享受任何优惠，此商品可在我的定单中查看，只可选择“提货”\r\n			</p>\r\n			<p>\r\n				3.开奖中：当点击升级后，商城有权暂时冻结用于升级的商品，此时无法对订单进行任何操作，等到升级产生结果后方可进行下一步操作。\r\n			</p>\r\n			<p>\r\n				4.当天参与升级或猜红包的订单，可在“我的红包记录”与“我的升级记录”里面查看\r\n			</p>\r\n			<h4>五、提货</h4>\r\n			<p>在商城促销定单中的商品，您可以击 “提货”按钮，进行提货，商城将会发送货物。\r\n<span style=\"color: #7D0000;\">（注意：任何未操作的单子，一旦点击合并，就只能合并提货！）</span></p>\r\n			<h4>六、提款</h4>\r\n			<p style=\"color: #7D0000;\">升级成功的商品在未提货的前提下可直接在“我的订单”中申请提款。</p>\r\n			<h4>七、提货须知</h4>\r\n			<p>可在商城购买任意商品，选择提货，商城将会在7个工作日内为您安排发货。发货后1-2日内未收到任何异议将视为自动确认收货。\r\n</p>\r\n			<h4>八、查看</h4>\r\n			<p>未完结的单子一律会在“全部订单”里面可查看（未完结单子：对单子未选择退货，提款；或者已选择提货未收到货的）</p>\r\n			\r\n		</div>\r\n	</body>\r\n	\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
