/* 
*作者：一些事情
*时间：2017-6-26
*购物车方法*需要结合mui一起使用
----------------------------------------------------------*/

//添加进购物车
function cartAdd(obj, webpath, linktype, linkurl){
	//alert(linkurl);
	var articleId = parseInt($("#commodityArticleId").val());
	var goodsId = parseInt($("#commodityGoodsId").val());
	var selectNum = parseInt($("#commoditySelectNum").val());
	if($(obj).prop("disabled") == true){
		return false;
	}
	//检查文章ID
	if(isNaN(articleId)){
		alert("商品参数不正确！");
		return false;
	}
	//检查商品是否有规格
	if(goodsId == 0 && $("#goodsSpecBox dl").length > 0){
		alert("请先选择商品规格！");
		return false;
	}
	//检查购买数量
	if(isNaN(selectNum) || selectNum == 0){
		alert("购买数量不能为零！");
		return false;
	}
	//检查库存数量
	if(parseInt(selectNum) > parseInt($("#commodityStockNum").text())){
		alert("购买数量大于库存数量，库存不足！");
		return false;
	}
	//记住按钮文字
	var buttonText = $(obj).text();
	//如果是立即购买
	if(linktype == 1){
		var jsondata = '[{"article_id":'+articleId+', "goods_id":'+goodsId+', "quantity":'+selectNum+'}]'; //结合商品参数
		$.ajax({
			type: "post",
			url: webpath + "tools/submit_ajax.ashx?action=cart_goods_buy",
			data: { "jsondata": jsondata },
			dataType: "json",
			beforeSend: function(XMLHttpRequest) {
				//发送前动作
				$(obj).prop("disabled",true).text("请稍候...");
			},
			success: function(data, textStatus) {
				if (data.status == 1) {
					alert('购买成功');
					
						location.href = linkurl;
					
					
				}else{
					alert("尝试加入购物清单失败，请重试！");
				}
			},
			error: function (XMLHttpRequest, textStatus, errorThrown) {
				alert("状态：" + textStatus + "；出错提示：" + errorThrown);
			},
			complete: function (XMLHttpRequest, textStatus) {
				$(obj).prop("disabled",false).text(buttonText);
			},
			timeout: 20000
		});
		return false;
	}else{
		$.ajax({
			type: "post",
			url: webpath + "tools/submit_ajax.ashx?action=cart_goods_add",
			data: {
				"article_id" : articleId,
				"goods_id" : goodsId,
				"quantity" : selectNum
			},
			dataType: "json",
			beforeSend: function(XMLHttpRequest) {
				//发送前动作
				$(obj).prop("disabled",true).text("请稍候...");
			},
			success: function(data, textStatus) {
				if (data.status == 1) {
					$("#cartInfoHint").remove();
					var HintHtml = '<div id="cartInfoHint" class="msg-tips cart-info">'
						+ '<div class="ico"></div>'
						+ '<div class="msg">'
						+ '<strong>商品已成功添加到购物车！</strong>'
						+ '<p>购物车共有<b>' + data.quantity + '</b>件商品，合计：<b class="red">' + data.amount + '</b>元</p>'
						+ '<a class="btn btn-success" title="去购物车结算" href="' + linkurl + '">去结算</a>&nbsp;&nbsp;'
						+ '<a title="再逛逛" href="javascript:;" onclick="hintRemove(\'#cartInfoHint\');">再逛逛</a>'
						+ '<i class="close" title="关闭" onclick="hintRemove(\'#cartInfoHint\');"><span>关闭</span></i>'
						+ '</div>'
						+ '</div>'
					$(obj).after(HintHtml); //添加节点
					$("#shoppingCartCount").text(data.quantity); //赋值给显示购物车数量的元素
				} else {
					$("#cartInfoHint").remove();
					var HintHtml = '<div id="cartInfoHint" class="msg-tips cart-info">'
						+ '<div class="ico error"></div>'
						+ '<div class="msg">'
						+ '<strong>商品添加到购物车失败！</strong>'
						+ '<p>' + data.msg + '</p>'
						+ '<i class="close" title="关闭" onclick="hintRemove(\'#cartInfoHint\');"><span>关闭</span></i>'
						+ '</div>'
						+ '</div>'
					$(obj).after(HintHtml); //添加节点
				}
			},
			error: function (XMLHttpRequest, textStatus, errorThrown) {
				alert("状态：" + textStatus + "；出错提示：" + errorThrown);
			},
			complete: function (XMLHttpRequest, textStatus) {
				$(obj).prop("disabled",false).text(buttonText);
			},
			timeout: 20000
		});
		return false;
	}
}

