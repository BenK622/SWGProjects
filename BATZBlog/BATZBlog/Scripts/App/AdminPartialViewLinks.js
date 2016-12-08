$(document).ready(function () {

    $('#blog').ready(function () {
        $.ajax({
            url: "/Admin/_AdminBlogPartialView",
            type: 'GET',
            success: function(value) {
                $("#partialPlaceHolder").html(value);
            }
        });
    });

    $('#blog').click(function () {
        $.ajax({
            url: "/Admin/_AdminBlogPartialView",
            type: 'GET',
            success: function (value) {
                $("#partialPlaceHolder").html(value);
            }
        });
    });

    $('#page').click(function () {
        $.ajax({
            url: "/Admin/_AdminStaticPagePartialView",
            type: 'GET',
            success: function (value) {
                $("#partialPlaceHolder").html(value);
            }
        });
    });

    $('#tour').click(function () {
        $.ajax({
            url: "/Admin/_AdminTourPagePartialView",
            type: 'GET',
            success: function (value) {
                $("#partialPlaceHolder").html(value);
            }
        });
    });

    $('#product').click(function () {
        $.ajax({
            url: "/Admin/_AdminProductPagePartialView",
            type: 'GET',
            success: function (value) {
                $("#partialPlaceHolder").html(value);
            }
        });
    });

});