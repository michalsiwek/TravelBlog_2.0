$(window).on('scroll', function () { stickAside() });

var contentHeight = $(".content-main-box").height();
var asideHeight = $("#right-aside").height();

var aside = $("#aside-sticky");
var stickyTop = aside.offset().top;

function stickAside() {
    if (contentHeight > asideHeight + 50) {
        var asideStickyHeight = aside.height();
        var footerTop = $('footer').offset().top;
        var scrollTop = $(window).scrollTop() + 25;
        var target = footerTop;
        var check = scrollTop + asideStickyHeight;

        var result = check >= target;
        if (scrollTop >= stickyTop && !result) {
            aside.addClass("sticky-aside");
            aside.removeClass("sticky-aside-bottom");
        } else if (result) {
            aside.removeClass("sticky-aside");
            aside.addClass("sticky-aside-bottom");
        } else {
            aside.removeClass("sticky-aside");
        }
    }
}