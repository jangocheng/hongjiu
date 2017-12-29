<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="auction_edit.aspx.cs" Inherits="Qrcms.Web.admin.auction.auction_edit" %>

<%@ Import Namespace="Qrcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑竞猜</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>

    <script type="text/javascript">
        var editor;
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            var editorMini = KindEditor.create('.editor-mini', {
                width: '100%',
                height: '250px',
                resizeType: 1,
                urlType: 'domain',
                formatUploadUrl: false,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                items: [
                    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                    'insertunorderedlist', '|', 'emoticons', 'image', 'link']
            });

            $("#select").click(function () {
                FunCallBack();
            });


            $("#float_num").blur(function () {
                //计算最高价和最低价
                var sale = $("#saleprice").val(),
                num = $("#float_num").val();
                if (sale == '') {
                    alert("请先输入销售价");
                    return;
                }
                if (num == '') {
                    alert("请先输入浮动比例");
                    return;
                }
                num = parseFloat(sale) * parseFloat(num) * 0.01;
                $("#highprice").val(parseFloat(sale) + num);
                $("#lowprice").val(parseFloat(sale) - num);
            });
            $("#saleprice").blur(function () {
                var sale = $("#saleprice").val();
                if (sale == '') {
                    alert("请先输入销售价");
                }
            });
        });

        //初始化商品列表窗口
        function showSpecDialog(callback) {
            var d = top.dialog({
                id: 'specDialogId',
                padding: 0,
                title: "商品列表",
                url: 'dialog/dialog_article.aspx'
            }).showModal();
            //将容器对象传进去
            d.data = $(".tab-content");
            callback();
        }
        //回调
        function GetInfo() {
            $.ajax({
                type: "post",
                url: "/tools/admin_ajax.ashx?action=getGoodInfo",
                data: { "id": $("#good_id").val(), "auction_no": $("#auction_no").val() },
                dataType: "json",
                success: function (msg) {
                    if (msg.status == '0') {
                    } else {
                        $("#name").val(msg.data.title);
                        $("#goodimg").val(msg.data.img_url);
                        editor.html(msg.data.content);
                        $("#gooddesc").text(msg.data.content);
                        $("#peroid").text("第" + msg.count + "期");
                        $("#txtTitle").val("【第" + msg.count + "期】" + msg.data.title);
                        $("#count").val(msg.count);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //alert(errorThrown);
                    //alert(XMLHttpRequest);
                    //alert(textStatus);
                },
            })
        }
        //函数合并
        function FunCallBack() {
            showSpecDialog(GetInfo);
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <input type="hidden" id="auction_no" value="<%=no%>" />
        <!--导航栏-->
        <div class="location">
            <a href="auction_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>编辑竞猜</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">竞猜信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>开奖期号</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>开奖号码</dt>
                <dd>
                    <asp:TextBox ID="txtQuiz_no" runat="server" CssClass="input normal" datatype="n" sucmsg=" " />
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>开奖时间</dt>
                <dd>
                    <asp:TextBox ID="txtQuiz_date" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
                </dd>
            </dl>
        </div>

        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
