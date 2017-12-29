<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.usercenter" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<title>我的好友</title>\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/iconfont.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<style type=\"text/css\">\r\n			.my_tuijian{\r\n				\r\n			}\r\n			.my_tuijian .bg{\r\n				width: 100%;\r\n			}\r\n			.my_tuijian .bg img{\r\n				width: 100%;\r\n				display: block;\r\n			}\r\n			.my_tuijian ul li{\r\n				height: auto;\r\n				padding: 5px 0;\r\n			}\r\n			.my_tuijian ul .hy_item:nth-of-type(2n){\r\n				background: #f4f4f4;\r\n			}\r\n			.my_tuijian ul li .tou_img{\r\n				width: 20%;\r\n				float: left;\r\n			}\r\n			.my_tuijian ul li .tou_img img{\r\n				width: 50px;\r\n				height: 50px;\r\n				border-radius:50% ;\r\n				margin: 0 auto;\r\n				display: block;\r\n			}\r\n			.my_tuijian ul li .hy_name{\r\n				width: 40%;\r\n				float: left;\r\n			}\r\n			.hy_name p{\r\n				color: #333;\r\n				font-size: 16px;\r\n				padding-top: 2px;\r\n				margin-bottom: 0;\r\n			}\r\n			\r\n			.hy_name span{\r\n				font-size: 14px;\r\n				color: #b7b6b6;\r\n			}\r\n			.hy_shujv{\r\n				width: 40%;\r\n				float: left;\r\n			}\r\n			.hy_shujv ul li{\r\n				float: left;\r\n				width: 50%;\r\n				height: 20px;\r\n				text-align: center;\r\n				font-size: 12px;\r\n				color: #b7b6b6;\r\n				margin-bottom: 5px;\r\n			}\r\n			.hy_shujv ul li:nth-of-type(2n){\r\n				border-left: 1px solid #b7b6b6;\r\n			}\r\n			\r\n		</style>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content my_tuijian\">\r\n			<div class=\"bg\" style=\"height: 138px;overflow: hidden\">\r\n				<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/my_tuijianbg_03.png\">\r\n			</div>\r\n			<div class=\"mui-scroll-wrapper\">\r\n				<div class=\"mui-scroll\">\r\n					<ul>\r\n                        ");
	DataTable tb = new Qrcms.BLL.users().GetList(10000," parent_user='"+userModel.user_name+"'"," id desc").Tables[0];

	int row__loop__id=0;
	foreach(DataRow row in tb.Rows)
	{
		row__loop__id++;


	templateBuilder.Append("\r\n						<li class=\"mui-clearfix hy_item\">\r\n							<div class=\"tou_img\">\r\n								<img src=\"" + Utils.ObjectToStr(row["avatar"]) + "\">\r\n							</div>\r\n							<div class=\"hy_name\">\r\n								<p>" + Utils.ObjectToStr(row["nick_name"]) + "</p>\r\n								<span>" + Utils.ObjectToStr(row["user_name"]) + "</span>\r\n							</div>\r\n							\r\n						</li>\r\n                        ");
	}	//end for if

	if (tb.Rows.Count<=0)
	{

	templateBuilder.Append("\r\n						<li class=\"mui-clearfix hy_item\" style=\"    line-height: 40px;\r\n    font-size: 14px;\r\n    text-align: center;\r\n    color: #777;\">\r\n							暂无记录\r\n						</li>\r\n                        ");
	}	//end for if

	templateBuilder.Append("\r\n					</ul>\r\n				</div>\r\n			</div>\r\n		</div>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n		<script>\r\n			(function($){\r\n		    $(\".mui-scroll-wrapper\").scroll({\r\n		        //bounce: false,//滚动条是否有弹力默认是true\r\n		        //indicators: false, //是否显示滚动条,默认是true\r\n		    });\r\n    \r\n		})(mui);\r\n		</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
