// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    $(window).scroll(function () {
        if ($(document).scrollTop() > 350) {
            $('nav').addClass('shrink');
        }
        else {
            $('nav').removeClass('shrink');
        }
    });
});
