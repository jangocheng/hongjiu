<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_article.aspx.cs" Inherits="Qrcms.Web.adminusers.dialog.dialog_article" %>

<%@ Import Namespace="Qrcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>商品列表</title>
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>

    <script type="text/javascript">
        var api = top.dialog.get(window);; //获取父窗体对象
        $(function () {
            //设置窗口按钮及事件
            api.button([{
                value: '确定',
                callback: function () {
                    createSpecHtml();
                },
                autofocus: true
            }, {
                value: '取消',
                callback: function () { }
            }
            ]);

            //设置规格按钮事件
            $(".spec-item li a").click(function () {
                if ($(this).parent().hasClass("selected")) {
                    $(this).parent().removeClass("selected");
                } else {
                    $(this).parent().addClass("selected");
                }
            });

            //初始化已选择的规格
            $(api.data).find("input[name='hide_spec_ids']").each(function () {
                var idsArr = $(this).val().split(",");
                for (var i = 0; i < idsArr.length; i++) {
                    $(".spec-item li").each(function () {
                        if (!$(this).hasClass("selected") && $(this).attr("id") == idsArr[i]) {
                            $(this).addClass("selected");
                        }
                    });
                }
            });
        });

        //创建规格列表
        function createSpecHtml() {

            if ($(api.data).parent().parent().find("#hide_goods_spec_list").length > 0) {
                //遍历已选择的规格

                var objt = $(".spec-item tr .checkall input[type=checkbox]:checked");
                if ($(objt).length > 1) {
                    alert("只能选择一个商品");
                    return;
                }
                if ($(objt).length == 0) {
                    alert("请选择一个商品");
                    return;
                }

                var specValueArr = new Array();
                $(".spec-item tr .checkall input[type=checkbox]:checked").each(function (i) {
                    specValueArr[i] = { 'id': $(this).parent().attr("article_id"), 'title': $(this).parent().attr("title"), 'zhaiyao': $(this).parent().attr("zhaiyao") };
                });
                //alert(specValueArr[0].id);
                //如果不选择则清空
                if (specValueArr.length == 0) {
                    //return false;
                }
                //分开组合规格
                var goodsSpecList = '';
                var articleIdList = '';
                var json;

                for (var i = 0; i < specValueArr.length; i++) {
                    json = specValueArr[i];
                    if (!json.id) {
                        json.id = '0';
                    }
                    if (!json.title) {
                        json.title = '';
                    }
                    if (!json.zhaiyao) {
                        json.zhaiyao = '';
                    }

                    goodsSpecList += '{"article_id": "' + json.id + '", "article_title": "' + json.title + '", "article_describe": "' + json.zhaiyao + '"}';
                    articleIdList += json.id;
                    if (i < specValueArr.length - 1) {
                        goodsSpecList += ',';
                        articleIdList += ',';
                    }
                };
                //赋值给父对象的隐藏域
                $(api.data).parent().parent().find("#hide_goods_spec_list").val("[" + goodsSpecList + "]");
                $(api.data).parent().parent().find("#articleid").val(articleIdList);

                var trHtml = ''; //规格总HTML

                for (var i = 0; i < specValueArr.length; i++) {
                    var json = specValueArr[i];

                    if (!json.id) {
                        json.id = '0';
                    }
                    if (!json.title) {
                        json.title = '';
                    }
                    if (!json.zhaiyao) {
                        json.zhaiyao = '';
                    }

                    trHtml += '<tr><td align="center"><input type="hidden" name="hide_goods_id" value="" />' +
                              '<input type="hidden" name="goods_article_id" value="' + json.id + '" />' +
                              '<input type="text" name="goods_article_title" class="td-input" value="' + json.title + '" />' +
                              '</td><td align="center">' +
                              '<input type="text" name="goods_article_describe" maxlength="10" class="td-input" value="' + json.zhaiyao + '" /></td>' + '<td align="center"><input type="text" name="goods_sku" maxlength="10" class="td-input" value="" /></td><td align="center"><input type="text" name="goods_price" maxlength="10" class="td-input" value="" /></td><td align="center"><input type="text" name="goods_point" maxlength="10" class="td-input" value="" /></td><td align="center"><input type="text" name="goods_notes" maxlength="10" class="td-input" value="" /></td><td align="center"><input type="text" name="goods_spec" maxlength="10" class="td-input" value="" /></td></tr>';
                }
                //$(api.data).html(trHtml);
                $(api.data).parent().parent().find("#change").click();//激活父页面方法
                api.close().remove();
                return false;
            }

            //根据商品id查询商品的详情和封面图
            //遍历已选择的规格
            var specValue = '';
            //如果不选择则清空
            var obj = $(".spec-item tr .checkall input[type=checkbox]:checked");
            if ($(obj).length > 1) {
                alert("只能选择一个商品");
                return;
            }
            if ($(obj).length == 0) {
                alert("请选择一个商品");
                return;
            }
            specValue = $(obj).parent().attr("article_id");
            $(api.data).find("#good_id").val(specValue);
            $(api.data).find("#name").val($(obj).parent().attr("title"));
            $(api.data).find("#select").click();//激活父页面方法
            api.close().remove();
            return false;
        }
       
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div style="width: 1000px; height: 580px; overflow: auto;">
            <div class="div-content">
                <ul class="spec-item">
                    <asp:Repeater ID="rptList" runat="server">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                                <tr>
                                    <th align="center">选择</th>
                                    <th align="center">商品标题</th>
                                    <th align="center">摘要</th>
                                    <th align="center">频道</th>
                                    <th align="center">分类</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" title='<%#Eval("title")%>' zhaiyao='<%#Eval("zhaiyao")%>' article_id='<%#Eval("id")%>' />
                                    <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                                </td>
                                <td align="center"><%#Eval("title")%></a></td>
                                <td align="center"><%#Eval("zhaiyao").ToString().Length>10 ? Eval("zhaiyao").ToString().Substring(0,10):Eval("zhaiyao").ToString()%></td>
                                <td align="center"><%#Eval("channel_id")%></td>
                                <td align="center"><%#Eval("category_id")%></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
</table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ul>
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
        </div>
    </form>
</body>
</html>
