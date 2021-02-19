//設定中文語系
$.datepicker.regional['zh-TW'] = {
    dayNames: ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"],
    dayNamesMin: ["日", "一", "二", "三", "四", "五", "六"],
    monthNames: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
    monthNamesShort: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
    prevText: "上月",
    nextText: "次月",
    weekHeader: "週"
};
//將預設語系設定為中文
$.datepicker.setDefaults($.datepicker.regional["zh-TW"]);

$(document).ready(function () {
    $('#datepicker1').datepicker({
        dateFormat: 'yy/mm/dd',
        changeMonth: true,
        changeYear: true,
        yearRange: "1980:2030",
        //在年份後顯示文字
        yearSuffix: "年",
        shortYearCutoff: "+10",
        beforeShow: function () {
            setTimeout(
                function () {
                    $('#ui-datepicker-div').css("z-index", 21);
                },
                100);
        }
    });
    $('#datepicker2').datepicker({
        dateFormat: 'yy/mm/dd',
        changeMonth: true,
        changeYear: true,
        yearRange: "1980:2030",
        //在年份後顯示文字
        yearSuffix: "年",
        shortYearCutoff: "+10",
        beforeShow: function () {
            setTimeout(
                function () {
                    $('#ui-datepicker-div').css("z-index", 21);
                },
                100);
        }
    });
});