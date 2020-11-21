



$(document).ready(function () {
   
    $('div.advertise_img span').click(function () {

        var imageId = $(this).attr('image-id');
        var len = $("div.deleteImage input[type='hidden']").length;
        
        $(this).parent().parent().remove();
        $('<input>').attr({
            type: 'hidden',
            name: 'SelectedImagesId['+len+']',
            value: imageId
        }).appendTo('div.deleteImage');
    });
})

