$.fn.addItems = function (data) {

    return this.each(function () {
        var list = this;
        $.each(data, function (val, text) {

            var option = new Option(text.text, text.value);
            list.add(option);
        });
    });

};

$(function () {

    if ($('#Cls').val() === "申請人") {
        $('#pnlUPDATE').show();
    }

    $('#ClsNowQry').hide(); 
    $('#ClsNowQryBtn').hide(); 

    function useunitFind() {
        var queryStr = $("#FlowCls").val();
        var docid = $("#DocId").val();
        var tls = $("#ClsNowQry").val();
        $.ajax({
            url: '../../UseUnitFind/GetToClsByKeyname',
            type: "GET",
            data: { keyname: queryStr, docid: docid, tle: tls },
            success: function (data) {
                //console.log(data);
                var select = $('#ClsNow');
                $('option', select).remove();
                if (data.length == 0) {
                    $("ClsNowNoErrorMsg").html("查無資料!");
                }
                else if (data.length == 1) {
                    select.addItems(data);
                    $('#ClsNow').trigger("change");
                    $("#ClsNowErrorMsg").html("");
                }
                else {
                    select.append($('<option selected="selected" disabled="disabled"></option>').text("請選擇").val(""));
                    select.addItems(data);
                    $("#ClsNowErrorMsg").html("");
                }
            }
        });
    };

    $('#FlowCls').change(function () {

        var queryStr = $("#FlowCls").val();

        var select = $('#ClsNow');
        $('option', select).remove();
        select.append($('<option selected="selected" disabled="disabled"></option>').text("請選擇").val(""));
        select.addItems("");

        if (queryStr == "醫工工程師" || queryStr == "單位主管") {
            $('#ClsNowQry').show();
            $('#ClsNowQryBtn').show();
        }

        //alert(queryStr + '-' + docid);
        //var tle = $("#Title").val();
        else {
            $('#ClsNowQry').hide();
            $('#ClsNowQryBtn').hide(); 
            useunitFind();
        }
    });

    $('#ClsNowQryBtn').click(function () {
        useunitFind();
    });


    /* Update checker. */
    $("#UpdCheckerBtn").click(function () {
        var updChecker = $("#UpdChecker").val();
        var docId = $("#DocId").val();
        $('#imgLOADING_CHK').show();
        $.ajax({
            url: '../../Repair/UpdateChecker',
            type: "POST",
            data: { DocId: docId, UpdChecker: updChecker },
            error: onFailed,
            success: function (data) {
                alert("修改成功!");
                $.Toast.showToast({
                    'title': '頁面重整中，請稍待...',
                    'icon': 'loading',
                    'duration': 0
                });
                window.location.reload();
            }
        });
    });

   
});
