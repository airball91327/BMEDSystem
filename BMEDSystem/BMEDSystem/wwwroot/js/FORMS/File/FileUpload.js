﻿$(function () {
    $("#DocType").prop('readonly', true);
    $("#DocId").prop('readonly', true);

    $("#btnUPLOAD").click(function () {
        uploadFiles();
    });

    $("#btnUpload").click(function () {
        uploadFile();
    });
});

function uploadFiles() {

    var files = document.getElementById("Files");
    var formData = new FormData();

    //for (var i = 0; i <= files.length; i++) {
    //    formData.append("files", files.files[i]);
    //}

    formData.append("files", files.files[0]);

    formData.append("SeqNo", $("#SeqNo").val());
    formData.append("IsPublic", $("#IsPublic").val());
    formData.append("DocType", $("#DocType").val());
    formData.append("DocId", $("#DocId").val());
    formData.append("Title", $("#Title").val());
    formData.append("FileLink", $("#FileLink").val());

    $.ajax(
        {
            url: '../AttainFiles/Upload',
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            success: function (response) {
                console.log(response);
                if (!response.success) {
                    alert(response.error);
                }
                else
                    alert('上傳成功');
            },
            error: function (data) {
                var msg = JSON.parse(data.responseText);
                alert(msg.Error);
            }
        }
    );
}

    function uploadFile() {

        var files = document.getElementById("Files");
        var formData = new FormData();

        //for (var i = 0; i <= files.length; i++) {
        //    formData.append("files", files.files[i]);
        //}

        formData.append("files", files.files[0]);

        formData.append("SeqNo", $("#SeqNo").val());
        formData.append("IsPublic", $("#IsPublic").val());
        formData.append("DocType", $("#DocType").val());
        formData.append("DocId", $("#DocId").val());
        formData.append("Title", $("#Title").val());
        formData.append("FileLink", $("#FileLink").val());

        $.ajax(
            {
                url: '../../AttainFiles/Upload',
                data: formData,
                processData: false,
                contentType: false,
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (!response.success) {
                        alert('檔案上傳有誤，請檢查欄位是否填寫齊全!');
                    }
                    else
                        alert('上傳成功');
                },
                error: function (data) {
                    var msg = JSON.parse(data.responseText);
                    alert(msg.Error);
                }
            }
        );
}


