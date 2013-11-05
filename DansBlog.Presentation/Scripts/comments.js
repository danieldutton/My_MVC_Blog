$(document).ready(function () {
    $(".fetch-comments").click(function (e) {
        //for testing
        //var v = $(this).parent().siblings().eq(3).attr("id");
        //alert(v);
        $(this).parent().siblings().eq(3).removeClass();
        $(this).parent().siblings().eq(3).removeClass("show");
        e.preventDefault();
    });
    
    $('.hide-comments').click(function (e) {
        ($(this).parent().parent().removeClass());
        ($(this).parent().parent().addClass("hide"));

        e.preventDefault();
    });
});
