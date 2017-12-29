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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" />\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n    <meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n    <title>猜大中小</title>\r\n    <style type=\"text/css\">\r\n\r\n    </style>\r\n</head>\r\n\r\n<body>\r\n    <div class=\"mui-content cainum\">\r\n        <div class=\"head\">\r\n\r\n        </div>\r\n        <div class=\"choose mui-clearfix\" id=\"choose\" style=\"width:86%;\">\r\n            <span class=\"selected\">大</span>\r\n            <span>中</span>\r\n            <span>小</span>\r\n        </div>\r\n        <div>\r\n            <button class=\"sjBtn\" id=\"sjBtn\">点击升级</button>\r\n        </div>\r\n        <div class=\"rank\">\r\n            <p class=\"mui-clearfix\">\r\n                <span class=\"rank_left\">开奖时间</span>\r\n                <span class=\"rank_center\">开奖号码</span>\r\n                <span class=\"rank_right\" style=\"color: #fff;\">结果</span>\r\n            </p>\r\n            <div class=\"rank_ul\" style=\"height: 120px;overflow: hidden;position: relative;\">\r\n                <div class=\"bd\">\r\n                    <ul id=\"wangqi_list\">\r\n                        <!--\r\n                        <li>\r\n                            <span class=\"rank_left\">2017-08-03 12:19:19</span>\r\n                            <span class=\"rank_center\">4564231</span>\r\n                            <span class=\"rank_right\">奇</span>\r\n                        </li>-->\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <!--<div class=\"times\">\r\n            下期开奖时间4521452毫秒\r\n        </div>-->\r\n    </div>\r\n    <div class=\"mask\" id=\"mask\"></div>\r\n    <div class=\"jiou_tan\" id=\"tan\">\r\n\r\n        <span class=\"close_btn\" id=\"close_btn\"></span>\r\n        <!--<p>距离开奖时间：<span>151112112</span>毫秒</p>-->\r\n        <a href=\"upgrade_record.aspx\" class=\"mui-btn wait_kj\">等待开奖</a>\r\n    </div>\r\n</body>\r\n<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery.SuperSlide.2.1.1.js\"></");
	templateBuilder.Append("script>\r\n<script>\r\n		mui.init();\r\n\r\n		//选择大、中、小\r\n		mui('body').on('tap', '#choose span', function() {\r\n\r\n			$(this).addClass('selected').siblings().removeClass('selected');\r\n		});\r\n\r\n\r\n		mui('body').on('tap', '#close_btn', function() {\r\n			$('#mask,#tan').css('display', 'none');\r\n			location.href= 'usercenter.aspx'\r\n		});\r\n		mui('body').on('tap', '.wait_kj', function() {\r\n			location.href=this.href;\r\n		});\r\n		mui('body').on('tap', '#sjBtn', function() {\r\n			var orderNo ='");
	templateBuilder.Append(Qrcms.Common.DTRequest.GetString("order_no").ToString());

	templateBuilder.Append("';\r\n			var n = $(\"#choose span.selected\").index() + 3;\r\n			var url = \"/tools/submit_ajax.ashx?action=order_orders_sj\";\r\n			mui.ajax(url, {\r\n				type: 'post',\r\n				datatype: 'string',\r\n				data: {\r\n					order_no: orderNo,\r\n					quiz: n,\r\n                    type:2\r\n				},\r\n				success: function(data){\r\n					data = JSON.parse(data);\r\n\r\n					if(data.status ==1){\r\n						$('#mask,#tan').css('display', 'block');\r\n						mui.toast(\"升级成功!请耐心等待开奖\");\r\n					}else{\r\n					    mui.toast(data.msg);\r\n					}\r\n				},\r\n				error: function(xhr, type, errorThrown) {\r\n					//异常处理；\r\n					console.log(type);\r\n				}\r\n			})\r\n		});\r\n\r\n		//加载往期竞猜大中小结果\r\n		function loadsj(){\r\n\r\n		    mui.ajax('/tools/submit_ajax.ashx?action=order_orders_auction&type=2', {\r\n				datatype:'string',\r\n				type:'get',\r\n				success:function(data){\r\n					//alert(9);\r\n					data = JSON.parse(data);\r\n					if(data.status == 1){\r\n						//alert(2);\r\n						var jieghuo = '';\r\n						var html ='';\r\n						for(var i = 0; i<data.Rows.length;i++){\r\n						    if (data.Rows[i].quiz_result.toString().indexOf('3') != -1) {\r\n							    jieguo = '大'\r\n						    } else if (data.Rows[i].quiz_result.toString().indexOf('4') != -1) {\r\n						        jieguo = '中'\r\n						    }else{\r\n							    jieguo = '小'\r\n							}\r\n							html += '<li><span class=\"rank_left\">'+jsonDateFormat(data.Rows[i].quiz_date) +'</span><span class=\"rank_center\">'+data.Rows[i].quiz_no +'</span><span class=\"rank_right\">'+jieguo+'</span></li>';\r\n\r\n						}\r\n\r\n						$('#wangqi_list').append(html);\r\n					}else{\r\n						var html ='';\r\n						//alert(data.msg);\r\n						html += '<li style=\"text-align:center;font-size:12px\">'+data.msg +'</li>';\r\n						$('#wangqi_list').append(html);\r\n					}\r\n				}\r\n\r\n			})\r\n		}\r\n\r\n		//调用加载函数\r\n		loadsj();\r\n		function jsonDateFormat(jsonDate) { //json时间格式转换\r\n			var date = new Date(parseInt(jsonDate.replace(\"/Date(\", \"\").replace(\")/\", \"\"), 10));\r\n			var month = date.getMonth() + 1 < 10 ? +(date.getMonth() + 1) : date.getMonth() + 1;\r\n			var day = date.getDate() < 10 ? \"0\" + date.getDate() : date.getDate();\r\n			var hours = date.getHours();\r\n			var minutes = date.getMinutes();\r\n			var seconds = date.getSeconds();\r\n			var milliseconds = date.getMilliseconds();\r\n			return date.getFullYear() + \"-\" + getzf(month) + \"-\" + day + \" \" + getzf(hours) + \":\" + getzf(minutes) + \":\" + getzf(seconds) /* + \".\" + milliseconds*/ ;\r\n		};\r\n		function getzf(num) { //补0操作\r\n			if(parseInt(num) < 10) {\r\n				num = '0' + num;\r\n			}\r\n			return num;\r\n		};\r\n\r\n</");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n		//alert(1);\r\n		jQuery(\".rank_ul\").slide({mainCell:\".bd ul\",autoPage:true,effect:\"top\",autoPlay:true,vis:4});\r\n</");
	templateBuilder.Append("script>\r\n\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
