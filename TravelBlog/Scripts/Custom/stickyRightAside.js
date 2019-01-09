$(window).on('scroll', function () { stickTitleBar() });
var aside = $("#right-aside");
var sticky = aside.position().top;
function stickTitleBar() {
    if ($(window).scrollTop() >= sticky) {
        aside.addClass("sticky-aside");
    } else {
        aside.removeClass("sticky-aside");
    }
}