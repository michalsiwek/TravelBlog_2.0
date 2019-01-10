$(window).on('scroll', function () { stickAside() });
var aside = $("#aside-sticky");
var stickyTop = aside.position().top;
function stickAside() {
    if ($(window).scrollTop() >= stickyTop) {
        aside.addClass("sticky-aside");
    } else {
        aside.removeClass("sticky-aside");
    }
}