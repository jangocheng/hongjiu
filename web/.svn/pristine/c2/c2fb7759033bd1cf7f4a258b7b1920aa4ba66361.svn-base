<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Qrcms.Web.api.payment.weixinzf.index" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>微信支付</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, target-densitydpi=high-dpi, initial-scale=1.0, maximum-scale=1.0, user-scalable=no,minimal-ui">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
</head>
<body>
    <img style="display: none; margin: 150px auto 0px auto; width: 150px; height: 150px" src="<%= ImageUrl %>" />
    <p style="color: #666; font-size: 12px; text-align: center; display: none;">用另一部手机打开微信扫扫二维码付款</p>



    <div class="page-group">

        <h1 class="title" style="text-align: center;">微信在线支付</h1>

        <div style="/* text-align: center; */width: 80%; margin: auto;">

            <div style="line-height: 30px; font-size: 1.2rem; color: #666;">
                订单号：
               <%=Qrcms.Common.DTRequest.GetString("pay_order_no") %>
            </div>

            <div class="item-inner" style="line-height: 30px; font-size: 1.2rem; color: #666;">
                金额：
               <%=Qrcms.Common.DTRequest.GetString("pay_order_amount") %>
            </div>

            <div>
                <input type="button" value=" 支 付 " onclick="callpay()" style="/* margin-bottom: 40px; *//* margin-top: 41px; */margin: 40px auto; display: block; width: 100%; border: 0px; border-radius: 5px; padding: 11px 0px; color: #fff; background: #2196F3;">
            </div>

        </div>
    </div>

    <script type='text/javascript' src='/templates/mobile/js/jquery-1.7.2.min.js'></script>
    <script>
<%--        $(function () {
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
        }--%>



    </script>



    <script type="text/javascript">

        //调用微信JS api 支付
        function jsApiCall() {
            WeixinJSBridge.invoke(
            'getBrandWCPayRequest',
            <%=wxJsApiParam%>,
            function (res) {
                WeixinJSBridge.log(res.err_msg);
                // window.location.href="/mobile/usercenter.aspx?action=index";
                //alert(res.err_code + res.err_desc + res.err_msg);
            }
            );
        }

        function callpay() {
            if (typeof WeixinJSBridge == "undefined") {
                if (document.addEventListener) {
                    document.addEventListener('WeixinJSBridgeReady', jsApiCall, false);
                }
                else if (document.attachEvent) {
                    document.attachEvent('WeixinJSBridgeReady', jsApiCall);
                    document.attachEvent('onWeixinJSBridgeReady', jsApiCall);
                }
            }
            else {
                jsApiCall();
            }
        }

    </script>

</body>
</html>
