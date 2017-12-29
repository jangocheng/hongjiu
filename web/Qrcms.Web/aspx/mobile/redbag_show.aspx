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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" />		\r\n		<title>红包记录</title>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content redbao_jl\">\r\n			<div class=\"hbjl_banner\">\r\n				<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/hbjl.png\">\r\n			</div>\r\n			<div class=\"hb_goods\">\r\n				<ul>\r\n					<li class=\"mui-card\">\r\n						<p class=\"mui-clearfix\">订单号1111111111111<span>已中奖</span></p>\r\n						<div class=\"goods-list\">\r\n									    		\r\n									 <div style=\"background: #fff url(");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/myorder1.png) no-repeat 12px 10px/100px 100px;min-height: 100px;\">\r\n										 <p>买1箱得2箱 法国原瓶进口波尔多AOC 红酒MS干红葡萄酒整箱</p>\r\n										  <p class=\"price mui-clearfix\">￥2999<a href=\"\" id=\"sqtk\">申请提款</a></p>  		\r\n									</div>\r\n										    	\r\n								</div>\r\n									    	<div>\r\n									    		\r\n									    		<ul class=\"mui-table-view\">\r\n									    			<li class=\"mui-table-view-cell\">\r\n									    				<a href=\"\" class=\"mui-navigate-right\">请选择收货地址</a>\r\n									    			</li>\r\n									    			<li class=\"mui-table-view-cell\">\r\n									    				<p>生成时间: 2017-07-31 18:00</p>\r\n									    			</li>\r\n									    		</ul>\r\n									    			\r\n									    	</div>\r\n						</li>\r\n				</ul>\r\n				<div class=\"ck\">\r\n					<h3>提款金额</h3>\r\n					<p class=\"tkje\">￥<span>2999</span></p>\r\n					<p class=\"jlyj\">奖励佣金：￥29.9</p>\r\n					<a href=\"\" class=\"tkBtn\">确定提款</a>\r\n					<a href=\"\" class=\"gb\" id=\"gbbtn\"></a>\r\n				</div>\r\n				<div class=\"ckbg\"></div>\r\n			</div>\r\n		</div>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n		\r\n		mui('body').on('tap','#sqtk',function(){\r\n			\r\n			$('.ck,.ckbg').css('display','block');\r\n		})\r\n		mui('body').on('tap','#gbbtn',function(){\r\n			$('.ck,.ckbg').css('display','none');\r\n		})\r\n		\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
