$(document).ready(function() {
    $('.center-grp .wp-block-table').each(function() {
        $(this).wrap('<div class="table-wrapper"></div>');
    });
    $('.dropdown-menu a').on('mouseenter', function() {
        $('.dropdown-menu a:focus').blur();
    });
    $(".search_txt")
        .attr("tabindex", "0") // Make it focusable if it's not already
        .attr("role", "button") // Optional: helps screen readers know it's interactive
        .attr("aria-expanded", "false") // For accessibility
        .on("click keydown", function(e) {
            if (e.type === "click" || (e.type === "keydown" && (e.key === "Enter" || e.key === " "))) {
                e.preventDefault(); // Prevent spacebar scrolling

                const $this = $(this);
                const $container = $this.parent().find(".asp_w_container");
                const isOpen = $container.is(":visible");

                $container.stop(true, true).slideToggle();
                $this.attr("aria-expanded", String(!isOpen));
            }
        });

    $('.wp-block-group,.wp-block-columns ,.wp-block-column').removeClass('is-layout-flow');

    $('.main_wrapper').attr('role', 'main');


    $('.owl-general .owl-carousel').owlCarousel({
        loop: true,
        dots: true,
        autoplay: true,
        margin: 10,
        nav: true,
        autoWidth: false,
        items: 1,
        navText: [
            '<img src="/wp-content/themes/planeteriaweb/img/arrow_forward.svg">',
            '<img src="/wp-content/themes/planeteriaweb/img/arrow_forward.svg">'
        ],
        navContainer: '.owl-general .custom-nav',
        /*responsive:{
        0:{
            items: 1
        },
        600:{
            items: 1
        },
        1000:{
            items: 1,
			    stagePadding: 200
        }
    }*/
    });

    // Function to activate the tab based on URL fragment
    var hash = window.location.hash;
    if (hash) {
        $('.nav-link[href="' + hash + '"]').tab('show');
    }

    // Update URL when tab is clicked
    $('a[data-toggle="tab"]').on('shown.bs.tab', function(e) {
        history.pushState(null, null, e.target.hash);
    });

    //Navbar
    if (jQuery(window).width() < 1200) {
        $('.navbar-nav  > li.menu-item-has-children, .navbar-nav  > li.megamenu_item   ').append('<div class="plusMinus"></div>');
        jQuery(".navbar-nav  > li.menu-item-has-children  > .plusMinus , .navbar-nav  > li.megamenu_item  > .plusMinus").click(function() {
            //jQuery(".show-mobile").slideToggle('fast');
            //jQuery(this).parent().siblings('li').find('ul.sub-menu').slideUp("fast");
            //jQuery(this).parent().siblings('li').find('.plus-minus').removeClass("minusIcon");
            $(this).parent().find('.dropdown-menu ,.megamenu_drop,.megamenu').slideToggle("fast");
            $(this).parent().toggleClass('activeBlue');
            $(this).toggleClass("minsicon");
        });
        //$(".select_language ").insertBefore('.navbar-toggler  ');
        // $(".soc_nav_wrap ").insertAfter('.nav_bottom');
        // $(".social_media ").insertAfter('.nav_bottom  ');
        $('.megamenu_drop  li.menu-item-has-children  ').append('<div class="pls_minus"></div>');

        jQuery(".megamenu_drop  li.menu-item-has-children  .pls_minus").click(function() {
            $(this).parent().find('.sub-menu').slideToggle("fast");
            $(this).parent().toggleClass('active-item');
            $(this).toggleClass("minus-info");
        });
        $('.wp-block-advgb-table').each(function() {
            $(this).wrap('<div class="table-wrap"></div>');
        });
        $('.wp-block-group > table').wrap('<div class="table-wrapper"></div>');

    }
    /*if (jQuery(window).width() < 992 ) {
            $('.navbar-nav  > li.megamenu_item   ').append('<div class="plusMinus"></div>');
            jQuery(".navbar-nav  > li.megamenu_item   > .plusMinus").click( function () {
            $(this).parent().find('.megamenu').slideToggle("fast");
            $(this).parent().toggleClass('activeBlue');
            $(this).toggleClass("minsicon");
            });
            }
            */
    $(".navbar-toggler").on("click", function() {
        $(this).toggleClass("active");
        $('.main_header').toggleClass("headerActive");
    });
    // Add a focusable toggle div
    $('.dropdown-menu > li.menu-item-has-children').prepend('<div class="plus-minus" tabindex="0" aria-expanded="false" role="button" aria-label="Toggle submenu"></div>');

    $('.dropdown-menu').on('click keydown', '.plus-minus', function(e) {
        // Handle click or Enter/Space key
        if (e.type === 'click' || (e.type === 'keydown' && (e.key === 'Enter' || e.key === ' '))) {
            e.preventDefault(); // Prevent scrolling on Space

            const $this = $(this);
            const $submenu = $this.parent().find('> .mega-submenu');
            const isOpen = $this.attr('aria-expanded') === 'true';

            // Toggle current
            $submenu.slideToggle('fast');
            $this.toggleClass('minus-icon').attr('aria-expanded', String(!isOpen));

            // Close others
            $this.parent().siblings('li').find('> .mega-submenu').slideUp('fast');
            $this.parent().siblings('li').find('.plus-minus')
                .removeClass('minus-icon')
                .attr('aria-expanded', 'false');
        }
    });



    $('.mega-submenu  > li.menu-item-has-children').prepend('<div class="plus-minus"></div>');
    jQuery(".mega-submenu   > li.menu-item-has-children  > .plus-minus").click(function() {
        jQuery(this).parent().find('>.mega-submenu').slideToggle("fast");
        jQuery(this).parent().siblings('li').find('> ul.mega-submenu').slideUp("fast");
        jQuery(this).parent().siblings('li').find('.plus-minus').removeClass("minus-icon");
        jQuery(this).toggleClass("minus-icon");
    });
    $('.text_card_block .btn_sm  ').parents('.img_text_card_col').find('.text-img-wrap').addClass("has-button ");

    $('.advgb-accordion-body').each(function() {
        $(this).wrapInner('<div class="accordion-content"></div>');
    });
    /*
                      $('.main_content > *').wrapAll('<div class="main-wrap"></div>');*/
    if (window.location.hash) {

        var target = $(window.location.hash); // Get the element based on the hash
        if (target.length) { // Check if the element exists
            var offset = $('.advgb-tabs-panel').outerHeight() + 30; // Adjust the offset
            $('html, body').animate({
                scrollTop: target.offset().top - offset // Scroll to the element
            }, 1000);
        }
    }
    $('.rel_forms').parent(".col_right").addClass("has_forms ");
    $('.alerticon').parent(".rtTitle").addClass("p-left ");
    $('a[href$=".pdf"]').each(function() {
        // Open the PDF link in a new window
        $(this).attr('target', '_blank');
    });
    $('.carousel-inner').each(function() {
        if ($(this).children('div').length === 1) $(this).siblings('.carousel-indicators, .carousel-control-prev, .carousel-control-next').hide();

    });
    $('.img_block .img_block_descr').each(function() {
        // Check if this div contains a p tag
        if ($(this).find('p').length === 0) {
            // If no p tag is found, add the class to the closest div
            $(this).closest('.img_block').addClass('no-p-tag');
        }
    });
    $('.main_wrapper').attr('id', 'page_content');
    $(".links li .expand_det").matchHeight({
        byRow: true,
        property: 'height',
        target: null,
        remove: false
    });

    $(".img_text_card_col .text_card_block ").matchHeight({
        byRow: true,
        property: 'height',
        target: null,
        remove: false
    });
    $('.advgb-accordion-item .advgb-accordion-body').css('border', '0px');

    //Translate using keyboard
    setTimeout(function() {
        let $translateButton = $(".gt_selected");
        let $translateMenu = $(".gt_option");

        if ($translateButton.length && $translateMenu.length) {
            $translateButton.on("click", function() {
                setTimeout(function() {
                    let $iframe = $(".gt_option");
                    if ($iframe.length) {
                        $iframe.attr("tabindex", "-1").focus();
                    }
                }, 500);
            });
            $(document).on("keydown", function(event) {
                if (event.key === "Escape") {
                    let $iframe = $(".gt_option");
                    if ($iframe.length) {
                        $iframe.hide();
                        $translateButton.focus();
                    }
                }
            });
        }
    }, 2000);


});

