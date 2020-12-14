function OnSuccess(data) {
    if (!data.success)
        alert(data.error);
    else {
        alert("[轉給自己] 成功!");
        location.replace("../../Home/Index");
    }
}