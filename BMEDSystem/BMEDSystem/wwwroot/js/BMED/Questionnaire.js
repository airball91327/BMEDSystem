var onFailed = function (data) {
    alert(data.responseText);
    $.Toast.hideToast();
};

function onSuccess() {
    $.Toast.hideToast();
    alert("建立成功");
    var url = $("#btn").data('request-url');
    /* Print confirm before submit. */
    //var r = confirm("是否列印?");
    //if (r == true) {
    //    window.printKeepDoc(DocId);
    //}

    location.href = url;
}

function onSuccessD() {
    $.Toast.hideToast();
    alert("刪除成功");
    var url = $("#btn").data('request-url');
    /* Print confirm before submit. */
    //var r = confirm("是否列印?");
    //if (r == true) {
    //    window.printKeepDoc(DocId);
    //}

    location.href = url;
}

 var onSuccessC = function(data) {
    
    var url = $("#btn").data('request-url');
    /* Print confirm before submit. */
    //var r = confirm("是否列印?");
    //if (r == true) {
    //    window.printKeepDoc(DocId);
    //}
    if (!data.success) {
        $.Toast.hideToast();
        alert(data.error);
    }
    else {
        $.Toast.hideToast();
        alert("新增成功");
        location.href = url;
    }
    
}