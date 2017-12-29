<%@ Page Language="C#" AutoEventWireup="true" Inherits="Qrcms.Web.UI.Page.useraddress" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<meta charset=\"utf-8\" />\r\n		<title>添加地址</title>\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/iconfont.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.poppicker.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.picker.css\" />\r\n		<style type=\"text/css\">\r\n			.mui-toast-container{\r\n				bottom: 30%;\r\n			}\r\n			.mui-switch.mui-active{\r\n				background: #7D0000;\r\n				border-color: #7D0000;\r\n			}\r\n		</style>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content add-address\">\r\n		    <div class=\"mui-input-group\">\r\n		  	<form  id=\"add_addressform\">\r\n		  		<div class=\"mui-input-row\">\r\n		            <label>收货人</label>\r\n		            <input type=\"text\" name=\"txtAcceptName\" id=\"txtName\" class=\"mui-input-clear\" placeholder=\"请输入收件人姓名\" datatype=\"name\" errormsg=\"请正确填写收货人姓名\">\r\n		        </div>\r\n		        <div class=\"mui-input-row\">\r\n		            <label>联系电话</label>\r\n		            <input type=\"text\" datatype=\"phone\" errormsg=\"请填写正确的手机号码\" name=\"txtMobile\" id=\"txtPhone\" class=\"mui-input-clear\" placeholder=\"请输入收件人电话\">\r\n		        </div>\r\n		        <div class=\"mui-input-row\">\r\n		            <p class=\"mui-navigate-right selcity\" >所在城市<span  id=\"cityname\">请选择</span></p>\r\n		            <input type=\"hidden\" name=\"txtProvince\" value=\"\" id=\"sheng\" />\r\n		            <input type=\"hidden\" name=\"txtCity\" value=\"\" id=\"shi\" />\r\n		            <input type=\"hidden\" name=\"txtArea\" value=\"\" id='qu' />\r\n		        </div>\r\n		        <div class=\"mui-input-row mui-hidden\">\r\n		        	<input type=\"hidden\" name=\"txtEmail\" id=\"txtEmail\" value=\"1\" />\r\n		        </div>\r\n		        <div class=\"mui-input-row mui-hidden\">\r\n		        	<input type=\"hidden\" name=\"txtTelphone\" id=\"txtTelphone\" value=\"1\" />\r\n		        </div>\r\n		        <div class=\"mui-input-row mui-hidden\">\r\n		        	<input type=\"hidden\" name=\"txtPostCode\" id=\"txtPostCode\" value=\"1\" />\r\n		        </div>\r\n		      \r\n		        <div class=\"mui-input-row\">\r\n		            <label>详细地址</label>\r\n		            <input type=\"text\" id=\"txtAddress\" name=\"txtAddress\" datatype=\"notnull\"   class=\"mui-input-clear\" placeholder=\"请输入详细地址 具体到门牌号\" errormsg=\"请填写详细地址\">\r\n		        </div>\r\n		        <div class=\"mui-input-row \">\r\n		        		<input type=\"text\" name=\"txtCode\" id=\"txtCode\" placeholder=\"请输入验证码\"/>\r\n		        	 \r\n		        </div>\r\n		        <div class=\"mui-input-row \">\r\n		        	 <a href=\"javascript:;\" onclick=\"ToggleCode(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx');return false;\" style=\"margin-top: 10px;float: left;font-size: 12px;color: #7D0000;margin-left: 12px;\"><img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx\" width=\"80\" height=\"22\" align=\"absmiddle\" /> 看不清楚？</a>\r\n		        </div>\r\n		    </div>\r\n		    <div class=\"mui-card\">\r\n		    	设为默认\r\n		    	<div class=\"mui-switch mui-switch-mini mui-active\" id=\"moren\">\r\n				  <div class=\"mui-switch-handle\"></div>\r\n				  <input type=\"hidden\" name=\"is_default\" value=\"1\"/>\r\n				</div>\r\n		    </div>\r\n		  	</form>\r\n		    <button id=\"add_save\" type=\"button\" class=\"mui-btn mui-btn-blue mui-btn-block\">保存</button>\r\n		</div>\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.picker.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.poppicker.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/city.js\"></");
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n		var choo = getQueryString('choose');\r\n		\r\n		\r\n		//城市选择\r\n		var selCity = new mui.PopPicker({\r\n				layer:3\r\n			})\r\n			selCity.setData(cityData);\r\n			mui(\"body\").on(\"tap\",'#cityname',function(){\r\n				//mui.toast(1);\r\n				selCity.show(function(SelectedItem) {\r\n					mui(\"#cityname\")[0].innerHTML = SelectedItem[0].text+\" \"+SelectedItem[1].text+\" \"+SelectedItem[2].text;\r\n					mui(\"input[name=txtProvince]\")[0].value = SelectedItem[0].text;\r\n					mui(\"input[name=txtCity]\")[0].value = SelectedItem[1].text;\r\n					mui(\"input[name=txtArea]\")[0].value = SelectedItem[2].text;\r\n				})\r\n		});\r\n		//切换验证码\r\nfunction ToggleCode(obj, codeurl) {\r\n    $(obj).children(\"img\").eq(0).attr(\"src\", codeurl + \"?time=\" + Math.random());\r\n	return false;\r\n}\r\n		//用户提交添加地址的相关信息\r\n		mui('body').on('tap','#add_save',function(){\r\n			//var formdata = serialize(document.getElementById('add_addressform'));\r\n			\r\n			var formdata = $('#add_addressform').serialize();\r\n			console.log(formdata);\r\n			if(getValid('add_addressform')){\r\n				mui.ajax('/tools/submit_ajax.ashx?action=user_address_edit',{\r\n					datatype:'string',\r\n					type:'post',\r\n					data:formdata,\r\n					success:function(data){\r\n						data = JSON.parse(data);\r\n							\r\n						if(data.status ==1){\r\n							mui.toast(data.msg);\r\n							if(choo==1){\r\n							//var orderNo ='");
	templateBuilder.Append(Qrcms.Common.DTRequest.GetString("order_no").ToString());

	templateBuilder.Append("'; \r\n							//var urlObj = window.location.href ;\r\n							var orderNo =  getQueryString('orderNo');\r\n								//alert(orderNo);\r\n								\r\n								setTimeout(function(){\r\n								window.location.href = 'choose_add.aspx?order_no='+orderNo;\r\n							},2000)\r\n							}else{\r\n								setTimeout(function(){\r\n								window.location.href = 'person_zl.aspx';\r\n							},2000)\r\n							}\r\n							\r\n							//alert(1);\r\n						}else{\r\n							mui.toast(data.msg);\r\n							\r\n						}\r\n					},\r\n					error:function(data){\r\n						mui.toast(data.msg);\r\n					}\r\n					\r\n					\r\n				})\r\n			}\r\n		});\r\n	\r\n	\r\n	\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
