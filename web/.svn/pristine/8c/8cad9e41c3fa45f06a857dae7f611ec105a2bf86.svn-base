<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Qrcms.Web.adminusers.index" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>后台管理中心</title>
    <link href="../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery.nicescroll.js"></script>
    <script type="text/javascript" charset="utf-8" src="../scripts/artdialog/dialog-plus-min.js"></script>
    <%--<script type="text/javascript" charset="utf-8" src="js/layindex.js"></script>--%>
    <script type="text/javascript" charset="utf-8" src="js/common.js"></script>
    <script type="text/javascript">
        //页面加载完成时
        $(function () {
            //检测IE
            if ('undefined' == typeof (document.body.style.maxHeight)) {
                window.location.href = 'ie6update.html';
            }
            initMenuTree(true);
        });

        function dishow(type) {

            if (type == 1) {
                document.getElementById("zzd").className = "selected";
                document.getElementById("yyy").className = "";
                document.getElementById("hhy").className = "";
                document.getElementById("ddd").className = "";
                document.getElementById("cjo").className = "";
                document.getElementById("qhbb").className = "";
                document.getElementById("kzmbb").className = "";
                ///控制显示隐藏
                document.getElementById("zd").style.display = "block";
                document.getElementById("yy").style.display = "none";
                document.getElementById("hy").style.display = "none";
                document.getElementById("dd").style.display = "none";
                document.getElementById("cja").style.display = "none";
                document.getElementById("qhb").style.display = "none";
                document.getElementById("kzmb").style.display = "none";

            }
            if (type == 2) {

                document.getElementById("zzd").className = "";
                document.getElementById("yyy").className = "selected";
                document.getElementById("hhy").className = "";
                document.getElementById("ddd").className = "";
                document.getElementById("cjo").className = "";
                document.getElementById("qhbb").className = "";
                document.getElementById("kzmbb").className = "";
                ///控制显示隐藏
                document.getElementById("zd").style.display = "none";
                document.getElementById("yy").style.display = "block";
                document.getElementById("hy").style.display = "none";
                document.getElementById("dd").style.display = "none";
                document.getElementById("cja").style.display = "none";
                document.getElementById("qhb").style.display = "none";
                document.getElementById("kzmb").style.display = "none";
            }
            if (type == 3) {
                document.getElementById("zzd").className = "";
                document.getElementById("yyy").className = "";
                document.getElementById("hhy").className = "selected";
                document.getElementById("ddd").className = "";
                document.getElementById("cjo").className = "";
                document.getElementById("qhbb").className = "";
                document.getElementById("kzmbb").className = "";
                ///控制显示隐藏
                document.getElementById("zd").style.display = "none";
                document.getElementById("yy").style.display = "none";
                document.getElementById("hy").style.display = "block";
                document.getElementById("dd").style.display = "none";
                document.getElementById("cja").style.display = "none";
                document.getElementById("qhb").style.display = "none";
                document.getElementById("kzmb").style.display = "none";
            }
            if (type == 4) {
                document.getElementById("zzd").className = "";
                document.getElementById("yyy").className = "";
                document.getElementById("hhy").className = "";
                document.getElementById("ddd").className = "selected";
                document.getElementById("cjo").className = "";
                document.getElementById("qhbb").className = "";
                document.getElementById("kzmbb").className = "";
                ///控制显示隐藏
                document.getElementById("zd").style.display = "none";
                document.getElementById("yy").style.display = "none";
                document.getElementById("hy").style.display = "none";
                document.getElementById("dd").style.display = "block";
                document.getElementById("cja").style.display = "none";
                document.getElementById("qhb").style.display = "none";
                document.getElementById("kzmb").style.display = "none";
            }
            if (type == 5) {
                document.getElementById("zzd").className = "";
                document.getElementById("yyy").className = "";
                document.getElementById("hhy").className = "";
                document.getElementById("ddd").className = "";
                document.getElementById("cjo").className = "selected";
                document.getElementById("qhbb").className = "";
                document.getElementById("kzmbb").className = "";
                ///控制显示隐藏
                document.getElementById("zd").style.display = "none";
                document.getElementById("yy").style.display = "none";
                document.getElementById("hy").style.display = "none";
                document.getElementById("dd").style.display = "none";
                document.getElementById("cja").style.display = "block";
                document.getElementById("qhb").style.display = "none";
                document.getElementById("kzmb").style.display = "none";
            }
            if (type == 6) {

                document.getElementById("zzd").className = "";
                document.getElementById("yyy").className = "";
                document.getElementById("hhy").className = "";
                document.getElementById("ddd").className = "";
                document.getElementById("cjo").className = "";
                document.getElementById("qhbb").className = "selected";
                document.getElementById("kzmbb").className = "";
                ///控制显示隐藏
                document.getElementById("zd").style.display = "none";
                document.getElementById("yy").style.display = "none";
                document.getElementById("hy").style.display = "none";
                document.getElementById("dd").style.display = "none";
                document.getElementById("cja").style.display = "none";
                document.getElementById("qhb").style.display = "block";
                document.getElementById("kzmb").style.display = "none";
            }
            if (type == 7) {

                document.getElementById("zzd").className = "";
                document.getElementById("yyy").className = "";
                document.getElementById("hhy").className = "";
                document.getElementById("ddd").className = "";
                document.getElementById("cjo").className = "";
                document.getElementById("qhbb").className = "";
                document.getElementById("kzmbb").className = "selected";
                ///控制显示隐藏
                document.getElementById("zd").style.display = "none";
                document.getElementById("yy").style.display = "none";
                document.getElementById("hy").style.display = "none";
                document.getElementById("dd").style.display = "none";
                document.getElementById("cja").style.display = "none";
                document.getElementById("qhb").style.display = "none";
                document.getElementById("kzmb").style.display = "block";
            }

        }
        //页面加载完成时执行
        $(function () {
            //点击切换按钮
            $(".icon-menu").click(function () {
                toggleMainMenu(); //切换按钮显示事件
            });
            // loadMenuTree(true); //加载管理首页左边导航菜单
            mainPageResize(); //主页面响应式

            //页面尺寸改变时
            $(window).resize(function () {
                //延迟执行,防止多次触发
                setTimeout(function () {
                    mainPageResize(); //主页面响应式
                    popMenuTreeResize(); //快捷菜单的设置
                }, 100);
            });
        });
        //切换按钮显示事件
        function toggleMainMenu() {
            $("body").toggleClass("lay-mini");
            if (!$("body").hasClass("lay-mini") && $(window).width() > 800) {
                $("#main-nav").show();
                $(".nav-right").show();
            } else {
                $("#main-nav").hide();
                if (($(".main-top").width() - 42) < $(".nav-right").width()) {
                    $(".nav-right").hide();
                } else {
                    $(".nav-right").show();
                }
            }
        }
        //导航菜单显示和隐藏
        function mainPageResize() {
            var docWidth = $(window).width();
            if (docWidth > 800) {
                $("body").removeClass("lay-mini");
                $("#main-nav").show();
                $(".nav-right").show();
            } else {
                $("body").addClass("lay-mini");
                $("#main-nav").hide();
            }
        }
        //设置快捷菜单容器的大小
        function popMenuTreeResize() {
            //计算容器的宽度
            var groupWidth = $("#pop-menu .list-box .list-group").outerWidth();
            var divWidth = $("#pop-menu .list-box .list-group").length * groupWidth;
            var winWidth = $(window).width();
            if (divWidth > winWidth) {
                var groupCount = Math.floor(winWidth / groupWidth);
                if (groupCount > 0) {
                    groupWidth = groupWidth * groupCount;
                }
            } else {
                groupWidth = divWidth;
            }
            $("#pop-menu .pop-box").width(groupWidth);
            //只有显示的时候才能设置高度
            if ($("#pop-menu").css("display") == "block") {
                setPopMenuHeight();
            }
        }
        //设置快捷菜单的高度
        function setPopMenuHeight() {
            //计算容器的高度
            var divHeight = $(window).height() * 0.6;
            var groupHeight = 0;
            $("#pop-menu .list-box .list-group").each(function () {
                if ($(this).height() > groupHeight) {
                    groupHeight = $(this).height();
                }
            });
            if (divHeight > groupHeight) {
                divHeight = groupHeight;
            }
            $("#pop-menu .list-box .list-group").height(groupHeight);
            $("#pop-menu .pop-box").height(divHeight);
        }
        //初始化导航菜单
        function initMenuTree(islink) {
            var navObj = $("#main-nav");
            var navGroupObj = $("#sidebar-nav .list-group");
            var navItemObj = $("#sidebar-nav .list-group .list-wrap");
            //先清空NAV菜单内容
            navObj.html('');
            navGroupObj.each(function (i) {
                //添加菜单导航
                var navHtml = $('<a>' + $(this).children("h1").attr("title") + '</a>').appendTo(navObj);
                //默认选中第一项
                if (i == 0) {
                    $(this).show();
                    navHtml.addClass("selected");
                }
                //为菜单添加事件
                navHtml.click(function () {
                    navObj.children("a").removeClass("selected");
                    $(this).addClass("selected");
                    navGroupObj.hide();
                    navGroupObj.eq(navObj.children("a").index($(this))).show();
                });
                //首先隐藏所有的UL
                $(this).find("ul").hide();
                //绑定树菜单事件.开始
                $(this).find("ul").each(function (j) { //遍历所有的UL
                    //遍历UL第一层LI
                    $(this).children("li").each(function () {
                        var liObj = $(this);
                        var spanObj = liObj.children("a").children("span");
                        //判断是否有子菜单和设置距左距离
                        var parentIconLenght = liObj.parent().parent().children("a").children(".icon").length; //父节点的左距离
                        //设置左距离
                        var lastIconObj;
                        for (var n = 0; n <= parentIconLenght; n++) { //注意<=
                            lastIconObj = $('<i class="icon" style="display:none;"></i>').insertBefore(spanObj); //插入到span前面
                        }

                        //如果有下级菜单
                        if (liObj.children("ul").length > 0) {
                            liObj.children("a").removeAttr("href"); //删除链接，防止跳转
                            liObj.children("a").append('<b class="expandable close"></b>'); //最后插件一个+-
                            //如果a有自定义图标则将图标插入，否则使用默认的样式
                            if (typeof (liObj.children("a").attr("icon")) != "undefined") {
                                lastIconObj.append('<img src="' + liObj.children("a").attr("icon") + '" />')
                            } else {
                                lastIconObj.addClass("folder");
                            }
                            //隐藏下级的UL
                            liObj.children("ul").hide();
                            //绑定单击事件
                            liObj.children("a").click(function () {
                                //如果菜单已展开则闭合
                                if ($(this).children(".expandable").hasClass("open")) {
                                    //设置自身的右图标为+号
                                    $(this).children(".expandable").removeClass("open");
                                    $(this).children(".expandable").addClass("close");
                                    //隐藏自身父节点的UL子菜单
                                    $(this).parent().children("ul").slideUp(300);
                                } else {
                                    //搜索所有同级LI且有子菜单的右图标为+号及隐藏子菜单
                                    $(this).parent().siblings().each(function () {
                                        if ($(this).children("ul").length > 0) {
                                            //设置自身的右图标为+号
                                            $(this).children("a").children(".expandable").removeClass("open");
                                            $(this).children("a").children(".expandable").addClass("close");
                                            //隐藏自身子菜单
                                            $(this).children("ul").slideUp(300);
                                        }
                                    });
                                    //设置自身的右图标为-号
                                    $(this).children(".expandable").removeClass("close");
                                    $(this).children(".expandable").addClass("open");
                                    //显示自身父节点的UL子菜单
                                    $(this).parent().children("ul").slideDown(300);
                                }
                            });

                        } else {
                            //如果a有自定义图标则将图标插入，否则使用默认的样式
                            if (typeof (liObj.children("a").attr("icon")) != "undefined") {
                                lastIconObj.append('<img src="' + liObj.children("a").attr("icon") + '" />');
                            } else if (typeof (liObj.children("a").attr("href")) == "undefined" || liObj.children("a").attr("href").length < 2) { //如果没有链接
                                liObj.children("a").removeAttr("href");
                                lastIconObj.addClass("folder");
                            } else {
                                lastIconObj.addClass("file");
                            }
                            if (typeof (liObj.children("a").attr("href")) != "undefined") {
                                //绑定单击事件
                                liObj.children("a").click(function () {
                                    //删除所有的选中样式
                                    navGroupObj.find("ul li a").removeClass("selected");
                                    //删除所有的list-group选中样式
                                    navGroupObj.removeClass("selected");
                                    //删除所有的main-nav选中样式
                                    navObj.children("a").removeClass("selected");
                                    //自身添加样式
                                    $(this).addClass("selected");
                                    //设置父list-group选中样式
                                    $(this).parents(".list-group").addClass("selected");
                                    //设置父main-nav选中样式
                                    navObj.children("a").eq(navGroupObj.index($(this).parents(".list-group"))).addClass("selected");
                                    //隐藏所有的list-group
                                    navGroupObj.hide();
                                    //显示自己的父list-group
                                    $(this).parents(".list-group").show();
                                    //保存到cookie
                                    if (typeof ($(this).attr("navid")) != "undefined") {
                                        addCookie("dt_manage_navigation_cookie", $(this).attr("navid"), 240);
                                    }
                                });
                            }
                        }

                    });
                    //显示第一个UL
                    if (j == 0) {
                        $(this).show();
                        //展开第一个菜单
                        if ($(this).children("li").first().children("ul").length > 0) {
                            $(this).children("li").first().children("a").children(".expandable").removeClass("close");
                            $(this).children("li").first().children("a").children(".expandable").addClass("open");
                            $(this).children("li").first().children("ul").show();
                        }
                    }
                });
                //绑定树菜单事件.结束
            });
            //定位或跳转到相应的菜单
            linkMenuTree(islink);
        }
        //定位或跳转到相应的菜单
        function linkMenuTree(islink, navid) {
            var navObj = $("#main-nav");
            var navGroupObj = $("#sidebar-nav .list-group");
            var navItemObj = $("#sidebar-nav .list-group .list-wrap");

            //读取Cookie,如果存在该ID则定位到对应的导航
            var cookieObj;
            var argument = arguments.length;
            if (argument == 2) {
                cookieObj = navGroupObj.find('a[navid="' + navid + '"]');
            } else {
                cookieObj = navGroupObj.find('a[navid="' + getCookie("dt_manage_navigation_cookie") + '"]');
            }
            if (cookieObj.length > 0) {
                //显示所在的导航和组
                //删除所有的选中样式
                navGroupObj.find("ul li a").removeClass("selected");
                //删除所有的list-group选中样式
                navGroupObj.removeClass("selected");
                //删除所有的main-nav选中样式
                navObj.children("a").removeClass("selected");
                //自身添加样式
                cookieObj.addClass("selected");
                //设置父list-group选中样式
                cookieObj.parents(".list-group").addClass("selected");
                //设置父main-nav选中样式
                navObj.children("a").eq(navGroupObj.index(cookieObj.parents(".list-group"))).addClass("selected");
                //隐藏所有的list-group
                navGroupObj.hide();
                //显示自己的父list-group
                cookieObj.parents(".list-group").show();
                //遍历所有的LI父节点
                cookieObj.parents("li").each(function () {
                    //搜索所有同级LI且有子菜单的右图标为+号及隐藏子菜单
                    $(this).siblings().each(function () {
                        if ($(this).children("ul").length > 0) {
                            //设置自身的右图标为+号
                            $(this).children("a").children(".expandable").removeClass("open");
                            $(this).children("a").children(".expandable").addClass("close");
                            //隐藏自身子菜单
                            $(this).children("ul").hide();
                        }
                    });
                    //设置自身的右图标为-号
                    if ($(this).children("ul").length > 0) {
                        $(this).children("a").children(".expandable").removeClass("close");
                        $(this).children("a").children(".expandable").addClass("open");
                    }
                    //显示自身的UL
                    $(this).children("ul").show();
                });
                //检查是否需要保存到cookie
                if (argument == 2) {
                    addCookie("dt_manage_navigation_cookie", navid, 240);
                }
                //检查是否需要跳转链接
                if (islink == true && cookieObj.attr("href") != "" && cookieObj.attr("href") != "#") {
                    frames["mainframe"].location.href = cookieObj.attr("href");
                }
            } else if (argument == 2) {
                //删除所有的选中样式
                navGroupObj.find("ul li a").removeClass("selected");
                //保存到cookie
                addCookie("dt_manage_navigation_cookie", "", 240);
            }
        }
    </script>
