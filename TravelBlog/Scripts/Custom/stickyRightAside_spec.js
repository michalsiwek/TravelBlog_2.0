$(window).on('scroll', function () { stickAside() });

var contentHeight = $(".content-main-box").height();
var asideHeight = $("#right-aside").height();

var aside = $("#aside-sticky");

var stickyBarLength = $('#title-bar').length;
var asideChange = 2 * $('#title-bar').height() + 25;;

stickyTop = aside.offset().top - asideChange;

function stickAside() {
    if (contentHeight > asideHeight + 50) {
        var asideStickyHeight = aside.height();

        var footerTop = $('footer').offset().top;
        var scrollTop = $(window).scrollTop();
        var target = footerTop - asideChange;
        var check = scrollTop + asideStickyHeight;

        var result = check >= target;

        if (scrollTop >= stickyTop && !result) {
            aside.addClass("sticky-aside");
            aside.removeClass("sticky-aside-bottom");
            if (stickyBarLength == 1) {
                aside.addClass("spec-sticky-aside");
            }
        } else if (result) {
            aside.removeClass("sticky-aside");
            aside.addClass("sticky-aside-bottom");
            aside.removeClass("spec-sticky-aside");
        } else {
            aside.removeClass("sticky-aside");
        }
    }
}