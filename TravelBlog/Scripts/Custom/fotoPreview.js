var pictHeight = $(window).outerHeight();
var fotoIndex = 0;
// foto preview
function fotoPreview(src) {
    $("#foto-preview").css("display", "block");
    $("#wrapper").css("height", pictHeight.toString() + "px;");
    $('#foto').attr('src', src);
}
// close foto preview
function closeFotoPreview() {
    $("#foto-preview").css("display", "none");
}
// load proper foto
$('.img-container').click(function(event) {
        var src = $(this).find('img').attr('src');
        fotoIndex = parseInt($(this).find('img').attr('img-id'));
        fotoPreview(src);
    });
// slider
function showPic(index) {
    if(index > 0 && fotoIndex < $('.img-container').size()) {
        fotoIndex += index;
    } else if (index < 0 && fotoIndex > 1) {
        fotoIndex += index;
    }
    var src = $('[img-id="' + fotoIndex + '"]').attr("src");
    $('#foto').attr('src', src);
}

$('#foto-prev').click(function () {
    showPic(-1);
});
$('#foto-next').click(function () {
    showPic(1);
});

$(document).keydown(function(e) {
    switch(e.which) {
        case 37: // arrow left
            showPic(-1);
            break;
        case 39: // arrow right
            showPic(1);
            break;
        default: return;
    }
    e.preventDefault();
});

// window resize handler
$("#close-preview").on('click', function() {closeFotoPreview()});
$(window).on("resize", function() {
    pictHeight = $(window).height();
    $('#wrapper').height(pictHeight);
});
$(window).trigger('resize');