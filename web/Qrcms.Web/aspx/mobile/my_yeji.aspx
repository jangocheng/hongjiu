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
	templateBuilder.Append("/css/mui.poppicker.css\" />\r\n		<title>我的业绩</title>\r\n		<style>\r\n			.my_yeji{\r\n				\r\n			}\r\n			\r\n			.my_yeji ul li p{\r\n				height: 25px;\r\n				line-height: 25px;\r\n				margin-bottom: 0;\r\n				color: #333;\r\n			}\r\n			.my_yeji ul li p span:nth-of-type(n){\r\n				float: left;\r\n				width: 60%;\r\n				height: 25px;\r\n				line-height: 25px;\r\n			}\r\n			.my_yeji ul li p span:nth-of-type(2n){\r\n				float: left;\r\n				width: 40%;\r\n				height: 25px;\r\n				line-height: 25px;\r\n			}\r\n			\r\n			.mui-table-view-cell{\r\n				padding: 0;\r\n			}\r\n			.my_yeji ul li{\r\n				height: 50px;\r\n				padding-left: 12px;\r\n			}\r\n			.yj{\r\n				height: 40px;\r\n				position: relative;\r\n			}\r\n			.yj:after{\r\n				position: absolute;\r\n				width: 100%;\r\n				height: 1px;\r\n				bottom: 0;\r\n				left: 12px;\r\n				content: '';\r\n				background: #eee;\r\n			}\r\n			.yj_left,.yj_center{\r\n				float: left;\r\n				width: 50%;\r\n				text-align: center;\r\n				line-height:40px ;\r\n			}\r\n		</style>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content my_yeji\">\r\n			<div class=\"mui-scroll-wrapper\" id=\"yj_wrapper\">\r\n				<div class=\"mui-scroll\" style=\"padding-top: 20px;\">\r\n					<button id=\"ks_time\" data-options='{}' class=\"btn mui-btn mui-btn-block colorfff\">请选择开始时间</button>\r\n					<label id=\"ks\" style=\"line-height: 30px;margin: 5px 0;font-size: 12px;text-align: center;display: block;\"></label>\r\n					<button id=\"js_time\" data-options='{}' class=\"btn mui-btn mui-btn-block colorfff\">请选择结束时间</button>\r\n					<label id=\"js\"  style=\"line-height: 30px;margin: 5px 0;font-size: 12px;text-align: center;display: block;\"></label>\r\n					<button class=\"mui-btn mui-btn-block colorfff\" id=\"search_btn\">查询</button>\r\n					\r\n					<p class=\"yj mui-clearfix\">\r\n						<span class=\"yj_left\">会员名</span>\r\n						<span class=\"yj_center\">合计</span>\r\n						<!--<span class=\"yj_right\">服务费</span>-->\r\n					</p>\r\n					<ul class=\"mui-table-view\" id=\"yeji_wrap\">\r\n						<!--<p class=\"yj mui-clearfix\">\r\n							<span class=\"yj_left\">xiaomao</span>\r\n							<span class=\"yj_center\">5000</span>\r\n							<span class=\"yj_right\">6000</span>\r\n						</p>-->\r\n					</ul>\r\n				</div>\r\n			</div>\r\n		</div>\r\n		\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\" ></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\" ></");
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
	templateBuilder.Append("script>\r\n		<script id=\"tbody_template\" type=\"text/html\">\r\n			 {{# for(var i = 0, len = d.Rows.length; i < len; i++){ }}\r\n					<p class=\"yj mui-clearfix\">\r\n						<a href=\"my_ylxq.aspx\" style=\"color: #333;\">\r\n							<span class=\"yj_left userName\">{{d.Rows[i].user_name}}</span>\r\n							<span class=\"yj_center\">{{d.Rows[i].performance}}</span>\r\n							<!--<span class=\"yj_right\">{{d.Rows[i].cover_charge}}</span>-->\r\n						</a>\r\n					</p>\r\n			 {{# } }}\r\n			 \r\n            {{# if(d.count==0){ }}\r\n              <p class=\"yj\" style=\"text-align: center;line-height: 40px;\">\r\n              	暂无数据\r\n              </p>\r\n             {{# } }}\r\n        </");
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n		\r\n			function LoadTPL(tplid,viewid,data)\r\n			{\r\n			    var tpl = document.getElementById(tplid).innerHTML;\r\n			   \r\n			    var render = laytpl(tpl).render(data);\r\n			  $(\"#\"+viewid).append(render);\r\n			   \r\n			 \r\n			     // $('#'+viewid).append(render);\r\n			  \r\n			}\r\n		\r\n		//获取业绩列表\r\n		mui('body').on('tap','#search_btn',function(){\r\n			$('#yeji_wrap').empty();\r\n			loadsj();\r\n		});\r\n		\r\n		function loadsj(){\r\n	mui.ajax('/tools/submit_ajax.ashx?action=orders_yjfwf_select',\r\n{\r\n				datatype:'json',\r\n				type:'get',\r\n				data:{\r\n					starttime:document.getElementById('ks').innerHTML,\r\n					endtime:document.getElementById('js').innerHTML\r\n				},\r\n				success:function(data){\r\n					//var num =Math.ceil(data.count /10);\r\n					//console.log(data.Rows.length);\r\n					// data = JSON.parse(data);\r\n					data = JSON.parse(data);\r\n					if(data.status ==1){\r\n						\r\n					\r\n							\r\n							\r\n								console.log(2)\r\n								LoadTPL('tbody_template','yeji_wrap',data);	\r\n								\r\n							\r\n						\r\n							\r\n					}else{\r\n						var html = '';\r\n						html +='<p class=\"yj\" style=\"text-align:center;line-height:40px\">'+data.msg+'</p>';\r\n						$('#yeji_wrap').append(html);\r\n					}\r\n				},\r\n				error:function(){\r\n					mui.toast('失败');\r\n				}\r\n			});\r\n		}\r\n		\r\n		loadsj();\r\n		//var page = 1;\r\n\r\n		mui('body').on('tap','.yj a',function(){\r\n			var kssj = document.getElementById('ks').innerHTML;\r\n			var jssj = document.getElementById('js').innerHTML;\r\n			var username =$(this).find('.userName').html();\r\n			\r\n			//console.log(username);\r\n			window.location.href = 'my_ylxq.aspx?starttime='+kssj+'&endtime='+jssj+'&user_name='+username;\r\n		})\r\n	</");
	templateBuilder.Append("script>\r\n	<script>\r\n		(function($) {\r\n				$.init();\r\n			//	var result = $('#result')[0];\r\n			var ksbtn = $('#ks_time')[0];\r\n			var jsbtn = $('#js_time')[0];\r\n			var ks = $('#ks')[0];\r\n			var js = $('#js')[0];\r\n			console.log(ksbtn);\r\n			console.log(jsbtn);\r\n			\r\n					ksbtn.addEventListener('tap', function() {\r\n						var optionsJson = this.getAttribute('data-options') || '{}';\r\n						var options = JSON.parse(optionsJson);\r\n						var id = this.getAttribute('id');\r\n						/*\r\n						 * 首次显示时实例化组件\r\n						 * 示例为了简洁，将 options 放在了按钮的 dom 上\r\n						 * 也可以直接通过代码声明 optinos 用于实例化 DtPicker\r\n						 */\r\n						var picker = new $.DtPicker(options);\r\n						picker.show(function(rs) {\r\n							/*\r\n							 * rs.value 拼合后的 value\r\n							 * rs.text 拼合后的 text\r\n							 * rs.y 年，可以通过 rs.y.vaue 和 rs.y.text 获取值和文本\r\n							 * rs.m 月，用法同年\r\n							 * rs.d 日，用法同年\r\n							 * rs.h 时，用法同年\r\n							 * rs.i 分（minutes 的第二个字母），用法同年\r\n							 */\r\n							//alert(rs.text);\r\n							ks.innerHTML =  rs.text;\r\n							//jsbtn.innerHTML = rs.text;\r\n							/* \r\n							 * 返回 false 可以阻止选择框的关闭\r\n							 * return false;\r\n							 */\r\n							/*\r\n							 * 释放组件资源，释放后将将不能再操作组件\r\n							 * 通常情况下，不需要示放组件，new DtPicker(options) 后，可以一直使用。\r\n							 * 当前示例，因为内容较多，如不进行资原释放，在某些设备上会较慢。\r\n							 * 所以每次用完便立即调用 dispose 进行释放，下次用时再创建新实例。\r\n							 */\r\n							picker.dispose();\r\n						});\r\n					}, false);\r\n					jsbtn.addEventListener('tap', function() {\r\n						var optionsJson = this.getAttribute('data-options') || '{}';\r\n						var options = JSON.parse(optionsJson);\r\n						var id = this.getAttribute('id');\r\n						/*\r\n						 * 首次显示时实例化组件\r\n						 * 示例为了简洁，将 options 放在了按钮的 dom 上\r\n						 * 也可以直接通过代码声明 optinos 用于实例化 DtPicker\r\n						 */\r\n						var picker = new $.DtPicker(options);\r\n						picker.show(function(rs) {\r\n							/*\r\n							 * rs.value 拼合后的 value\r\n							 * rs.text 拼合后的 text\r\n							 * rs.y 年，可以通过 rs.y.vaue 和 rs.y.text 获取值和文本\r\n							 * rs.m 月，用法同年\r\n							 * rs.d 日，用法同年\r\n							 * rs.h 时，用法同年\r\n							 * rs.i 分（minutes 的第二个字母），用法同年\r\n							 */\r\n							//alert(rs.text);\r\n							js.innerHTML =  rs.text;\r\n							//jsbtn.innerHTML = rs.text;\r\n							/* \r\n							 * 返回 false 可以阻止选择框的关闭\r\n							 * return false;\r\n							 */\r\n							/*\r\n							 * 释放组件资源，释放后将将不能再操作组件\r\n							 * 通常情况下，不需要示放组件，new DtPicker(options) 后，可以一直使用。\r\n							 * 当前示例，因为内容较多，如不进行资原释放，在某些设备上会较慢。\r\n							 * 所以每次用完便立即调用 dispose 进行释放，下次用时再创建新实例。\r\n							 */\r\n							picker.dispose();\r\n						});\r\n					}, false);\r\n				\r\n			})(mui);\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
