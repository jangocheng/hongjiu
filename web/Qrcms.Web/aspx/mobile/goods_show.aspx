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
	templateBuilder.Append("/css/swiper-3.4.2.min.css\" />\r\n		<style type=\"text/css\">\r\n			.selected{\r\n				background: #BF0A0A !important;\r\n				color: #fff !important;\r\n			}\r\n			.mui-toast-container{\r\n				bottom: 50%;\r\n			}\r\n			.detail div p img{\r\n				width: 80%;\r\n				display: block;\r\n				margin: 0 auto;\r\n			}\r\n			.mui-slider{\r\n				height: 7.5rem;\r\n			}\r\n			.mui-slider .mui-slider-item{\r\n				height: 7.5rem;\r\n			}\r\n			.mui-slider .mui-slider-item img{\r\n				height: 7.5rem;\r\n			}\r\n			.swiper-container,.swiper-container .swiper-wrapper {\r\n				width: 100%;\r\n				height: 7.5rem;\r\n			}\r\n			.swiper-slide,.swiper-slide img{\r\n				width: 100%;\r\n				height: 7.5rem;\r\n			}\r\n			.swiper-pagination-bullet-active{\r\n				opacity: 1;\r\n				background: #902626 !important;\r\n			}\r\n			\r\n		</style>\r\n	</head>\r\n	<body>\r\n		");
	 Qrcms.Model.users userModel = new Qrcms.Web.UI.UserPage().GetUserInfo();
	        decimal amount = 0;
	        if (userModel != null)
	        {
	            amount = userModel.amount;
	        }
			

	templateBuilder.Append("\r\n\r\n		<div class=\"mui-content goods_show\">\r\n			<!--\r\n            	商品banner\r\n            -->\r\n			<!-- <div class=\"mui-slider\">\r\n				<div class=\"mui-slider-group mui-slider-loop\">\r\n					 <div class=\"mui-slider-item mui-slider-item-duplicate\"><a href=\"#\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/banner2.png\" /></a></div>\r\n				   \r\n				    <div class=\"mui-slider-item\"><a href=\"#\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/banner2.png\" /></a></div>\r\n				    <div class=\"mui-slider-item\"><a href=\"#\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/banner2.png\" /></a></div>\r\n				    \r\n				     <div class=\"mui-slider-item mui-slider-item-duplicate\"><a href=\"#\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/banner2.png\" /></a></div>\r\n				</div>\r\n				<div class=\"mui-slider-indicator\">\r\n					<div class=\"mui-indicator mui-active\"></div>\r\n					<div class=\"mui-indicator \"></div>\r\n				</div>\r\n			</div>-->\r\n			\r\n			<div class=\"swiper-container\">\r\n			    <div class=\"swiper-wrapper\">\r\n			    	 ");
	if (model.albums!=null)
	{

	foreach(Qrcms.Model.article_albums modelt in model.albums)
	{

	templateBuilder.Append("\r\n			        <div class=\"swiper-slide\">\r\n			        	<img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.thumb_path));
	templateBuilder.Append("\" />\r\n			        </div>\r\n			       ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n			    </div>\r\n    			<!-- 如果需要分页器 -->\r\n    			<div class=\"swiper-pagination\"></div>\r\n    \r\n    \r\n  \r\n			</div>\r\n			\r\n			\r\n		\r\n			<div class=\"mui-card title\">\r\n				<p>");
	templateBuilder.Append(Utils.ObjectToStr(model.title));
	templateBuilder.Append("</p>\r\n				<p>¥<span id=\"sell_price\">" + Utils.ObjectToStr(model.fields["sell_price"]) + "</span></p>\r\n				<p>\r\n					<!--<span>运费：<i id=\"yf_money\">" + Utils.ObjectToStr(model.fields["yunfei"]) + "</i></span>-->\r\n					<!--<span>月销量：<i>1587件</i></span>\r\n					<span><i>浙江杭州</i></span>-->\r\n				</p>\r\n			</div>\r\n			<div class=\"sj_price\">\r\n					<span>数量:</span>\r\n					<div class=\"mui-numbox\" data-numbox-step=\"1\" data-numbox-min=\"0\" data-numbox-max=\"100\">\r\n									<button class=\"mui-btn mui-numbox-btn-minus\" type=\"button\">-</button>	\r\n									<input type=\"text\" value=\"1\" class=\"mui-numbox-input\" id=\"commoditySelectNum\" />\r\n									<button class=\"mui-btn mui-numbox-btn-plus\" type=\"button\">+</button>\r\n								</div>\r\n				<input type=\"hidden\" name=\"stockQuantity\" id=\"stockQuantity\" value=\"4\" />\r\n				</div>\r\n			<!--\r\n            	选择商品规格\r\n            -->\r\n			<!--<div class=\"mui-input-group goods-spec\">\r\n			    <div class=\"mui-input-row\">\r\n			        <label>请选择规格</label>\r\n			        <input id=\"menu-btn\" type=\"text\" readonly >\r\n			    </div>\r\n			   \r\n			</div>-->\r\n			<!--\r\n            	商家信息\r\n            -->\r\n			<!--<div class=\"shop_header mui-clearfix\">\r\n            	<div>\r\n            		<img src=\"images/shop-logo1.png\" alt=\"\" />\r\n            	</div>\r\n            	<div>\r\n            		<p>OPPO旗舰店</p>\r\n            		<p>商家编号：<span id=\"shopno\"></span></p>\r\n            	</div>\r\n			</div>-->\r\n			<!--\r\n            	商品图文详情\r\n            -->\r\n			<div class=\"detail\">\r\n			    <h5><span>商品介绍</span></h5>\r\n			    <div>\r\n			    	");
	templateBuilder.Append(Utils.ObjectToStr(model.content));
	templateBuilder.Append("\r\n			    </div>\r\n				<p>—— 已经到底了 ——</p>\r\n			</div>\r\n			\r\n		</div>\r\n		<div class=\"goods_showbtn\">\r\n				<!--<div class=\"sj_price\">\r\n					<span>数量:</span>\r\n					<div class=\"mui-numbox\" data-numbox-step=\"1\" data-numbox-min=\"0\" data-numbox-max=\"100\">\r\n									<button class=\"mui-btn mui-numbox-btn-minus\" type=\"button\">-</button>	\r\n									<input type=\"text\" value=\"1\" class=\"mui-numbox-input\" id=\"commoditySelectNum\" />\r\n									<button class=\"mui-btn mui-numbox-btn-plus\" type=\"button\">+</button>\r\n								</div>\r\n				<input type=\"hidden\" name=\"stockQuantity\" id=\"stockQuantity\" value=\"4\" />\r\n				</div>-->\r\n					\r\n				\r\n				<!--<button type=\"button\" class=\"mui-btn mui-btn-blue \">加入购物车</button>-->\r\n				<span type=\"button\" class=\"mui-btn mui-btn-blue \" style=\"border: 1px solid rgb(253,165,0); background: rgb(253,165,0);display: inline-block;\" >账户余额&nbsp;<b id=\"acount\">");
	templateBuilder.Append(Utils.ObjectToStr(amount));
	templateBuilder.Append("</b></span>\r\n				<button type=\"button\" class=\"mui-btn mui-btn-blue\" id=\"buy\" >立即购买</button>\r\n		</div>\r\n		<div id=\"menu-wrapper\" class=\"menu_wrapper mui-hidden\">\r\n			<div id=\"menu\" class=\"menu\">\r\n			\r\n			 \r\n			\r\n			  	<input id=\"commodityArticleId\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.id));
	templateBuilder.Append("\" />\r\n                <input id=\"commodityGoodsId\" type=\"hidden\" value=\"0\" />\r\n               \r\n				<ul class=\"mui-table-view\">\r\n					<!--\r\n                    	商品规格\r\n                    -->\r\n						 ");
	List<Qrcms.Model.article_goods_spec> specList = get_article_goods_spec(model.id, "parent_id=0");

	if (specList!=null)
	{

	foreach(Qrcms.Model.article_goods_spec modelt1 in specList)
	{

	templateBuilder.Append("\r\n					<li>\r\n						<div class=\"mui-row\">\r\n							<p style=\"text-align: left; padding-left: 2.5%;\">");
	templateBuilder.Append(Utils.ObjectToStr(modelt1.title));
	templateBuilder.Append("</p>\r\n							<input type=\"hidden\" />\r\n							<!--\r\n                            	规格选项\r\n                            -->\r\n							  ");
	List<Qrcms.Model.article_goods_spec> itemList = get_article_goods_spec(model.id, "parent_id="+modelt1.spec_id);

	if (itemList!=null)
	{

	foreach(Qrcms.Model.article_goods_spec modelt2 in itemList)
	{

	templateBuilder.Append("\r\n							<span class=\"mui-col-sm-3 mui-col-xs-3\">\r\n								");
	templateBuilder.Append(Utils.ObjectToStr(modelt2.title));
	templateBuilder.Append("\r\n								<input type=\"hidden\" />\r\n							</span>\r\n							 ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n						</div>\r\n					</li>\r\n					 ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n					\r\n				</ul>\r\n				<button type=\"button\" class=\"mui-btn mui-btn-blue mui-btn-block\">确定</button>\r\n			</div>\r\n		</div>\r\n		<div id=\"menu-backdrop\" class=\"menu-backdrop\"></div>\r\n		<div class=\"games\" id=\"games\">\r\n			<div class=\"game_txt\">\r\n				<h3>升级规则</h3>\r\n				<div class=\"mui-scroll-wrapper\">\r\n					<div class=\"mui-scroll\">\r\n						商品列表中，左边为小升级商品，右边为大升级商品，未中奖为小商品，中奖为大商品。在每个订单保存这个结果。客户可以在榜单看到结果，商品只有大商品可以提货或提现佣金，小商品只能提货。\r\n					</div>\r\n				</div>\r\n				<div class=\"game_btn mui-clearfix\">\r\n					<a href=\"\" id=\"goto_hb\" style=\"display:none;\">猜红包</a>\r\n					<a href=\"\" id=\"goto_jo\">猜鸡藕</a>\r\n                    <a href=\"\" id=\"goto_dx\">猜大中小</a>\r\n                    <a href=\"\" id=\"goto_nn\">猜牛牛</a>\r\n					<a href=\"\" id=\"goto_th\">提货</a>                   \r\n				</div>\r\n			</div>\r\n			<a class=\"close\" id=\"closeBtn\">\r\n				\r\n			</a>\r\n		</div>\r\n		<div class=\"mask\" id=\"mask\"></div>\r\n	</body>\r\n	<script src=\"");
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
	templateBuilder.Append("script>\r\n	\r\n	\r\n	<script>\r\n		mui.init();\r\n		\r\n//			var menuWrapper = document.getElementById(\"menu-wrapper\");\r\n//			var menu = document.getElementById(\"menu\");\r\n//			var menuWrapperClassList = menuWrapper.classList;\r\n//			var backdrop = document.getElementById(\"menu-backdrop\");\r\n//			backdrop.addEventListener('tap', toggleMenu);\r\n//			document.getElementById(\"menu-btn\").addEventListener('tap', function(){\r\n//				console.log(1);\r\n//				mui(\"#menu-wrapper\")[0].style.bottom = \"50px\";\r\n//				mui(\".menu-backdrop\")[0].style.bottom = \"50px\";\r\n//				mui(\"#menu-wrapper .mui-btn-block\")[0].style.display = \"none\";\r\n////				mui(\".goods_showbtn .mui-btn\")[0].removeEventListener(\"tap\",addCart);\r\n////				mui(\".goods_showbtn .mui-btn\")[1].removeEventListener(\"tap\",buyNow);\r\n////				mui(\".goods_showbtn .mui-btn\")[0].addEventListener(\"tap\",addGwc)\r\n////				mui(\".goods_showbtn .mui-btn\")[1].addEventListener(\"tap\",buy)\r\n//				toggleMenu();\r\n//		});\r\n//		mui('body').on('tap','#buy',function(){\r\n//			window.location.href = \"confirm_order.aspx\";\r\n//		});\r\n\r\n		$(function(){\r\n			$('#menu ul li span').on('click',function(){\r\n				\r\n				$(this).addClass('selected').siblings().removeClass('selected');\r\n			})\r\n		});\r\n		\r\n		mui('body').on('tap','#closeBtn',function(){\r\n			$('#mask,#games').css('display','none');\r\n		});\r\n		\r\n		mui('body').on('tap','.game_btn a',function(){\r\n			location.href = this.href;\r\n		})\r\n	\r\n	//立即购买\r\n	mui('body').on('tap','#buy',function(){\r\n				\r\n				//	余额\r\n				var acount = document.getElementById('acount').innerText;\r\n				//数量\r\n				var num = document.getElementById('commoditySelectNum').value;\r\n				//商品价格\r\n				var price = document.getElementById('sell_price').innerText;\r\n				\r\n				//运费\r\n				//var yunfei = document.getElementById('yf_money').innerText;\r\n				//console.log(yunfei);\r\n				var xiaofei = parseInt(num * price);\r\n				//var zonge = parseInt(xiaofei+yunfei);\r\n				//console.log(zonge);\r\n//				console.log(xiaofei);\r\n				if(acount < xiaofei){\r\n					mui.toast('账户余额不足，请充值');  //判断账户余额是否充足\r\n						setTimeout(function(){\r\n							window.location.href = 'chongzhi.aspx';\r\n						},2000)\r\n				}else{\r\n					mui.ajax('/tools/submit_ajax.ashx?action=order_save2',{\r\n						type:'post',\r\n						datatype:'string',\r\n						data:{\r\n							id:getQueryString('id'),\r\n							quantity:num\r\n						},\r\n						success:function(data){\r\n							\r\n							data = JSON.parse(data);\r\n							console.log(data.status);\r\n							if(data.status == 1){\r\n								/*alert(9999)*/\r\n								\r\n							\r\n								var prostatus = '");
	templateBuilder.Append(Utils.ObjectToStr(model.is_upgrade));
	templateBuilder.Append("';  //判断是否是升级商品\r\n								//alert(prostatus);\r\n								if(prostatus =='1'){\r\n									\r\n									$('#games,#mask').css('display','block');\r\n									$('#goto_hb').attr('href','chaihb.aspx?order_no='+data.order_no);\r\n									$('#goto_jo').attr('href', 'caijiou.aspx?order_no=' + data.order_no);\r\n									$('#goto_dx').attr('href', 'caidaxiao.aspx?order_no=' + data.order_no);\r\n									$('#goto_nn').attr('href', 'cainiuniu.aspx?order_no=' + data.order_no);\r\n									$('#goto_th').attr('href','choose_add.aspx?order_no='+data.order_no);\r\n									\r\n								}else if(prostatus =='0'){\r\n									\r\n									//普通商品购买\r\n									mui.toast('恭喜，订单提交成功');\r\n									setTimeout(function(){\r\n										window.location.href = 'my_orderlist.aspx?order_no='+data.order_no;\r\n									},3000)\r\n									\r\n								}\r\n							}else{\r\n								mui.toast(data.msg);\r\n							}\r\n						},\r\n						error:function(){\r\n							mui.toast('失败');\r\n						}\r\n					})\r\n				}\r\n		\r\n		\r\n	\r\n	});\r\n		\r\n	\r\n	\r\n	</");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/swiper-3.4.2.min.js\"></");
    templateBuilder.Append("script>\r\n	<script>\r\n	 function getQueryString(name) { var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', 'i'); var r = window.location.search.substr(1).match(reg); if (r != null) { return unescape(r[2]); } return null;}   if(getQueryString('Type')==2){var el = document.getElementById('goto_jo');  el.parentNode.removeChild(el); var el2 = document.getElementById('goto_nn');  el2.parentNode.removeChild(el2);} else if(getQueryString('Type')==1){var el = document.getElementById('goto_dx');  el.parentNode.removeChild(el); var el2 = document.getElementById('goto_nn');  el2.parentNode.removeChild(el2);}	 var mySwiper = new Swiper ('.swiper-container', {\r\n		    direction: 'horizontal',\r\n		    loop: true,\r\n		    speed:300,\r\n		    // 如果需要分页器\r\n		    pagination: '.swiper-pagination',\r\n    \r\n   \r\n 		})        \r\n  </");
	templateBuilder.Append("script>\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
