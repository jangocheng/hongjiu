﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_sms.aspx.cs" Inherits="Qrcms.Web.adminusers.users.user_sms" ValidateRequest="false" %>
<%@ Import namespace="Qrcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>短信通知</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>

<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="user_list.aspx"><span>会员管理</span></a>
  <i class="arrow"></i>
  <span>短信通知</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">批量短信通知</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>输入类型</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblSmsType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True" onselectedindexchanged="rblSmsType_SelectedIndexChanged">
          <asp:ListItem Value="1">手动输入</asp:ListItem>
          <asp:ListItem Value="2">批量通知</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
  <dl id="div_group" runat="server" visible="false">
    <dt>会员组别</dt>
    <dd>
      <div class="rule-multi-porp">
        <asp:CheckBoxList ID="cblGroupId" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
      </div>
    </dd>
  </dl>
  <dl id="div_mobiles" runat="server" visible="false">
    <dt>手机号码</dt>
    <dd>
      <asp:TextBox ID="txtMobileNumbers" runat="server" CssClass="input" style="padding:0;width:98%;height:150px;" datatype="/((^1\d{10})(,1\d{10})*$)+/" tip="以英文“,”逗号分隔开" nullmsg="请填写手机号码，多个手机号以“,”号分隔开！" errormsg="手机号必须是以1开头的11位数字，多个手机号以“,”号分隔开！" TextMode="MultiLine"></asp:TextBox>
      <div class="clear"></div>
      <span class="Validform_checktip">*多个手机号码以英文“,”逗号分隔开</span>
    </dd>
  </dl>
  <dl>
    <dt>短信内容</dt>
    <dd>
      <asp:TextBox ID="txtSmsContent" runat="server" CssClass="input" style="padding:0;width:98%;height:150px;" datatype="*" tip="长短信按62个字符每条短信扣取" nullmsg="请填写短信内容！" TextMode="MultiLine" onkeydown="checktxt(this, 'txtTip');" onkeyup="checktxt(this, 'txtTip');"></asp:TextBox>
      <div class="clear"></div>
      <span id="txtTip"></span>
      <span class="Validform_checktip">*长短信按62个字符每条短信扣取</span>
    </dd>
  </dl>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具栏-->

</form>
</body>
</html>