</head>

<body class="indexbody">
    <form id="form1" runat="server">
        <!--全局菜单-->
        <a class="btn-paograms" onclick="togglePopMenu();"></a>
        <div id="pop-menu" class="pop-menu">
            <div class="pop-box">
                <h1 class="title"><i></i>导航菜单</h1>
                <i class="close" onclick="togglePopMenu();">关闭</i>
                <div class="list-box"></div>
            </div>
            <i class="arrow">箭头</i>
        </div>
        <!--/全局菜单-->

        <div class="main-top">
            <a class="icon-menu"></a>
            <%--<div id="main-nav" class="main-nav" style="display: none;"><a id="ddd" class="selected">订单</a></div>--%>
            <div class="nav-right">
                <div class="info">
                    <i></i>
                    <span>您好，<%=admin_info.user_name %><br>
                        <%=new Qrcms.BLL.user_groups().GetTitle(admin_info.group_id) %>
                    </span>
                </div>
                <div class="option">
                    <i></i>
                    <div class="drop-wrap">
                        <div class="arrow"></div>
                        <ul class="item">
                           <%-- <li>
                                <a href="../" target="_blank">预览网站</a>
                            </li>
                            <li>
                                <a href="center.aspx" target="mainframe">管理中心</a>
                            </li>
                            <li>
                                <a href="manager/manager_pwd.aspx" onclick="linkMenuTree(false, '');" target="mainframe">修改密码</a>
                            </li>--%>
                            <li>
                                <asp:LinkButton ID="lbtnExit" runat="server" OnClick="lbtnExit_Click">注销登录</asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="main-left">
            <h1 class="logo"></h1>
            <div id="sidebar-nav" class="sidebar-nav">
                <div class="list-group1" id="zd" style="display: none;">
                    <%--  <h1 title="站点">
                        <img src="/admin/skin/default/nav/home.png"></h1>--%>
                    <div class="list-wrap">
                        <h2>站点管理<i></i></h2>
                        <ul style="display: block;">
                            <li>
                                <a navid="channel_main" target="mainframe">
                                    <i class="icon folder"></i><span>默认站点</span>
                                    <b class="expandable open"></b></a>
                                <ul style="display: block;">
                                    <li>
                                        <a navid="channel_news" target="mainframe">
                                            <i class="icon"></i><i class="icon folder"></i><span>新闻资讯</span>
                                            <b class="expandable close"></b></a>
                                        <ul style="display: none;">
                                            <li>
                                                <a navid="channel_news_list" href="article/article_list.aspx?channel_id=6" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>内容管理</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="channel_news_category" href="article/category_list.aspx?channel_id=6" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>栏目类别</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="channel_news_comment" href="article/comment_list.aspx?channel_id=6" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>评论管理</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <a navid="channel_goods" target="mainframe">
                                            <i class="icon"></i><i class="icon folder"></i><span>购物商城</span>
                                            <b class="expandable close"></b></a>
                                        <ul style="display: none;">
                                            <li>
                                                <a navid="channel_goods_list" href="article/article_list.aspx?channel_id=7" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>内容管理</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="channel_goods_category" href="article/category_list.aspx?channel_id=7" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>栏目类别</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="channel_goods_comment" href="article/comment_list.aspx?channel_id=7" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>评论管理</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <a navid="channel_video" target="mainframe">
                                            <i class="icon"></i><i class="icon folder"></i><span>视频专区</span>
                                            <b class="expandable close"></b></a>
                                        <ul style="display: none;">
                                            <li>
                                                <a navid="channel_video_list" href="article/article_list.aspx?channel_id=8" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>内容管理</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="channel_video_category" href="article/category_list.aspx?channel_id=8" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>栏目类别</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="channel_video_comment" href="article/comment_list.aspx?channel_id=8" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>评论管理</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <a navid="channel_photo" target="mainframe">
                                            <i class="icon"></i><i class="icon folder"></i><span>图片分享</span>
                                            <b class="expandable close"></b></a>
                                        <ul style="display: none;">
                                            <li>
                                                <a navid="channel_photo_list" href="article/article_list.aspx?channel_id=9" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>内容管理</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="channel_photo_category" href="article/category_list.aspx?channel_id=9" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>栏目类别</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="channel_photo_comment" href="article/comment_list.aspx?channel_id=9" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>评论管理</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <a navid="channel_down" target="mainframe">
                                            <i class="icon"></i><i class="icon folder"></i><span>资源下载</span>
                                            <b class="expandable close"></b></a>
                                        <ul style="display: none;">
                                            <li>
                                                <a navid="channel_down_list" href="article/article_list.aspx?channel_id=10" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>内容管理</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="channel_down_category" href="article/category_list.aspx?channel_id=10" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>栏目类别</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="channel_down_comment" href="article/comment_list.aspx?channel_id=10" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>评论管理</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <a navid="channel_content" target="mainframe">
                                            <i class="icon"></i><i class="icon folder"></i><span>公司介绍</span>
                                            <b class="expandable close"></b></a>
                                        <ul style="display: none;">
                                            <li>
                                                <a navid="channel_content_list" href="article/article_list.aspx?channel_id=11" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>内容管理</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="channel_content_category" href="article/category_list.aspx?channel_id=11" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>栏目类别</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="channel_content_comment" href="article/comment_list.aspx?channel_id=11" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>评论管理</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="list-group1" id="yy" style="display: none;">
                    <%-- <h1 title="应用">
                        <img src="/admin/skin/default/nav/pus.png"></h1>--%>
                    <div class="list-wrap">
                        <h2>应用管理<i></i></h2>
                        <ul style="display: block;">
                            <li>
                                <a navid="sys_plugin_manage" target="mainframe">
                                    <i class="icon folder"></i><span>插件管理</span>
                                    <b class="expandable open"></b></a>
                                <ul style="display: block;">
                                    <li>
                                        <a navid="plugin_link" href="/plugins/link/admin/index.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>链接管理</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="plugin_feedback" href="/plugins/feedback/admin/index.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>留言管理</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a navid="sys_weixin_message" target="mainframe">
                                    <i class="icon folder"></i><span>微信管理</span>
                                    <b class="expandable close"></b></a>
                                <ul style="display: none;">
                                    <li>
                                        <a navid="weixin_base_settings" target="mainframe">
                                            <i class="icon"></i><i class="icon folder"></i><span>基本设置</span>
                                            <b class="expandable close"></b></a>
                                        <ul style="display: none;">
                                            <li>
                                                <a navid="weixin_account_manage" href="weixin/account_list.aspx" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>公众平台管理</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="weixin_custom_menu" href="weixin/menu_list.aspx" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>自定义菜单</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <a navid="weixin_message_manage" target="mainframe">
                                            <i class="icon"></i><i class="icon folder"></i><span>消息管理</span>
                                            <b class="expandable close"></b></a>
                                        <ul style="display: none;">
                                            <li>
                                                <a navid="weixin_subscribe_subscribe" href="weixin/subscribe_edit.aspx?action=subscribe" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>关注回复</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="weixin_subscribe_default" href="weixin/subscribe_edit.aspx?action=default" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>默认回复</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="weixin_response_text" href="weixin/text_list.aspx" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>文本回复</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="weixin_response_picture" href="weixin/picture_list.aspx" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>图文回复</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="weixin_response_sound" href="weixin/sound_list.aspx" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>语音回复</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a navid="weixin_response_content" href="weixin/response_list.aspx" target="mainframe">
                                                    <i class="icon"></i><i class="icon"></i><i class="icon file"></i><span>消息记录</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="list-group1 selected" id="hy" style="display: none;">
                    <h1 title="会员">
                        <img src="/admin/skin/default/nav/user.png"></h1>
                    <div class="list-wrap">
                        <h2>会员管理<i></i></h2>
                        <ul style="display: block;">
                            <li>
                                <a navid="user_manage" target="mainframe">
                                    <i class="icon folder"></i><span>会员管理</span>
                                    <b class="expandable open"></b></a>
                                <ul style="display: block;">
                                    <li>
                                        <a navid="users_xiaji" href="users/users_xiaji.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>我的下级</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="user_audit" href="users/user_audit.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>审核会员</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="user_list" href="users/user_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>所有会员</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="user_group" href="users/group_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>会员组别</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="tixian" href="users/tixian.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>提现记录</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a navid="user_log" target="mainframe">
                                    <i class="icon folder"></i><span>会员日志</span>
                                    <b class="expandable close"></b></a>
                                <ul style="display: none;">
                                    <li>
                                        <a navid="user_sms" href="users/user_sms.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>发送短信</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="user_message" href="users/message_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>站内消息</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="user_recharge_log" href="users/recharge_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>充值记录</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="user_amount_log" href="users/amount_log.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>消费记录</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="user_point_log" href="users/point_log.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>积分记录</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="user_commision_log" href="users/commision_log.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>佣金记录</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a navid="user_settings" target="mainframe">
                                    <i class="icon folder"></i><span>会员设置</span>
                                    <b class="expandable close"></b></a>
                                <ul style="display: none;">
                                    <li>
                                        <a navid="user_config" href="users/user_config.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>参数设置</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="user_oauth" href="users/oauth_app_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>OAuth设置</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="user_sms_template" href="users/sms_template_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>短信模板</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="user_mail_template" href="users/mail_template_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>邮件模板</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="list-group" id="dd" style="display: block;">
                    <h1 title="">
                        <img src="/admin/skin/default/nav/order.png"></h1>
                    <div class="list-wrap">
                        <h2>代理商管理<i></i></h2>
                        <ul style="display: block;">
                            <li>
                                <a navid="order_manage" target="mainframe">
                                    <i class="icon folder"></i><span>代理商管理</span>
                                    <b class="expandable open"></b></a>
                                <ul style="display: block;">
                                    <li>
                                        <a navid="order_yj_list" href="order/order_yj_list.aspx" target="mainframe" class="selected">
                                            <i class="icon"></i><i class="icon file"></i><span>业绩统计</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="users_xiaji" href="users/users_xiaji.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>我的下级</span>
                                        </a>
                                    </li>
