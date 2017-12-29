<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.useraddress" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"utf-8\"/>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" rel=\"stylesheet\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n	</head>\r\n	<body>\r\n		      <div class=\"mui-page\" id=\"address_page\">\r\n        	<div class=\"mui-navbar-inner mui-bar mui-bar-nav\">\r\n				<button type=\"button\" class=\"mui-left mui-action-back mui-btn  mui-btn-link mui-btn-nav mui-pull-left colorfff\">\r\n					<i class=\"mui-icon mui-icon-left-nav colorfff\" ></i>\r\n					\r\n				</button>\r\n				<h1 class=\" mui-title colorfff\">收货地址</h1>	\r\n			</div>\r\n			<div class=\"mui-page-content delivery-address mtp\">\r\n				<div class=\"mui-scroll-wrapper\" id=\"sh_address_wrap\">\r\n					<div class=\"mui-scroll\">\r\n						<div>\r\n						   <ul id=\"address_list\" class=\"address_list\">\r\n						   	   ");
	DataTable list = get_user_addr_book_list(15, page, "user_id="+userModel.id, out totalcount);

	templateBuilder.Append("<!--取得一个DataTable-->\r\n          ");
	string pagelist = get_page_link(15, page, totalcount, "useraddress", "__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n          ");
	foreach(DataRow dr in list.Rows)
	{

	templateBuilder.Append("\r\n							   <li>\r\n							   		\r\n							   			 <div class=\"mui-card\">\r\n								    	<p>" + Utils.ObjectToStr(dr["accept_name"]) + " <span>" + Utils.ObjectToStr(dr["mobile"]) + "</span></p>\r\n								    	<p> " + Utils.ObjectToStr(dr["area"]) + " " + Utils.ObjectToStr(dr["address"]) + "</p>\r\n								    	<div>\r\n								    		<div class=\"mui-input-row mui-checkbox mui-left\">\r\n												<label>设为默认</label>\r\n												<input name=\"checkbox1\" address-data-no=\"124314\" value=\"Item 1\" type=\"checkbox\">\r\n											</div> \r\n											<div>\r\n												<a href=\"\">编辑</a>\r\n												<a href=\"\" address-data-no=\"1\">删除</a>\r\n											</div>\r\n								    	</div>\r\n							    	</div>\r\n							   		\r\n							   	</li>\r\n							   	   ");
	}	//end for if

	templateBuilder.Append("\r\n						   </ul>\r\n			  \r\n						</div>\r\n						<button id=\"add_addressBtn\" type=\"button\" class=\"mui-btn mui-btn-blue mui-btn-block\">添加新地址</button>\r\n					</div>\r\n				</div>\r\n			</div>\r\n        </div>\r\n	</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
