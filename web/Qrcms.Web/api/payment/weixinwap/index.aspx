<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Qrcms.Web.api.payment.weixinwap.index" %>


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
    <link rel="stylesheet" type="text/css" href="/templates/mobile/css/StyleSheet.css"/>
    <link rel="stylesheet" href="//g.alicdn.com/msui/sm/0.6.2/css/sm.css"/>
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
</head>
<body>  

    <div class="page-group">
        <div class="page page-current">
            <header class="bar bar-nav">
                <a class="button button-link button-nav pull-left" href="javascript:history.go(-1);" data-transition='slide-out'><img class="header-back" src="/templates/mobile/images/back.png"/></a>
                <h1 class="title">在线支付</h1>
            </header>

            <div class="content backgroundf5f5f5" style="text-align:center;">
                 <form id="form1" runat="server">
                     <div class="list-block">
                        <ul>
                          <li class="item-content">
                            <div class="item-media"><i class="icon icon-f7"></i></div>
                            <div class="item-inner">
                              <div class="item-title">订单号</div>
                              <div class="item-after"><%=order_no %></div>
                            </div>
                          </li>
                          <li class="item-content">
                            <div class="item-media"><i class="icon icon-f7"></i></div>
                            <div class="item-inner">
                              <div class="item-title">金额</div>
                              <div class="item-after"><%=order_amount %></div>
                            </div>
                          </li>
                        </ul>
                      </div>
                     <div class="content-block">
                        <input type="button" runat="server" value="下一步" onclick="callpay()"  class="button button-big button-fill backgroundFF6633"  style="margin-bottom: 40px;" />
                    </div>
                </form>
            </div>

        </div>
    </div>
    <script type='text/javascript' src='/templates/mobile/js/jquery-1.11.2.min.js'></script>
</body>
</html>