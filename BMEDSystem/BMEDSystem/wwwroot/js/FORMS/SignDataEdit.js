$(function () {

    $('#modal-form').on('hidden.bs.modal', function () {
        var docid = $("#DocId").val();
        $.ajax({
            url: '../../AttainFiles/List',
            type: "POST",
            data: { id: docid, typ: "OutsideBmed" },
            success: function (data) {
                $("#pnlFILES").html(data);
            }
        });
    });
});