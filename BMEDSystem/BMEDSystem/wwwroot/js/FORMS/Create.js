//$("input[name='Application']").trigger('click');

$("input[name='Application']").click(function () {
    var s = $("input[name='Application']:checked").val();
    if (s === "患者自帶") {
        $("#PatientBring").hide();
        document.getElementById("Vendor").required = false;
        document.getElementById("Phone").required = false;
        document.getElementById("Personnel").required = false;
        $("#ClinicalTrials").hide();
        document.getElementById("ProjectId").required = false;
        document.getElementById("IRB_NO").required = false;
        document.getElementById("TrialHost").required = false;


    } else if (s === "臨床試驗") {
        $("#PatientBring").show();
        document.getElementById("Vendor").required = true;
        document.getElementById("Phone").required = true;
        document.getElementById("Personnel").required = true;
        $("#ClinicalTrials").show();
        document.getElementById("ProjectId").required = true;
        document.getElementById("IRB_NO").required = true;
        document.getElementById("TrialHost").required = true;
    } else {
        $("#ClinicalTrials").hide();
        document.getElementById("ProjectId").required = false;
        document.getElementById("IRB_NO").required = false;
        document.getElementById("TrialHost").required = false;
        $("#PatientBring").show();
        document.getElementById("Vendor").required = true;
        document.getElementById("Phone").required = true;
        document.getElementById("Personnel").required = true;
    }
    if (s === "患者自帶") {
        $("#ContentFile").hide();
        document.getElementById("Content").required = false;
    } else {
        $("#ContentFile").show();
        document.getElementById("Content").required = true;
    }
});


function Days() {
    var t = $("#UseDayFrom").val();
    var s = $("#UseDayTo").val();

    $.ajax({
        url: '../OutsideBmed/GetDay',
        type: "POST",
        data: { UseDayFrom: t, UseDayTo: s },
        dataType: "json",
        async: false,
        cache: false,
        success: function (data) {
            $("#Day").val(data);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
};








$("input[name='Content']").click(function () {
    var c = $("input[name='Content']:checked").val();
    if (c === "經衛生福利部醫療器材許可證") {
        $("#license").show();
        $("#Consent").hide();
    } else if (c === "貨品進口同意書") {
        $("#Consent").show();
        $("#license").hide();
    }
});

$('#modalFILES').on('hidden.bs.modal', function () {
    var docid = $("#DocId").val();
    $.ajax({
        url: '../AttainFiles/List',
        type: "POST",
        data: { docid: docid, typ: "6" },
        success: function (data) {
            $("#pnlFILES").html(data);
        }
    });
});
