$(document).ready(function () {
    $("input[name='content7']").click(function () {
       // var i7 = document.getElementById("content7");
        //if (i7.checked) {
        //    alert("have");
        //    document.getElementById("item4").checked = false;
        //    document.getElementById("item5").checked = false;
        //    document.getElementById("item6").checked = false;
        //}
        if ($("input[name='content7']").checked == true) {//如果按鈕有被選擇的話（被選擇是true）
            $("input[name='content4']").prop("checked", false);
            $("input[name='content5']").prop("checked", false);
            $("input[name='content6']").prop("checked", false);
        };
    });

    $("input[name='content4']").click(function () {
        if ($("input[name='content4']").checked == true) {//如果按鈕有被選擇的話（被選擇是true）
            $("input[name='content7']").prop("checked", false);
        };
    });

    $("input[name='content5']").click(function () {
        if ($("input[name='content5']").checked == true) {//如果按鈕有被選擇的話（被選擇是true）
            $("input[name='content7']").prop("checked", false);
        };
    });

    $("input[name='content6']").click(function () {
        if ($("input[name='content6']").checked == true) {//如果按鈕有被選擇的話（被選擇是true）
            $("input[name='content7']").prop("checked", false);
        };
    });
});