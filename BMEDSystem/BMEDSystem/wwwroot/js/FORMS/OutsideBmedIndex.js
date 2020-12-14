$.fn.addItems = function (data) {

    return this.each(function () {
        var list = this;
        $.each(data, function (val, text) {
            var option = new Option(text.text, text.value);
            console.log(option + "-" + text.text + "-" + text.value);
            list.add(option);
        });
    });

};

$(function () {
    $('#FORMSqtyDPTIDbtn').click(function () {
        var queryStr = $("#FORMSqtyDPTIDQry").val();
        var ul = $(this).data('request-url');
        $.ajax({
            url: ul,
            type: "GET",
            data: { keyname: queryStr },
            success: function (data) {
                console.log(data);
                var select = $('#FORMSqtyDPTID');
                $('option', select).remove();
                if (data.length == 0) {
                    $("#FORMSqtyDPTIDNoErrorMsg").html("查無資料!");
                }
                else if (data.length == 1) {
                    select.addItems(data);
                    $('#FORMSqtyDPTID').trigger("change");
                    $("#FORMSqtyDPTIDErrorMsg").html("");
                }

                else {
                    select.append($('<option selected="selected" disabled="disabled"></option>').text("請選擇").val(""));
                    select.addItems(data);
                    $("#FORMSqtyDPTIDErrorMsg").html("");
                     }
            }

        });
    });

    $('#FORMSqtyClsUserbtn').click(function () {
        var queryStr = $("#FORMSqtyClsUserQry").val();
        var ul = $(this).data('request-url');
        alert("有");
        $.ajax({
            url: ul,
            type: "GET",
            data: { keyname: queryStr },
            success: function (data) {
                //console.log(data);
                var select = $('#FORMSqtyClsUser');
                $('option', select).remove();
                if (data.length == 0) {
                    $("#FORMSqtyClsUserNoErrorMsg").html("查無資料!");
                }
                else if (data.length == 1) {
                    select.addItems(data);
                    $('#FORMSqtyClsUser').trigger("change");
                    $("#FORMSqtyClsUserErrorMsg").html("");
                }
                else {
                    select.append($('<option selected="selected" disabled="disabled"></option>').text("請選擇").val(""));
                    select.addItems(data);
                    $("#FORMSqtyClsUserErrorMsg").html("");
                }
            }
        });
    });


    


});
