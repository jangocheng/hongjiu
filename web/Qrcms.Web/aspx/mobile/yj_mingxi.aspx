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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n			<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />		\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<title>佣金明细</title>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content mingxi\">\r\n			<div class=\"mui-scroll-wrapper\" id=\"mingxi_wrap\">\r\n				<div class=\"mui-scroll\">\r\n					<ul class=\"mui-table-view\" id=\"mingxi_list\">\r\n						<!--<li class=\"mui-table-view-cell\">\r\n							<p class=\"mui-clearfix\">订单消费&nbsp;B201547414<span>-566.00</span></p>\r\n							<p class=\"mui-clearfix\">2017/05/26 12:05</p>\r\n						</li>\r\n						<li class=\"mui-table-view-cell\">\r\n							<p class=\"mui-clearfix\">余额充值&nbsp;B201547414<span>+2000.00</span></p>\r\n							<p class=\"mui-clearfix\">2017/05/26 12:05</p>\r\n						</li>-->\r\n						\r\n					</ul>\r\n				</div>\r\n			</div>\r\n		</div>\r\n		<!--模板引擎绑定数据-->\r\n		\r\n	</body>\r\n	<script src=\"");
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
	templateBuilder.Append("script>\r\n	<script>\r\n		//MUI框架初始化\r\n			mui.init();\r\n		//JS模板引擎\r\n			function LoadTPL(tplid,viewid,data)\r\n				{\r\n				    var tpl = document.getElementById(tplid).innerHTML;\r\n				   \r\n				    var render = laytpl(tpl).render(data);\r\n				 	 $(\"#\"+viewid).append(render);\r\n				   \r\n				 \r\n//				      $('#'+viewid).append(render);\r\n				  \r\n				}\r\n		//页面滚动\r\n			(function($){\r\n			    $(\".mui-scroll-wrapper\").scroll({\r\n			        //bounce: false,//滚动条是否有弹力默认是true\r\n			        //indicators: false, //是否显示滚动条,默认是true\r\n			    });\r\n    \r\n			})(mui);\r\n			\r\n		//加载明细数据\r\n			function loadsj(page){\r\n				$.ajax({\r\n					url:'/tools/submit_ajax.ashx?action=user_commision_log',\r\n					datatype:\"json\",\r\n					type:\"get\",\r\n					data:{page:page,pagesize:10},\r\n					async:false,\r\n					success:function(data){\r\n						 var  data=JSON.parse(data);\r\n        //字符串拼接实现数据渲染\r\n							var html =\"\";\r\n							\r\n					for(i = 0 ; i<data.Rows.length;i++){\r\n							html += '<li class=\"mui-table-view-cell\"><p class=\"mui-clearfix\">'+'&nbsp;'+data.Rows[i].remark+'&nbsp;'+'<span>'+data.Rows[i].value +'</span></p>';\r\n						html += '<p class=\"mui-clearfix\">' + jsonDateFormat(data.Rows[i].add_time)\r\n +'</p></li>';\r\n						\r\n							\r\n						\r\n					}\r\n					$('.mui-table-view').append(html);\r\n\r\n					/*模板引擎的方式实现数据渲染*/\r\n//						LoadTPL('tbody_template','mingxi_list',data);	\r\n					}\r\n				})\r\n			}\r\n			\r\n			//上拉加载下拉刷新实现更多数据加载\r\n			loadsj(1);\r\n			var page = 1;\r\n			mui.init({\r\n			 	pullRefresh : {\r\n			        container:\"#mingxi_wrap\",\r\n			        up : {\r\n			            height:150,\r\n			            auto:false,\r\n			            contentrefresh : \"正在加载...\",\r\n			            contentnomore:'没有更多了',\r\n			            callback :function(data) {\r\n			                var self = this; // 这里的this == mui('#refreshContainer').pullRefresh()\r\n			                // 加载更多的内容\r\n			                if(data.Rows !=\"\"){\r\n			                	 loadMore(this);\r\n			                	 mui('#mingxi_list').pullRefresh().endPullupToRefresh(false);\r\n			                }else{\r\n			                	 mui('#mingxi_list').pullRefresh().endPullupToRefresh(true);\r\n			                }\r\n			               \r\n			            }\r\n			        },\r\n			        down:{\r\n			        	contentrefresh : \"正在加载...\",\r\n			        	callback:function(){\r\n			        		 var self = this; // 这里的this == mui('#refreshContainer').pullRefresh()\r\n			                // 加载更多的内容\r\n			                loadMore(this);\r\n			        	}\r\n			        } \r\n			    }\r\n			});\r\n			var loadMore = function(pullRefresh) {\r\n			    // 加载更多的内容到列表中\r\n			 \r\n			    // 如果没有更多数据了，则关闭上拉加载\r\n			    //发起ajax请求，获取json数据，并将它渲染到页面上\r\n			  	page++;\r\n			  	setTimeout(function(){\r\n			  		console.log(\"第二次加载\");\r\n			  		loadsj(page);\r\n			  	},1500)\r\n			  	console.log(1);			   \r\n			};\r\n			\r\n	function jsonDateFormat(jsonDate) { //json时间格式转换\r\n	var date = new Date(parseInt(jsonDate.replace(\"/Date(\", \"\").replace(\")/\", \"\"), 10));\r\n	var month = date.getMonth() + 1 < 10 ? +(date.getMonth() + 1) : date.getMonth() + 1;\r\n	var day = date.getDate() < 10 ? \"0\" + date.getDate() : date.getDate();\r\n	var hours = date.getHours();\r\n	var minutes = date.getMinutes();\r\n	var seconds = date.getSeconds();\r\n	var milliseconds = date.getMilliseconds();\r\n	return date.getFullYear() + \"-\" + getzf(month) + \"-\" + day + \" \" + getzf(hours) + \":\" + getzf(minutes) + \":\" + getzf(seconds) /* + \".\" + milliseconds*/ ;\r\n};\r\nfunction getzf(num) { //补0操作\r\n	if(parseInt(num) < 10) {\r\n		num = '0' + num;\r\n	}\r\n	return num;\r\n};\r\n \r\n\r\n\r\n		\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
