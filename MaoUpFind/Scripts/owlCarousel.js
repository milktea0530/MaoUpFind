/* 圖片輪播用 */
$(document).ready(() => {
    $('.owl-carousel').owlCarousel({
        center: true,
        loop: true,
        margin: 10,
        nav: true,
        autoplay: true,
        autoplayTimeout: 3000,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1
            },
            1000: {
                items: 2
            },
            1400: {
                items: 3
            }

        }
    });
});