<%--                                    <li>
                                        <a navid="order_confirm" href="order/order_confirm.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>待确认订单</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="order_list" href="order/order_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>全部订单</span>
                                        </a>
                                    </li>--%>
                                </ul>
                            </li>
<%--                            <li>
                                <a navid="order_settings" target="mainframe">
                                    <i class="icon folder"></i><span>订单设置</span>
                                    <b class="expandable close"></b></a>
                                <ul style="display: none;">
                                    <li>
                                        <a navid="order_config" href="order/order_config.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>订单参数设置</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="order_payment" href="order/payment_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>支付方式设置</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="order_express" href="order/express_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>配送方式设置</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>--%>
                        </ul>
                    </div>
                </div>
                <div class="list-group1" id="cja" style="display: none;">
                    <h1 title="猜奇偶"></h1>
                    <div class="list-wrap">
                        <h2>猜奇偶<i></i></h2>
                        <ul style="display: block;">
                            <li>
                                <a navid="auction_" target="mainframe">
                                    <i class="icon folder"></i><span>猜奇偶管理</span>
                                    <b class="expandable open"></b></a>
                                <ul style="display: block;">
                                    <li>
                                        <a navid="auction_list" href="auction/auction_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>猜奇偶管理</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="auction_order_list" href="auction/auction_order_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>订单列表</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="list-group1" id="qhb" style="display: none;">
                    <h1 title="抢红包"></h1>
                    <div class="list-wrap">
                        <h2>抢红包<i></i></h2>
                        <ul style="display: block;">
                            <li>
                                <a navid="Redpacket_" target="mainframe">
                                    <i class="icon folder"></i><span>抢红包管理</span>
                                    <b class="expandable open"></b></a>
                                <ul style="display: block;">
                                    <li>
                                        <a navid="Redpacket_order_list" href="Redpacket/Redpacket_order_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>订单列表</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="list-group1" id="kzmb" style="display: none;">
                    <%--<h1 title="控制面板">
                        <img src="/admin/skin/default/nav/sys.png"></h1>--%>
                    <div class="list-wrap">
                        <h2>控制面板<i></i></h2>
                        <ul style="display: block;">
                            <li>
                                <a navid="sys_settings" target="mainframe">
                                    <i class="icon folder"></i><span>系统管理</span>
                                    <b class="expandable open"></b></a>
                                <ul style="display: block;">
                                    <li>
                                        <a navid="sys_config" href="settings/sys_config.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>系统设置</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="sys_plugin_config" href="settings/plugin_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>插件设置</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="sys_url_rewrite" href="settings/url_rewrite_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>URL配置</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="advert_list" href="advert/advert_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>广告管理</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a navid="sys_site_settings" target="mainframe">
                                    <i class="icon folder"></i><span>站点设置</span>
                                    <b class="expandable close"></b></a>
                                <ul style="display: none;">
                                    <li>
                                        <a navid="sys_site_manage" href="channel/site_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>站点管理</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="sys_channel_manage" href="channel/channel_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>频道管理</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="sys_channel_field" href="channel/attribute_field_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>扩展字段</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="sys_goods_spec" href="channel/spec_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>商品规格</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="sys_article_tags" href="channel/tags_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>Tags标签</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a navid="sys_design" target="mainframe">
                                    <i class="icon folder"></i><span>界面管理</span>
                                    <b class="expandable close"></b></a>
                                <ul style="display: none;">
                                    <li>
                                        <a navid="sys_site_templet" href="settings/templet_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>站点模板管理</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="sys_builder_html" href="settings/builder_html.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>生成静态管理</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="sys_navigation" href="settings/nav_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>后台导航管理</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a navid="sys_manager" target="mainframe">
                                    <i class="icon folder"></i><span>系统用户</span>
                                    <b class="expandable close"></b></a>
                                <ul style="display: none;">
                                    <li>
                                        <a navid="manager_list" href="manager/manager_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>管理员管理</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="manager_role" href="manager/role_list.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>角色管理</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a navid="manager_log" href="manager/manager_log.aspx" target="mainframe">
                                            <i class="icon"></i><i class="icon file"></i><span>管理日志</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="main-container">
            <iframe id="mainframe" name="mainframe" frameborder="0" src="center.aspx"></iframe>
        </div>

    </form>
</body>
</html>
<script type="text/javascript">
    document.getElementById("main-nav").style.display = "none";
</script>
