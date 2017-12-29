<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.userpoint" ValidateRequest="false" %>
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

	templateBuilder.Append("<!doctype html>\r\n<html>\r\n\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<title>积分明细</title>\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />		\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n	<style>\r\n		.mui-content{\r\n			font-size: 12px;\r\n		}\r\n		.mui-content .mui-table-view-cell{\r\n			display: flex;\r\n		}\r\n		.mui-content .mui-table-view-cell>span{\r\n			text-align: center;\r\n			display: block;\r\n			flex: 1;\r\n		}\r\n					.page-list>span:first-child{\r\n	display: none;\r\n}\r\n.page-list{\r\n	text-align: center;\r\n	margin: 20px 0;\r\n	margin-left: 15%;\r\n}\r\n.page-list a,.page-list span {\r\n    display: block;\r\n    float: left;\r\n    margin: 2px 0 0 -1px;\r\n    padding: 4px 12px;\r\n    \r\n    height: 30px;\r\n    border: 1px solid #e1e1e1;\r\n    background: #fff;\r\n    color: #333;\r\n    text-decoration: none;\r\n    font-size: 14px;\r\n}\r\n.page-list .current{\r\n	    color: #fff;\r\n    background: #BF0A0A;\r\n    border-color: #BF0A0A;\r\n}\r\n		\r\n	</style>		\r\n	</head>\r\n\r\n	<body>\r\n		<div class=\"mui-content\">\r\n		    <ul class=\"mui-table-view\">\r\n    <li class=\"mui-table-view-cell\" style=\"font-weight: bold;color:dodgerblue;\">积分明细</li>\r\n      ");
	DataTable pointList = get_user_point_list(10, page,"user_id="+userModel.id, out totalcount);

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n          ");
	string pagelist = get_page_link(10, page, totalcount, "/mobile/jf_mingxi.aspx?action=list&page=__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n          ");
	foreach(DataRow dr in pointList.Rows)
	{

	templateBuilder.Append("\r\n    <li class=\"mui-table-view-cell\">\r\n    	\r\n    	<span>" + Utils.ObjectToStr(dr["add_time"]) + "</span>\r\n    	<span>" + Utils.ObjectToStr(dr["remark"]) + "</span>\r\n    	<span> ");
	if (Utils.StrToInt(Utils.ObjectToStr(dr["value"]), 0)>0)
	{

	templateBuilder.Append("\r\n                +" + Utils.ObjectToStr(dr["value"]) + "\r\n                ");
	}
	else
	{

	templateBuilder.Append("\r\n                " + Utils.ObjectToStr(dr["value"]) + "\r\n                ");
	}	//end for if

	templateBuilder.Append("</span>\r\n               \r\n    </li>\r\n     ");
	}	//end for if

	if (pointList.Rows.Count==0)
	{

	templateBuilder.Append("\r\n           <li class=\"mui-table-view-cell\">暂无记录...</li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n   <div class=\"page-list\">");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("</div>\r\n</ul>\r\n		</div>\r\n		\r\n	</body>\r\n\r\n</html>\r\n<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n</");
	templateBuilder.Append("script>");
	Response.Write(templateBuilder.ToString());
}
</script>
