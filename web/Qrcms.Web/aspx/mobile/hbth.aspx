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
	const int pagesize = 10;

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/iconfont.css\" />\r\n		<title>合并提货</title>\r\n		<style type=\"text/css\">\r\n			.mui-control-item{\r\n				position: relative;\r\n			}\r\n			.mui-control-item.mui-active:after{\r\n				position: absolute;\r\n				bottom: 0;\r\n				left: 25%;\r\n				width: 50%;\r\n				content: '';\r\n				height: 4px;\r\n				background: #c42e2e;							\r\n			}\r\n			.orderBox{\r\n				display: none;\r\n				/*margin-top: 50px;*/\r\n			}\r\n			.orderbox_a {\r\n				width: 100%;\r\n				height: 40px;\r\n				line-height: 40px;\r\n			}\r\n			.orderbox_a a{\r\n				width: 20%;\r\n				float: left;\r\n				color: #333;\r\n				text-align: center;\r\n				line-height: 40px;\r\n				font-size: 12px;\r\n				position: relative;\r\n			}\r\n			.orderbox_a a.active{\r\n				color: #BF0A0A;\r\n			}\r\n			.orderbox_a a.active:after{\r\n				    position: absolute;\r\n				    bottom: 0;\r\n				    left: 25%;\r\n				    width: 50%;\r\n				    content: '';\r\n				    height: 2px;\r\n				    background: #c42e2e;\r\n			}\r\n			.page-list>span:first-child{\r\n				display: none;\r\n			}\r\n			.page-list{\r\n				text-align: center;\r\n				margin: 20px 0;\r\n				margin-left: 15%;\r\n			}\r\n			.page-list a,.page-list span {\r\n			    display: block;\r\n			    float: left;\r\n			    margin: 2px 0 0 -1px;\r\n			    padding: 4px 12px;\r\n			   /* line-height: 30px;*/\r\n			    height: 30px;\r\n			    border: 1px solid #e1e1e1;\r\n			    background: #fff;\r\n			    color: #333;\r\n			    font-size: 14px;\r\n			    text-decoration: none;\r\n			}\r\n			.page-list .current{\r\n				    color: #fff;\r\n			    background: #BF0A0A;\r\n			    border-color: #BF0A0A;\r\n			}\r\n			.my_order .goods-list{\r\n				padding: 5px;\r\n			}\r\n			.my_order .goods-list>a>div>p:last-child {\r\n				font-size: 13px;\r\n				color: #333333;\r\n				font-weight: bold;\r\n				padding-right: 20px;\r\n				line-height: 22px;\r\n				padding-bottom: 10px;\r\n			}\r\n			.btn_group{\r\n				width: 100%;\r\n				text-align: center;\r\n				padding: 5px 0;\r\n				height: 30px;\r\n				position: relative;\r\n				\r\n			}			\r\n			.btn_group a {\r\n				color: #fff;\r\n				display: block;\r\n				float: right;\r\n				line-height: 25px;\r\n				margin-right: 5px;\r\n				width: 65px;\r\n				height: 25px;\r\n			}\r\n			.btn_group:after{\r\n				position: absolute;\r\n				height: 1px;\r\n				bottom:0\r\n				left: 12px;\r\n				background: #E5E5E5;\r\n				content: '';\r\n				width: 100%;\r\n			}			\r\n			.btn_group .tihuo {\r\n				background-color: #cc3d44;\r\n			}			\r\n			.btn_group .tuihuo {\r\n				background-color: #177cb0;\r\n			}		\r\n			.btn_group .hongbao {\r\n				background-color: #ff0000;\r\n			}			\r\n			.btn_group .shengji {\r\n				background-color: #febb2c;\r\n			}\r\n			.my_order .goods-list > div >a>p:first-of-type {\r\n			    font-size: 13px;\r\n			    color: #333333;\r\n			    padding-top: 30px;\r\n			    font-weight: bold;\r\n			    padding-right: 20px;\r\n			    line-height: 22px;\r\n			}\r\n			.my_order .goods-list >a >div{\r\n				padding-left: 12px;\r\n			}\r\n			.my_order .goods-list >a> div .goods_img{\r\n				float: left;\r\n				width:100px;\r\n				height: 50px;	\r\n				\r\n			}\r\n				.my_order .goods-list >a> div .goods_img img{\r\n					height: 80px;\r\n					display: block;\r\n					margin: 0 auto;\r\n				}\r\n			.mui-text-right span{\r\n				display: inline-block;\r\n				height: 25px;\r\n				text-align: center;\r\n				line-height: 25px;\r\n				padding: 0 5px;\r\n				border: 1px solid rgb(204,61,68);\r\n				margin: 0 2px;\r\n   				font-weight: normal;\r\n			}\r\n			.hbth{\r\n				width: 60px;\r\n				height:60px;\r\n				background: #7D0000;\r\n				color: #fff;\r\n				text-align: center;\r\n				line-height:60px;\r\n				border-radius: 50%;\r\n				font-size: 12px;\r\n				position: fixed;\r\n				top: 5px;\r\n				right: 5px;\r\n				z-index: 999;\r\n				\r\n			}\r\n				.my_order .mui-card input[type=checkbox]:before {\r\n    			font-size: 19px;\r\n			}\r\n			.my_order .mui-card input[type=checkbox] {\r\n			    border: 1px solid transparent;\r\n			    width: 15px;\r\n			    height: 15px;\r\n			    border-radius: 50%;\r\n  \r\n  				 } \r\n	  		 .my_order .mui-card span.mui-checkbox{\r\n	  		 	position: absolute;\r\n	  		 	top: 45px;\r\n	  		 	right: -3%;\r\n  		 	}\r\n  		 	.my_order .mui-checkbox input[type='checkbox']:checked:before {\r\n    color: #7D0000 !important;}\r\n    		#add_addressBtn{\r\n    			  position: fixed;\r\n    			  bottom: 0;\r\n			    width: 94%;\r\n			    left: 3%;\r\n			    line-height: 1;\r\n			    padding: 12px 0;\r\n			    font-size: 16px;\r\n			    background: #7D0000;\r\n			    border: 1px solid #7D0000;\r\n    		}\r\n    		.tihuo{\r\n    			position: fixed;\r\n    			bottom: 0;\r\n    			width: 100%;\r\n    			height: 50px;\r\n    			background: #fff;\r\n    			left: 0;\r\n    			z-index: 999;\r\n    		}\r\n    		.tihuo span,.tihuo a{\r\n    			width: 50%;\r\n    			float: left;\r\n    			height: 50px;\r\n    			line-height: 50px;\r\n    			font-size: 14px;\r\n    			padding-left: 12px;\r\n    		}\r\n    		.tihuo a{\r\n    			background: #7D0000;\r\n    			color: #fff;\r\n    			text-align: center;\r\n    		}\r\n		</style>\r\n	</head>\r\n	<body>\r\n");
	
	string strWhere="status=2 and isnull(accept_name,'') = '' and user_id="+userModel.id;
	
	

	templateBuilder.Append("\r\n		\r\n		<div class=\"mui-content my_order\">\r\n			\r\n\r\n			\r\n					\r\n						<div id=\"scroll1\" class=\"mui-scroll-wrapper orderBox\" style=\"display: block;\" >\r\n							<div class=\"mui-scroll\">\r\n								<ul class=\"mui-table-view\" id=\"all_list\" style=\"margin-bottom:50px\">\r\n									\r\n  ");
	DataTable list = get_order_list(10, page, strWhere, out totalcount);

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n        \r\n          ");
	foreach(DataRow dr in list.Rows)
	{

	                                    Qrcms.Model.cart_items modelt=get_article(dr["order_no"].ToString());
	                                    

	templateBuilder.Append("\r\n<li class=\"mui-card\">\r\n										<p>订单号：<b>" + Utils.ObjectToStr(dr["order_no"]) + "</b><i style=\"display: none;\">" + Utils.ObjectToStr(dr["Order_type"]) + "</i></p>\r\n									    	<div class=\"goods-list\">\r\n									    		<span class=\"mui-checkbox mui-clearfix xz\" id=\"" + Utils.ObjectToStr(dr["order_no"]) + "\" data-no=\"" + Utils.ObjectToStr(dr["order_no"]) + "\" data-status=\"\" onclick=\"get(this)\">\r\n					\r\n										<input type=\"checkbox\" class=\"gou\" name=\"szdz\" data-no=\"" + Utils.ObjectToStr(dr["order_no"]) + "\" num=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.quantity));
	templateBuilder.Append("\" id=\"szdz_" + Utils.ObjectToStr(dr["order_no"]) + "\"/>\r\n					\r\n					\r\n					\r\n										</span>\r\n\r\n              <a href=\"javascript:void(0)\">\r\n              \r\n									    		<div class=\"mui-clearfix\">\r\n									    		<div class=\"goods_img\">\r\n									    				<img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.img_url));
	templateBuilder.Append("\" >\r\n									    		</div>\r\n										    		<p>");
	templateBuilder.Append(Utils.ObjectToStr(modelt.title));
	templateBuilder.Append("   ｘ ");
	templateBuilder.Append(Utils.ObjectToStr(modelt.quantity));
	templateBuilder.Append("</p>\r\n										    		<!--<p class=\"mui-text-right\">订单号：" + Utils.ObjectToStr(dr["order_no"]) + "</p>-->\r\n										    		\r\n										    	</div>\r\n										    	</a>\r\n										    \r\n									    	</div>\r\n									</li>\r\n");
	}	//end for if

	if (totalcount<1)
	{

	templateBuilder.Append("\r\n													<li class=\"mui-card\">\r\n														<p style=\"text-align: center;line-height: 40px;\">暂无相关订单</p>\r\n													</li>\r\n													  ");
	}	//end for if

	templateBuilder.Append("\r\n\r\n								</ul>\r\n								\r\n							</div>\r\n						</div>\r\n\r\n       				<div class=\"tihuo\" id=\"tihuo\">\r\n       					<span>运费:<i style=\"color: #7D0000;font-style: normal;font-weight: bold;\">￥</i><b style=\"color: #7D0000;\"></b></span>\r\n       					<a href=\"\" class=\"qdth\">确定提货</a>\r\n       				</div>\r\n       				\r\n       </div>\r\n     \r\n        \r\n     \r\n	</body>\r\n	\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/dingdan.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n\r\n		mui.init();\r\n//	\r\n\r\n		(function($){\r\n		    $(\".mui-scroll-wrapper\").scroll({\r\n		        //bounce: false,//滚动条是否有弹力默认是true\r\n		        //indicators: false, //是否显示滚动条,默认是true\r\n		    });\r\n    \r\n		})(mui);\r\n		\r\n		\r\n		\r\n		\r\n		//订单号数组初始化\r\n		var orderNo_zu = [];\r\n		//订单号字符串初始化\r\n		var zs_order = '' ;\r\n		var qnum = 0;\r\n		//获取运费元素\r\n		var $yf = $('#tihuo').find('b');\r\n	\r\n		//console.log($yf);\r\n		\r\n		//运费元素初始化\r\n		$yf.text(0);\r\n	\r\n		//设置提货商品的勾选事件\r\n		function get(id){\r\n			}\r\n $(\"input[name='szdz']\").click(function(){\r\n			////获取订单号\r\n			//var orderNo = $(id).attr('data-no');\r\n			\r\n			////获取input元素\r\n			//var cid=document.getElementById(\"szdz_\"+orderNo);\r\n			\r\n			////如果勾选该商品，就将商品添加到数组里面并且转成字符串，否在从数组里去除\r\n			//if(cid.checked  == true){\r\n					\r\n			//	orderNo_zu.push(orderNo);\r\n			//	console.log(orderNo_zu);\r\n			//	jisuan();\r\n			//	zs_order = orderNo_zu.join();\r\n			//	console.log(zs_order);\r\n				\r\n			//	//cid.checked = false ;\r\n			//	return \r\n			//}else{\r\n				\r\n			//	orderNo_zu.pop(orderNo);\r\n			//	console.log(orderNo_zu);\r\n			//	jisuan();\r\n			//	zs_order = orderNo_zu.join();\r\n			//	console.log(zs_order);\r\n			//	//cid.checked = true ;	\r\n			//	return \r\n		    //}\r\n		    orderNo_zu = [];\r\n		    zs_order = \"\";\r\n		    qnum = 0;\r\nconsole.log('=================')\r\n		    $(\"input[name='szdz']\").each(function () {\r\n\r\n		        if ($(this).get(0).checked)\r\n		        {\r\nconsole.log('1')\r\n		            var _no = $(this).attr(\"data-no\");\r\n		            var _num = $(this).attr(\"num\");\r\n		            qnum += parseInt(_num);\r\n		            orderNo_zu.push(_no)\r\n		        }\r\n		    })\r\n		    zs_order = orderNo_zu.join();\r\njisuan();\r\n		})\r\n\r\n		//设置计算运费的方法，点击勾选触发\r\n		function jisuan(){\r\n			console.log(orderNo_zu.length)\r\n			if(orderNo_zu.length == 0){\r\n					$yf.text(0);\r\n					//bObj.innerHTML =0;\r\n				}else{\r\nvar _nl=qnum;\r\nvar dz=");
	templateBuilder.Append(Utils.ObjectToStr(config.dz_freight));
	templateBuilder.Append(";\r\nvar dj=");
	templateBuilder.Append(Utils.ObjectToStr(config.dj_freight));
	templateBuilder.Append(";\r\n\r\n					//bObj.innerText = (orderNo_zu.length -1) * 3 + 10;\r\n					$yf.text((_nl -1) * dz + dj);\r\n					//console.log( (orderNo_zu.length -1) * 3 + 10);\r\n				}\r\n			\r\n		}\r\n//		mui('body').on('tap','.qdth',function(){\r\n//			var btnArray = ['确认', '取消'];\r\n//			mui.confirm('是否确认全部提货？', '订单列表', btnArray, function(e) {\r\n//				if(e.index == 0){\r\n//					$('.qdth').attr('href','choose_add.aspx');\r\n////					mui.openWindow({\r\n////						url:\"choose_add.aspx?order_no=\"+orderNo,\r\n////						id:\"choose_add.aspx?order_no=\"+orderNo\r\n////					});\r\n//					location.href = 'choose_add.aspx?order_no='+orderNo;\r\n//					\r\n//				}else{\r\n//					mui.toast('您已取消提货');\r\n//				}\r\n//			})\r\n//			mui.ajax('')\r\n//		})\r\n\r\n		mui('body').on('tap','.qdth',function(){\r\n			//alert(2);\r\nvar amount=");
	templateBuilder.Append(userModel.amount.ToString());

	templateBuilder.Append(";\r\nif(orderNo_zu.length == 0){\r\nalert('请选择订单进行合并提货！');\r\nreturn;\r\n}\r\nif(amount<parseInt($yf.text()))\r\n{\r\nif(confrim('余额不足，是否理解充值？'))\r\n{\r\nlocation.href='/mobile/chongzhi.aspx';\r\n}\r\nreturn;\r\n}\r\n			var btnArray = ['确认','取消'];\r\n			mui.confirm('是否确定全部提货','提货',btnArray,function(e){\r\n				if(e.index ==0){\r\n					window.location.href = 'choose_add.aspx?order_no='+zs_order;\r\n				}else{\r\n					mui.toast('您已取消提货');\r\n				}\r\n			})\r\n		})\r\n		\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
