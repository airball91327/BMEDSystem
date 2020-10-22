function showMsgAndPrint() {
    //alert("儲存成功!");
}

var onFailed = function (data) {
    alert(data.responseText);
    $.Toast.hideToast();
};

/* When stockType is "has stock", after save the details, print the details. */
function printStockDtl() {

    //var newstr = document.getElementById(myDiv).innerHTML;
    var DocId = $("#costDocId").val();
    var SeqNo = $("#costSeqNo").val();
    var printContent = "";
    /* Get print page. */
    $.ajax({
        url: '../../RepairCost/PrintStockDetails',
        type: "GET",
        async: false,
        data: { docId: DocId, seqNo: SeqNo },
        success: function (data) {
            printContent = data;
        }
    });
    $.ajaxSettings.async = true; // Set this ajax async back to true.
    /* New a window to print. */
    var printPage = window.open();
    printPage.document.open();
    printPage.document.write("<BODY onload='window.print();window.close()'>");
    printPage.document.write(printContent);
    printPage.document.close();
}

$(function () {

    /* Default setting for the view. */
    $("#Price").attr('readonly', true);
    $("#TotalCost").attr('readonly', true);

    $('#PartName').attr("readonly", false);
    $('#Price').attr("readonly", false);
    $('#btnQtyStock').hide();
    $("#pnlSIGN").hide();
    $("#pnlACCDATE").show();
    $("#CVendor").show();
    $("#pnlTICKET").show();
    $("#pnlVENDOR").show();
    $('label[for="AccountDate"]').text("發票日期");

    //$(".datefield").datepicker({
    //    format: "yyyy/mm/dd"
    //});
    //$("#AccountDate").datepicker({format:"yyyy/mm/dd"});

    $('#modalSTOCK').on('hidden.bs.modal', function () {
        var $obj = $('input:radio[name="rblSELECT"]:checked').parents('tr').children();
        if ($obj.length > 0) {
            $("#PartNo").val($obj.get(0).innerText.trim());
            $("#PartName").val($obj.get(1).innerText.trim());
            $("#Standard").val($obj.get(2).innerText.trim());
            $("#Unite").val($obj.get(3).innerText.trim());
            $("#Price").val($obj.get(4).innerText.trim());
            var v1 = $("#Price").val();
            var v2 = $("#Qty").val();
            if (v1 !== null && v2 !== null) {
                $("#TotalCost").val(v1 * v2);
            }
            $("#VendorId").val('000');
            $("#VendorName").val($obj.get(4).innerText.trim());
        }
    });

    /* According stock type to change labels and input textboxs. */
    $('input:radio[name="StockType"]').click(function () {
        //$('#PartName').attr("readonly", false);
        $('#Price').attr("readonly", false);
        var item = $(this).val();
        if (item === "2") {             // 點選"發票"
            $('#btnQtyProduct').show();
            $('#btnQtyStock').hide();
            $("#SignNo").val('');
            $("#pnlSIGN").hide();
            $("#pnlACCDATE").show();
            $("#CVendor").show();
            $("#pnlTICKET").show();
            $("#pnlPETTY").show();
            $("#pnlVENDOR").show();
            $("#pnlTAXCLASS").show();
            $('label[for="AccountDate"]').text("發票日期");
        }
        else if (item === "3") {        // 點選"簽單"
            $('#btnQtyProduct').show();
            $('#btnQtyStock').hide();
            $("#TicketDtl_TicketDtlNo").val('');
            $("#pnlTICKET").hide();
            $("#pnlPETTY").hide();
            $('#IsPettyN').prop("checked", true);
            $("#pnlACCDATE").show();
            $("#pnlSIGN").show();
            $("#pnlTAXCLASS").hide();
            $('label[for="AccountDate"]').text("簽單日期");
            $('input:radio[name="IsPetty"]').prop("disabled", true);
        }
        else {
            $('#btnQtyStock').show();    // 點選"庫存"
            $('#btnQtyProduct').hide();
            $('#PartName').attr('readonly', true);
            //$('#Price').attr('readonly', true);
            $("#CVendor").hide();
            $("#pnlTICKET").hide();
            $("#pnlPETTY").hide();
            $('#IsPettyN').prop("checked", true);
            $("#pnlSIGN").hide();
            $("#pnlACCDATE").hide();
            $("#pnlVENDOR").hide();
            $("#pnlTAXCLASS").hide();
        }
    });
    $('input:radio[name="StockType"]').trigger('click');

    /* Auto calculate total price when input price or qty. */
    $('#Price').change(function () {
        var v1 = $(this).val();
        var v2 = $('#Qty').val();
        if (v1 !== null && v2 !== null) {
            $('#TotalCost').val(v1 * v2);
        }
    });
    $('#Qty').change(function () {
        var v1 = $(this).val();
        var v2 = $('#Price').val();
        if (v1 !== null && v2 !== null) {
            $('#TotalCost').val(v1 * v2);
        }
    });

    /* Get ticket seq. */
    $("#btnGETSEQ").click(function () {
        $.ajax({
            url: '../../Ticket/GetTicketSeq',
            type: "POST",
            async: true,
            success: function (data) {
                //console.log(data); // For Debug
                $("#TicketDtl_TicketDtlNo").val("AA" + data);
            }
        });

    });

    /* Search vendors on modal, and insert value to text field. */
    $("#modalVENDOR").on("hidden.bs.modal", function () {
        var vendorName = $("#Vno option:selected").text();
        var vendorId = $("#Vno option:selected").val();

        /* includes is not support in IE, so need to use indexOf. */
        if ($("#Vno option:selected").text() === "請選擇" || $("#Vno option:selected").text() === "查無廠商" ||
            $("#Vno option:selected").text().indexOf("請選擇廠商") !== -1) {
            $("#VendorName").val("");
            $("#VendorId").val("");
        }
        else {
            $("#VendorName").val(vendorName);
            $("#VendorId").val(vendorId);
        }
    });

    /* Get Vendors by query string. */
    $("#btnQryVendor").click(function () {
        var queryStr = $("#keyWordVendor").val();
        $.ajax({
            url: '../../Vendor/GetVendorByKeyName',
            type: "GET",
            data: { keyWord: queryStr },
            success: function (data) {
                //console.log(data);
                var select = $('#VendorId');
                $('option', select).remove();
                if (data.length === 0) {
                    $("#QryVendorErrorMsg").html("查無資料!");
                }
                else if (data.length === 1) {
                    select.addItems(data);
                    $('#VendorId').trigger("change");
                    $("#QryVendorErrorMsg").html("");
                }
                else {
                    select.append($('<option selected="selected" disabled="disabled"></option>').text("請選擇").val(""));
                    select.addItems(data);
                    $("#QryVendorErrorMsg").html("");
                }
            }
        });
    });
    $("#VendorId").change(function () {
        var vendorName = $('#VendorId option:selected').text().split("(", 1);
        $("#VendorName").val(vendorName);
    });

    /* Default settings.*/
    //$("#UniteNo").attr("disabled", "disabled");
    //$("input[type=radio][name=QryType]").change(function () {
    //    /* While select query type. */
    //    if (this.value == '關鍵字') {
    //        $("#KeyWord").removeAttr("disabled");
    //        $("#UniteNo").attr("disabled", "disabled");
    //    }
    //    else if (this.value == '統一編號') {
    //        $("#UniteNo").removeAttr("disabled");
    //        $("#KeyWord").attr("disabled", "disabled");
    //    }
    //});
    /* According TaxClass to change btnGETSEQ. */
    $('input:radio[name="TaxClass"]').click(function () {
        var item = $(this).val();
        if (item === "1") {             // 點選"收據"
            $('#btnGETSEQ').show();
        }
        else {
            $('#btnGETSEQ').hide();
        }
    });
});
