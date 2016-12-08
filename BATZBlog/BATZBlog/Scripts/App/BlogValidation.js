$(document)
    .ready(function () {
        $('#blogForm')
            .validate({
                rules: {
                    Title: {
                        required: true
                    },
                    PostDate: {
                        required: true,
                        date: true
                    },
                    PostBody: {
                        required: true,
                        minlength: 5
                    },
                    Category: {
                        required: true,
                        range: [1, 4]
                    }
                },
                messages: {
                    Title: {
                        required: "Enter a Title"

                    },
                    PostDate: {
                        required: "Enter a Post Date",
                        date: "Not a valid date format"
                    },
                    PostBody: {
                        required: "Enter something into the Post Body",
                        minlength: "The body must contain at least 5 characters"
                    },
                    Category: {
                        required: "Choose a Category",
                        range: "Choose a Category"
                    }
                }
            });
    });