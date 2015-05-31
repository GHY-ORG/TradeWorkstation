$(function () {
    var $index_class_block = $(".index .index-pic-block");
    var $index_pic_block_h6 = $(".index .index-class-block>h6");

    $index_class_block.eq(0).show();
    $index_class_block.eq(6).show();
    $index_class_block.eq(10).show();

    $index_pic_block_h6.mouseenter(function () {
        //获取类别的class
        var $index_block = $("." + $(this).parent().parent().attr("class").split(" ")[0]);
        //获取h6的index
        var index = $(this).index();
        //index-pic-block变化
        $index_block.find(".index-pic-block").each(function () {
            $(this).hide();
        });
        $index_block.find(".index-pic-block").eq(index).show();
        //index-class-block变化
        $index_block.find(".index-class-block>h6").each(function () {
            $(this).removeClass("h6-on");
        });
        $(this).addClass("h6-on");
    });
});