<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="auction_list.aspx.cs" Inherits="Qrcms.Web.adminusers.auction.auction_list" %>

<%@ Import Namespace="Qrcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>猜奇偶管理</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">

        //修改平均价
        function update_price(no, low, high) {
            var winDialog = top.dialog({
                title: '修改平均价',
                content: '<textarea id="txtOrderRemark" name="txtOrderRemark" rows="2" cols="20" class="input"></textarea><span style="display: block;">平均价之下：' + low + '人，平均价之上：' + high + '人</span>',
                okValue: '确定',
                ok: function () {
                    var remark = $("#txtOrderRemark", parent.document).val();
                    if (remark == "") {
                        top.dialog({
                            title: '提示',
                            content: '对不起，请输入平均价！',
                            okValue: '确定',
                            ok: function () { }
                        }).showModal(winDialog);
                        return false;
                    }
                    var postData = { "no": no, "price": remark };
                    //发送AJAX请求
                    sendAjaxUrl(winDialog, postData, "../../tools/auction_ajax.ashx?action=updateAvgPrice");
                    return false;
                },
                cancelValue: '取消',
                cancel: function () { }
            }).showModal();
        }


        //发送AJAX请求
        function sendAjaxUrl(winObj, postData, sendUrl) {
            $.ajax({
                type: "post",
                url: sendUrl,
                data: postData,
                dataType: "json",
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    top.dialog({
                        title: '提示',
                        content: '尝试发送失败，错误信息：' + errorThrown,
                        okValue: '确定',
                        ok: function () { }
                    }).showModal(winObj);
                },
                success: function (data, textStatus) {
                    if (data.status == 1) {
                        winObj.close().remove();
                        var d = dialog({ content: data.msg }).show();
                        setTimeout(function () {
                            d.close().remove();
                            location.reload(); //刷新页面
                        }, 2000);
                    } else {
                        top.dialog({
                            title: '提示',
                            content: '错误提示：' + data.msg,
                            okValue: '确定',
                            ok: function () { }
                        }).showModal(winObj);
                    }
                }
            });
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>猜奇偶管理</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li style="display:none"><a class="add" href="auction_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>

                        </ul>
                    </div>
                    <div class="r-list">
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
                            <th align="center" style="width: 5%;">选择</th>
                            <th align="center" style="width: 20%;">开奖期号</th>
                            <th align="center" style="width: 10%;">开奖号码</th>
                            <th align="center" style="width: 10%;">中奖(奇/偶)</th>
                            <th align="center" style="width: 20%;">开奖时间</th>
                            <th align="center" style="width: 10%;">查看订单</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th align="center" style="width: 5%;">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("no")%>' runat="server" />
                        </th>
                        <th align="center" style="width: 20%;"><%#Eval("title")%></a>
                    
                        </th>
                        <th align="center" style="width: 10%;"><%#Eval("quiz_no")%>
                        </th>
                        <th align="center" style="width: 10%;"><%#Getquiz_result(Convert.ToInt32(Eval("quiz_result"))) %> 
                        </th>
                        <th align="center" style="width: 20%;"><%#Eval("quiz_date")%>
                        </th>
                        <th align="center" style="width: 10%;"><%#GetOperatorLook(Convert.ToString(Eval("no")))%>
                        </th>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
</table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/列表-->

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
