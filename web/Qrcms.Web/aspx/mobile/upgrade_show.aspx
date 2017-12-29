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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" />		\r\n		<title>升级记录详情</title>\r\n		<style type=\"text/css\">\r\n			.zhuangtai{\r\n				display: flex;\r\n				\r\n			}\r\n			.zhuangtai>li{\r\n				background-color: #c3c3c3;\r\n				color: white;\r\n				flex: 1;\r\n				width: 25%;\r\n				text-align: center;\r\n			}\r\n			\r\n			.zhuangtai .done{\r\n				background-color: #83bd39;\r\n			}\r\n			.hb_goods{\r\n				margin-top: 0;\r\n			}\r\n			.chakan{\r\n				background: #fff;\r\n				font-size: 14px;\r\n				font-weight:bold;\r\n				color:#999;\r\n				text-align: center;\r\n			}\r\n			\r\n		</style>\r\n	</head>\r\n	<body>        ");
	if (model.order_goods!=null)
	{

	foreach(Qrcms.Model.order_goods modelt in model.order_goods)
	{

	templateBuilder.Append("\r\n		<div class=\"mui-content redbao_jl\">\r\n			<!--<div class=\"hbjl_banner\">\r\n				<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/hbjl.png\">\r\n			</div>-->\r\n			<div class=\"chakan\">查看订单</div>\r\n			<div class=\"hb_goods\">\r\n				\r\n				<ul>\r\n					  \r\n					<li class=\"mui-card\">\r\n\r\n						<p class=\"mui-clearfix\">订单号:");
	templateBuilder.Append(Utils.ObjectToStr(model.order_no));
	templateBuilder.Append("<span> ");
	if (model.quiz_result==1)
	{

	templateBuilder.Append("\r\n                            已中奖\r\n                            ");
	}	//end for if

	if (model.quiz_result==2)
	{

	templateBuilder.Append("\r\n                            未中奖\r\n                            ");
	}	//end for if

	templateBuilder.Append("</span></p>\r\n						<p class=\"mui-clearfix\" style=\"color: red;\">订单状态:   ");
	templateBuilder.Append(get_order_status(model.id).ToString());

	templateBuilder.Append("</p>\r\n\r\n						<div class=\"goods-list\" style=\"overflow:hidden\">\r\n                            <div style=\"height:80px; width:80px; text-align:center; float:left; padding-left:0px;\">\r\n                                <img src=\"");
	templateBuilder.Append(get_article_img_url(modelt.article_id).ToString());

	templateBuilder.Append("\" style=\"height:80px;\" />\r\n                            </div>\r\n									 <div style=\"padding-left:0px; float:left\">\r\n										 <p>");
	templateBuilder.Append(Utils.ObjectToStr(modelt.goods_title));
	templateBuilder.Append("</p>\r\n										 <input type=\"hidden\" id=\"orderNo\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.order_no));
	templateBuilder.Append("\" />\r\n										\r\n										 <p class=\"price mui-clearfix\">单价:￥");
	templateBuilder.Append(Utils.ObjectToStr(modelt.real_price));
	templateBuilder.Append("&nbsp;  数量:");
	templateBuilder.Append(Utils.ObjectToStr(modelt.quantity));
	templateBuilder.Append("\r\n										 	   ");
	if(model.quiz_result==1 && model.status==2 && string.IsNullOrEmpty(model.accept_name))
	                                         {
	                                         

	templateBuilder.Append("\r\n										 	<a href=\"\" id=\"sqtk\">申请提款</a>\r\n										 ");
	                                         }
	                                         

	templateBuilder.Append("\r\n                                         </p> \r\n									</div>\r\n										    	\r\n								</div>\r\n									    	<div>\r\n									    		\r\n									    		<ul class=\"mui-table-view\">\r\n                                                    ");
	if (!string.IsNullOrEmpty(model.accept_name))
	{

	templateBuilder.Append("\r\n									    			<li class=\"mui-table-view-cell\">\r\n									    				<ul class=\"mui-table-view\">\r\n    <li class=\"mui-table-view-cell\" style=\"color: deepskyblue;font-weight: bold;\">收货信息</li>\r\n    <li class=\"mui-table-view-cell\">顾客姓名：");
	templateBuilder.Append(Utils.ObjectToStr(model.accept_name));
	templateBuilder.Append("</li>\r\n    <li class=\"mui-table-view-cell\">送货地址：");
	templateBuilder.Append(Utils.ObjectToStr(model.area));
	templateBuilder.Append(" ");
	templateBuilder.Append(Utils.ObjectToStr(model.address));
	templateBuilder.Append(" ");
	templateBuilder.Append(Utils.ObjectToStr(model.post_code));
	templateBuilder.Append("</li>\r\n    <li class=\"mui-table-view-cell\">联系电话：");
	templateBuilder.Append(Utils.ObjectToStr(model.mobile));
	templateBuilder.Append(" ");
	templateBuilder.Append(Utils.ObjectToStr(model.telphone));
	templateBuilder.Append("</li>\r\n \r\n\r\n</ul>\r\n									    			</li>\r\n                                                    ");
	}	//end for if

	templateBuilder.Append("\r\n									    			<li class=\"mui-table-view-cell\">\r\n									    				<p>生成时间: ");
	templateBuilder.Append(Utils.ObjectToStr(model.add_time));
	templateBuilder.Append("</p>\r\n									    			</li>\r\n									    		</ul>\r\n									    			\r\n									    	</div>\r\n						</li>\r\n						\r\n				</ul>\r\n				<div class=\"ck\">\r\n					<h3>提款金额</h3>\r\n					<p class=\"tkje\">￥");
	templateBuilder.Append((modelt.real_price*modelt.quantity).ToString());

	templateBuilder.Append("</p>\r\n\r\n					<a href=\"\" class=\"tkBtn\">确定提款</a>\r\n					<a href=\"\" class=\"gb\" id=\"gbbtn\"></a>\r\n				</div>\r\n				<div class=\"ckbg\"></div>\r\n			</div>\r\n		</div>        ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n		\r\n		mui('body').on('tap','#sqtk',function(){\r\n			\r\n			$('.ck,.ckbg').css('display','block');\r\n		})\r\n		mui('body').on('tap','#gbbtn',function(){\r\n			$('.ck,.ckbg').css('display','none');\r\n		})\r\n		\r\n		//申请提款\r\n		mui('body').on('tap','.tkBtn',function(){\r\n			//订单号\r\n			//var orderNo ='");
	templateBuilder.Append(Qrcms.Common.DTRequest.GetString("order_no").ToString());

	templateBuilder.Append("'; \r\n			var orderNo = $('#orderNo').val();\r\n			mui.ajax('/tools/submit_ajax.ashx?action=order_tikuan&order_no='+orderNo,{\r\n				type:\"post\",\r\n				datatype:'string',\r\n				success:function(data){\r\n					data = JSON.parse(data);\r\n					//alert(1);\r\n					if(data.status ==1){\r\n						mui.toast(data.msg);\r\n						setTimeout(function(){\r\n							location.href = 'my_orderlist.aspx';\r\n						},2000)\r\n					}else{\r\n						mui.toast(data.msg);\r\n					}\r\n				},\r\n				error:function(data){\r\n					alert(2);\r\n					mui.toast(data.msg);\r\n				}\r\n			})\r\n		})\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
