<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.article_list" ValidateRequest="false" %>
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
	const int pagesize = 10;

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n	<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/iconfont.css\" />\r\n		<title>品牌专题</title>\r\n		<style>\r\n			.page-list>span:first-child{\r\n	display: none;\r\n}\r\n.page-list{\r\n	text-align: center;\r\n	margin: 20px 0;\r\n	margin-left: 15%;\r\n}\r\n.page-list a,.page-list span {\r\n    display: block;\r\n    float: left;\r\n    margin: 2px 0 0 -1px;\r\n    padding: 4px 12px;\r\n   /* line-height: 30px;*/\r\n    height: 30px;\r\n    border: 1px solid #e1e1e1;\r\n    background: #fff;\r\n    color: #333;\r\n    text-decoration: none;\r\n}\r\n.page-list .current{\r\n	    color: #fff;\r\n    background: #BF0A0A;\r\n    border-color: #BF0A0A;\r\n}\r\n.brand_list .brand_buy  a{\r\n	width: 60px;\r\n}\r\n	.brand_zt .mui-scroll-wrapper {\r\n		padding-bottom: 50px;\r\n	}\r\n</style>\r\n		\r\n	</head>\r\n	<body>\r\n		<!--<header class=\"mui-bar mui-bar-nav\">  \r\n	    <a class=\"mui-action-back mui-icon mui-icon-left-nav mui-pull-left colorhei\" id=\"goto_home\"></a>  \r\n	        <h1 class=\"mui-title mytitle\">品牌专题</h1>  \r\n	    </header>  -->\r\n		<div class=\"mui-content brand_zt\">\r\n			<div class=\"mui-scroll-wrapper\" id=\"brand_wrap\">\r\n				<div class=\"mui-scroll\">\r\n					<ul class=\"brand_list mui-clearfix\" id=\"brand_list\">\r\n						");
	DataTable iud = get_article_list(channel, category_id,10, page, "status=0", out totalcount, out pagelist, "brand_zt", category_id, "__id__");

	int ths__loop__id=0;
	foreach(DataRow ths in iud.Rows)
	{
		ths__loop__id++;


	templateBuilder.Append("\r\n						<li>\r\n							<a href=\"/mobile/goods_show.aspx?id=" + Utils.ObjectToStr(ths["id"]) + "\">\r\n								\r\n								<img src=\"" + Utils.ObjectToStr(ths["img_url"]) + "\">\r\n								<p>" + Utils.ObjectToStr(ths["title"]) + "</p>\r\n								<p>" + Utils.ObjectToStr(ths["sub_title"]) + "</p>\r\n								<p>" + Utils.ObjectToStr(ths["xiao_title"]) + "</p>\r\n							</a>\r\n							<div class=\"brand_buy\">\r\n									<p>￥" + Utils.ObjectToStr(ths["sell_price"]) + "</p>\r\n									<a href=\"/mobile/goods_show.aspx?id=" + Utils.ObjectToStr(ths["id"]) + "\">立即购买</a>\r\n							</div>\r\n						</li>\r\n						 ");
	}	//end for if

	templateBuilder.Append("\r\n					\r\n					</ul>\r\n					<div class=\"page-list mui-clearfix\">");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("</div>\r\n				</div>\r\n			</div>\r\n		</div>\r\n		<nav class=\"mui-bar mui-bar-tab\">\r\n		    <a href=\"index.aspx\" class=\"mui-tab-item\">\r\n		        <span class=\"mui-icon iconfont icon-home\"></span>\r\n		        <span class=\"mui-tab-label\">首页</span>\r\n		    </a>\r\n		    <a href=\"paihang.aspx\" class=\"mui-tab-item\">\r\n		        <span class=\"mui-icon iconfont icon-un-class\"></span>\r\n		        <span class=\"mui-tab-label\">排行榜</span>\r\n		    </a>\r\n		    <!--<a href=\"shop_cart.aspx\" class=\"mui-tab-item\">\r\n		        <span class=\"mui-icon iconfont icon-un-car\"></span>\r\n		        <span class=\"mui-tab-label\">购物车</span>\r\n		    </a>-->\r\n		    <a href=\"usercenter.aspx\" class=\"mui-tab-item\" id=\"my_usercenter\">\r\n		        <span class=\"mui-icon iconfont icon-My\"></span>\r\n		        <span class=\"mui-tab-label\">个人中心</span>\r\n		    </a>\r\n		</nav>\r\n	\r\n	</body>\r\n	<script src=\"");
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
	templateBuilder.Append("script>\r\n	<script>\r\n		//mui初始化\r\n		mui.init();\r\n		mui('.mui-bar-tab').on('tap','a',function(){\r\n			document.location.href = this.href;\r\n		});\r\n		\r\n		//页面滚动\r\n		(function($){\r\n		    $(\".mui-scroll-wrapper\").scroll({\r\n		        //bounce: false,//滚动条是否有弹力默认是true\r\n		        //indicators: false, //是否显示滚动条,默认是true\r\n		    });\r\n    \r\n		})(mui);\r\n		\r\n		//返回首页的跳转\r\n//		mui('body').on('tap','#goto_home',function(){\r\n//			window.location.href =\"index.html\";\r\n//		})\r\n/*\r\n		//进入商品详情页的跳转\r\n		mui('body').on('tap','.enter_xq',function(){\r\n			console.log('进入去买东西咯');\r\n			location.href = this.href;\r\n		})\r\n		\r\n		mui('body').on('tap','#brand_list li a',function(){\r\n			location.href = this.href;\r\n		})\r\n		\r\n		\r\n		mui('body').on('tap','.page-list',function(){\r\n			location.href = this.href;\r\n		})\r\n*/\r\n		//上拉加载\r\n//			mui.init({\r\n//			 	pullRefresh : {\r\n//			        container:\"#brand_wrap\",\r\n//			        up : {\r\n//			            height:150,\r\n//			            auto:false,\r\n//			            contentrefresh : \"正在加载...\",\r\n//			            contentnomore:'没有更多了',\r\n//			            callback :function() {\r\n//			                var self = this; // 这里的this == mui('#refreshContainer').pullRefresh()\r\n//			                // 加载更多的内容\r\n//			                loadMore(this);\r\n//			            }\r\n//			        },\r\n////			        down:{\r\n////			        	style:'circle',\r\n////			        	callback:function(){\r\n////			        		 var self = this; // 这里的this == mui('#refreshContainer').pullRefresh()\r\n////			                // 加载更多的内容\r\n////			                loadMore(this);\r\n////			        	}\r\n////			        }\r\n//			     \r\n//			    }\r\n//			});\r\n//			var loadMore = function(pullRefresh) {\r\n//			    // 加载更多的内容到列表中\r\n//			    // \r\n//			    // 如果没有更多数据了，则关闭上拉加载\r\n//			    //发起ajax请求，获取json数据，并将它渲染到页面上\r\n//			  \r\n//			  	setTimeout(function(){\r\n//			  		console.log(\"第二次加载\");\r\n//			  		//loadsj(page);\r\n//			  	},1500)\r\n//			  	console.log(1);			   \r\n//			};		\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
