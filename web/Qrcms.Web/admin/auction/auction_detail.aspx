<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="auction_detail.aspx.cs" Inherits="Qrcms.Web.admin.auction.auction_detail" %>


<%@ Import Namespace="Qrcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>竞拍详情</title>
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

             //初始化编辑器
             editor = KindEditor.create('.editor', {
                 width: '100%',
                 height: '350px',
                 resizeType: 1,
                 urlType: 'domain',
                 formatUploadUrl: false,
                 uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                 fileManagerJson: '../../tools/upload_ajax.ashx?action=ManagerFile',
                 allowFileManager: true
             });
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
        });

     
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="auction_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>竞拍详情</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">商品信息</a></li>
                        <li><a href="javascript:;">基本信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>商品名称</dt>
                <dd>
                    <input type="hidden" id="good_id" value="" runat="server"/>
                    <asp:TextBox ID="name" runat="server" CssClass="input normal upload-path" ReadOnly="true"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>商品图片</dt>
                <dd>
                    <asp:TextBox ID="goodimg" runat="server" CssClass="input normal upload-path" ReadOnly="true"></asp:TextBox>
                    <%--<div class="upload-box upload-img"></div>--%>
                </dd>
            </dl>
            <dl>
                <dt>内容描述</dt>
                <dd>
                    <textarea id="gooddesc" class="editor" runat="server" ></textarea>
                </dd>
            </dl>
            <dl style="display:none;">
                <dt>期数</dt>
                <dd>
                    <input type="hidden" id="count" runat="server" value="" />
                    <asp:Label ID="peroid" runat="server" />
                </dd>
            </dl>
            <dl>
                <dt>标题</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" "  ReadOnly="true"/>
                    <span class="Validform_checktip">*标题最多100个字符</span>
                </dd>
            </dl>
            <dl>
                <dt>封面图</dt>
                <dd>
                    <asp:TextBox ID="banner" runat="server" CssClass="input normal upload-path"  ReadOnly="true"></asp:TextBox>
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>
            <dl>
                <dt>是否推荐</dt>
                <dd>
                     <div class="rule-multi-checkbox">
                        <asp:CheckBoxList ID="cblItem" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1">推荐</asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </dd>
            </dl>
        </div>
        <div class="tab-content" style="display: none;">
            <dl>
                <dt>销售价</dt>
                <dd>
                    <asp:TextBox ID="saleprice" runat="server" CssClass="input normal"  datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" "  ReadOnly="true"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>浮动比例</dt>
                <dd>
                    <asp:TextBox ID="float_num" runat="server" CssClass="input normal"  datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" "  ReadOnly="true"></asp:TextBox>
                    <span class="Validform_checktip">*单位%</span>
                </dd>
            </dl>
            <dl>
                <dt>最高价</dt>
                <dd>
                    <asp:TextBox ID="highprice" runat="server" CssClass="input normal" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" "  ReadOnly="true"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>最低价</dt>
                <dd>
                    <asp:TextBox ID="lowprice" runat="server" CssClass="input normal" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" "  ReadOnly="true"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>截止时间</dt>
                <dd>
                    <asp:TextBox ID="endtime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',minDate:'%y-%M-%d %H:%m:%s'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2} \d{1,2}:\d{1,2}:\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "  ReadOnly="true"/>
                </dd>
            </dl>
            <dl>
                <dt>描述</dt>
                <dd>
                    <textarea name="remark" rows="2" cols="20" id="remark" class="input" datatype="*0-255" sucmsg=" " runat="server" ></textarea>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
      <%--  <div class="page-footer">
              <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>--%>
        <!--/工具栏-->

    </form>
</body>
</html>
