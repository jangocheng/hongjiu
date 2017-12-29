function clickSubmit(sendUrl){
	$.ajax({
		type: "POST",
		url: sendUrl,
		dataType: "json",
		timeout: 20000,
		success: function(data, textStatus) {
			if (data.status == 1){
				
//				var d = dialog({content:data.msg}).show();
				mui.toast(data.msg)
				setTimeout(function () {
					
					
				location.reload();
					
				}, 2000);
//				alert(1);
				
			} else {
				dialog({title:'提示', content:data.msg, okValue:'确定', ok:function (){}}).showModal();
			}
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			dialog({title:'提示', content:"状态：" + textStatus + "；出错提示：" + errorThrown, okValue:'确定', ok:function (){}}).showModal();
		}
	});
}