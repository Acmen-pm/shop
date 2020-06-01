$(function () {
    var len = $("#banner img").length;
    var myul = "<ul>";
    for (var i = 0; i < len; i++) 
        myul += "<li>.</li>";
    myul += "</ul>";
    $(myul).appendTo($("#banner"));

    $("#banner img").css("opacity", 0).css("filter", 'alpha(opacity='+(0*100)+')');
    $("#banner img").eq(0).css("opacity", 0).css("filter", 'alpha(opacity=' + (1 * 100) + ')');
    $("#banner ul li").eq(0).css("color", "#333");

    var banner_time = setInterval(fun,1000);

    var banner_type = 1;    //2-上下轮播    1-左右轮播
    var banner_index = 0;   //计数器


    function banner(obj, prev) {
        $(obj).css('color', '#333');
        if (banner_type == 2) { //上下轮播
            $("#banner img").eq(prev).animate({
                opacity: '0',
                top: '150px'
            }, 1500).css('z-index', 1);

            $("#banner img").eq($(obj).index()).animate({
                opacity: '1',
                top: '0px'
            }, 1500).css('z-index', 2);
        }
        else if (banner_type == 1) {    //左右轮播
            $("#banner img").eq(prev).animate({
                opacity: '0',
                left: '-900px'
            }, 1500).css('z-index', 1);

            $("#banner img").eq($(obj).index()).animate({
                opacity: '1',
                left: '0px'
            }, 1500).css('z-index', 2);
        }
    }//自定义轮播函数结束
    function fun() {
        if (banner_index >= $("#banner ul li").size())
            banner_index = 0;   //回到0号索引，确保循环轮播
        var x = banner_index == 0 ? $("banner ul li").size() - 1 : banner_index - 1;
        banner($("#banner ul li").eq(banner_index), x);
        banner_index++;
    }
});