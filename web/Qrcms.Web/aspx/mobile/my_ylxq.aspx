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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<link rel=\"stylesheet\"  href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.dtpicker.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.picker.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.poppicker.css\" />\r\n		<title>我的业绩</title>\r\n		<style>\r\n			.my_yeji{\r\n				\r\n			}\r\n			\r\n			.my_yeji ul li p{\r\n				height: 25px;\r\n				line-height: 25px;\r\n				margin-bottom: 0;\r\n				color: #333;\r\n			}\r\n			.my_yeji ul li p span:nth-of-type(n){\r\n				float: left;\r\n				width: 60%;\r\n				height: 25px;\r\n				line-height: 25px;\r\n			}\r\n			.my_yeji ul li p span:nth-of-type(2n){\r\n				float: left;\r\n				width: 40%;\r\n				height: 25px;\r\n				line-height: 25px;\r\n			}\r\n			\r\n			.mui-table-view-cell{\r\n				padding: 0;\r\n			}\r\n			.my_yeji ul li{\r\n				height: 50px;\r\n				padding-left: 12px;\r\n			}\r\n			.yj{\r\n				height: 40px;\r\n				position: relative;\r\n			}\r\n			.yj:after{\r\n				position: absolute;\r\n				width: 100%;\r\n				height: 1px;\r\n				bottom: 0;\r\n				left: 12px;\r\n				content: '';\r\n				background: #eee;\r\n			}\r\n			.yj_left,.yj_center,.yj_right,.yj_bleft{\r\n				float: left;\r\n				\r\n				text-align: center;\r\n				line-height:40px ;\r\n			}\r\n			.yj_bleft{\r\n				width:40%;\r\n			}\r\n			.yj_left{\r\n				width:20%;\r\n			}\r\n			.yj_center{\r\n				width:20%;\r\n			}\r\n			.yj_right{\r\n				width:20%;\r\n			}\r\n			\r\n		</style>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content my_yeji\">\r\n			<div class=\"mui-scroll-wrapper\" id=\"yj_wrapper\">\r\n				<div class=\"mui-scroll\" style=\"padding-top: 20px;\">\r\n				\r\n					\r\n					<p class=\"yj mui-clearfix\">\r\n						<span class=\"yj_bleft\">订单号</span>\r\n						<span class=\"yj_left\">会员名</span>\r\n						<span class=\"yj_center\">业绩</span>\r\n						<!--<span class=\"yj_right\">服务费</span>-->\r\n					</p>\r\n					<ul class=\"mui-table-view\" id=\"yeji_wrap\">\r\n						<!--<p class=\"yj mui-clearfix\">\r\n							<span class=\"yj_left\">xiaomao</span>\r\n							<span class=\"yj_center\">5000</span>\r\n							<span class=\"yj_right\">6000</span>\r\n						</p>-->\r\n					</ul>\r\n				</div>\r\n			</div>\r\n		</div>\r\n		\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\" ></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\" ></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.dtpicker.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.picker.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.poppicker.js\"></");
	templateBuilder.Append("script>\r\n	<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/layer/layer.js\"></");
	templateBuilder.Append("script>\r\n	<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/laytpl/laytpl.js\"></");
	templateBuilder.Append("script>\r\n	<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/laypage/laypage.js\"></");
	templateBuilder.Append("script>\r\n		<script id=\"tbody_template\" type=\"text/html\">\r\n			 {{# for(var i = 0, len = d.Rows.length; i < len; i++){ }}\r\n					<p class=\"yj mui-clearfix\">\r\n							<span class=\"yj_bleft\">{{d.Rows[i].order_no}}</span>\r\n							<span class=\"yj_left\">{{d.Rows[i].user_name}}</span>\r\n							<span class=\"yj_center\">{{d.Rows[i].performance}}</span>\r\n							<!--<span class=\"yj_right\">{{d.Rows[i].cover_charge}}</span>-->\r\n					</p>\r\n			 {{# } }}\r\n			 \r\n            {{# if(d.count==0){ }}\r\n              <p class=\"yj\" style=\"text-align: center;line-height: 40px;\">\r\n              	暂无数据\r\n              </p>\r\n             {{# } }}\r\n        </");
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n		\r\n			function LoadTPL(tplid,viewid,data)\r\n			{\r\n			    var tpl = document.getElementById(tplid).innerHTML;\r\n			   \r\n			    var render = laytpl(tpl).render(data);\r\n			  $(\"#\"+viewid).append(render);\r\n			   \r\n			 \r\n			     // $('#'+viewid).append(render);\r\n			  \r\n			}\r\n		\r\n			var kstime = getQueryString('starttime');\r\n			var jstime = getQueryString('endtime');\r\n			var vip = getQueryString('user_name');\r\n		\r\n		function loadsj(){\r\n	mui.ajax('/tools/submit_ajax.ashx?action=orders_yjfwf_xq',\r\n{\r\n				datatype:'json',\r\n				type:'get',\r\n				data:{\r\n					starttime:kstime,\r\n					endtime:jstime,\r\n					user_name:vip\r\n				},\r\n				success:function(data){\r\n					//var num =Math.ceil(data.count /10);\r\n					//console.log(data.Rows.length);\r\n					// data = JSON.parse(data);\r\n					data = JSON.parse(data);\r\n					if(data.status ==1){\r\n						\r\n					\r\n							\r\n							\r\n								console.log(2)\r\n								LoadTPL('tbody_template','yeji_wrap',data);	\r\n								\r\n							\r\n						\r\n							\r\n					}else{\r\n						var html = '';\r\n						html +='<p class=\"yj\" style=\"text-align:center;line-height:40px\">'+data.msg+'</p>';\r\n						$('#yeji_wrap').append(html);\r\n					}\r\n				},\r\n				error:function(){\r\n					mui.toast('失败');\r\n				}\r\n			});\r\n		}\r\n		\r\n		loadsj();\r\n		//var page = 1;\r\n		(function($){\r\n		    $(\".mui-scroll-wrapper\").scroll({\r\n		        //bounce: false,//滚动条是否有弹力默认是true\r\n		        //indicators: false, //是否显示滚动条,默认是true\r\n		    });\r\n    \r\n		})(mui);\r\n	</");
	templateBuilder.Append("script>\r\n\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
