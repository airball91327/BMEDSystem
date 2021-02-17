$.fn.addItems = function (data) {

    return this.each(function () {
        var list = this;
        $.each(data, function (val, text) {

            var option = new Option(text.text, text.value);
            list.add(option);
        });
    });

};

/* Get UseUnit by UseUnitQry string. */
$("#UseUnitQryBtn").click(function () {
    var queryStr = $("#UseUnitQry").val();
    var ul = $(this).data('request-url');
    $.ajax({
        url: ul, 
        type: "GET",
        data: { keyname: queryStr},
        success: function (data) {
            //console.log(data);
            var select = $('#UseUnit');
            $('option', select).remove();
            if (data.length == 0) {
                $("#UseUnitNoErrorMsg").html("查無資料!");
            }
            else if (data.length == 1) {
                select.addItems(data);
                $('#UseUnit').trigger("change");
                $("#UseUnitNoErrorMsg").html("");
            }
            else {
                select.append($('<option selected="selected" disabled="disabled"></option>').text("請選擇").val(""));
                select.addItems(data);
                $("#UseUnitNoErrorMsg").html("");
            }
        }
    });
});


$('#ToUserIdQryBtn').click(function () {
    var UserNameStr = $("#ToUserIdQry").val();
    $.ajax({
        url: '../UseUnitFind/GetToNameByKeyname',
        type: "GET",
        data: { keyname: UserNameStr },
        success: function (data) {
            //console.log(data);
            var select = $('#ToUserId');
            $('option', select).remove();
            if (data.length == 0) {
                $("#ToUserIdNoErrorMsg").html("查無資料!");
            }
            else if (data.length == 1) {
                select.addItems(data);
                $('#ToUserId').trigger("change");
                $("#ToUserIdNoErrorMsg").html("");
            }
            else {
                select.append($('<option selected="selected" disabled="disabled"></option>').text("請選擇").val(""));
                select.addItems(data);
                $("#ToUserIdNoErrorMsg").html("");
            }
        }
    });
});



