<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="generateCode.aspx.cs" Inherits="Qrcms.Web.api.payment.weixinsm.generateCode" %>

<!DOCTYPE html>
<meta name="viewport" content="width=device-width,inital-scale=1.0,minimum-scale=0.5,maximum-scale=2.0,user-scalable=no">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/> 
    <meta http-equiv="refresh" content="6" /> 
    <title></title>
    <link href="css/wechattrade.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script> 
    <script type="text/javascript" src="js/wechatpay.js"></script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUKLTYwMzQ0OTkxNmRkhS6p9m8Y2XZtfz4pTAXnJ4wqDqE=" />
</div>

<div>

	<input type="hidden" name="__VIEWSTATEGENERATOR" id="__VIEWSTATEGENERATOR" value="830935F6" />
</div>
    <div class="header">
        <div class="wrap">
             
                   <%--<a  href="index.aspx" > 返回支付测试</a>--%> 
            
        </div>
    </div>
    <div class="topwrap box-shadow-def">
        <div class="innerwrap box-border-def hide-coupon">
            <div class="innercnt">
                <div class="innercnt-wrap clearfix">
                    <div class="orders show-orders-single" id="order_wrap">
                        <div class="orders-single">
                            <h2 class="orders-title">
                                微信支付</h2>
                            
                            <div class="orders-detail">
                                <a href="#" class="js-detail">详情</a>
                                <div class="layer-tips layer-tips-wide layer-tips-stress detail-layer-tips">
                                    <span class="ico-direction-t">
                                        <!-- 图标 -->
                                    </span><a href="#none" class="btn-close js-close" title="关闭">关闭</a>
                                    <div class="layer-tips-main">
                                        <ul class="detail-list">
                                            <li><span class="item-name">商户订单号：</span><span class="item-value"><asp:Label ID="orderno" runat="server" Text=""></asp:Label></span></li>
                                            <li><span class="item-name">商品描述：</span><span class="item-value"><asp:Label ID="shopdesc" runat="server"></asp:Label></span></li>
                                            <li><span class="item-name">附加信息：</span><span class="item-value"><asp:Label ID="attach" runat="server"></asp:Label></span></li>
                                            <li><span class="item-name">总 金 额：</span><span class="item-value"><asp:Label ID="money" runat="server"></asp:Label>元</span></li>
                                           <%-- <li><span class="item-name">订 单 号：</span><span class="item-value">M1503160636</span></li>
                                            <li><span class="item-name">交易金额：</span><span class="item-value">1.00</span></li>--%>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="orders-money">
                                </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="pay_total_money" class="pay-money">
                <div class="money-line">
                    应付：<strong id="total_fee_show" class="money"><asp:Label ID="totalmoney" runat="server"></asp:Label></strong>元</div>
            </div>
        </div>
        <div id="payMsg">
            <div class="area_bd" id="pay_succ" style="display:none">
                <i class="icon110_msg pngFix"></i>
                <h3 class="pay_msg_t">
                    购买成功</h3>
                
               <p class="pay_msg_desc">
                <span id="redirectTimer">8</span>秒后返回商户网页。
               </p>
            </div>
            <div class="area_bd" id="pay_error" style="display:none">
                <i class="icon60_msg pngFix"></i>
                <h3 class="pay_msg_t">
                    无法支付</h3>
                <p class="pay_msg_desc">
                    商品金额大于银行卡快捷支付限额</p>
            </div>
            <div class="area" id="qr_normal">
                <span class="qr_img_wrapper">
                    <img class="qrcode" alt="二维码" id="QRcode" src="#" runat="server" />
                    
                    <img class="guide " src="image/webpay_guide.gif" alt="" id="guide" /></span>
                <div class="msg_default_cg">
                    <i class="icon60_qr pngFix"></i>
                    <p>
                        请使用微信扫码<br />
                        二维码以完成支付</p>
                    
                </div>
                <div><p style="color:red; padding:12px;">请注意！生成的二维码在30秒内未扫码，系统将自动跳转到平台首页！</p></div>
                <div class="msg_default_box" style="display:none">
                    <i class="icon70_qr pngFix"></i>
                    <p>
                        <strong>扫描成功</strong><br />
                        请在手机确认支付</p>
                </div>                
            </div>
        </div>
    </div>
    
    <!--[if IE 6]><script type="text/javascript" src="js/DD_belatedPNG1c27aa.js"></script><script type="text/javascript"> window.onload = function() { DD_belatedPNG.fix(".pngFix"); } </script><![endif]-->
    </form>
   
</body> 
</html>
