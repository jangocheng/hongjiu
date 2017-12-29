﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_list.aspx.cs" Inherits="Qrcms.Web.admin.order.order_list" %>

<%@ Import Namespace="Qrcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>订单管理</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>订单列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','只允许删除已作废订单，是否继续？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                    <asp:ListItem Value="" Selected="True">订单状态</asp:ListItem>
                                    <asp:ListItem Value="1">已生成</asp:ListItem>
                                    <asp:ListItem Value="2">已确认</asp:ListItem>
                                    <asp:ListItem Value="3">已完成</asp:ListItem>
                                    <asp:ListItem Value="4">已取消</asp:ListItem>
                                    <asp:ListItem Value="5">已作废</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select" style="display: none">
                                <asp:DropDownList ID="ddlPaymentStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaymentStatus_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">支付状态</asp:ListItem>
                                    <asp:ListItem Value="1">待支付</asp:ListItem>
                                    <asp:ListItem Value="2">已支付</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlExpressStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExpressStatus_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">发货状态</asp:ListItem>
                                    <asp:ListItem Value="1">待发货</asp:ListItem>
                                    <asp:ListItem Value="2">已发货</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlifupgrade" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlifupgrade_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">订单属性</asp:ListItem>
                                    <asp:ListItem Value="1">升级</asp:ListItem>
                                    <asp:ListItem Value="2">红包</asp:ListItem>
                                    <asp:ListItem Value="3">正常</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlquizresult" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlquizresult_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">中奖状态</asp:ListItem>
                                    <asp:ListItem Value="1">未开奖</asp:ListItem>
                                    <asp:ListItem Value="2">中奖</asp:ListItem>
                                    <asp:ListItem Value="3">未中奖</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:Button ID="Button1" runat="server" Text="导出" CssClass="btn" OnClick="Button1_Click" />
                        </div>
                    </div>
                    <div class="r-list">
                        <div style="float: left; margin-right: 5px;">
                            <asp:TextBox ID="txtStartTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " placeholder="请选择开始日期" />
                            <asp:TextBox ID="txtEndTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " placeholder="请选择结束日期" />
                        </div>
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="8%">选择</th>
                            <th align="left">订单号</th>
                            <th align="left" width="10%">会员账号</th>
                            <th align="left" width="6%">是否升级</th>
                            <th width="8%">订单状态</th>
                            <th width="10%">总金额</th>
                            <th width="10%">业绩</th>
                            <th width="10%">手续费</th>
                            <th align="left" width="14%">下单时间</th>
                            <th>商品标题</th>
                            <th>数量</th>
                            <th width="8%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Enabled='<%#bool.Parse((Convert.ToInt32(Eval("status")) > 3 ).ToString())%>' Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        </td>
                        <td><a href="order_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>"><%#Eval("order_no")%></a></td>
                        <td><%#Eval("user_name").ToString() == "" ? "匿名用户" : Eval("user_name").ToString()%></td>
                        <td><%# getUp(Convert.ToInt32(Eval("order_type")))%></td>
                        <td align="center"><%#GetOrderStatus(Convert.ToInt32(Eval("id")))%></td>
                        <td align="center"><%#Eval("order_amount")%></td>
                        <td align="center"><%#Eval("performance")%></td>

                        <td align="center"><%# Convert.ToInt32(Eval("order_type"))!=1 ?(decimal)0.00:decimal.Round(Convert.ToDecimal(Eval("order_amount"))*(decimal)0.05,2)%></td>
                        <td><%#string.Format("{0:g}",Eval("add_time"))%></td>
                        <td align="center"><%#Eval("t1")%>...</td>
                        <td align="center"><%#Eval("quantity")%></td>
                        <td align="center"><a href="order_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">详细</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
</table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/列表-->
        <div class="tab-content">
            总金额汇总：<asp:Label ID="Label1" ForeColor="Red" runat="server" Text="0.00"></asp:Label>&nbsp;元&nbsp;&nbsp;&nbsp;
            商品数量统计：<asp:Label ID="Label2" ForeColor="Red" runat="server" Text="0.00"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
            业绩汇总：<asp:Label ID="Label3" ForeColor="Red" runat="server" Text="0.00"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
             手续费汇总：<asp:Label ID="Label4" ForeColor="Red" runat="server" Text="0.00"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                    OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->

    </form>
</body>
</html>