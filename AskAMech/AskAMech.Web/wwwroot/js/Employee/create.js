$(document).ready(function () {
    {
            var formData = new FormData();
            formData.append('FirstName', $('#FirstName').val());
            formData.append('LastName', $('#LastName').val());
            formData.append('IdNumber', $('#IdNumber').val());
            formData.append('Email', $('#Email').val());
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
    }

    
    $(function () {
        $("form[name='myform']").validate({
            
            rules: {
                FirstName: 'required',
                LastName: 'required',
                IdNumber: 'required',
                Email: {
                    required: true,
                    Email: true
                }
            },
           
            messages: {
                FirstName: 'Please enter your firstname',
                LastName: 'Please enter your lastname',
                IdNumber:'Please enter your ID number',
                Email: 'Please enter a valid email address'
            },
           // $('#btnSubmit').submit(function ()
            submitHandler: function (btnSubmit) {
                btnSubmit.submit();
            }
        });
    });
});
