/* 跑馬燈 */
$('.marquee').verticalLoop({
    delay: 5000,
    order: 'asc'
});

/* 導覽列淡入淡出效果 */
$(window).scroll(function () {
    let scrollTop = $(this).scrollTop();
    //let winHeight = $(window).height();
    if (scrollTop > 60) $('.myNavBg-0').addClass("myNavBg-1");
    else $('.myNavBg-0').removeClass("myNavBg-1");
});
$(".myNavBg-0").hover(function () {
    $('.myNavBg-0').addClass("myNavBg-1");
}, function () {
    let scrollTop = $(window).scrollTop();
    //let winHeight = $(window).height();
    if (scrollTop <= 60) $('.myNavBg-0').removeClass("myNavBg-1");
});
