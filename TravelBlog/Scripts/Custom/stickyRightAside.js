$(window).on('scroll', function () { stickAside() });

var aside = $("#aside-sticky");
var stickyTop = aside.offset().top;

function stickAside() {
    var asideStickyHeight = aside.height();
    var footerTop = $('footer').offset().top;
    var scrollTop = $(window).scrollTop();
    var target = footerTop - 50;
    var check = scrollTop + asideStickyHeight;

    var result = check >= target;

    if ($(window).scrollTop() >= stickyTop && !result) {
        aside.addClass("sticky-aside");
        aside.removeClass("sticky-aside-bottom");
    } else if (result) {
        aside.removeClass("sticky-aside");
        aside.addClass("sticky-aside-bottom");
    } else {
        aside.removeClass("sticky-aside");
    }
}