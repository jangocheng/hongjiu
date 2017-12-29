mui('body').on('tap','#link_submit',function(){
			var res = /^1[34578]\d{9}$/;
			var zj =res.test($('#txtMobile').val());
			console.log(zj);
			if($('#txtMobile').val()==""){
				mui.toast('手机号码不能为空');
			}else if(zj==false){
				mui.toast('请填写正确的手机号');
			}else{
				$('#link_submit').addClass('mui-action-back');
				$link = $('#txtMobile').val();
				$('#phone').html($link);
			}
		});