var onFailed = function (data) {
    alert(data.responseText);
    $.Toast.hideToast();
};