$(window).on('resize', function() {
    /*
       if (jQuery(window).width() < 1200) {
          $(".select_language ").insertBefore('.navbar-toggler  ');
          $(".soc_nav_wrap ").insertAfter('.nav_bottom');
       }
       if (jQuery(window).width() > 1200) {
          $(".select_language ").insertBefore('.top_search  ');
          $(".soc_nav_wrap ").insertBefore('.select_language');
       }*/


});

//Url in window target
(function($, window) {
    var adjustAnchor = function() {

        var $anchor = $(':target'),
            fixedElementHeight = 150;

        if ($anchor.length > 0) {

            $('html, body')
                .stop()
                .animate({
                    scrollTop: $anchor.offset().top - fixedElementHeight
                }, 200);
            window.scrollTo(0, $anchor.offset().top - fixedElementHeight);

        }

    };

    $(window).on('hashchange load', function() {
        adjustAnchor();
    });

})(jQuery, window);



//Header shrink on scroll
$(document).on("scroll ", function() {
    if ($(document).scrollTop() > 0) {
        $(".main_header ").addClass("shrink ");

    } else {
        $(".main_header ").removeClass("shrink ");

    }
});

//main accordion

(function($) {
    $('.accmain .acctitle').click(function(j) {
        var dropDown = $(this).closest('.acccard').find('.accpanel');
        $(this).closest('.accmain').find('.accpanel').not(dropDown).slideUp();
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
        } else {
            $(this).closest('.accmain').find('.acctitle.active').removeClass('active');
            $(this).addClass('active');
        }

        dropDown.stop(false, true).slideToggle();

        j.preventDefault();
    });
})(jQuery);
$(function() {
    $('[data-toggle="tooltip"]').tooltip()
})

