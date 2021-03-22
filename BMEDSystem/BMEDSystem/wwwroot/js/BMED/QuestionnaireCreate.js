var onFailed = function (data) {
    alert(data.responseText);
    $.Toast.hideToast();
};

function onSuccess() {
    $.Toast.hideToast();
    alert("已送出");

    var href = $("#btn").data('request-url');
    /* Print confirm before submit. */
    //var r = confirm("是否列印?");
    //if (r == true) {
    //    window.printKeepDoc(DocId);
    //}

    location.href = href;
}
