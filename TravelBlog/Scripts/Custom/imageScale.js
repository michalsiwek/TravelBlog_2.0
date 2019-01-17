$(window).on('load', function () { imageScale() });

function imageScale() {
    var containers = $(".img-container");
    for (i = 0; i < containers.length; i++) {
        var containerRatio = containers[i].offsetWidth / containers[i].offsetHeight;
        var image = containers[i].children[0];
        var ratio = image.width / image.height;
        if (ratio < containerRatio) {
            image.style = "width: 100%;";
        } else {
            image.style = "height: 100%;";
        }
    }
}