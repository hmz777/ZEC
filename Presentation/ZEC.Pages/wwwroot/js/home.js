$(function () {
    //Swiper Config (Main carousel)
    //================================================
    const swiper1 = new Swiper('.swiper1', {
        loop: true,
        autoplay: {
            delay: 5000,
            disableOnInteraction: false
        },
        pagination: {
            el: '.swiper-pagination',
            clickable: true
        }
    });
    //================================================
    //Swiper Config (Popular categories carousel)
    //================================================
    const swiper2 = new Swiper('.swiper2', {
        slidesPerView: '6',
        spaceBetween: 25,
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        }
    });
    //================================================
    //Swiper Config (Sales zone)
    //================================================
    const swiper3 = new Swiper('.swiper3', {
        slidesPerView: '5',
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        }
    });
    //================================================
    //Swiper Config (Featured collection)
    //================================================
    const swiper4 = new Swiper('.swiper4', {
        slidesPerView: '3',
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        }
    });
    //================================================
    //Review stars config
    //================================================
    $(".product-review-stars").rating({ "displayOnly": true, "showCaption": false });
    //================================================
});