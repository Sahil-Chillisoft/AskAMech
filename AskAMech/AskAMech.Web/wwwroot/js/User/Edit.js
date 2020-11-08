﻿$(document).ready(function () {

    $('#Update').click(function (event) {
        event.preventDefault();

        var $form = $('#userProfileUpdateForm');
        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            var formData = $form.serialize();
            $.ajax({
                url: '/User/Edit',
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
        var successModal = $('#UpdateSuccessDiv');
        $.ajax({
            url: '/Employee/EditSuccess',
            type: 'GET',
            cache: false,
            success: function (data) {
                successModal.html(data);
                successModal.find('.modal').modal('show');
            }
        });
    }

    $('#Confirm').click(function (event) {
        event.preventDefault();
        $('#successModal').modal('hide');
        $('#Description').val('');
        $('#ErrorMessage').text('');
    });
});