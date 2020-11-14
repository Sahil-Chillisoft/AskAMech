$(document).ready(function () {

    $('#Update').click(function (event) {
        event.preventDefault();

        var $form = $('#UserProfileUpdateForm');
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


    $('#Confirm').click(function (event) {
        event.preventDefault();
        $('#successModal').modal('hide');
        $('#Description').val('');
        $('#ErrorMessage').text('');
    });


    $('#UpdatePassword').click(function (event) {
        event.preventDefault();
        displayUpdatePasswordModal();
    });


    $('#VerifyCurrentPassword').click(function (event) {
        event.preventDefault();
        verifyCurrentPassword();
    });

    $('#UpdateNewPassword').click(function (event) {
        event.preventDefault();
        updateNewPassword();
    });

});

function verifyCurrentPassword() {
    var currentPassword = $('#CurrentPassword').val();
    var password = $('#Password').val();

    if (currentPassword === '' || currentPassword === null) {
        $('#UpdatePasswordValidation').text('* Please enter your current password to be verified');
    }
    else if (currentPassword !== password) {
        $('#UpdatePasswordValidation').text('Error: Entered password does not match your current password');
    }
    else {
        $('#NewPasswordDiv').show();
        $('#UpdateNewPassword').show();
        $('#ValidateCurrentPasswordDiv').hide();
        $('#UpdatePasswordValidation').text('');
    }
}

function updateNewPassword() {
    var newPassword = $('#NewPassword').val();
    var confirmNewPassword = $('#ConfirmNewPassword').val();
    if (newPassword === '' || confirmNewPassword === '') {
        $('#UpdatePasswordValidation').text('* Please enter all fields');
    }
    else if (newPassword !== confirmNewPassword) {
        $('#UpdatePasswordValidation').text('* Passwords do not match');
    }
    else if (newPassword === confirmNewPassword) {
        //TODO: Do ajax call to post data to controller to update the users password.
    }
}

function displayUpdatePasswordModal() {
    var updatePasswordModal = $('#UpdatePasswordDiv');
    $.ajax({
        url: '/User/UpdatePassword',
        type: 'GET',
        cache: false,
        success: function (data) {
            updatePasswordModal.html(data);
            updatePasswordModal.find('.modal').modal('show');
            $('#NewPasswordDiv').hide();
            $('#UpdateNewPassword').hide();
        }
    });
}

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