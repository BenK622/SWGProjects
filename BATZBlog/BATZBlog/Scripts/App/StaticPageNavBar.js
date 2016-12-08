$(document).ready(function () {
    $.ajax({
        url: "/Public/StaticLinksPartial",
        type: 'GET',
        success: function (value) {
            $("#staticLinkPartial").html(value);
        }
    });
});


//$(document).ready(function () {
//   var url="/Public/StaticLinksPartial"

//   $.getJSON(url)
//       .done(function(data)){

//}
       
//});