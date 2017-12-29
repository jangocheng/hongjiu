<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.userorder_show" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n\r\n	<head>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" />\r\n		<title>提货详情</title>\r\n		<style>\r\n			.redbao_jl .mui-card .main p span {\r\n				font-size: 14px;\r\n				float: none;\r\n				color: #999;\r\n			}\r\n			\r\n			.redbao_jl .mui-card .dizhi p span {\r\n				color: #8f8f94;\r\n				font-size: 14px;\r\n				float: none;\r\n			}\r\n			\r\n			.redbao_jl .mui-card .dizhi p .mui-pull-right {\r\n				float: right;\r\n			}\r\n		</style>\r\n	</head>\r\n\r\n	<body>\r\n		<div class=\"mui-content redbao_jl\">\r\n			<div class=\"hb_goods\">\r\n				<ul>\r\n					");
	if (model.order_goods!=null)
	{

	foreach(Qrcms.Model.order_goods modelt in model.order_goods)
	{

	templateBuilder.Append("\r\n					<li class=\"mui-card\">\r\n						<p class=\"mui-clearfix\">订单号");
	templateBuilder.Append(Utils.ObjectToStr(model.order_no));
	templateBuilder.Append("<span>已中奖</span></p>\r\n						<div class=\"goods-list\">\r\n\r\n							<div style=\"background: #fff url(");
	templateBuilder.Append(get_article_img_url(modelt.article_id).ToString());

	templateBuilder.Append(") no-repeat 12px 10px/100px 100px;min-height: 100px;\">\r\n								<p>");
	templateBuilder.Append(Utils.ObjectToStr(modelt.goods_title));
	templateBuilder.Append("</p>\r\n								<p class=\"price mui-clearfix mui-text-right\">￥");
	templateBuilder.Append(Utils.ObjectToStr(modelt.real_price));
	templateBuilder.Append("&nbsp;&nbsp;&nbsp;数量：×<span>");
	templateBuilder.Append(Utils.ObjectToStr(modelt.quantity));
	templateBuilder.Append("</span></p>\r\n							</div>\r\n\r\n						</div>\r\n						<div>\r\n\r\n							<ul class=\"mui-table-view main\">\r\n								<li class=\"mui-table-view-cell\">\r\n									<p>提款金额: <span>2999</span></p>\r\n									<p>奖励佣金: <span>20</span></p>\r\n								</li>\r\n\r\n								<li class=\"mui-table-view-cell\">\r\n									<p>生成时间: <span>2017-07-31 18:00</span></p>\r\n								</li>\r\n								<li class=\"mui-table-view-cell\">\r\n									<p>订单状态: <span>待支付</span></p>\r\n								</li>\r\n							</ul>\r\n\r\n						</div>\r\n					</li>\r\n					");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n				</ul>\r\n\r\n			</div>\r\n		</div>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n\r\n		mui('body').on('tap', '#sqtk', function() {\r\n\r\n			$('.ck,.ckbg').css('display', 'block');\r\n		})\r\n		mui('body').on('tap', '#gbbtn', function() {\r\n			$('.ck,.ckbg').css('display', 'none');\r\n		})\r\n	</");
	templateBuilder.Append("script>\r\n\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
