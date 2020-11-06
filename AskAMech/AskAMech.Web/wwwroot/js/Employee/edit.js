$(document).ready(function () {

    $('#Update').click(function (event) {
        event.preventDefault();

        var $form = $('#employeeUpdateForm');
        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            var formData = $form.serialize();
            $.ajax({
                url: '/Employee/Update',
                type: 'POST',
                cache: false,
                enctype: 'multipart/form-data',
                processData: false,
                data: formData,
                success: function (data) {
                    if (data.success) {
                        displaySuccessModal();
                    } else {
                        $('#ErrorMessage').text(data.message);
                    }
                }
            });
        }
    });

    function displaySuccessModal() {
        var successModal = $('#createSuccessDiv');
        $.ajax({
            url: '/Employee/CreateSuccess',
            type: 'GET',
            cache: false,
            success: function (data) {
                successModal.html(data);
                successModal.find('.modal').modal('show');
            }
        });
    }
});