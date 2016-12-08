$(document)
    .ready(function () {
        $('#pageForm')
            .validate({
                rules: {
                    Title: {
                        required: true
                    },
                    PageBody: {
                        required: true,
                        minlength: 5
                    }
                },
                messages: {
                    Title: {
                        required: "Enter a Title"

                    },
                    PageBody: {
                        required: "Enter something into the Page Body",
                        minlength: "The body must contain at least 5 characters"
                    }
                }
            });
    });