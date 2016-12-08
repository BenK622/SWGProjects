$(document)
    .ready(function () {
        $('#productEditForm')
            .validate({
                rules: {
                    ProductName: {
                        required: true
                    },
                    ProductDescription: {
                        required: true
                    },
                    Price: {
                        required: true,
                        min: 0.01
                    },
                    Category: {
                        required: true,
                        range: [0, 3]
                    },
                    "file": {
                        extension: "jpg"
                    }
                },
                messages: {
                    ProductName: {
                        required: "Enter a Product Name"

                    },
                    ProductDescription: {
                        required: "Enter a Description"
                    },
                    Price: {
                        required: "Enter a Price",
                        min: "Enter a Price more than $0.00"
                    },
                    Category: {
                        required: "Enter a Category",
                        range: "Enter a valid Category"
                    },
                    "file": {
                        extension: "The file must be a JPG"
                    }
                }
            });
    });