//修改购物车数量
function updateCart(obj) {
    var objInput;
    var goodsQuantity; //购买数量
    var stockQuantity = parseInt(obj.parentNode.parentNode.querySelector("input[name='hideStockQuantity']").value); //库存数量
    var articleId = obj.parentNode.parentNode.querySelector("input[name='hideArticleId']").value; //文章ID
    var goodsId = obj.parentNode.parentNode.querySelector("input[name='hideGoodsId']").value; //商品ID
    var goodsPrice = obj.parentNode.parentNode.querySelector("input[name='hideGoodsPrice']").value; //商品单价
    
        objInput = obj.parentNode.parentNode.querySelector("input[name='GoodsNumber']");
		goodsQuantity = parseInt(objInput.value);
        
    if (isNaN(goodsQuantity)) {
        mui.toast('商品数量只能输入数字!');
        return false;
    }
    if (isNaN(stockQuantity)) {
        mui.toast('检测不到商品库存数量!');
        return false;
    }
    if (goodsQuantity < 1) {
        objInput.value = 1;
    }
    if (goodsQuantity > stockQuantity) {
        mui.toast('购买数量不能大于库存数量!');
        objInput.value = stockQuantity;
    }
    mui.ajax("/tools/submit_ajax.ashx?action=cart_goods_update",{
    	data:{
            "article_id": articleId,
            "goods_id": goodsId,
            "quantity": goodsQuantity
    	},
    	dataType:"json",
    	type:"post",
    	success:function (data, textStatus) {
            if (data.status != 1) {
                mui.toast(data.msg);
            }
       	},
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            mui.toast("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
    return false;
}

//删除购物车商品
function deleteGoods(goodsdata){
	mui('.shopping-list').on('tap', '.mui-btn-red', function(event) {
	    var datastr;
		var elem = this;
		var inp = elem.parentNode.nextElementSibling.firstElementChild.getAttribute("sel");
		var deleteNum = inp.substring(inp.length-1,inp.length);
		var li = elem.parentNode.parentNode;
		var div = elem.parentNode.parentNode.parentNode.parentNode;
		var btnArray = ['确认', '取消'];
		mui.confirm('确认删除该条记录？', '购物车', btnArray, function(e) {
			if (e.index == 0) {
			    //组合参数
		        var articleId = elem.parentNode.nextElementSibling.querySelector("input[name='hideArticleId']").value;
		        var goodsId = elem.parentNode.nextElementSibling.querySelector("input[name='hideGoodsId']").value;
		        datastr = { "article_id": articleId, "goods_id": goodsId }
				if(li.previousElementSibling == null && li.nextElementSibling == null){
					div.parentNode.removeChild(div);
					goodsdata.removevalue("goods"+deleteNum);
					goodsdata.removevalue("selall"+deleteNum);
				}else{
					li.parentNode.removeChild(li);
				}
			    mui.ajax("/tools/submit_ajax.ashx?action=cart_goods_delete",{
			        type: "post",
			        data: datastr,
			        dataType: "json",
			        timeout: 20000,
			        success: function (data, textStatus) {
			            if (data.status == 1) {
			                cartAmountTotal(); //重新统计
			                mui.toast(data.msg);
			            } else {
			                mui.toast(data.msg);
			            }
			        },
			        error: function (XMLHttpRequest, textStatus, errorThrown) {
			            mui.toast("状态：" + textStatus + "；出错提示：" + errorThrown);
			        }
			    });
    			selEventMain(goodsdata)
			} else {
				setTimeout(function() {
					mui.swipeoutClose(li);
				}, 0);
			}
		});
	});
}

//选择商品
function selEventMain(array){
	var chknum2=0;
	var chknum1=0;
	var checkBox = mui("input[type=checkbox]");
	checkBox.each(function(){
		this.checked = false;
		this.removeEventListener("change",arguments.callee)
	})
	mui(".shopping-cart").off("change","input[name=selall]")
	function selEvent(all,goods){
		var chkall=document.getElementById(all);
        chkall.addEventListener("change",function(){ 
            if(this.checked){ 
                mui("input[sel='"+ goods +"']").each(function(){
                    this.checked=true;
					chknum = cbknum;
                });
                	chknum2 += chknum;
                if( chknum2 > cbknum2 ){
                	chknum2 = cbknum2
                }
            }else{ 
                mui("input[sel='"+ goods +"']").each(function(){ 
                        this.checked=false; 
 						chknum = 0;
                    });
                    chknum2 -=  cbknum;
               	}
                cartAmountTotal();
			},false)
 
            var cbknum=mui("input[sel='"+ goods +"']").length;
        var chknum= 0; 
        mui(".shopping-cart").on("change","input[sel='"+ goods +"']",function(){
            if(this.checked) 
            {
                chknum++;
            }else{ 
                chknum--; 
            } 
            if(cbknum==chknum){ 
                chkall.checked=true;
                chknum1++;
            }else{
            	if(chkall.checked == true){
            		chknum1--;
            	}
                chkall.checked=false;
            }
            cartAmountTotal();
        }); 
        
		var chkall1=document.getElementById("selAll");
        chkall1.addEventListener("change",function(){ 
            if(this.checked){ 
                chknum = cbknum;
            }else{ 
                chknum = 0;
           	}
            cartAmountTotal();
		},false)
	}
    
	var chkall1=document.getElementById("selAll");
    chkall1.addEventListener("change",function(){ 
        if(this.checked){ 
            mui(".shopping-cart input[type=checkbox]").each(function(){ 
                this.checked=true; 
            });
            chknum2 = cbknum2;
            chknum1 = cbknum1;
        }else{ 
            mui(".shopping-cart input[type=checkbox]").each(function(){ 
                        this.checked=false;
                    });
                    chknum2 = 0;
                    chknum1 = 0;
               	}
	            cartAmountTotal();
			},false)
 
    var cbknum1=mui(".shopping-cart input[name=selall]").length;
    mui(".shopping-cart").on("change","input[name=selall]",function(){
                if(this.checked) 
                { 
                    chknum1++;
                    if( chknum1 > cbknum1){
                    	chknum1 = cbknum1
                    }
                }else{ 
                    chknum1--;
                }
                if(cbknum1==chknum1){ 
                    chkall1.checked=true; 
                }else{
                    chkall1.checked=false; 
                }
                cartAmountTotal();
            });
 
    var cbknum2=mui(".shopping-cart input[sel*=goods]").length;
    mui(".shopping-cart").on("change","input[sel*=goods]",function(){
        if(this.checked) 
        { 
            chknum2++; 
        }else{ 
            chknum2--;
        }
        if(cbknum2==chknum2){
            chkall1.checked=true; 
        }else{ 
            chkall1.checked=false; 
        } 
        cartAmountTotal();
    });
    for(var i = 0;i < array.length; i += 2){
    	selEvent(array[i],array[i+1])
    }
}

//计算购物车金额
function cartAmountTotal() {
    var jsondata = ""; //商品组合参数
    var totalAmount = 0; //商品总计
    var totalNumber = 0; //商品总数统计
    mui(".shopping-cart input[sel*=goods]:checked").each(function (i) {
        var articleId = this.parentNode.querySelector("input[name='hideArticleId']").value; //文章ID
        var goodsId = this.parentNode.querySelector("input[name='hideGoodsId']").value; //商品ID
        var goodsPrice = this.parentNode.querySelector("input[name='hideGoodsPrice']").value; //商品单价
        var goodsQuantity = this.parentNode.querySelector("input[name='GoodsNumber']").value; //购买数量
        var branchNo = this.parentNode.parentNode.parentNode.parentNode.querySelector("input[name='branch_no']").value;
        totalAmount += parseFloat(goodsPrice) * parseFloat(goodsQuantity);
        totalNumber += parseFloat(goodsQuantity);
        jsondata += '{"article_id":"' + articleId + '", "goods_id":"' + goodsId + '", "branch_no":"'+branchNo+'", "quantity":"'+goodsQuantity+'"}';
        if (i < mui(".shopping-cart input[sel*=goods]:checked").length - 1) {
            jsondata += ',';
        }
    });
    mui("#totalQuantity")[0] ? mui("#totalQuantity")[0].innerHTML = totalNumber:"";
    mui("#totalAmount")[0].innerHTML = totalAmount.toFixed(2);
    if (jsondata.length > 0) {
        jsondata = '[' + jsondata + ']';
    }
    mui("#jsondata")[0].value = jsondata;
}

//进入结算中心
function formSubmit(obj) {
    var jsondata = mui("#jsondata")[0].value;
    var that = obj;
    if (jsondata == "") {
        mui.toast("未选中要购买的商品，请选中后提交！");
        return false;
    }
    //记住按钮文字
    var buttonText = that.innerHTML;
    //加入购物清单
   	var url = "/tools/submit_ajax.ashx?action=cart_goods_buy";
    mui.ajax(url,{
    	data:{
    		"jsondata": jsondata
    	},
    	dataType:"json",
    	type:"post",
    	success:function(data){
            if (data.status == 1) {
            	mui.toast(data.msg)
                location.href = "confirm-order.html";
            } else {
            	that.disabled = false;
            	that.innerHTML = buttonText;
                mui.toast(data.msg);
            }
    	},
    	error:function(a,b,c){
    		console.log(a+","+b+","+c)
    	}
    });
    return false;
}

/*初始化收货地址*/
function initUserAddress(obj) {
}

