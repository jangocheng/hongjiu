mui.ajax("/tools/article_ajax.ashx?action=getArticleInfo",{
	data:{
		id:getQueryString("id")
	},
	dataType:"json",
	type:"post",
	success:function(data){
		var first="";
		var last = "";
		var html = "";
		var indicator="";
		var detailImg = "";
		if(data.status == 1){

			var data1 = data.data[0];
			if(data1.img_path){
				var oBanner = data1.img_path.split(',');
				first += '<div class="mui-slider-item mui-slider-item-duplicate"><a href="#"><img src="'+oBanner[oBanner.length-2]+'" /></a></div>';
				for(var i = 0 ; i < oBanner.length-1 ; i++ ){
					first += '<div class="mui-slider-item"><a href="#"><img src="'+oBanner[i]+'" /></a></div>';
					if(i == 0){
						indicator += '<div class="mui-indicator mui-active"></div>';
					}else{
						indicator += '<div class="mui-indicator"></div>';
					}
				}
				first += '<div class="mui-slider-item mui-slider-item-duplicate"><a href="#"><img src="'+oBanner[0]+'" /></a></div>';
				mui(".mui-slider-group")[0].innerHTML = first;
				mui(".mui-slider-indicator")[0].innerHTML = indicator;
			}
			
			//请求标题、价格、详情信息
			mui(".title p")[0].innerHTML = data1.title;
			mui(".title input[name=goods_id]")[0].value = data1.id;
			mui(".title p")[1].innerHTML = "￥"+data1.sell_price+"<span></span>"
			mui(".detail div")[0].innerHTML = data1.content;
			mui(".shop-show-header img")[0].setAttribute("src",data1.face_img);
			mui(".shop-show-header p")[0].innerHTML = data1.sub_name;
			mui("#shopno")[0].innerHTML = data1.no;
			mui(".goods-show-btn p")[0].innerHTML = "￥"+data1.sell_price;
			mui(".shop-show-header")[0].addEventListener("tap",function(){
				location.href = "shop-show.html?no="+data1.no
			})
		}
	},
	error: function(xhr, type){
		   	console.log(xhr+","+type);
	}
})


/*加载规格*/
var num = 0;

mui.ajax("/tools/article_ajax.ashx?action=getArticleSpec",{
	data:{
		id:getQueryString("id")
	},
	dataType:"json",
	type:"post",
	success:function(data){
		var html = "";
		if(data.status == "1"){
			if(data.data.length != 0){
				data.data.forEach(function(val,index){
					if(val.parent_id == 0 && index == 0){
						html += '<li><div class="mui-row">'+
			    					'<p>'+val.title+'</p>'+
			    					'<input type="hidden" value="'+val.spec_id+'" />'
    					num++;
					}else if(val.parent_id == 0){
						html += '</div></li><li><div class="mui-row">'+
			    					'<p>'+val.title+'</p>'+
			    					'<input type="hidden" value="'+val.spec_id+'" />'
    					num++;
					}else{
						html += '<a class="mui-col-sm-3 mui-col-xs-3">'+val.title+
			    				'<input type="hidden" value="'+val.spec_id+'" /></a>'
					}
				})
				mui("#menu-wrapper .mui-table-view")[0].innerHTML = html;
				selSpec(num);
			}
		}
	},
	error: function(xhr, type){
	   	console.log(xhr+","+type);
	}
})


