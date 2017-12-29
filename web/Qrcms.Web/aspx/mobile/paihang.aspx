﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.article" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n    <meta charset=\"utf-8\" />\r\n    <title>排行榜</title>\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/iconfont.css\" />\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/iconfont.css\" />\r\n    <style>\r\n        .list_title .ph_left {\r\n            width: 19%;\r\n        }\r\n\r\n        .list_title .ph_center {\r\n            width: 27%;\r\n        }\r\n\r\n        .list_title .ph_right {\r\n            width: 18%;\r\n        }\r\n\r\n        .list_title .ph_right1 {\r\n            width: 10%;\r\n            float: left;\r\n            line-height: 30px;\r\n            text-align: center;\r\n        }\r\n\r\n        .list_box .ph_left {\r\n            width: 19%;\r\n        }\r\n\r\n        .list_box .ph_center {\r\n            width: 27%;\r\n        }\r\n\r\n        .list_box .ph_right {\r\n            width: 18%;\r\n        }\r\n\r\n        .list_box .ph_right1 {\r\n            width: 10%;\r\n            float: left;\r\n            text-align: center;\r\n            line-height: 45px;\r\n        }\r\n\r\n        .list_box .list_smallbox li {\r\n            padding: 0 5px;\r\n            height: auto;\r\n            border-bottom: 1px solid #e5e5e5;\r\n            font-size: 12px;\r\n        }\r\n\r\n        .ph_list .list_box .ph_left {\r\n            height: auto;\r\n            line-height: 14px;\r\n            margin-top: 10px;\r\n        }\r\n\r\n        .mui-bar-tab .mui-tab-item.mui-active {\r\n            color: #902626;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"mui-content paihang\">\r\n\r\n        <!--<div class=\"ph_title\" id=\"ph_title\">\r\n            <span class=\"active\">猜奇偶</span>\r\n            <span>猜红包</span>\r\n        </div>-->\r\n        <div class=\"ph_list\" style=\"margin-top: 25px;width:96%;\">\r\n            <div class=\"list_title mui-clearfix\">\r\n                <span class=\"ph_left\">开奖时间</span>\r\n                <span class=\"ph_center\">开奖期号</span>\r\n                <span class=\"ph_right\">开奖号码</span>\r\n                <span class=\"ph_right1\">鸡藕</span>\r\n                <span class=\"ph_right1\" style=\"width:15%;\">大中小</span>\r\n                <span class=\"ph_right1\">牛牛</span>\r\n            </div>\r\n            <div class=\"list_box\">\r\n                <div class=\"mui-scroll-wrapper\" id=\"phbang_list\">\r\n                    <div class=\"mui-scroll\">\r\n                        <ul class=\"list_smallbox\" style=\"display: block;\" id=\"jiou_ul\">\r\n                            <li class=\"mui-clearfix\">\r\n                                <!--<p class=\"mui-clearfix\">\r\n                                    <span class=\"ph_left\">2017-08-08 18:05:06</span>\r\n                                    <span class=\"ph_center\">2017455474</span>\r\n                                    <span class=\"ph_right\">48541</span>\r\n                                    <span class=\"ph_right1\">奇</span>\r\n                                </p>-->\r\n                            </li>\r\n\r\n\r\n                        </ul>\r\n                        <!--\r\n                            猜红包\r\n                        -->\r\n                        <!--<ul class=\"list_smallbox\">\r\n                            <li class=\"mui-clearfix\">\r\n                                <div class=\"ph_left\" >\r\n                                    1\r\n                                </div>\r\n                                <div class=\"ph_center\" >\r\n                                    <img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/ph_tx.png\">\r\n\r\n                                    <i>蜜蜂不采蜜</i>\r\n                                </div>\r\n                                <div class=\"ph_right\">\r\n                                    300\r\n                                </div>\r\n                            </li>\r\n\r\n\r\n\r\n\r\n\r\n\r\n                        </ul>-->\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <nav class=\"mui-bar mui-bar-tab\">\r\n        <a href=\"index.aspx\" class=\"mui-tab-item\">\r\n            <span class=\"mui-icon iconfont icon-home\"></span>\r\n            <span class=\"mui-tab-label\">首页</span>\r\n        </a>\r\n        <a href=\"paihang.aspx\" class=\"mui-tab-item mui-active\">\r\n            <span class=\"mui-icon iconfont icon-un-class\"></span>\r\n            <span class=\"mui-tab-label\">排行榜</span>\r\n        </a>\r\n        <!--<a href=\"shop_cart.aspx\" class=\"mui-tab-item\">\r\n            <span class=\"mui-icon iconfont icon-un-car\"></span>\r\n            <span class=\"mui-tab-label\">购物车</span>\r\n        </a>-->\r\n        <a href=\"usercenter.aspx\" class=\"mui-tab-item\" id=\"my_usercenter\">\r\n            <span class=\"mui-icon iconfont icon-My\"></span>\r\n            <span class=\"mui-tab-label\">个人中心</span>\r\n        </a>\r\n    </nav>\r\n\r\n\r\n</body>\r\n<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-3.0.0.min.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/layer/layer.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/laytpl/laytpl.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/layer/laypage/laypage.js\"></");
	templateBuilder.Append("script>\r\n<script>\r\n    mui.init();\r\n\r\n    mui('.mui-bar-tab').on('tap', 'a', function () {\r\n        document.location.href = this.href;\r\n    });\r\n\r\n\r\n    (function ($) {\r\n        console.log(1);\r\n        $(\".mui-scroll-wrapper\").scroll({\r\n            //bounce: false,//滚动条是否有弹力默认是true\r\n            //indicators: false, //是否显示滚动条,默认是true\r\n\r\n        });\r\n\r\n    })(mui);\r\n\r\n\r\n    //切换\r\n    //		var ph_title = document.getElementById('ph_title');\r\n    //		var span = ph_title.getElementsByTagName('span');\r\n    //		var box = document.getElementsByClassName('list_smallbox');\r\n    //		for(var i = 0; i<span.length;i++){\r\n    //			span[i].index = i;\r\n    //			span[i].onclick = function(){\r\n    //				for(var j = 0; j<box.length;j++){\r\n    //					span[j].className='';\r\n    //					box[j].style.display = 'none';\r\n    //\r\n    //				}\r\n    //				span[this.index].className =\"active\";\r\n    //				box[this.index].style.display = 'block';\r\n    //			}\r\n    //		}\r\n\r\n    function loadjiou(page) {\r\n\r\n        $.ajax({\r\n            type: \"get\",\r\n            url: \"/tools/submit_ajax.ashx?action=order_orders_auction&type=123\",\r\n            async: true,\r\n            data: { page: page },\r\n            datatype: 'string',\r\n            success: function (data) {\r\n                data = JSON.parse(data);\r\n                if (data.status == 1) {\r\n                    //alert(2);\r\n                    var html = '';\r\n                    for (var i = 0; i < data.Rows.length; i++) {\r\n                        var jieguo = '';\r\n\r\n                        if (data.Rows[i].quiz_result.toString().indexOf('1') != -1) {\r\n                            jieguo = '鸡'\r\n                        } else {\r\n                            jieguo = '藕'\r\n                        }\r\n\r\n                        var no = data.Rows[i].no.slice(4, data.Rows[i].no.length);\r\n                        html += '<li class=\"mui-clearfix\"><p class=\"mui-clearfix\"><span class=\"ph_left\">' + jsonDateFormat(data.Rows[i].quiz_date) + '</span><span class=\"ph_center\">' + no + '</span><span class=\"ph_right\">' + data.Rows[i].create_user + '</span>';\r\n                        if (data.Rows[i].quiz_result.toString().indexOf('1') != -1) {\r\n                            html += '<span class=\"ph_right1\" style=\"color:blue\">' + jieguo + '</span>';\r\n                        } else {\r\n                            html += '<span class=\"ph_right1\" style=\"color:#f00\">' + jieguo + '</span>';\r\n                        }\r\n                        if (data.Rows[i].quiz_result.toString().indexOf('3') != -1) {\r\n                            html += '<span class=\"ph_right1\" style=\"color:#f00;width:15%;\">大</span>';\r\n                        } else if (data.Rows[i].quiz_result.toString().indexOf('4') != -1) {\r\n                            html += '<span class=\"ph_right1\" style=\"color:green;width:15%;\">中</span>';\r\n                        } else {\r\n                            html += '<span class=\"ph_right1\" style=\"color:blue;width:15%;\">小</span>';\r\n                        }\r\n                        if (data.Rows[i].quiz_result.toString().indexOf('6') != -1) {\r\n                            html += '<span class=\"ph_right1\" style=\"color:#f00;\">有</span></p></li></p></li>';\r\n                        } else {\r\n                            html += '<span class=\"ph_right1\" style=\"color:blue;\">没</span></p></li></p></li>';\r\n                        }\r\n                    }\r\n                    $('#jiou_ul').append(html);\r\n                } else {\r\n                    var html = '';\r\n                    html += '<li style=\"text-align:center\">' + data.msg + '</li>';\r\n                    $('#jiou_ul').append(html);\r\n                }\r\n            }\r\n        });\r\n    }\r\n\r\n    loadjiou(1);\r\n    //		//\r\n    //			mui.init({\r\n    //			 	pullRefresh : {\r\n    //			        container:\"#phbang_list\",\r\n    //			        up : {\r\n    //			            height:150,\r\n    //			            auto:false,\r\n    //			            contentrefresh : \"正在加载...\",\r\n    //			            contentnomore:'没有更多了',\r\n    //			            callback :function() {\r\n    //			                var self = this; // 这里的this == mui('#refreshContainer').pullRefresh()\r\n    //			                // 加载更多的内容\r\n    //			                loadMore(this);\r\n    //			            }\r\n    //			        },\r\n    ////			        down:{\r\n    ////			        	contentrefresh : \"正在加载...\",\r\n    ////			        	callback:function(){\r\n    ////			        		 var self = this; // 这里的this == mui('#refreshContainer').pullRefresh()\r\n    ////			                // 加载更多的内容\r\n    ////			                loadMore(this);\r\n    ////			        	}\r\n    ////			        }\r\n    //\r\n    //			    }\r\n    //			});\r\n    //			var loadMore = function(pullRefresh) {\r\n    //			    // 加载更多的内容到列表中\r\n    //			    // TODO\r\n    //			    // 如果没有更多数据了，则关闭上拉加载\r\n    //			    //发起ajax请求，获取json数据，并将它渲染到页面上\r\n    //\r\n    //			  	setTimeout(function(){\r\n    //			  		console.log(\"第二次加载\");\r\n    //			  		//loadjiou(1);\r\n    //			  	},1500)\r\n    //			  	console.log(1);\r\n    //			};\r\n    //\r\n    function jsonDateFormat(jsonDate) { //json时间格式转换\r\n        var date = new Date(parseInt(jsonDate.replace(\"/Date(\", \"\").replace(\")/\", \"\"), 10));\r\n        var month = date.getMonth() + 1 < 10 ? +(date.getMonth() + 1) : date.getMonth() + 1;\r\n        var day = date.getDate() < 10 ? \"0\" + date.getDate() : date.getDate();\r\n        var hours = date.getHours();\r\n        var minutes = date.getMinutes();\r\n        var seconds = date.getSeconds();\r\n        var milliseconds = date.getMilliseconds();\r\n        return date.getFullYear() + \"-\" + getzf(month) + \"-\" + day + \" \" + getzf(hours) + \":\" + getzf(minutes) + \":\" + getzf(seconds) /* + \".\" + milliseconds*/;\r\n    };\r\n    function getzf(num) { //补0操作\r\n        if (parseInt(num) < 10) {\r\n            num = '0' + num;\r\n        }\r\n        return num;\r\n    };\r\n</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
