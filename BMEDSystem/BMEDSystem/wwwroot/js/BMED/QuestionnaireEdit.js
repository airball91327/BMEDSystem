var flowmsg = function (data) {
    var homeHref = $("#btn").data('request-url');
    $("#btnGO").attr("disabled", false);

    $.Toast.hideToast();
    if (!data.success) {
        alert(data.error);
    }
    else {
        alert("編輯成功!");

        /* window.close(), 當前非彈出視窗在最新版本的chrome和firefox裡不能關閉，而在IE中是可以關閉的 
         * 非彈出視窗，即是指（opener=null 及 非window.open()開啟的視窗,比如URL直接輸入的瀏覽器窗體， 或由其它程式呼叫產生的瀏覽器視窗）
         */
        if (window.opener === null) {
            location.replace(homeHref);
        }
        else {
            opener.location.reload();//This will call ReSubmit() function on parent window.
            //opener.location.reload();//This will refresh parent window.
            window.close();
        }
    }
}

var onFailed = function (data) {
    alert(data.responseText);
    $.Toast.hideToast();
};