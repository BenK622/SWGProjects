$(document)
    .ready(function () {
        $('#showForm')
            .validate({
                rules: {
                    VenueName: {
                        required: true
                    },
                    ShowDate: {
                        required: true,
                        date: true
                    },
                    City: {
                        required: true
                    },
                    State: {
                        required: true
                    }
                },
                messages: {
                    VenueName: {
                        required: "Enter a Venue Name"

                    },
                    ShowDate: {
                        required: "Enter a Show Date",
                        date: "Not a valid date format"
                    },
                    City: {
                        required: "Enter a City"
                    },
                    State: {
                        required: "Enter a State"
                    }
                }
            });
    });