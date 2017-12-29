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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<title>确认订单</title>\r\n	</head>\r\n	<body>\r\n		<div id=\"offCanvasWrapper\" class=\"mui-off-canvas-wrap mui-draggable confirm_order\">\r\n			<aside id=\"offCanvasSide\" class=\"mui-off-canvas-right\">\r\n				<div id=\"offCanvasSideScroll\" class=\"mui-scroll-wrapper\">\r\n					<div class=\"mui-scroll\">\r\n	\r\n					</div>\r\n				</div>\r\n			</aside>\r\n			<div class=\"mui-inner-wrap\">\r\n				<div id=\"offCanvasContentScroll\" class=\"mui-content mui-scroll-wrapper\">\r\n					<div class=\"mui-scroll\">\r\n					    <div class=\"mui-card mui-navigate-right sel-address\">\r\n					    	<p>吴亚武<span>12545258785</span></p>\r\n					    	<p>浙江省杭州市江干区区政府大楼区长办公室</p>\r\n					    	<input type=\"hidden\" name=\"index_address_id\"/>\r\n					    </div>\r\n					    \r\n					    <!--订单项目列表开始-->\r\n					    <div class=\"mui-card goods\">\r\n		    				\r\n		    				<input type=\"hidden\" name=\"branch_no\"  />\r\n		    	\r\n					    	<div class=\"goods-list\">\r\n					    		<div style=\"background: #fff url(images/goods-img1.jpg) no-repeat 12px 10px/100px 100px;\">\r\n						    		<p>买一送二红酒买一送二红酒买红酒买</p>\r\n						    		<p>￥299<span>x1</span></p>\r\n						    		<div class=\"mui-numbox\" data-numbox-step=\"1\" data-numbox-min=\"0\" data-numbox-max=\"100\">\r\n										<button class=\"mui-btn mui-numbox-btn-minus\" type=\"button\">-</button>	\r\n										<input type=\"text\" value=\"1\" class=\"mui-numbox-input\" />\r\n										<button class=\"mui-btn mui-numbox-btn-plus\" type=\"button\">+</button>\r\n									</div>\r\n						    	</div>\r\n					    	</div>\r\n		    \r\n					    	<div class=\"mui-input-group\">\r\n					    	    <div class=\"mui-input-row\">\r\n					    	        <label>配送方式</label>\r\n					    	      \r\n					    	        <input type=\"text\" readonly value=\"包邮 \">\r\n					    			<input type=\"hidden\" name=\"express_id\"  />\r\n					    			\r\n					    	    </div>\r\n					    	    <!--<div class=\"mui-input-row\">\r\n					    	        <label>买家留言</label>\r\n				    	            <input type=\"text\" name=\"message\" class=\"mui-input-clear\" placeholder=\"填写留言给卖家\">\r\n					    	    </div>\r\n					    	    <div class=\"mui-input-row\">\r\n					    	        <p>共1件商品  小计：<span>￥999999</span></p>\r\n					    	    </div>-->\r\n					    	</div>\r\n					    </div>\r\n					    <!--\r\n                        		订单项目列表结束\r\n                        -->\r\n					</div>\r\n					<div class=\"confirm-btn-box\">\r\n						<p>实付款：<span id=\"totalAmount\">￥2999</span></p>\r\n						<button type=\"button\" class=\"mui-btn mui-btn-blue \">确认提交</button>\r\n					</div>\r\n				</div>\r\n				<div class=\"mui-off-canvas-backdrop\"></div>\r\n			</div>\r\n		</div>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
