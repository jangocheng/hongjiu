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

	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n	<head>\r\n		<meta charset=\"UTF-8\">\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/base.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/mui.min.css\" />\r\n		<link rel=\"stylesheet\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no\" />\r\n		<title>拆红包</title>\r\n	</head>\r\n	<body>\r\n		<div class=\"mui-content chaihb\">\r\n			<div class=\"hongbao mui-clearfix\">\r\n				<span></span>\r\n				<span></span>\r\n			</div>\r\n			<div class=\"hb_pro\" style=\"overflow: hidden;\">\r\n				<div class=\"bd\">\r\n					<ul>\r\n                        ");
	DataTable tb = new Qrcms.BLL.orders().GetList(5, " quiz_result=1 and Order_type=2", " id desc").Tables[0];

	                            foreach(DataRow row in tb.Rows){
	                        string u_name=Qrcms.Common.Utils.ObjectToStr(row["user_name"]);
	                        u_name = u_name.Remove((u_name.Length < 4 ? 4:u_name.Length)-4);
	                        u_name=u_name+"****";
	                        

	templateBuilder.Append("\r\n						<li>恭喜用户 ");
	templateBuilder.Append(Utils.ObjectToStr(u_name));
	templateBuilder.Append(" 获得  ");
	templateBuilder.Append(get_order_article_title(Qrcms.Common.Utils.ObjToInt(row["id"],0)).ToString());

	templateBuilder.Append("</li>\r\n                        ");
	                        }
	                        

	templateBuilder.Append("\r\n					</ul>\r\n				</div>\r\n			</div>\r\n			\r\n		</div>\r\n		<div class=\"mask\"  id=\"mask\"></div>\r\n		<div class=\"hb_jieguo\" id=\"hb_jieguo\">\r\n			<div class=\"zhuhe\">\r\n				<p id=\"jg_txt\"></p>\r\n			\r\n			</div>\r\n			<a href=\"redbao_record.aspx\" class=\"mui-btn goto_show\" id=\"goto_xq\">查看详情</a>\r\n			<span class=\"closebtn\" id=\"closebtn\"></span>\r\n			<p class=\"notice\">您可以用市场价换购优购价的商品哦！</p>\r\n		</div>\r\n		\r\n			\r\n		\r\n	</body>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery-1.7.2.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/mui.min.js\"></");
	templateBuilder.Append("script>\r\n	<script src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/jquery.SuperSlide.2.1.1.js\"></");
	templateBuilder.Append("script>\r\n	<script type=\"text/javascript\">\r\n		//alert(1);\r\n		jQuery(\".hb_pro\").slide({mainCell:\".bd ul\",autoPage:true,effect:\"leftMarquee\",autoPlay:true,interTime:50});\r\n	</");
	templateBuilder.Append("script>\r\n	<script>\r\n		mui.init();\r\n		mui('body').on('tap','span',function(){\r\n			var jgobj = document.getElementById('jg_txt');\r\n			var orderNo ='");
	templateBuilder.Append(Qrcms.Common.DTRequest.GetString("order_no").ToString());

	templateBuilder.Append("'; \r\n			console.log(orderNo);\r\n			mui.ajax('/tools/submit_ajax.ashx?action=order_orders_hb',{\r\n				type:'post',\r\n				datatype:'string',\r\n				data:{\r\n					order_no:orderNo\r\n				},\r\n				success:function(data){\r\n					//alert(99);\r\n					\r\n					data = JSON.parse(data);\r\n						var txt = data.msg;\r\n						//alert(txt);\r\n						jgobj.innerText = txt;\r\n					if(data.status ==1){\r\n						\r\n					\r\n					}else {\r\n						\r\n						\r\n					}\r\n				}\r\n			});\r\n			$('#mask,#hb_jieguo').css('display','block');\r\n		});\r\n		mui('body').on('tap','#closebtn',function(){\r\n			$('#mask,#hb_jieguo').css('display','none');\r\n		});\r\n		mui('body').on('tap','#goto_xq',function(){\r\n			location.href = this.href;\r\n		})\r\n		mui('body').on('tap','#closebtn',function(){\r\n			window.location.href = 'usercenter.aspx';\r\n		})\r\n	</");
	templateBuilder.Append("script>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
