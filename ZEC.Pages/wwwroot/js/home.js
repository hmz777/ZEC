//Swiper Config (Main carousel)
//================================================
const swiper1 = new Swiper('.swiper1', {
    loop: true,
    autoplay: {
        delay: 5000,
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