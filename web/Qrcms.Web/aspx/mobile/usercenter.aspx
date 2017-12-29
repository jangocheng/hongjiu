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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<title>个人中心</title>\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/iconfont.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n\r\n		<style>\r\n			.woyao_dh{\r\n				background: #fff url(");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/userbg_08.png) no-repeat 10px 5px;\r\n				background-size:25px ;\r\n			}\r\n			.wo_caifu{\r\n				background: #fff url(");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/my_caifu.png) no-repeat 10px 5px;\r\n				background-size:23px ;\r\n			}\r\n			.wo_hy{\r\n				background: #fff url(");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/my_friend.png) no-repeat 10px 5px;\r\n				background-size:25px ;\r\n			}\r\n			.wo_yeji{\r\n				background: #fff url(");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/my_yeji.png) no-repeat 10px 8px;\r\n				background-size:23px ;\r\n			}\r\n		</style>\r\n\r\n		<style>\r\n			.woyao_dh{\r\n				background: #fff url(");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/userbg_08.png) no-repeat 10px 5px;\r\n				background-size:25px ;\r\n			}\r\n		</style>\r\n\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content grzx\">\r\n			<div class=\"user_head\">\r\n				<div>\r\n					<a href=\"person_zl.aspx\">\r\n						<img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.avatar));
	templateBuilder.Append("\">\r\n						<p>\r\n							<span style=\"font-size: 16px;\">");
	templateBuilder.Append(Utils.ObjectToStr(userModel.user_name));
	templateBuilder.Append("</span>\r\n						</p>\r\n						\r\n					</a>\r\n					<p>\r\n						<a href=\"my_money.aspx\"><span>余额 ");
	templateBuilder.Append(Utils.ObjectToStr(userModel.amount));
	templateBuilder.Append("</span></a>&nbsp;&nbsp;|&nbsp;&nbsp;\r\n						<a href=\"tixian.aspx\"><span>提现</span></a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"chongzhi.aspx\"><span style=\"    font-size: 16px; color: #CA0000;\">充值</span></a>&nbsp;&nbsp;|&nbsp;&nbsp;\r\n						<a href=\"my_jifen.aspx\"><span>积分");
	templateBuilder.Append(Utils.ObjectToStr(userModel.point));
	templateBuilder.Append("</span></a>\r\n					</p>\r\n				</div>\r\n				\r\n			</div>\r\n			<div>\r\n				<ul class=\"mui-table-view grzx_list orderbg\">\r\n					<li>\r\n						<a href=\"my_orderlist.aspx\" class=\"mui-navigate-right\">全部订单</a>\r\n					</li>\r\n					\r\n				</ul>\r\n				<!--<div class=\"all_order\">\r\n						<ul class=\"mui-clearfix\">\r\n							<li>\r\n								<a href=\"my_orderlist.aspx?status=1\">\r\n									<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/dingdan4.png\">\r\n									<p>待支付</p>\r\n								</a>\r\n							</li>\r\n							<li>\r\n								<a href=\"my_orderlist.aspx?status=2\">\r\n									<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/dingdan3.png\">\r\n									<p>待收货</p>\r\n								</a>\r\n							</li>\r\n							<li>\r\n								<a href=\"my_orderlist.aspx?status=3\">\r\n									<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/dingdan2.png\">\r\n									<p>待完成</p>\r\n								</a>\r\n							</li>\r\n							<li>\r\n								<a href=\"my_orderlist.aspx?status=4\">\r\n									<img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/dingdan.png\">\r\n									<p>退款/退货</p>\r\n								</a>\r\n							</li>\r\n						</ul>\r\n				</div>-->\r\n				<ul class=\"mui-table-view grzx_list mtp woyao_sj\">\r\n					<li class=\"mui-table-cell\">\r\n						<a href=\"sj_products.aspx?category_id=58\" class=\"mui-navigate-right\">我要升级</a>\r\n					</li>\r\n				</ul>\r\n				<ul class=\"mui-table-view grzx_list mtp woyao_sj wo_caifu\">\r\n					<li class=\"mui-table-cell\">\r\n						<a href=\"my_money.aspx\" class=\"mui-navigate-right\">我的财富</a>\r\n					</li>\r\n				</ul>\r\n		\r\n				<!--<ul class=\"mui-table-view grzx_list mtp woyao_sj\">\r\n					<li class=\"mui-table-cell\">\r\n						<a href=\"my_money.aspx\" class=\"mui-navigate-right\">我的财富</a>\r\n					</li>\r\n				</ul>-->\r\n\r\n				<ul class=\"mui-table-view grzx_list woyao_dh\">\r\n					<li class=\"mui-table-cell\">\r\n						<a href=\"duihuan_zq.aspx\" class=\"mui-navigate-right\">兑换专区</a>\r\n					</li>\r\n				</ul>\r\n				<ul class=\"mui-table-view grzx_list mtp woyao_rz\">\r\n					<li class=\"mui-table-cell\">\r\n						<a href=\"realname_sucess.aspx\" class=\"mui-navigate-right\">实名认证</a>\r\n					</li>\r\n				</ul>\r\n                   ");
	if (groupModel.is_QRcodestate==1)
	{

	templateBuilder.Append("\r\n		<ul class=\"mui-table-view grzx_list mtp woyao_sj wo_yeji\">\r\n					<li class=\"mui-table-cell\">\r\n						<a href=\"my_yeji.aspx\" class=\"mui-navigate-right\">我的盈利</a>\r\n					</li>\r\n				</ul>\r\n\r\n				<ul class=\"mui-table-view grzx_list woyao_fx \">\r\n					<li class=\"mui-table-cell\">\r\n						<a href=\"share_ewm.aspx\" class=\"mui-navigate-right\">分享二维码</a>\r\n					</li>\r\n				</ul>\r\n\r\n              \r\n				<ul class=\"mui-table-view grzx_list woyao_tuijian wo_hy \">\r\n\r\n				<ul class=\"mui-table-view grzx_list woyao_tuijian \">\r\n\r\n              \r\n				<ul class=\"mui-table-view grzx_list woyao_tuijian mtp\">\r\n\r\n					<li class=\"mui-table-cell\">\r\n						<a href=\"my_tuijian.aspx\" class=\"mui-navigate-right\">我的推荐</a>\r\n					</li>\r\n				</ul>  ");
	}	//end for if

	templateBuilder.Append("\r\n				<ul class=\"mui-table-view grzx_list mtp woyao_hbjl\">\r\n					<li class=\"mui-table-cell\">\r\n						<a href=\"redbao_record.aspx\" class=\"mui-navigate-right\">我的红包记录</a>\r\n					</li>\r\n				</ul>\r\n				<ul class=\"mui-table-view grzx_list woyao_sjjl\">\r\n					<li class=\"mui-table-cell\">\r\n						<a href=\"upgrade_record.aspx\" class=\"mui-navigate-right\">我的升级记录</a>\r\n					</li>\r\n				</ul>\r\n				<!--<ul class=\"mui-table-view grzx_list mtp\">\r\n					<li class=\"mui-table-cell\">\r\n						<a href=\"my-money.html\" class=\"mui-navigate-right\">我的财富</a>\r\n					</li>\r\n				</ul>\r\n				\r\n				\r\n				\r\n				\r\n				<ul class=\"mui-table-view grzx_list mtp\">\r\n					<li class=\"mui-table-cell\">\r\n						<a href=\"my-orderlist.html\" class=\"mui-navigate-right\">我的订单</a>\r\n					</li>\r\n				</ul>-->\r\n				\r\n				\r\n				\r\n			</div>\r\n		</div>\r\n		<nav class=\"mui-bar mui-bar-tab\">\r\n		    <a href=\"index.aspx\" class=\"mui-tab-item \">\r\n		        <span class=\"mui-icon iconfont icon-home\"></span>\r\n		        <span class=\"mui-tab-label\">首页</span>\r\n		    </a>\r\n		    <a href=\"paihang.aspx\" class=\"mui-tab-item\">\r\n		        <span class=\"mui-icon iconfont icon-un-class\"></span>\r\n		        <span class=\"mui-tab-label\">排行榜</span>\r\n		    </a>\r\n		    <!--<a href=\"shop_cart.aspx\" class=\"mui-tab-item\">\r\n		        <span class=\"mui-icon iconfont icon-un-car\"></span>\r\n		        <span class=\"mui-tab-label\">购物车</span>\r\n		    </a>-->\r\n		    <a href=\"usercenter.aspx\" class=\"mui-tab-item mui-active\">\r\n		        <span class=\"mui-icon iconfont icon-My\"></span>\r\n		        <span class=\"mui-tab-label\">个人中心</span>\r\n		    </a>\r\n		</nav>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/webuploader.min.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n		/*底部导航跳转*/\r\n		mui('.mui-bar-tab').on('tap','a',function(){\r\n			document.location.href = this.href;\r\n		});\r\n		\r\n//		function shuaxin(){\r\n//			window.location.reload();\r\n//		}\r\n//		shuaxin();\r\n	//	window.location.href = 'usercenter.aspx';\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
