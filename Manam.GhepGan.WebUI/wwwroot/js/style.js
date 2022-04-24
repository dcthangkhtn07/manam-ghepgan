$(window).scroll(function(e) {
    var scroll = $(window).scrollTop();
    if (scroll >= 150) {
        $('.navbar').addClass('fixed-top').addClass('scrolling');
        $('#nagivation-container').removeClass('container-fluid');
        $('#nagivation-container').addClass('container');
    } else {
        $('.navbar').removeClass('fixed-top').removeClass('scrolling');
        $('#nagivation-container').removeClass('container');
        $('#nagivation-container').addClass('container-fluid');
    }

});