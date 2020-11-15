$(document).ready(function () {

    $('#Update').click(function (event) {
        event.preventDefault();

        if (isValidUsername()) {
            var $form = $('#UserProfileUpdateForm');
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
                    }
                    else {
                        $('#ErrorMessage').text(data.message);
                    }
                }
            });
        } else {
            $('#UsernameValidation').text('* Please enter username');
        }
    });


    $('#Confirm').click(function (event) {
        event.preventDefault();
        window.location.reload();
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


    $('#EmployeeDetails').click(function (event) {
        event.preventDefault();
        displayEmployeeDetailsModal();
    });

});

function isValidUsername() {
    var username = $('#Username').val();
    if (username === '')
        return false;
    else
        return true;
}

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
        updatePassword(newPassword);
    }
}

function updatePassword(password) {
    $.ajax({
        url: '/User/UpdatePassword',
        data: { password: password },
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data.success) {
                var updatePasswordModal = $('#UpdatePasswordDiv');
                updatePasswordModal.find('.modal').modal('hide');
                displaySuccessModal();
            }
        }
    });
}

function displayEmployeeDetailsModal() {
    var employeeDetailsModal = $('#EmployeeDetailsDiv');
    var employeeId = $('#EmployeeId').val();
    $.ajax({
        url: '/User/EmployeeDetails',
        type: 'GET',
        cache: false,
        data: { employeeId: employeeId },
        success: function (data) {
            employeeDetailsModal.html(data);
            employeeDetailsModal.find('.modal').modal('show');
        }
    });
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
        url: '/User/EditSuccess',
        type: 'GET',
        cache: false,
        success: function (data) {
            successModal.html(data);
            successModal.find('.modal').modal('show');
        }
    });
}