$(document).ready(function () {

    $('#create').click(function (event) {
        event.preventDefault();

        var $form = $('#employeeCreateForm');
        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            var formData = $form.serialize();
            $.ajax({
                url: '/Employee/Create',
                type: 'POST',
                cache: false,
                enctype: 'multipart/form-data',
                processData: false,
                data: formData, 
                success: function(data) {
                    if (data.success) {
                        alert(data.message);
                    } else {
                        alert(data.message);
                    }
                }
            });
        }
    });
});
