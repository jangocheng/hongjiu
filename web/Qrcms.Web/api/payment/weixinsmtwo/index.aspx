<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Qrcms.Web.api.payment.weixinsmtwo.index" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>微信支付</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, target-densitydpi=high-dpi, initial-scale=1.0, maximum-scale=1.0, user-scalable=no,minimal-ui">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">

</head>
<body>  
    <img style="    display: block;margin:150px auto 0px auto; width:150px; height:150px" src="<%= ImageUrl %>"/>
    <p style="color:#666; font-size:12px; text-align: center;">用另一部手机打开微信扫扫二维码付款</p>
    
    <script type='text/javascript' src='/templates/mobile/js/jquery-1.7.2.min.js'></script>
    <script>
        $(function () {
            setInterval(function () {
                getStatus();
            }, 3000);
        });
        function getStatus() {
            $.ajax({
                url: 'index.aspx?action=sel&orderno=<%=Qrcms.Common.DTRequest.GetString("pay_order_no")%>',
                type: 'POST',
                dataType: 'json',
                success: function (data, textStatus, jqXHR) {
                    if (data.status == "1") {
                        location.href = "/mobile/usercenter.aspx";
                    }
                }

            })
        }
    </script>

</body>
</html>