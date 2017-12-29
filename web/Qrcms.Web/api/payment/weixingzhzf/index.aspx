<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Qrcms.Web.api.payment.weixingzhzf.index" %>

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
                <input type="button" id="btn" value=" 支 付 " onclick="callpay()" style="/* margin-bottom: 40px; *//* margin-top: 41px; */margin: 40px auto; display: block; width: 100%; border: 0px; border-radius: 5px; padding: 11px 0px; color: #fff; background: #2196F3;">
            </div>

        </div>
    </div>

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
    <script type="text/javascript">

        var orderNo = '';
        var amount = '';
        //调用微信JS api 支付
        function jsApiCall() {
            <%--  WeixinJSBridge.invoke(
            'getBrandWCPayRequest',
            <%=wxJsApiParam%>,
            function (res) {
                WeixinJSBridge.log(res.err_msg);
                // window.location.href="/mobile/usercenter.aspx?action=index";
                //alert(res.err_code + res.err_desc + res.err_msg);
            }
            );--%>
            document.getElementById("btn").style.visibility = "hidden";
            WeixinJSBridge.invoke(
                'getBrandWCPayRequest', {
                    "appId":  '<%=appId%>', //公众号名称，由商户传入  
                    "timeStamp":  '<%=timeStamp%>', //时间戳，自1970 年以来的秒数           
                    "nonceStr":  '<%=nonceStr%>', //随机串           
                    "package":  '<%=package%>',     
                    "signType":  '<%=signType%>', //微信签名方式:           
                    "paySign": '<%=paySign%>', //微信签名,       
                }, function (res) {                   
                if (res.err_msg == "get_brand_wcpay_request:ok") {
                    $.ajax({
                        url: 'index.aspx?action=PayCompleate' + '&orderNo=' + orderNo + '&amount='+amount,
                        type: 'POST',
                        dataType: 'json',
                        success: function (data, textStatus, jqXHR) {
                            if (data.status == "1") {
                                alert('充值成功')
                                location.href = "/mobile/usercenter.aspx";
                            }
                            else
                            {
                                alert('充值失败')
                                location.href = "/mobile/usercenter.aspx";
                            }
                        }

                    })
                    // 此处可以使用此方式判断前端返回,微信团队郑重提示：res.err_msg 将在用户支付成 功后返回ok，但并不保证它绝对可靠。 
                    //location.href = "/mobile/usercenter.aspx";
                }               
            });
        }

        function callpay() {

            orderNo = '<%=orderno%>';
            amount = '<%=amount%>';
          
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
