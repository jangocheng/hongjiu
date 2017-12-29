<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Redpacket_details.aspx.aspx.cs" Inherits="Qrcms.Web.adminusers.Redpacket.Redpacket_details_aspx" %>

<%@ Import Namespace="Qrcms.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>查看订单</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnExpress").click(function () { OrderExpress(); });   //确认发货
            $("#btnComplete").click(function () { OrderComplete(); }); //完成订单
            //$("#btnPrint").click(function () { OrderPrint(); });       //打印订单
        });
        //确认发货
        function OrderExpress() {
            var winDialog = top.dialog({
                title: '提示',
                url: 'dialog/dialog_auction_express.aspx?no=' + $("#spanOrderNo").text(),
                width: 450,
                height: 400,
                data: window //传入当前窗口
            }).showModal();
        }
        //打印订单
        function OrderPrint() {
            var winDialog = top.dialog({
                title: '打印订单',
                url: 'dialog/dialog_auction_print.aspx?order_no=' + $("#spanOrderNo").text(),
                width: 850
            }).showModal();
        }

        //完成订单
        function OrderComplete() {
            var winDialog = top.dialog({
                title: '完成订单',
                content: '订单完成后，订单处理完毕，确认要继续吗？',
                button: [{
                    value: '确定',
                    callback: function () {
                        var postData = { "no": $("#spanOrderNo").text(), "edit_type": "order_complete" };
                        //发送AJAX请求
                        sendAjaxUrl(winDialog, postData, "../../tools/admin_ajax.ashx?action=auction_express_complete");
                        return false;
                    },
                    autofocus: true
                }, {
                    value: '取消',
                    callback: function () { }
                }]
            }).showModal();
        }


        //=================================工具类的JS函数====================================
        //检查是否货币格式
        function checkIsMoney(val) {
            var regtxt = /^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/;
            if (!regtxt.test(val)) {
                return false;
            }
            return true;
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
            <a href="express_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="order_list.aspx"><span>订单管理</span></a>
            <i class="arrow"></i>
            <span>订单详细</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">订单详细信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dd style="margin-left: 50px; text-align: center;">
                    <div class="order-flow" style="width: 1000px">
                        <div class="order-flow-left">
                            <a class="order-flow-input">生成</a>
                            <span>
                                <p class="name">订单已生成</p>
                                <p><%=model.createdate%></p>
                            </span>
                        </div>
                         <%if (model.status == 0)
                          { %>
                        <div class="order-flow-arrive">
                            <a class="order-flow-input">付款</a>
                            <span>
                                <p class="name">已付款</p>
                            </span>
                        </div>
                        <%if(model.win_status==0) {%>
                         <div class="order-flow-arrive">
                            <a class="order-flow-input">中奖</a>
                            <span>
                                <p class="name">等待开奖</p>
                            </span>
                        </div>
                        <%} else if(model.win_status==1){ %>
                         <div class="order-flow-arrive">
                            <a class="order-flow-input">中奖</a>
                            <span>
                                <p class="name">已中奖</p>
                            </span>
                        </div>
                          <div class="order-flow-right-arrive">
                            <a class="order-flow-input">完成</a>
                            <span>
                                <p class="name">订单完成</p>
                            </span>
                        </div>
                        <%} %>
                        <%}
                           else if (model.status == 1){%>
                         <div class="order-flow-arrive">
                            <a class="order-flow-input">付款</a>
                            <span>
                                <p class="name">已付款</p>
                            </span>
                        </div>
                           <div class="order-flow-arrive">
                            <a class="order-flow-input">中奖</a>
                            <span>
                                <p class="name">未中奖</p>
                            </span>
                        </div>
                        <div class="order-flow-arrive">
                            <a class="order-flow-input">发货</a>
                            <span>
                                <p class="name">等待发货</p>
                            </span>
                        </div>

                        <div class="order-flow-wait">
                            <a class="order-flow-input">发货</a>
                            <span>
                                <p class="name">已发货</p>
                            </span>
                        </div>

                        <div class="order-flow-right-wait">
                            <a class="order-flow-input">完成</a>
                            <span>
                                <p class="name">订单完成</p>
                            </span>
                        </div>
                        <%}
                          else if (model.status == 2)
                          {%>
                          <div class="order-flow-arrive">
                            <a class="order-flow-input">付款</a>
                            <span>
                                <p class="name">已付款</p>
                            </span>
                        </div>
                           <div class="order-flow-arrive">
                            <a class="order-flow-input">中奖</a>
                            <span>
                                <p class="name">未中奖</p>
                            </span>
                        </div>
                        <div class="order-flow-arrive">
                            <a class="order-flow-input">发货</a>
                            <span>
                                <p class="name">等待发货</p>
                            </span>
                        </div>

                        <div class="order-flow-arrive">
                            <a class="order-flow-input">发货</a>
                            <span>
                                <p class="name">已发货</p>
                            </span>
                        </div>

                        <div class="order-flow-right-wait">
                            <a class="order-flow-input">完成</a>
                            <span>
                                <p class="name">订单完成</p>
                            </span>
                        </div>
                        <%}
                          else if (model.status == 3)
                          {%>
                         <div class="order-flow-arrive">
                            <a class="order-flow-input">付款</a>
                            <span>
                                <p class="name">已付款</p>
                            </span>
                        </div>
                        <% if(model.win_status==1){ %>
                         <div class="order-flow-arrive">
                            <a class="order-flow-input">中奖</a>
                            <span>
                                <p class="name">已中奖</p>
                            </span>
                        </div>
                          <div class="order-flow-right-arrive">
                            <a class="order-flow-input">完成</a>
                            <span>
                                <p class="name">订单完成</p>
                            </span>
                        </div>
                        <%}
                           else if (model.win_status == 2) { %>
                            <div class="order-flow-arrive">
                            <a class="order-flow-input">中奖</a>
                            <span>
                                <p class="name">未中奖</p>
                            </span>
                        </div>
                        <div class="order-flow-arrive">
                            <a class="order-flow-input">发货</a>
                            <span>
                                <p class="name">等待发货</p>
                            </span>
                        </div>

                        <div class="order-flow-arrive">
                            <a class="order-flow-input">发货</a>
                            <span>
                                <p class="name">已发货</p>
                            </span>
                        </div>

                        <div class="order-flow-right-arrive">
                            <a class="order-flow-input">完成</a>
                            <span>
                                <p class="name">订单完成</p>
                            </span>
                        </div>
                           <%}%>

                        <%} %>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>订单号</dt>
                <dd><span id="spanOrderNo"><%=model.no %></span></dd>
            </dl>
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <dl>
                        <dt>商品列表</dt>
                        <dd>
                            <div class="table-container">
                                <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
                                    <thead>
                                        <tr>
                                            <th style="text-align: left;">商品信息</th>
                                            <th width="8%">销售价</th>
                                            <th width="8%">数量</th>
                                            <th width="12%">金额合计</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="td_c">
                        <td style="text-align: left; white-space: inherit; word-break: break-all; line-height: 20px;">
                            <%=model.article_title%></td>
                        <td><%=model2.sale_price %></td>
                        <td><%=model.quantity %></td>
                        <td><%=model.amount %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
        </table>
      </div>
    </dd>
  </dl>
                </FooterTemplate>
            </asp:Repeater>
            <dl>
                <dt>收货信息</dt>
                <dd>
                    <div class="table-container">
                        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
                            <tr>
                                <th width="20%">收件人</th>
                                <td>
                                    <div class="position">
                                        <span id="spanAcceptName"><%=model.accept_name %></span>
                                        <input id="btnEditAcceptInfo" runat="server" visible="false" type="button" class="ibtn" value="修改" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>收货地址</th>
                                <td><span id="spanArea"><%=model.accept_address %></span> <span id="spanAddress"><%=model.accept_address %></span></td>
                            </tr>
                            <tr>
                                <th>手机</th>
                                <td><span id="spanMobile"><%=model.accept_mobile %></span></td>
                            </tr>
                        </table>
                    </div>
                </dd>
            </dl>
            <dl id="dlUserInfo" runat="server" visible="false">
                <dt>会员信息</dt>
                <dd>
                    <div class="table-container">
                        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
                            <tr>
                                <th width="20%">会员账户</th>
                                <td>
                                    <asp:Label ID="lbUserName" runat="server" /></td>
                            </tr>
                            <tr>
                                <th>会员组别</th>
                                <td>
                                    <asp:Label ID="lbUserGroup" runat="server" Text="-" /></td>
                            </tr>
                            <tr>
                                <th>账户余额</th>
                                <td>
                                    <asp:Label ID="lbUserAmount" runat="server" Text="0" />
                                    元</td>
                            </tr>
                            <tr>
                                <th>账户积分</th>
                                <td>
                                    <asp:Label ID="lbUserPoint" runat="server" Text="0" />
                                    分</td>
                            </tr>
                        </table>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>支付配送</dt>
                <dd>
                    <div class="table-container">
                        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
                            <tr>
                                <th width="20%">支付方式</th>
                                <td>账户余额</td>
                            </tr>
                            <tr>
                                <th>配送方式</th>
                                <td><%=Express(model.express_id) %></td>
                            </tr>
                            <tr>
                                <th valign="top">订单备注</th>
                                <td>
                                    <div class="position">
                                        <div id="divRemark"><%=model2.remark %>></div>
                                    </div>
                                </td>
                            </tr>
                            <%if (model.status == 2)
                              {%>
                            <tr>
                                <th>物流单号</th>
                                <td><%=model.express_no%></td>
                            </tr>
                            <tr>
                                <th style="vertical-align: top;">物流跟踪</th>
                                <td>
                                    <asp:Literal ID="litExpressDetail" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <%} %>
                        </table>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>订单统计</dt>
                <dd>
                    <div class="table-container">
                        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
                            <tr>
                                <th width="20%">商品总金额</th>
                                <td>
                                    <div class="position">
                                        <span id="spanRealAmountValue"><%=model.amount %></span> 元
              <input id="btnEditRealAmount" runat="server" visible="false" type="button" class="ibtn" value="调价" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>配送费用</th>
                                <td>
                                    <div class="position">
                                        <span id="spanExpressFeeValue"><%=model.express_fee %></span> 元
              <input id="btnEditExpressFee" runat="server" visible="false" type="button" class="ibtn" value="调价" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>订单总金额</th>
                                <td><%=Count()%> 元</td>
                            </tr>
                        </table>
                    </div>
                </dd>
            </dl>
        </div>
        <!--/内容-->


        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <input id="btnExpress" runat="server" visible="false" type="button" value="确认发货" class="btn" />
                <input id="btnComplete" runat="server" visible="false" type="button" value="完成订单" class="btn" />
                <input id="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>

