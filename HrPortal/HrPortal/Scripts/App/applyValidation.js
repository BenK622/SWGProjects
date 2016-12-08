$(document)
    .ready(function (){
     $('#applyForm').validate({
        rules:{
            "applicant.FirstName": {
                required: true
            },
            "applicant.LastName":{
                required: true
            },
            "applicant.Email":{
                required: true,
                email: true
            },
            "applicant.PhoneNumber":{
                required: true
            },
            "file":{
                required: true,
                extension: "txt"
                
            }
            

        },
        messages: {
            "applicant.FirstName": {
                required: "Enter your First Name"
            },
            "applicant.LastName": {
                required: "Enter your Last Name",
            },
            "applicant.Email": {
                required: "Enter a email, you do have one right??",
                email: "Can you put that in a valid format?"
            },
            "applicant.PhoneNumber": {
                required: "Enter a phone number"
            },
            "file": {
                required: "Please attach your resume",
                extension: "Please put a valid file in- txt only at the moment"
            }

        }
     });
});