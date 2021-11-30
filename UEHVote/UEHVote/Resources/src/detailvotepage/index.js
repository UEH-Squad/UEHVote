const detailVoteCarousel = () => {
    $('.owl-carousel').owlCarousel({
        loop: true,
        dots: false,
        margin: 0,
        nav: true,
        responsive: {
            0: {
                items: 2,
                slideBy: 2,
            },
            1200: {
                items: 3,
                slideBy: 3,
            },
        }
    })
}

export default { detailVoteCarousel };