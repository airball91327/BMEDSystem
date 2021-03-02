$(function () {
    $("#AssetQryBtn").click(function () {
        //Build the new URL
        var queryStr = $("#AssetAccDptQry").val();
        //var ul = '../ FindInKey / QueryAssets';
        var ul = $(this).data('request-url');
        $.ajax({
            url: ul,
            type: "GET",
            data: { key: queryStr },
            success: function (data) {
                var select = $('#AssetNo');
                $('option', select).remove();
                if (data.length == 0) {
                    $("#AssetNoErrorMsg").html("查無資料!");
                }
                else if (data.length == 1) {
                    select.addItems(data);
                    $('#AssetNo').trigger("change");
                    $("#AssetNoErrorMsg").html("");
                }
                else {
                    select.append($('<option selected="selected" disabled="disabled"></option>').text("請選擇").val(""));
                    select.addItems(data);
                    $("#AssetNoErrorMsg").html("");
                }
            }
        });
    });

    $("#ApplyDptQryBtn").click(function () {
        //Build the new URL
        var queryStr = $("#ApplyDptQry").val();
        var ul = $(this).data('request-url');
        $.ajax({
            url: ul,
            type: "GET",
            data: { key: queryStr },
            success: function (data) {
                var select = $('#ApplyDpt');
                $('option', select).remove();
                if (data.length == 0) {
                    $("#ApplyDptErrorMsg").html("查無資料!");
                }
                else if (data.length == 1) {
                    select.addItems(data);
                    $('#ApplyDpt').trigger("change");
                    $("#ApplyDptErrorMsg").html("");
                }
                else {
                    select.append($('<option selected="selected" disabled="disabled"></option>').text("請選擇").val(""));
                    select.addItems(data);
                    $("#ApplyDptErrorMsg").html("");
                }
            }
        });
    });

    $("#EngCodeQryBtn").click(function () {
        //Build the new URL
        var queryStr = $("#EngCodeQry").val();
        var ul = $(this).data('request-url');
        $.ajax({
            url: ul,
            type: "GET",
            data: { key: queryStr },
            success: function (data) {
                var select = $('#EngCode');
                $('option', select).remove();
                if (data.length == 0) {
                    $("#EngCodeDptErrorMsg").html("查無資料!");
                }
                else if (data.length == 1) {
                    select.addItems(data);
                    $('#EngCode').trigger("change");
                    $("#EngCodeErrorMsg").html("");
                }
                else {
                    select.append($('<option selected="selected" disabled="disabled"></option>').text("請選擇").val(""));
                    select.addItems(data);
                    $("#EngCodeErrorMsg").html("");
                }
            }
        });
    });

    $("#ClsUserQryBtn").click(function () {
        //Build the new URL
        var queryStr = $("#ClsUserDptQry").val();
        var ul = $(this).data('request-url');
        $.ajax({
            url: ul,
            type: "GET",
            data: { key: queryStr },
            success: function (data) {
                var select = $('#ClsUsers');
                $('option', select).remove();
                if (data.length == 0) {
                    $("#ClsUserDptErrorMsg").html("查無資料!");
                }
                else if (data.length == 1) {
                    select.addItems(data);
                    $('#ClsUsers').trigger("change");
                    $("#ClsUserErrorMsg").html("");
                }
                else {
                    select.append($('<option selected="selected" disabled="disabled"></option>').text("請選擇").val(""));
                    select.addItems(data);
                    $("#ClsUserErrorMsg").html("");
                }
            }
        });
    });
});