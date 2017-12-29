<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Redpacket_order_list.aspx.cs" Inherits="Qrcms.Web.adminusers.Redpacket.Redpacket_order_list" %>

<%@ Import Namespace="Qrcms.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>订单列表</title>
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
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确定删除吗？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">订单状态</asp:ListItem>
                                    <asp:ListItem Value="1">已付款</asp:ListItem>
                                    <asp:ListItem Value="2">待发货</asp:ListItem>
                                    <asp:ListItem Value="3">已发货</asp:ListItem>
                                    <asp:ListItem Value="4">已完成</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlWinStatus" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">中奖状态</asp:ListItem>
                                    <asp:ListItem Value="1">待开奖</asp:ListItem>
                                    <asp:ListItem Value="2">已中奖</asp:ListItem>
                                    <asp:ListItem Value="3">未中奖</asp:ListItem>
                                </asp:DropDownList>
                            </div>
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
                            <th align="center" width="8%">选择</th>
                            <th>订单号</th>
                            <th>用户名</th>
                            <th>订单状态</th>
                            <th>购买数量</th>
                            <th>订单金额</th>
                            <th>业绩</th>
                            <th>服务费</th>
                            <th>购买时间</th>
                            <th>中奖状态</th>
                            <th>商品标题</th>
                            <th>操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("order_no")%>' runat="server" />
                        </td>
                        <td align="center"><a href="auction_details.aspx?action=<%#DTEnums.ActionEnum.Edit %>&no=<%#Eval("order_no")%>"><%#Eval("order_no")%></a></td>
                        <td align="center"><%#Eval("user_name")%></td>
                        <td align="center"><%#GetOrderType(Convert.ToInt32(Eval("id")))%></td>
                        <td align="center"><%#Eval("quantity")%></td>
                        <td align="center"><%#Eval("real_price")%></td>

                        <td align="center"><%#Eval("performance")%></td>
                        <td align="center"><%#Eval("cover_charge")%></td>
                        <td align="center"><%#string.Format("{0:g}",Eval("payment_time"))%></td>
                        <td align="center"><%#GetOrderStatus(Convert.ToInt32(Eval("quiz_result")))%></td>
                        <td align="center"><%#Eval("t1")%>...</td>
                        <td align="center"><a href="../order/order_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">详细</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
</table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/列表-->

        <!--/合计-->
        <div class="tab-content">
            业绩汇总：<asp:Label ID="lblperformance" ForeColor="Red" runat="server" Text="0.00"></asp:Label>&nbsp;元&nbsp;&nbsp;&nbsp;
            服务费汇总：<asp:Label ID="lblcovercharge" ForeColor="Red" runat="server" Text="0.00"></asp:Label>&nbsp;元
        </div>
        <!--/合计-->

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
