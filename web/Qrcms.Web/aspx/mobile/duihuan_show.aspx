<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.article_show" ValidateRequest="false" %>
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
	const string channel = "goods";

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<title>商品详情</title>\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/offcanvas-drag.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/swiper-3.4.2.min.css\" />\r\n		<style>\r\n			.mui-toast-container{\r\n				bottom: 25%;\r\n			}\r\n			.swiper-container,.swiper-container .swiper-wrapper {\r\n				width: 100%;\r\n				height: 7.5rem;\r\n			}\r\n			.swiper-slide,.swiper-slide img{\r\n				width: 100%;\r\n				height: 7.5rem;\r\n			}\r\n			.swiper-pagination-bullet-active{\r\n				opacity: 1;\r\n				background: #902626 !important;\r\n			}\r\n			\r\n		</style>\r\n		\r\n	</head>\r\n	<body>\r\n		");
	 Qrcms.Model.users userModel = new Qrcms.Web.UI.UserPage().GetUserInfo();
	        decimal point = 0;
	        if (userModel != null)
	        {
	            point = userModel.point;
	        }
			

	templateBuilder.Append("\r\n		<div class=\"mui-content goods_show\">\r\n			<!--\r\n            	商品banner\r\n            -->\r\n			 <!--<div class=\"mui-slider\">\r\n				<div class=\"mui-slider-group mui-slider-loop\">\r\n					 <div class=\"mui-slider-item mui-slider-item-duplicate\"><a href=\"#\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/banner2.png\" /></a></div>\r\n				   \r\n				    <div class=\"mui-slider-item\"><a href=\"#\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/banner2.png\" /></a></div>\r\n				    <div class=\"mui-slider-item\"><a href=\"#\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/banner2.png\" /></a></div>\r\n				    \r\n				     <div class=\"mui-slider-item mui-slider-item-duplicate\"><a href=\"#\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/banner2.png\" /></a></div>\r\n				</div>\r\n				<div class=\"mui-slider-indicator\">\r\n					<div class=\"mui-indicator mui-active\"></div>\r\n					<div class=\"mui-indicator \"></div>\r\n				</div>\r\n			</div>-->\r\n			\r\n			\r\n			<div class=\"swiper-container\">\r\n			    <div class=\"swiper-wrapper\">\r\n			    	 ");
	if (model.albums!=null)
	{

	foreach(Qrcms.Model.article_albums modelt in model.albums)
	{

	templateBuilder.Append("\r\n			        <div class=\"swiper-slide\">\r\n			        	<img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.thumb_path));
	templateBuilder.Append("\" />\r\n			        </div>\r\n			       ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n			    </div>\r\n    			<!-- 如果需要分页器 -->\r\n    			<div class=\"swiper-pagination\"></div>\r\n    \r\n    \r\n  \r\n			</div>\r\n			\r\n			\r\n				<p>");
	templateBuilder.Append(Utils.ObjectToStr(model.title));
	templateBuilder.Append("</p>\r\n				<p id=\"goods_point\">积分：<span class=\"point\">" + Utils.ObjectToStr(model.fields["point"]) + "</span></p>\r\n				<p>\r\n					<span>运费：<i>" + Utils.ObjectToStr(model.fields["yunfei"]) + "</i></span>\r\n					<!--<span>月销量：<i>1587件</i></span>\r\n					<span><i>浙江杭州</i></span>-->\r\n				</p>\r\n			</div>\r\n			<!--\r\n            	选择商品规格\r\n            -->\r\n			<!--<div class=\"mui-input-group goods-spec\">\r\n			    <div class=\"mui-input-row\">\r\n			        <label>请选择规格 颜色</label>\r\n			        <input id=\"menu-btn\" type=\"text\" readonly >\r\n			    </div>\r\n			   \r\n			</div>-->\r\n			<div class=\"sj_price\">\r\n					<span>数量:</span>\r\n					<div class=\"mui-numbox\" data-numbox-step=\"1\" data-numbox-min=\"0\" data-numbox-max=\"100\">\r\n									<button class=\"mui-btn mui-numbox-btn-minus\" type=\"button\">-</button>	\r\n									<input type=\"text\" value=\"1\" class=\"mui-numbox-input\" id=\"commoditySelectNum\" />\r\n									<button class=\"mui-btn mui-numbox-btn-plus\" type=\"button\">+</button>\r\n								</div>\r\n				<input type=\"hidden\" name=\"stockQuantity\" id=\"stockQuantity\" value=\"4\" />\r\n				</div>\r\n			<!--\r\n            	商家信息\r\n            -->\r\n			<!--<div class=\"shop_header mui-clearfix\">\r\n            	<div>\r\n            		<img src=\"images/shop-logo1.png\" alt=\"\" />\r\n            	</div>\r\n            	<div>\r\n            		<p>OPPO旗舰店</p>\r\n            		<p>商家编号：<span id=\"shopno\"></span></p>\r\n            	</div>\r\n			</div>-->\r\n			<!--\r\n            	商品图文详情\r\n            -->\r\n			<div class=\"detail\">\r\n			    <h5><span>商品介绍</span></h5>\r\n			    <div>\r\n			    	<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/brandzt1.png\" alt=\"\" />\r\n			    </div>\r\n				<p>—— 已经到底了 ——</p>\r\n			</div>\r\n			\r\n		</div>\r\n		<div class=\"goods_showbtn\">\r\n				\r\n					\r\n				\r\n				<span type=\"button\" class=\" mui-btn mui-btn-block\" style=\"border: 1px solid rgb(253,165,0); background: rgb(253,165,0);display: inline-block;color: #fff;left: 0;\" >账户积分<b id=\"person_point\">");
	templateBuilder.Append(Utils.ObjectToStr(point));
	templateBuilder.Append("</b></span>\r\n				<button type=\"button\" class=\"mui-btn mui-btn-blue\" id=\"buy\">立即购买</button>\r\n		</div>\r\n		<div id=\"menu-wrapper\" class=\"menu_wrapper mui-hidden\">\r\n				<input id=\"commodityArticleId\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.id));
	templateBuilder.Append("\" />\r\n                <input id=\"commodityGoodsId\" type=\"hidden\" value=\"0\" />\r\n			<div id=\"menu\" class=\"menu\">\r\n				\r\n				<ul class=\"mui-table-view\">\r\n					 ");
	List<Qrcms.Model.article_goods_spec> specList = get_article_goods_spec(model.id, "parent_id=0");

	if (specList!=null)
	{

	foreach(Qrcms.Model.article_goods_spec modelt1 in specList)
	{

	templateBuilder.Append("\r\n					<li>\r\n						<div class=\"mui-row\">\r\n							<p style=\"text-align: left; padding-left: 2.5%;\">");
	templateBuilder.Append(Utils.ObjectToStr(modelt1.title));
	templateBuilder.Append("</p>\r\n							<input type=\"hidden\" />\r\n							");
	List<Qrcms.Model.article_goods_spec> itemList = get_article_goods_spec(model.id, "parent_id="+modelt1.spec_id);

	if (itemList!=null)
	{

	foreach(Qrcms.Model.article_goods_spec modelt2 in itemList)
	{

	templateBuilder.Append("\r\n							<span class=\"mui-col-sm-3 mui-col-xs-3\">\r\n								");
	templateBuilder.Append(Utils.ObjectToStr(modelt2.title));
	templateBuilder.Append("\r\n								<input type=\"hidden\" />\r\n							</span>\r\n									 ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n						</div>\r\n					</li>\r\n					 ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n				\r\n				</ul>\r\n				<button type=\"button\" class=\"mui-btn mui-btn-blue mui-btn-block\">确定</button>\r\n			</div>\r\n		</div>\r\n		<div id=\"menu-backdrop\" class=\"menu-backdrop\"></div>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/laytpl/laytpl.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/cart.js\"></");
	templateBuilder.Append("script>\r\n	<!--<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/goodsshow.js\"></");
	templateBuilder.Append("script>-->\r\n	<script>\r\n		mui.init();\r\n		var p=" + Utils.ObjectToStr(model.fields["point"]) + ";\r\n		\r\n		var pp=Math.abs(p);\r\n		\r\n		$(\".point\").html(pp);\r\n		\r\n//		mui('body').on('tap','#buy',function(){\r\n//			window.location.href = \"confirm_order.aspx\";\r\n//		})\r\n			var menuWrapper = document.getElementById(\"menu-wrapper\");\r\n			var menu = document.getElementById(\"menu\");\r\n			var menuWrapperClassList = menuWrapper.classList;\r\n//			var backdrop = document.getElementById(\"menu-backdrop\");\r\n//			backdrop.addEventListener('tap', toggleMenu);\r\n//			document.getElementById(\"menu-btn\").addEventListener('tap', function(){\r\n//				console.log(1);\r\n//				mui(\"#menu-wrapper\")[0].style.bottom = \"50px\";\r\n//				mui(\".menu-backdrop\")[0].style.bottom = \"50px\";\r\n//				mui(\"#menu-wrapper .mui-btn-block\")[0].style.display = \"none\";\r\n//				toggleMenu();\r\n//		});\r\nvar num = document.getElementById('commoditySelectNum').value;\r\n		mui('body').on('tap','#buy',function(){\r\n			\r\n			var g=" + Utils.ObjectToStr(model.fields["point"]) + ";\r\n			//alert(g)\r\n			var p=$(\"#person_point\").text();\r\n			if(g>p){\r\n				mui.toast(\"你的积分不足\")\r\n} else {\r\n\r\n	mui.ajax('/tools/submit_ajax.ashx?action=order_save2', {\r\n			type: 'post',\r\n			datatype: 'string',\r\n			data: {\r\n				id: getQueryString('id'),\r\n				quantity: num\r\n			},\r\n			success: function(data) {\r\n				data = JSON.parse(data);\r\n				if(data.status == 1) {\r\n					//alert(99999)\r\n					\r\n					mui.toast(data.msg);\r\n					setTimeout(function(){\r\n						window.location.href = 'my_orderlist.aspx';\r\n					},2000)\r\n				} else{\r\n					//alert(8888)\r\n					mui.toast(data.msg);\r\n				}\r\n			}\r\n		}\r\n	)\r\n}})\r\n	\r\n\r\n\r\n</");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/swiper-3.4.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script>\r\n	 var mySwiper = new Swiper ('.swiper-container', {\r\n		    direction: 'horizontal',\r\n		    loop: true,\r\n		    speed:300,\r\n		    // 如果需要分页器\r\n		    pagination: '.swiper-pagination',\r\n    \r\n   \r\n 		})        \r\n</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
