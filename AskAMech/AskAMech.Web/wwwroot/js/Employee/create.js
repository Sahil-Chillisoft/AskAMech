$(document).ready(function () {

    $('#btnSubmit').click(function (event) {
        event.preventDefault();
        var myform = $('#myform')[0];

        //myform.validate({

        //    rules: {
        //        FirstName: 'required',
        //        LastName: 'required',
        //        IdNumber: 'required',
        //        Email: {
        //            required: true,
        //            Email: true
        //        }
        //    },

        //    messages: {
        //        FirstName: 'Please enter your firstname',
        //        LastName: 'Please enter your lastname',
        //        IdNumber: 'Please enter your ID number',
        //        Email: 'Please enter a valid email address'
        //    },
        //});


        var formData = new FormData(myform)   
        $.ajax({
            url: 'Employee/Create',
            type: 'POST',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                alert(response);
            }
        });
    });
});
