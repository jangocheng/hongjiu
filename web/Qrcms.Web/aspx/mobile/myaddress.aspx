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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"utf-8\"/>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" rel=\"stylesheet\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<title>收货地址</title>\r\n		<style>\r\n			#add_addressBtn{\r\n				position: fixed;\r\n				bottom: 0;\r\n				z-index: 99;\r\n			}\r\n		</style>\r\n	</head>\r\n	<body>\r\n		     \r\n        	<!--<div class=\"mui-navbar-inner mui-bar mui-bar-nav\">\r\n				<button type=\"button\" class=\"mui-left mui-action-back mui-btn  mui-btn-link mui-btn-nav mui-pull-left colorfff\">\r\n					<i class=\"mui-icon mui-icon-left-nav colorfff\" ></i>\r\n					\r\n				</button>\r\n				<h1 class=\" mui-title colorfff\">收货地址</h1>	\r\n			</div>-->\r\n			<div class=\"mui-content delivery-address mtp\">\r\n				<div class=\"mui-scroll-wrapper\" id=\"sh_address_wrap\">\r\n					<div class=\"mui-scroll\">\r\n						<div>\r\n						   <ul id=\"address_list\" class=\"address_list\" style=\"background: #f2f2f2;\">\r\n						   	   ");
	DataTable list = get_user_addr_book_list(15, page, "user_id="+userModel.id, out totalcount);

	templateBuilder.Append("<!--取得一个DataTable-->\r\n          ");
	string pagelist = get_page_link(15, page, totalcount, "useraddress", "__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n          	");
	foreach(DataRow dr in list.Rows)
	{

	templateBuilder.Append("\r\n							   <li style=\"margin-top: 10px;\">\r\n							   		\r\n							   			 <div class=\"mui-card\">\r\n								    	<p>" + Utils.ObjectToStr(dr["accept_name"]) + " <span>" + Utils.ObjectToStr(dr["mobile"]) + "</span></p>\r\n								    	<p> " + Utils.ObjectToStr(dr["area"]) + " " + Utils.ObjectToStr(dr["address"]) + "</p>\r\n								    	<div>\r\n								    		<div class=\"mui-input-row mui-checkbox mui-left\">\r\n								    			 ");
	if (Utils.ObjectToStr(dr["is_default"])=="0")
	{

	templateBuilder.Append("\r\n												<a onclick=\"swmr()\" class=\"moren\"  style=\"margin-left: 30px;color: #333;font-size: 12px;\" data-id=\"" + Utils.ObjectToStr(dr["id"]) + "\">设为默认</a>");
	}
	else
	{

	templateBuilder.Append("\r\n                <span style=\"margin-left: 30px;font-size: 12px;color: #7D0000;\">已默认</span>\r\n                ");
	}	//end for if

	templateBuilder.Append(" \r\n												<!--<input name=\"checkbox1\" address-data-no=\"124314\" value=\"Item 1\" type=\"checkbox\" class=\"check\">-->\r\n											</div> \r\n											<div>\r\n												<a href=\"edit_add.aspx?action=edit&id=" + Utils.ObjectToStr(dr["id"]) + "\" class=\"add_edit\">编辑</a>\r\n												<a href=\"javascript:void(0)\" class=\"del_add\" data-id=\"" + Utils.ObjectToStr(dr["id"]) + "\">删除</a>\r\n											</div>\r\n								    	</div>\r\n							    	</div>\r\n							   		\r\n							   	</li>\r\n							   	   ");
	}	//end for if

	templateBuilder.Append("\r\n						   </ul>\r\n			  \r\n						</div>\r\n						<div style='height: 50px;'></div>\r\n						\r\n					</div>\r\n					\r\n				</div>\r\n			</div>\r\n			<button id=\"add_addressBtn\" type=\"button\" class=\"mui-btn mui-btn-blue mui-btn-block\">添加新地址</button>\r\n	   <script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\"></");
	templateBuilder.Append("script>\r\n       <script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n       <script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>	\r\n\r\n       <script>\r\n       	mui.init();\r\n       		(function($){\r\n			    $(\".mui-scroll-wrapper\").scroll({\r\n			        //bounce: false,//滚动条是否有弹力默认是true\r\n			        //indicators: false, //是否显示滚动条,默认是true\r\n			    });\r\n    \r\n			})(mui);\r\n			\r\n			mui('body').on('tap','.add_edit',function(){\r\n				location.href = this.href;\r\n			})\r\n			\r\n			//删除地址\r\n			mui('body').on('tap','.del_add',function(){\r\n				var addid = $('.del_add').attr('data-id');\r\n				console.log(addid);\r\n				mui.ajax('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_address_delete',{\r\n					datatype:'string',\r\n					type:'post',\r\n					data:{\r\n						'checkId':addid\r\n					},\r\n					success:function(data){\r\n						 data = JSON.parse(data);\r\n						console.log(data);\r\n						if(data.status ==1){\r\n							\r\n							mui.toast(data.msg);\r\n							setTimeout(function(){\r\n								location.reload();\r\n							},2000)\r\n						}\r\n					}\r\n				})\r\n			})\r\n\r\n			mui('body').on('tap','#add_addressBtn',function(){\r\n				location.href = 'add_address.aspx?';\r\n			});\r\n			mui('body').on('tap','input[type=\"checkbox\"]',function(){\r\n			\r\n				$(\"input[type='checkbox']\").removeAttr('checked');\r\n				$(this).attr('checked')\r\n			});\r\n			\r\n			//设为默认地址\r\n		function swmr(){\r\n			$(\"input[type='checkbox']\").removeAttr('checked');\r\n			var check = $('.check').attr('checked');\r\n			var id = $('.moren').attr('data-id');\r\n			mui.ajax('/tools/submit_ajax.ashx?action=user_address_default&id='+id,{\r\n					type:'post',\r\n				datatype:'string',\r\n			\r\n				success:function(data){\r\n					data = JSON.parse(data);\r\n					if(data.status ==1){\r\n						mui.toast(data.msg);\r\n						check = true;\r\n						location.reload();\r\n						\r\n					}\r\n				}\r\n			})\r\n		};\r\n		\r\n       </");
	templateBuilder.Append("script>\r\n	</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
