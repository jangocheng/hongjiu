<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.article" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<meta charset=\"utf-8\" />\r\n		<title>购物车</title>\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/iconfont.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<style type=\"text/css\">\r\n			.mui-bar-tab .mui-tab-item.mui-active{\r\n				color: #7D0000;\r\n			}\r\n		</style>\r\n	<body>\r\n		<div class=\"mui-content shop_cart\">\r\n			<div class=\"shop_list\">\r\n				<!--<div class=\"shop_empty\">\r\n					<img src=\"images/shop_empty.png\">\r\n					<p>购物车还是空的，赶快去购物吧</p>\r\n				</div>-->\r\n				<div class=\"mui-scroll-wrapper\">\r\n					<div class=\"mui-scroll\">\r\n						<div id=\"shopgoods_list\" class=\"shopgoods_list\">\r\n							<div>\r\n								<div class=\"mui-input-row mui-checkbox mui-left mui-navigate-right\">\r\n									<label>OPPO旗舰店</label>\r\n									<input type=\"checkbox\" name=\"\" id=\"\" value=\"\" />\r\n								</div>\r\n								<ul class=\"mui-table-view goods_list\">\r\n									<li class=\"mui-table-view-cell mui-transitioning\">\r\n										<div class=\"mui-slider-right mui-disabled\">\r\n											<a href=\"\" class=\"mui-btn mui-btn-red goods_delete\" data-id=\"\">删除</a>\r\n										</div>\r\n										<div style=\"background: url(");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/201707041728032461.png) 34px 10px / 100px no-repeat rgb(247, 247, 247); transform: translate(0px, 0px);\" class=\"mui-input-row mui-checkbox mui-left mui-slider-handle\">\r\n											<input type=\"checkbox\" />\r\n											<p>正品耐克跑步鞋 专业运动员长 跑耐滑防磨</p>\r\n											<p>颜色：黑色，内存：4G</p>\r\n											<p>155￥</p>\r\n											<div class=\"mui-numbox\" data-numbox-step=\"1\" data-numbox-min=\"0\" data-numbox-max=\"100\">\r\n												<button class=\"mui-btn mui-numbox-btn-minus\" type=\"button\">-</button>	\r\n												<input type=\"text\" value=\"1\" class=\"mui-numbox-input\" />\r\n												<button class=\"mui-btn mui-numbox-btn-plus\" type=\"button\">+</button>\r\n											</div>\r\n										</div>\r\n									</li>\r\n								</ul>\r\n							</div>\r\n							\r\n						</div>\r\n					</div>\r\n				</div>\r\n				\r\n				\r\n			</div>\r\n		</div>\r\n		<div class=\"shop_btnbox\">\r\n			<div class=\"mui-input-row mui-checkbox mui-left\">\r\n				<label>\r\n					全选\r\n					<p>合计：<span>￥<b>0</b></span></p>\r\n				</label>\r\n				\r\n				<input type=\"checkbox\" />\r\n				\r\n			</div>\r\n			<button class=\"mui-btn\" type=\"button\">\r\n					结算<span>(0)</span>\r\n				</button>\r\n		</div>\r\n		<nav class=\"mui-bar mui-bar-tab\">\r\n		    <a href=\"index.aspx\" class=\"mui-tab-item \">\r\n		        <span class=\"mui-icon iconfont icon-home\"></span>\r\n		        <span class=\"mui-tab-label\">首页</span>\r\n		    </a>\r\n		    <a href=\"paihang.aspx\" class=\"mui-tab-item\">\r\n		        <span class=\"mui-icon iconfont icon-un-class\"></span>\r\n		        <span class=\"mui-tab-label\">排行榜</span>\r\n		    </a>\r\n		    <a href=\"shop_cart.aspx\" class=\"mui-tab-item mui-active\">\r\n		        <span class=\"mui-icon iconfont icon-un-car\"></span>\r\n		        <span class=\"mui-tab-label\">购物车</span>\r\n		    </a>\r\n		    <a href=\"usercenter.aspx\" class=\"mui-tab-item \">\r\n		        <span class=\"mui-icon iconfont icon-My\"></span>\r\n		        <span class=\"mui-tab-label\">我的</span>\r\n		    </a>\r\n		</nav>\r\n			<!--<script id=\"tbody_template\" type=\"text/html\">\r\n			 {{# for(var i = 0;i<d.shopcart.length;i++){ }}\r\n							<div class=\"shopgoods_item\">\r\n								<div class=\"mui-input-row mui-checkbox mui-left mui-navigate-right\">\r\n									<label>{{d.shopcart[i].shopname}}</label>\r\n									<input type=\"checkbox\" name=\"\" id=\"\" value=\"\" />\r\n								</div>\r\n								<ul class=\"mui-table-view goods_list\">\r\n									<li class=\"mui-table-view-cell mui-transitioning\">\r\n										<div class=\"mui-slider-right mui-disabled\">\r\n											<a href=\"\" class=\"mui-btn mui-btn-red goods_delete\" data-id=\"\">删除</a>\r\n										</div>\r\n										<div style=\"background: url(images/201707041728032461.png) 34px 10px / 100px no-repeat ; transform: translate(0px, 0px);\" class=\"mui-input-row mui-checkbox mui-left mui-slider-handle\">\r\n											<input type=\"checkbox\" />\r\n											<p>{{d.shopcart[i].proname}}</p>\r\n											<p></p>\r\n											<p>￥{{d.shopcart[i].price}}</p>\r\n											<div class=\"mui-numbox\" data-numbox-step=\"1\" data-numbox-min=\"0\" data-numbox-max=\"100\">\r\n												<button class=\"mui-btn mui-numbox-btn-minus\" type=\"button\">-</button>	\r\n												<input type=\"text\" value=\"1\" class=\"mui-numbox-input\" />\r\n												<button class=\"mui-btn mui-numbox-btn-plus\" type=\"button\">+</button>\r\n											</div>\r\n										</div>\r\n									</li>\r\n								</ul>\r\n							</div>\r\n			 {{# } }}\r\n			 \r\n            {{# if(d.count==0){ }}\r\n               <div class=\"shop_empty\">\r\n					<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/shop_empty.png\">\r\n					<p>购物车还是空的，赶快去购物吧</p>\r\n				</div>\r\n             {{# } }}\r\n        </");
	templateBuilder.Append("script>-->\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\"></");
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
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n		\r\n			//JS模板引擎\r\n		function LoadTPL(tplid,viewid,data)\r\n			{\r\n			    var tpl = document.getElementById(tplid).innerHTML;\r\n			   \r\n			    var render = laytpl(tpl).render(data);\r\n			  $(\"#\"+viewid).append(render);\r\n			   \r\n			 \r\n			     // $('#'+viewid).append(render);\r\n			  \r\n			}\r\n		\r\n		//页面滚动\r\n		(function($){\r\n			console.log('gd');\r\n		    $(\".mui-scroll-wrapper\").scroll({\r\n		        //bounce: false,//滚动条是否有弹力默认是true\r\n		        //indicators: false, //是否显示滚动条,默认是true\r\n		    });\r\n    \r\n		})(mui);\r\n		\r\n		/*底部导航跳转*/\r\n		mui('.mui-bar-tab').on('tap','a',function(){\r\n			document.location.href = this.href;\r\n		});\r\n		\r\n		mui('body').on('tap','.goods_delete',function(){\r\n			var id = $(this).attr('data-id');\r\n			var btnArray = [\"否\",\"是\"];\r\n			mui.confirm('',\"确定删除？\",btnArray,function(e){\r\n				if(e.index == 1){\r\n					console.log(\"删除成功\");\r\n				}\r\n			})\r\n			\r\n		})\r\n		\r\n		/*购物车商品加载*/\r\n//		function loadsj(page){\r\n//			$.ajax({\r\n//				type:\"get\",\r\n//				url:\"js/shopcart.json\",\r\n//				async:true,\r\n//				datatype:'json',\r\n//				data:{page:page},\r\n//				success:function(data){\r\n//					console.log('进入购物车');\r\n//						LoadTPL('tbody_template','shopgoods_list',data);\r\n//				}\r\n//			});\r\n//		}\r\n//		loadsj(1);\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
