$(window).on('scroll', function() {stickTitleBar()});
var titlebar = $("#title-bar");
var sticky = titlebar.position().top;
function stickTitleBar() {
    if ($(window).scrollTop() >= sticky) {
        titlebar.addClass("sticky-title");
        $("#title-bar-sticky").css("display", "block");
    } else {
        $("#title-bar-sticky").css("display", "none");
        titlebar.removeClass("sticky-title");
    }
}