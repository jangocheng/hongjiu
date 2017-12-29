<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Qrcms.Web.admin.login" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no">
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>管理员登录</title>
<link href="skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript">
    $(function () {
        //检测IE
        if ('undefined' == typeof (document.body.style.maxHeight)) {
            window.location.href = 'ie6update.html';
        }
    });
</script>
<style type="text/css">
    .login-form .col .login-input1{padding:5px 10px 5px 34px; background:#fff; border:0; border-radius:3px; font-size:14px; line-height:1em; *line-height:30px; height:32px; width:236px; color:#333; }
</style>
</head>

<body class="loginbody">
<form id="form1" runat="server">
<div style="width:100%; height:100%; min-width:300px; min-height:260px;"></div>
<div class="login-wrap">
  <div class="login-logo">LOGO</div>
  <div class="login-form">
    <div class="col">
      <asp:TextBox ID="txtUserName" runat="server" CssClass="login-input" placeholder="管理员账号" title="管理员账号"></asp:TextBox>
      <label class="icon user" for="txtUserName"></label>
    </div>
    <div class="col">
      <asp:TextBox ID="txtPassword" runat="server" CssClass="login-input" TextMode="Password" placeholder="管理员密码" title="管理员密码"></asp:TextBox>
      <label class="icon pwd" for="txtPassword"></label>
    </div>
     <div class="col">
      <asp:TextBox ID="txtQaptach" runat="server" CssClass="login-input1" Width="136px" TextMode="Password" placeholder="验证码" title="验证码"></asp:TextBox>
      <img src="Qaptcha.aspx" onclick="this.src='Qaptcha.aspx?r=' + Math.random();" alt="点击刷新验证码" style="cursor: pointer;float:left;margin-left:0px;" />
    </div>
    <div class="col">
      <asp:Button ID="btnSubmit" runat="server" Text="登 录" CssClass="login-btn" onclick="btnSubmit_Click" />
    </div>
  </div>
  <div class="login-tips"><i></i><p id="msgtip" runat="server">请输入用户名和密码</p></div>
</div>

<div class="copy-right">
</div>
</form>
</body>
</html>
