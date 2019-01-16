$(window).on('load', function () { imageScale() });

function imageScale() {
    var container = $(".img-container").first();
    var containerRatio = container.outerWidth() / container.outerHeight();
    var images = $('.gallery-pic-mini');
    for (i = 0; i < images.length; i++) {
        var pic = images[i];
        var ratio = pic.width / pic.height;
        if (ratio < containerRatio) {
            pic.style = "width: 100%;";
        } else {
            pic.style = "height: 100%;";
        }
    }
}