/*商品详情页面规格表格切换*/
var busying = false;
function toggleMenu() {
	if (busying) {
		return;
	}
	busying = true;
	if (menuWrapperClassList.contains('mui-active')) {
		document.body.classList.remove('menu-open');
		menuWrapper.className = 'menu-wrapper fade-out-up animated';
		menu.className = 'menu bounce-out-up animated';
		mui(".goods_showbtn .mui-btn")[0].removeEventListener("tap",addGwc);
		mui(".goods_showbtn .mui-btn")[1].removeEventListener("tap",buy);
		mui(".goods_showbtn .mui-btn")[0].addEventListener("tap",addCart)
		mui(".goods_showbtn .mui-btn")[1].addEventListener("tap",buyNow)
		setTimeout(function() {
			backdrop.style.opacity = 0;
			menuWrapper.classList.add('hidden');
		}, 500);
	} else {
		document.body.classList.add('menu-open');
		menuWrapper.className = 'menu-wrapper fade-in-down animated mui-active';
		menu.className = 'menu bounce-in-down animated';
		backdrop.style.opacity = 1;
	}
	setTimeout(function() {
		busying = false;
	}, 500);
}

	
//初始化规格选择事件
var specid = "";
var specIdS = "";
function selSpec(num){
	var str = [];
	mui("#menu li").each(function(){
		var a = this.getElementsByTagName("a");
		for(var i = 0; i < a.length; i++ ){
			a[i].addEventListener("tap",function(){
				if(this.classList.contains("sel-active")){
					this.classList.remove("sel-active")
				}else{
					for(var j = 0; j < a.length; j++){
						a[j].classList.remove("sel-active");
						if(a[j].classList.contains("sel-active")){
							this.classList.add("sel-active");
						}else{
							this.classList.add("sel-active");
						}
					}
					if(mui("#menu a[class*=sel-active]").length == num){
						str = [];
						specid = ",";
						mui("#menu a[class*=sel-active]").each(function(i){
							str.push(this.text);
							specid += this.querySelector("input").value + ",";
						})
						specid = specid.substring(0);
						document.getElementById("menu-btn").value = str.join(",");
	                    //发送异步请求
	                    mui.ajax("/tools/article_ajax.ashx?action=getSpecInfo",{
	                    	data:{
	                    		"id": getQueryString("id"),
	                            "spec": specid
	                        },
	                    	dataType:"json",
	                    	type:"post",
	                    	success:function (data, textStatus) {
	                            if (data.status == 1) {
	                                mui(".goods-show-btn p")[0].innerHTML = "￥"+data.sell_price;
	                                specIdS = data.id
	                                //检查是否足够库存
	                                mui("#stockQuantity")[0].value = data.stock_quantity;
	                                if (parseInt(data.stock_quantity) < 1) {
	                                	mui.toast("商品该规格库存不足,请重新选择！")
	                                }
	                            } else {
	                                mui.toast(data.msg);
	                            }
	                        },
					        error: function(xhr, type){
					           	console.log(xhr+","+type);
	                        }
	                    });
					}
				}
			})
		}
	})
}
			
//加入购物车
function addGwc() {
	if(mui("#menu a[class*=sel-active]").length == num){
		if(mui("#stockQuantity")[0].value > 0){
			mui.ajax("/tools/submit_ajax.ashx?action=cart_goods_add", {
				data: {
					article_id: getQueryString("id"),
					goods_id:specIdS,
					branch_no:mui('#shopno')[0].innerHTML,
					quantity:1
				},
				dataType: "json",
				type: "post",
				success: function(data) {
		            if(data.status == 1){
		            	mui.toast(data.msg)
		            	toggleMenu();
		            }else{
		            	mui.toast(data.msg)
		            	if(data.msg.indexOf("登录") > -1){
		            		location.href = "login.html"
		            	}
		            }
				},
				error: function(xhr, type) {
					console.log(xhr + "," + type);
				}
			})
		}else{
			mui.toast("商品库存不足")
		}
	}else{
		mui.toast("请选择规格")
	}
}

//立即购买
function buy(){
	if(mui("#menu a[class*=sel-active]").length == num){
		if(mui("#stockQuantity")[0].value > 0){
			var info = [{"article_id": parseInt(getQueryString("id")), "goods_id": parseInt(specIdS), "quantity": 1,"branch_no": mui('#shopno')[0].innerHTML}]
			mui.ajax("/tools/submit_ajax.ashx?action=cart_goods_buy", {
				data: {
					jsondata:JSON.stringify(info)
				},
				dataType: "json",
				type: "post",
				success: function(data) {
		            if (data.status == 1) {
		                location.href = "confirm-order.html";
		            } else {
		                mui.toast(data.msg);
		            	if(data.msg.indexOf("登录") > -1){
		            		location.href = "login.html";
		            	}
		            }
				},
				error: function(xhr, type) {
					console.log(xhr + "," + type);
				}
			})
		}else{
			mui.toast("商品库存不足")
		}
	}else{
		mui.toast("请选择规格")
	}	
}

//加入购物车按钮
function addCart(){
	mui("#menu-wrapper .mui-btn-block")[0].removeEventListener("tap",buy)
	mui("#menu-wrapper")[0].style.bottom = "0";
	mui("#menu-wrapper .mui-btn-block")[0].style.display = "block";
	mui("#menu-wrapper .mui-btn-block")[0].addEventListener("tap",addGwc)
	toggleMenu();
}

//立即购买按钮
function buyNow(){
	mui("#menu-wrapper .mui-btn-block")[0].removeEventListener("tap",addGwc)
	mui("#menu-wrapper")[0].style.bottom = "0";
	mui("#menu-wrapper .mui-btn-block")[0].style.display = "block";
	mui("#menu-wrapper .mui-btn-block")[0].addEventListener("tap",buy)
	toggleMenu();
}