$(document).ready(function () {
    $("input[name='content7']").click(function () {
        if (document.getElementById("content7").checked == true) {//如果按鈕有被選擇的話（被選擇是true）
            $("input[name='content4']").prop("checked", false);
            $("input[name='content5']").prop("checked", false);
            $("input[name='content6']").prop("checked", false);
        };
    });

    $("input[name='content4']").click(function () {
        if (document.getElementById("content4").checked == true) {//如果按鈕有被選擇的話（被選擇是true）
            $("input[name='content7']").prop("checked", false);
        };
    });

    $("input[name='content5']").click(function () {
        if (document.getElementById("content5").checked == true) {//如果按鈕有被選擇的話（被選擇是true）
            $("input[name='content7']").prop("checked", false);
        };
    });

    $("input[name='content6']").click(function () {
        if (document.getElementById("content6").checked == true) {//如果按鈕有被選擇的話（被選擇是true）
            $("input[name='content7']").prop("checked", false);
        };
    });
});