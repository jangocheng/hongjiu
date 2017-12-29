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
	const int pagesize = 10;

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link rel=\"stylesheet\"  href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\">				\r\n		<title>设置收货地址</title>\r\n		<style type=\"text/css\">\r\n			.mui-card{\r\n				margin: 0;\r\n				padding: 0 10px;\r\n				min-height: 100px;\r\n				box-shadow: none;\r\n				position: relative;\r\n			}\r\n			.choose_add .mui-card p{\r\n				height: 30px;\r\n				line-height: 30px;\r\n				color: #333;\r\n				\r\n			}\r\n			.choose_add .mui-card p span{\r\n				float: right;\r\n			}\r\n			.choose_add .mui-card div p{\r\n				margin-bottom: 0;\r\n				line-height: 24px;\r\n				color: #333;\r\n				padding-right: 15px;\r\n			}\r\n			.choose_add .mui-card:after{\r\n				position: absolute;\r\n				height: 1px;\r\n				width: 100%;\r\n				left: 12px;\r\n				bottom: 0;\r\n				background: #e5e5e5;\r\n				content: '';\r\n			}\r\n			.choose_add .mui-card.mui-checkbox{\r\n				right: 0;\r\n				margin-top: 0;\r\n			}\r\n			.choose_add .mui-card input[type=checkbox]:before {\r\n    			font-size: 19px;\r\n			}\r\n			.choose_add .mui-card input[type=checkbox] {\r\n			    border: 1px solid transparent;\r\n			    width: 15px;\r\n			    height: 15px;\r\n			    border-radius: 50%;\r\n  \r\n  				 } \r\n	  		 .choose_add .mui-card span.mui-checkbox{\r\n	  		 	position: absolute;\r\n	  		 	top: 45px;\r\n	  		 	right: -3%;\r\n  		 	}\r\n  		 	.choose_add .mui-checkbox input[type='checkbox']:checked:before {\r\n    color: #7D0000 !important;}\r\n    		#add_addressBtn{\r\n    			  position: fixed;\r\n    			  bottom: 0;\r\n    width: 94%;\r\n    left: 3%;\r\n    line-height: 1;\r\n    padding: 12px 0;\r\n    font-size: 16px;\r\n    background: #7D0000;\r\n    border: 1px solid #7D0000;\r\n    		}\r\n    		.mui-toast-container{\r\n    			bottom: 50%;\r\n    		}\r\n		</style>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content choose_add\">\r\n			\r\n			 ");
	DataTable list = get_user_addr_book_list(15, page, "user_id="+userModel.id, out totalcount);

	templateBuilder.Append("<!--取得一个DataTable-->\r\n          ");
	string pagelist = get_page_link(15, page, totalcount, "useraddress", "__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n          	");
	foreach(DataRow dr in list.Rows)
	{

	templateBuilder.Append("\r\n			<div class=\"mui-card szdz\">\r\n				<p class=\"mui-clearfix\">" + Utils.ObjectToStr(dr["accept_name"]) + "<span>" + Utils.ObjectToStr(dr["mobile"]) + "</span></p>\r\n				<div>\r\n					<p>" + Utils.ObjectToStr(dr["area"]) + " " + Utils.ObjectToStr(dr["address"]) + "</p>\r\n					<input type=\"hidden\" value=\"" + Utils.ObjectToStr(dr["id"]) + "\" class=\"add_id\" />\r\n				</div>\r\n\r\n				<span class=\"mui-checkbox mui-clearfix\">\r\n					\r\n						<input type=\"checkbox\" class=\"gou\" name=\"szdz\" id=\"szdz\"/>\r\n					\r\n					\r\n					<a href=\"\" class=\"back_link\"></a>\r\n				</span>\r\n				\r\n			</div>\r\n			 ");
	}	//end for if

	if (list.Rows.Count==0)
	{

	templateBuilder.Append("\r\n           		<li style=\"line-height: 30px;text-align: center;padding: 20px 0;\">暂无收货地址</li>	\r\n          	");
	}	//end for if

	templateBuilder.Append("\r\n			 \r\n           		<button id=\"add_addressBtn\" type=\"button\" class=\"mui-btn mui-btn-blue mui-btn-block\">添加新地址</button>\r\n          \r\n		</div>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n		mui('body').on('tap','#add_addressBtn',function(){\r\n			//var orderNo ='");
	templateBuilder.Append(Qrcms.Common.DTRequest.GetString("order_no").ToString());

	templateBuilder.Append("';\r\n			var orderNo = getQueryString('order_no');\r\n				location.href = 'add_address.aspx?choose=1&orderNo='+orderNo;\r\n		});\r\n		mui('body').on('tap','.gou',function(){\r\n			$('.back_link').addClass('mui-action-back');\r\n		});\r\n		\r\n		mui('body').on('tap','#add_add',function(){\r\n			location.href = this.href ;\r\n		});\r\n		\r\n		//设置收货地址\r\n		mui('body').on('tap','.szdz',function(){\r\n			$(this).find('input[type=checkbox]').attr('checked',true);\r\n			var Addid = $('.add_id').val();\r\n			//var orderNo ='");
	templateBuilder.Append(Qrcms.Common.DTRequest.GetString("order_no").ToString());

	templateBuilder.Append("'; \r\n			var orderNo = getQueryString('order_no');\r\n			console.log(orderNo);\r\n			var btnArray = ['确认', '取消'];\r\n			mui.confirm('是否设置为提货地址？', '提货', btnArray, function(e) {\r\n				if(e.index ==0){\r\n					mui.ajax('/tools/submit_ajax.ashx?action=order_orders_dz&order_no='+orderNo,{\r\n						data:{\r\n							'id':Addid\r\n						},\r\n						datatype:'string',\r\n						type:'post',\r\n						success:function(data){\r\n							data = JSON.parse(data);\r\n							if(data.status ==1){\r\n								mui.toast(data.msg);\r\n								setTimeout(function(){\r\n									location.href = 'my_orderlist.aspx';\r\n								},2000)\r\n							}else{\r\n								mui.toast(data.msg);\r\n							}\r\n						},\r\n						error:function(data){\r\n							mui.toast(\"失败\");\r\n						}\r\n					})\r\n				}else{\r\n					mui.toast('您已取消设置该地址');\r\n					$(\"input[type=checkbox]\").removeAttr(\"checked\");\r\n				}\r\n			})\r\n		})\r\n</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
