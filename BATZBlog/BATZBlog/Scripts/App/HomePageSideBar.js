$(document).ready(function () {
    $.ajax({
        url: "/Public/UpcomingEventsPartial",
        type: 'GET',
        success: function (value) {
            $("#upcomingShows").html(value);
        }
    });

    $.ajax({
        url: "/Public/BlogPostCategoriesPartial",
        type: 'GET',
        success: function (value) {
            $("#postsByCategories").html(value);
        }
    });
        $.ajax({
        url: "/Public/GetAllTagsInuse",
        type: 'GET',
        success: function (value) {
            $("#postsByTags").html(value);
        }
    });

});