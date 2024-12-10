(function ($) {
    "use strict";

    // Spinner
    var spinner = function () {
        setTimeout(function () {
            if ($('#spinner').length > 0) {
                $('#spinner').removeClass('show');
            }
        }, 1);
    };
    spinner(0);


    // Fixed Navbar
    $(window).scroll(function () {
        if ($(window).width() < 992) {
            if ($(this).scrollTop() > 100) {
                $('.fixed-top').addClass('shadow');
            } else {
                $('.fixed-top').removeClass('shadow');
            }
        } else {
            if ($(this).scrollTop() > 100) {
                $('.fixed-top').addClass('shadow').css('top', -100);
            } else {
                $('.fixed-top').removeClass('shadow').css('top', 0);
            }
        }
    });


    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });
    $('.back-to-top').click(function () {
        $('html, body').animate({scrollTop: 0}, 1500, 'easeInOutExpo');
        return false;
    });


    // Testimonial carousel
    $(".testimonial-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 2000,
        center: false,
        dots: true,
        loop: true,
        margin: 25,
        nav: true,
        navText: [
            '<i class="bi bi-arrow-left"></i>',
            '<i class="bi bi-arrow-right"></i>'
        ],
        responsiveClass: true,
        responsive: {
            0: {
                items: 1
            },
            576: {
                items: 1
            },
            768: {
                items: 1
            },
            992: {
                items: 2
            },
            1200: {
                items: 2
            }
        }
    });


    // vegetable carousel
    $(".vegetable-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1500,
        center: false,
        dots: true,
        loop: true,
        margin: 25,
        nav: true,
        navText: [
            '<i class="bi bi-arrow-left"></i>',
            '<i class="bi bi-arrow-right"></i>'
        ],
        responsiveClass: true,
        responsive: {
            0: {
                items: 1
            },
            576: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 3
            },
            1200: {
                items: 4
            }
        }
    });


    // Modal Video
    $(document).ready(function () {
        var $videoSrc;
        $('.btn-play').click(function () {
            $videoSrc = $(this).data("src");
        });

        $('#videoModal').on('shown.bs.modal', function (e) {
            $("#video").attr('src', $videoSrc + "?autoplay=1&amp;modestbranding=1&amp;showinfo=0");
        })

        $('#videoModal').on('hide.bs.modal', function (e) {
            $("#video").attr('src', $videoSrc);
        })
    });

    function debounce(func, delay) {
        let timeout;
        return function () {
            const context = this;
            const args = arguments;
            clearTimeout(timeout); // Clear the previous timeout
            timeout = setTimeout(function () {
                func.apply(context, args);
            }, delay);
        };
    }

    const debouncedUpdateCartQuantity = debounce(function (productId, quantity) {
        $.ajax({
            url: '/cart/update',
            method: 'PUT',
            data: {
                productId: productId,
                quantity: quantity
            },
            xhrFields: {
                withCredentials: true
            },
            success: function (response) {
                console.log('Cart updated successfully');
            },
            error: function (error) {

                console.log('Error updating cart');
            }
        });
    }, 600);

    // Product Quantity
    $('.quantity button').on('click', function () {
        var button = $(this);
        var inputField = button.closest('.quantity').find('input[type="text"]');
        var productId = button.closest('.quantity').find('input[name="productId"]').val();
        var oldValue = parseFloat(inputField.val());
        if (button.hasClass('btn-plus')) {
            var newVal = parseFloat(oldValue) + 1;
        } else {
            if (oldValue > 0) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 0;
            }
        }
        inputField.val(newVal);
        debouncedUpdateCartQuantity(productId, newVal);
    });

    $('.delete.rounded-circle').on('click', function () {
        var productId = $(this).closest('tr').attr('product-id');
        var cartCode = $(this).closest('tr').attr('cart-code');

        $.ajax({
            url: `/cart/${cartCode}/${productId}`,
            method: 'DELETE',
            success: function (response) {
                window.location.reload();
            },
            error: function (xhr, status, error) {
                alert("Error: Some thing wrong" );
            }
        });
    });

    $($("#carouselId div.carousel-item")[0]).addClass("active");

    $(".nav-category.nav-item").click(function () {
        const categoryId = $(this).attr("value");
        if (!categoryId)
            return;

        $.ajax({
            method: "GET",
            url: `category/${categoryId}`,
            contentType: "application/json",
            processData: true,
            success: function (data, textStatus, xhr) {
                const elmRow = $(`#tab-${categoryId} .row`);
                elmRow.empty();
                if (xhr.status === 200) {
                    if (data?.value?.length > 0) {
                        const listProduct = data.value;
                        listProduct.forEach(i => {
                            if (i != null) {
                                const formattedPrice = `${new Intl.NumberFormat('vi-VN').format(i.price)} ₫"`;
                                const item = `
                        <div class="col-md-6 col-lg-4 col-xl-3">
                        <form action="/cart/add" method="post">
                             <input type="hidden" value="${i.productId}" name="productId"/>
                             <div class="rounded position-relative fruite-item">
                            <div class="fruite-img">
                                <img 
                                src="img/${i.imageUrl}" 
                                class="img-fluid w-100 rounded-top"
                                alt=""
                                 >
                            </div>
                            <div class="text-white bg-secondary px-3 py-1 rounded position-absolute" style="top: 10px; left: 10px;">Fruits</div>
                            <div class="p-4 border border-secondary border-top-0 rounded-bottom">
                                <h4>${i.productName}</h4>
                                <p>${i.description}</p>
                                <div class="d-flex justify-content-between flex-lg-wrap">
                                    <input class="form-control mr-2" type="number" value="1" min="1" max="20" name="quantity">
                                    <p class="text-dark fs-5 fw-bold mb-0">${formattedPrice}</p>
                                    <button class="btn border border-secondary rounded-pill px-3 text-primary">
                                      <i class="fa fa-shopping-bag me-2 text-primary"></i>
                                       Add to cart
                                    </button>
                                </div>
                                </div>
                            </div>
                    </form>
                        </div>
                    `
                                elmRow.append(item);
                            }
                        })
                    } else {
                        const item = `
                     <div class="col-md-6 col-lg-4 col-xl-3">
                         <div class="rounded position-relative fruite-item">
                        <div class="text-white bg-secondary px-3 py-1 rounded position-absolute" style="top: 10px; left: 10px;">
                        Data not found
                     </div>
                    </div>
                    `
                        elmRow.append(item);
                    }
                }
            },
            complete: function () {

            },
            error: function (xhr, status, error) {
                console.error("Error:", status, error); // Handle errors
            }
        });
    });

})(jQuery);

