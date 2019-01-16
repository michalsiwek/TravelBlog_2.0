$(window).on('load', function () { imageScale() });

function imageScale() {
    var container = $(".img-container").first();
    console.log(container.outerWidth());
    console.log(container.outerHeight());
    var containerRatio = container.outerWidth() / container.outerHeight();
    console.log(containerRatio);
    var images = $(".resizable-pic");
    for (i = 0; i < images.length; i++) {
        var pic = images[i];
        var ratio = pic.width / pic.height;
        console.log(ratio);
        if (ratio < containerRatio) {
            pic.style = "width: 100%;";
        } else {
            pic.style = "height: 100%;";
        }
    }
}