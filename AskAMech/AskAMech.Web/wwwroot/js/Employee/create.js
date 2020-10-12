$(document).ready(function () {

    $('#btnSubmit').click(function (event) {
        event.preventDefault();
        var myform = $('#myform')[0];
        console.log(myform);
        

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

        //$.validator.unobtrusive.parse(myform);

       // if (myform.valid()) {
            var formData = new FormData(myform)
            $.ajax({
                url: 'Employee/Create',
                type: 'POST',
                cache: false,
                data: formData,
            }).done(function (data) {
                alert(response);

            });
        //}

    });
});
