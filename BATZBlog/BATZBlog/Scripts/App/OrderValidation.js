$(document)
    .ready(function () {
        $('#OrderAddForm')
            .validate({
                rules: {
                    "order.CustomerFirstName": {
                        required: true
                    },
                    "order.CustomerLastName": {
                        required: true
                    },
                    "order.CustomerCity": {
                        required: true,
                        
                    },
                    "order.CustomerState": {
                        required: true,
                        
                    },
                   "order.Quantity": {
                        required: true,
                         min: 1,

                    }
                 
                },
                messages: {
                    "order.CustomerFirstName": {
                        required: "Enter a First Name"

                    },
                    "order.CustomerLastName": {
                        required: "Enter a Last Name"
                    },
                    "order.CustomerCity": {
                        required: "Enter a City",
                      
                    },
                    "order.CustomerState": {
                        required: "Enter a State",
                      
                    },
                    "order.Quantity": {
                        required: "Enter a quantity of 1 or more.",

                    }

                }
            });
    });