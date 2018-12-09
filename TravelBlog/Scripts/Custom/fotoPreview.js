var pictHeight = $(window).outerHeight();
var fotoIndex = 0;
// foto preview
function fotoPreview(src, desc) {
    $("#foto-preview").css("display", "block");
    $("#wrapper").css("height", pictHeight.toString() + "px;");
    $('#foto').attr('src', src);
    var parentWidth = $('#foto-container').width();
    var fotoDesc = $('#foto-desc');
    fotoDesc.width(parentWidth - 300);
    if (desc == "") {
        fotoDesc.css("display", "none");
    } else {
        fotoDesc.css("display", "block");
        fotoDesc.text(desc);
    }
}
// close foto preview
function closeFotoPreview() {
    $("#foto-preview").css("display", "none");
}
// load proper foto
$('.img-container').click(function(event) {
    var src = $(this).find('img').attr('src');
    fotoIndex = parseInt($(this).find('img').attr('img-id'));
    var desc = $(this).find('.picture-description').attr('value');
    fotoPreview(src, desc);
});
// slider
function showPic(index) {
    if (index > 0 && fotoIndex < $('.img-container').length) {
        fotoIndex += index;
    } else if (index < 0 && fotoIndex > 1) {
        fotoIndex += index;
    }
    var src = $('[img-id="' + fotoIndex + '"]').attr("src");
    var desc = $('[desc-id="desc' + fotoIndex + '"]').attr("value");
    var fotoDesc = $('#foto-desc');
    $('#foto').attr('src', src);
    if (desc == "") {
        fotoDesc.css("display", "none");
    } else {
        fotoDesc.css("display", "block");
        fotoDesc.text(desc);
    }
}

$('#foto-prev').unbind('click').click(function () {
    showPic(-1);
});
$('#foto-next').unbind('click').click(function () {
    showPic(1);
});

$(document).unbind('keydown').keydown(function(e) {
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
    var parentWidth = $('#foto-container').width();
    $('#foto-desc').width(parentWidth - 300);
});
$(window).trigger('resize');