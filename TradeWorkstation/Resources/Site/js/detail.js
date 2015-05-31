$(function () {
    var $big_pic_img = $(".big-pic img");
    var $mini_box_pic_img = $(".mini-box-pic>img");
    $(".mini-box-pic>img:first").addClass("img-on");
    //二货详情-图片轮播
    $mini_box_pic_img.mouseover(function () {
        $mini_box_pic_img.removeClass("img-on");
        $(this).addClass("img-on");
        $new_pic_url = $(this).attr("src");
        var pid = $new_pic_url.split("/")[5];
        $big_pic_img.attr("src", "/TradeWorkstation/PicPool/Get/ID/"+pid+"/Size/700x700");
    }).mouseleave(function () {
        var $big_pid = $big_pic_img.attr("src").split("/")[5];
        var $small_pid = $(this).attr("src").split("/")[5];
        if ($big_pid != $small_pid) {
            $(this).removeClass("img-on");
        }
    });
});