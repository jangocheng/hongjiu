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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\"><meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<title>确认发货</title>\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.picker.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.poppicker.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content deliver-goods\">\r\n		    <div class=\"mui-input-group\">\r\n		        <div class=\"mui-input-row\">\r\n		            <label>配送方式</label>\r\n		            <input id=\"selectMode\" type=\"text\" readonly name=\"express_name\" value=\"请选择配送方式\">\r\n		            <input type=\"hidden\" name=\"express_id\" />\r\n		        </div>\r\n		        <div class=\"mui-input-row\">\r\n		            <label>物流单号</label>\r\n		            <input type=\"text\" name=\"express_no\" class=\"mui-input-clear\" placeholder=\"请输入物流单号\">\r\n		        </div>\r\n		    </div>\r\n		    <button type=\"button\" class=\"mui-btn mui-btn-blue mui-btn-block\">确认发货</button>\r\n		</div>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.picker.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.poppicker.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n		/*商家发货，配送方式选择*/\r\n		var picker = new mui.PopPicker();\r\n			var statePicker = document.getElementById('selectMode');\r\n			picker.setData([{value:'0',text:'圆通'},{value:'1',text:'申通'}]);\r\n			statePicker.addEventListener(\"tap\",function(){\r\n			 	picker.show(function (selectItems) {\r\n				    statePicker.value = selectItems[0].text;\r\n				});\r\n			});\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
