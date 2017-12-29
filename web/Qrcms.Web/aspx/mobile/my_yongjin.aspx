﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.usercenter" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<title>我的佣金</title>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content yongjin\">\r\n			<div class=\"yongjin_head\">\r\n				<p>佣金余额（元）</p>\r\n				<p>");
	templateBuilder.Append(Utils.ObjectToStr(userModel.commision));
	templateBuilder.Append("</p>\r\n			</div>\r\n			<!--<div class=\"tx_cz mui-clearfix\">\r\n				<ul>\r\n					<li class=\"mui-clearfix\">\r\n						<a href=\"tixian.aspx\">\r\n							<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/myyue.png\">\r\n							<p>提现</p>\r\n						</a>\r\n					</li>\r\n					<li class=\"mui-clearfix\">\r\n						<a href=\"chongzhi.aspx\">\r\n							<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/myyue-cz.png\">\r\n							<p>充值</p>\r\n						</a>\r\n					</li>\r\n				</ul>\r\n				\r\n			</div>-->\r\n			<div>\r\n				<ul class=\"mui-table-view\">\r\n					<li class=\"mui-table-view-cell\">\r\n						<a href=\"tixian.aspx\" class=\"mui-navigate-right\">提现</a>\r\n					</li>\r\n				</ul>\r\n				<ul class=\"mui-table-view mtp\">\r\n					<li class=\"mui-table-view-cell\">\r\n						<a href=\"yj_mingxi.aspx\" class=\"mui-navigate-right\">查看明细</a>\r\n					</li>\r\n				</ul>\r\n			</div>\r\n			\r\n		</div>\r\n	</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
