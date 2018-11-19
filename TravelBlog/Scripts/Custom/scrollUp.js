        $(function($)
        {
            $.scrollTo(0);
            $('#scrollup').click(function() { $.scrollTo($('body'), 1000); });
        }
        );
            
        $(window).scroll(function()
        {
            if($(this).scrollTop()>750) $('#scrollup').fadeIn();
            else $('#scrollup').fadeOut();
        });