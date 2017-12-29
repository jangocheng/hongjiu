<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.userorder" ValidateRequest="false" %>
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
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/swiper-3.4.2.min.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/iconfont.css\" />\r\n		<title>我的红包记录</title>\r\n		<style type=\"text/css\">\r\n			.mui-control-item{\r\n				position: relative;\r\n			}\r\n			.mui-control-item.mui-active:after{\r\n				position: absolute;\r\n				bottom: 0;\r\n				left: 25%;\r\n				width: 50%;\r\n				content: '';\r\n				height: 4px;\r\n				background: #c42e2e;							\r\n			}\r\n			.orderBox{\r\n				display: none;\r\n				/*margin-top: 50px;*/\r\n			}\r\n			.orderbox_a {\r\n				width: 100%;\r\n				height: 40px;\r\n				line-height: 40px;\r\n			}\r\n			.orderbox_a a{\r\n				width: 20%;\r\n				float: left;\r\n				color: #333;\r\n				text-align: center;\r\n				line-height: 40px;\r\n				font-size: 12px;\r\n				position: relative;\r\n			}\r\n			.orderbox_a a.active{\r\n				color: #BF0A0A;\r\n			}\r\n			.orderbox_a a.active:after{\r\n				    position: absolute;\r\n				    bottom: 0;\r\n				    left: 25%;\r\n				    width: 50%;\r\n				    content: '';\r\n				    height: 2px;\r\n				    background: #c42e2e;\r\n			}\r\n			.page-list>span:first-child{\r\n				display: none;\r\n			}\r\n			.page-list{\r\n				text-align: center;\r\n				margin: 20px 10px;\r\n			\r\n			}\r\n			.page-list a,.page-list span {\r\n			    display: block;\r\n			    float: left;\r\n			    margin: 2px 0 0 -1px;\r\n			    padding: 4px 12px;\r\n			   /* line-height: 30px;*/\r\n			    height: 30px;\r\n			    border: 1px solid #e1e1e1;\r\n			    background: #fff;\r\n			    color: #333;\r\n			    font-size: 14px;\r\n			    text-decoration: none;\r\n			}\r\n			.page-list .current{\r\n				    color: #fff;\r\n			    background: #BF0A0A;\r\n			    border-color: #BF0A0A;\r\n			}\r\n			.my_order .goods-list>a>div>p:last-child {\r\n				font-size: 13px;\r\n				color: #333333;\r\n				font-weight: bold;\r\n				padding-right: 20px;\r\n				line-height: 22px;\r\n				padding-bottom: 10px;\r\n			}\r\n			.btn_group{\r\n				width: 100%;\r\n				text-align: center;\r\n				padding: 5px 0;\r\n				height: 25px;\r\n				position: relative;\r\n				\r\n			}			\r\n			.btn_group a {\r\n				color: #fff;\r\n				display: block;\r\n				float: right;\r\n				line-height: 25px;\r\n				margin-right: 5px;\r\n				width: 65px;\r\n				height: 25px;\r\n			}\r\n			.btn_group:after{\r\n				position: absolute;\r\n	height: 1px;\r\n	bottom:0\r\n	left: 12px;\r\n	background: #E5E5E5;\r\n	content: '';\r\n	width: 100%;\r\n			}			\r\n			.btn_group .tihuo {\r\n				background-color: #cc3d44;\r\n			}			\r\n			.btn_group .tuihuo {\r\n				background-color: #177cb0;\r\n			}		\r\n			.btn_group .hongbao {\r\n				background-color: #ff0000;\r\n			}			\r\n			.btn_group .shengji {\r\n				background-color: #febb2c;\r\n			}\r\n			.my_order .goods-list > div >a>p:first-of-type {\r\n    font-size: 13px;\r\n    color: #333333;\r\n    padding-top: 30px;\r\n    font-weight: bold;\r\n    padding-right: 20px;\r\n    line-height: 22px;\r\n}\r\n.my_order .goods-list >a >div{\r\n	padding-left: 12px;\r\n}\r\n.my_order .goods-list >a> div .goods_img{\r\n	float: left;\r\n	width:100px;\r\n	height: 50px;	\r\n	margin-top: 20px;\r\n}\r\n.my_order .goods-list >a> div .goods_img img{\r\n	height: 80px;\r\n	display: block;\r\n	margin: 0 auto;\r\n}\r\n	\r\n		</style>\r\n	</head>\r\n	<body>\r\n");
	int status=DTRequest.GetInt("status",0);
	string strWhere=" Order_type=2 and user_id="+userModel.id;
	if(status!=0)
	{
	strWhere+=" and status ="+status;
	}
	else
	{
	strWhere+=" and status<=3";
	}
	

	templateBuilder.Append("\r\n		<!--<header class=\"mui-bar mui-bar-nav\">  \r\n	       	<a class=\"mui-action-back mui-icon mui-icon-left-nav mui-pull-left\"></a>  \r\n	        <h1 class=\"mui-title mytitle\">我的订单</h1>  \r\n	    </header> -->\r\n		<div class=\"mui-content my_order\">\r\n			\r\n\r\n				<!--	<div  style=\"width: 100%;background: #fff;\" id=\"orderbox_a\" class=\" mui-clearfix orderbox_a\">\r\n						\r\n								<a class=\"");
	templateBuilder.Append(status==0?"active":"".ToString());

	templateBuilder.Append("\" href=\"/mobile/my_orderlist.aspx\">\r\n									全部\r\n								</a>\r\n							\r\n						\r\n								<a  class=\"");
	templateBuilder.Append(status==1?"active":"".ToString());

	templateBuilder.Append("\"  href=\"/mobile/my_orderlist.aspx?status=1\">\r\n									待支付\r\n								</a>\r\n							\r\n							\r\n								<a  class=\"");
	templateBuilder.Append(status==2?"active":"".ToString());

	templateBuilder.Append("\" href=\"/mobile/my_orderlist.aspx?status=2\">\r\n									待收货\r\n								</a>\r\n							\r\n							\r\n								<a  class=\"");
	templateBuilder.Append(status==3?"active":"".ToString());

	templateBuilder.Append("\"   href=\"/mobile/my_orderlist.aspx?status=3\">\r\n									已完成\r\n								</a>\r\n							\r\n							\r\n								<a  class=\"");
	templateBuilder.Append(status==4?"active":"".ToString());

	templateBuilder.Append("\"  href=\"/mobile/my_orderlist.aspx?status=4\">\r\n									退款/退货\r\n								</a>\r\n					</div>\r\n				-->\r\n				\r\n					\r\n						<div id=\"scroll1\" class=\"mui-scroll-wrapper orderBox\" style=\"display: block;\" >\r\n							<div class=\"mui-scroll\">\r\n								<ul class=\"mui-table-view\" id=\"all_list\">\r\n									<!--\r\n                                    	全部订单\r\n                                    -->\r\n  ");
	DataTable list = get_order_list(10, page, strWhere, out totalcount);

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n          ");
	string pagelist = get_page_link(10, page, totalcount,"/mobile/redbao_record.aspx?status="+status+"&page=__id__");

	templateBuilder.Append(" <!--取得分页页码列表-->\r\n          ");
	foreach(DataRow dr in list.Rows)
	{

	templateBuilder.Append("\r\n\r\n<li class=\"mui-card\">\r\n										<p>订单号：<b>" + Utils.ObjectToStr(dr["order_no"]) + "</b><i style=\"display: none;\">" + Utils.ObjectToStr(dr["Order_type"]) + "</i></p>\r\n									    	<div class=\"goods-list\">\r\n									    		\r\n									    		");
	Qrcms.Model.cart_items modelt=get_article(dr["order_no"].ToString());
	

	templateBuilder.Append("\r\n              <a href=\"upgrade_show.aspx?id=" + Utils.ObjectToStr(dr["id"]) + "\">\r\n              \r\n									    		<div>\r\n									    			<div class=\"goods_img\">\r\n									    				<img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.img_url));
	templateBuilder.Append("\">\r\n									    			</div>\r\n										    		<p>");
	templateBuilder.Append(Utils.ObjectToStr(modelt.title));
	templateBuilder.Append("  ｘ ");
	templateBuilder.Append(Utils.ObjectToStr(modelt.quantity));
	templateBuilder.Append("</p>\r\n										    		<p class=\"mui-text-right\">\r\n                                                        ");
	templateBuilder.Append(show_status(dr).ToString());

	templateBuilder.Append("\r\n                                                    </p>\r\n										    		\r\n										    	</div>\r\n										    	</a>\r\n										    	\r\n									    	</div>\r\n									    	<div class=\"btn_group clearfix\">\r\n									    		 ");
	templateBuilder.Append(show_btn(dr).ToString());

	templateBuilder.Append("\r\n								\r\n								\r\n							</div>\r\n									    	<div>\r\n									    		\r\n									    		<p>\r\n									    			<span>实付款：<i>￥" + Utils.ObjectToStr(dr["order_amount"]) + "</i></span>\r\n									    	</div>\r\n									</li>\r\n");
	}	//end for if

	if (totalcount<1)
	{

	templateBuilder.Append("\r\n													<li class=\"mui-card\">\r\n														<p style=\"text-align: center;line-height: 40px;\">暂无相关订单</p>\r\n													</li>\r\n													  ");
	}	//end for if

	templateBuilder.Append("\r\n\r\n								</ul>\r\n								<div class=\"page-list mui-clearfix\">\r\n							  				\r\n											");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("\r\n							  	</div>\r\n							</div>\r\n						</div>\r\n					\r\n	\r\n				<!--\r\n                	group结束\r\n                -->\r\n			\r\n		</div>\r\n		\r\n		<!--\r\n        	全部订单\r\n        -->\r\n      \r\n       \r\n       \r\n     \r\n        \r\n     \r\n	</body>\r\n	<!--\r\n    	相关文件 引入\r\n    -->\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/layer/layer.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/laytpl/laytpl.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/laypage/laypage.js\"></");
	templateBuilder.Append("script>\r\n	<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/artdialog/dialog-plus-min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/dingdan.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		//MUI框架初始化\r\n		mui.init();\r\n		\r\n//		//tab切换函数\r\n//		 function tab(){\r\n//		 	var orderbox_a = document.getElementById('orderbox_a');\r\n//		 	var aobj =  orderbox_a.getElementsByTagName('a');\r\n//		 	console.log(aobj.length);\r\n//		 	var boxitem = document.getElementsByClassName('orderBox');\r\n//		 	console.log(boxitem.length);\r\n//		 	for(var i = 0; i<aobj.length;i++){\r\n//		 		aobj[i].index = i;\r\n//		 		aobj[i].onclick = function(){\r\n//		 			for(var j = 0; j<boxitem.length;j++){\r\n//		 				aobj[j].className ='';\r\n//		 				boxitem[j].style.display = 'none';\r\n//		 			}\r\n//		 			aobj[this.index].className ='active';\r\n//		 			boxitem[this.index].style.display ='block';\r\n//		 		}\r\n//		 	}\r\n//		 }\r\n//		 tab();\r\n		\r\n		mui('body').on('tap','#orderbox_a a',function(){\r\n			console.log(1);\r\n			location.href = this.href;\r\n			return false;\r\n		});\r\n		\r\n		mui('body').on('tap','.page-list a',function(){\r\n			location.href = this.href;\r\n		});\r\n		mui(\"body\").on(\"tap\",\".tihuo\",function(){\r\n			var orderNo = $('.tihuo').attr('data-no');\r\n			var btnArray = ['确认', '取消'];\r\n			mui.confirm('是否确认提货？', '订单列表', btnArray, function(e) {\r\n				if(e.index == 0){\r\n					$('.tihuo').attr('href','choose_add.aspx');\r\n//					mui.openWindow({\r\n//						url:\"choose_add.aspx?order_no=\"+orderNo,\r\n//						id:\"choose_add.aspx?order_no=\"+orderNo\r\n//					});\r\n					location.href = 'choose_add.aspx?order_no='+orderNo;\r\n					\r\n				}\r\n			})\r\n		});\r\n		\r\n		//退货\r\n		mui(\"body\").on(\"tap\",\".tuihuo\",function(){\r\n			var btnArray = ['确认', '取消'];\r\n			console.log($('.tuihuo').attr('data-no'));\r\n			var orderNo = $('.tuihuo').attr('data-no');\r\n			mui.confirm('是否确认退货？', '订单列表', btnArray, function(e) {\r\n				if(e.index == 0){\r\n					mui.ajax('/tools/submit_ajax.ashx?action=order_orders_th',{\r\n						type:'post',\r\n						datatype:'string',\r\n						data:{\r\n							order_no:orderNo\r\n						},\r\n						success:function(data){\r\n							//alert(1);\r\n							data = JSON.parse(data);\r\n							if(data.status == 1){\r\n								alert(data.msg);\r\n								setTimeout(function(){\r\n									location.reload();\r\n								},2000)\r\n							}\r\n						}\r\n					})\r\n				}\r\n			})\r\n		});\r\n		\r\n		mui('body').on('tap','.goods-list>a',function(){\r\n			location.href = this.href ;\r\n		});\r\n		mui('body').on('tap','.btn_group>a',function(){\r\n			location.href = this.href ;\r\n		});\r\n		\r\n		//页面滚动\r\n		(function($){\r\n		    $(\".mui-scroll-wrapper\").scroll({\r\n		        //bounce: false,//滚动条是否有弹力默认是true\r\n		        //indicators: false, //是否显示滚动条,默认是true\r\n		    });\r\n    \r\n		})(mui);\r\n\r\n		//退货\r\n	\r\n//	\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