$(window).on('load', function() {
    $('.wp-block-image.alignleft,  .wp-block-image.alignright').wrap('<div class="left_right_wraper"></div>');
});







function checkOverflow() {
    $('.kt-tabs-wrap').each(function() {
        var $tabs = $(this).find('.kt-tabs-title-list');
        if ($tabs.length && $tabs[0].scrollWidth > $tabs[0].clientWidth) {
            $(this).addClass('overflowing');
        } else {
            $(this).removeClass('overflowing');
        }
    });
}

// Initial check after full page load
$(window).on('load', function() {
    checkOverflow();
});

// On resize
$(window).on('resize', function() {
    checkOverflow();
});






$(window).on('load', function() {
    // Check if the screen width is above 1200px
    if ($(window).width() > 1200) {
        // Get the height of the main_header
        var headerHeight = $('.main_header').outerHeight(true); // Include margin

        // Assign the height as padding-top to the main_wrapper
        $('.main_wrapper').css('padding-top', headerHeight + 'px');
    }
});
$('.close').on('click', function() {
    $('.main_wrapper').css('padding-top', ''); // Reset padding to default
});



$(".kb-table").each(function() {
    const $table = $(this);
    const $tbody = $table.find("tbody").first();
    if ($tbody.length === 0) return;

    const $firstRow = $tbody.find("tr").first();
    if ($firstRow.length === 0) return;

    const $thElements = $firstRow.find("th");

    if ($thElements.length > 0) {
        const $thead = $("<thead></thead>");
        $thead.append($firstRow); // Move the first row into the thead
        $table.prepend($thead); // Insert thead before tbody
    }
});