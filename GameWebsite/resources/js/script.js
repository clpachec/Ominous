$(document).ready(function() {
    
    /* For the sticky navigation */
    $('.js--section-charles').waypoint(function(direction) {
        if (direction == "down") {
            $('nav').addClass('sticky');
        } else {
            $('nav').removeClass('sticky');
        } 
    }, {
        offset: '60px;'
    });
    
    /* Scroll on buttons */
    $('.js--scroll-to-charles').click(function () {
       $('html, body').animate({scrollTop: $('.js--section-charles').offset().top}, 1000); 
    });
    
    $('.js--scroll-to-gameplay').click(function () {
       $('html, body').animate({scrollTop: $('.js--section-gameplay').offset().top}, 1000); 
    });
    
    /* Navigation scroll */
    
    $(function() {
      $('a[href*="#"]:not([href="#"])').click(function() {
        if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
          var target = $(this.hash);
          target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
          if (target.length) {
            $('html, body').animate({
              scrollTop: target.offset().top
            }, 1000);
            return false;
          }
        }
      });
    });    

    /* Animations on scroll */

    $('.js--wp-1').waypoint(function(direction) {
        $('.js--wp-1').addClass('animated fadeIn');
    }, {
        offset: '50%'
    })
    
     $('.js--wp-2').waypoint(function(direction) {
        $('.js--wp-2').addClass('animated rubberBand');
    }, {
        offset: '50%'
    })
     
      $('.js--wp-3').waypoint(function(direction) {
        $('.js--wp-3').addClass('animated fadeInLeft');
    }, {
        offset: '50%'
    })
      
      $('.js--wp-4').waypoint(function(direction) {
        $('.js--wp-4').addClass('animated fadeInRight');
    }, {
        offset: '50%'
    })
     
      $('.js--wp-5').waypoint(function(direction) {
        $('.js--wp-5').addClass('animated pulse');
    }, {
        offset: '50%'
    })
});