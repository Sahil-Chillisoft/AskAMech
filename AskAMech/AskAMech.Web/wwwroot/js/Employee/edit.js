﻿$(document).ready(function () {

    var employeeId = $('#Id').val();

    $('#Update').click(function (event) {
        event.preventDefault();

        var $form = $('#employeeUpdateForm');
        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            var formData = $form.serialize();
            $.ajax({
                url: '/Employee/Edit',
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


    $('#Deactivate').click(function (event) {
        event.preventDefault();
        displayConfirmEmployeeDeactivationModal();
    });


    $('#Reactivate').click(function (event) {
        event.preventDefault();
        displayConfirmEmployeeReactivationModal();
    });


    $('#UpdateEmployeeActiveStatus').click(function (event) {
        event.preventDefault();
        setEmployeeActivationStatus(false, employeeId);
    });


    $('#CancelUpdateEmployeeActiveStatus').click(function (event) {
        event.preventDefault();
        window.location.reload();
    });


    $('#ReactivateEmployee').click(function (event) {
        event.preventDefault();
        setEmployeeActivationStatus(true, employeeId);
    });


    $('#CancelReactivateEmployee').click(function (event) {
        event.preventDefault();
        window.location.reload();
    });


    $('#ResetPassword').click(function (event) {
        event.preventDefault();
        displayConfirmPasswordResetModal();
    });


    $('#ResetEmployeePassword').click(function (event) {
        event.preventDefault();
        resetEmployeeUserAccountPassword(employeeId);
    });


    $('#CancelResetEmployeePassword').click(function (event) {
        event.preventDefault();
        window.location.reload();
    });


    $('#ConfirmPasswordResetResponse').click(function (event) {
        event.preventDefault();
        window.location.reload();
    });
});

function setEmployeeActivationStatus(isActive, employeeId) {
    var request = {
        'employee.id': employeeId,
        'employee.isActive': isActive
    }
    $.ajax({
        url: '/Employee/UpdateActiveStatus',
        type: 'POST',
        cache: false,
        data: request,
        success: function (data) {
            if (data.success)
                window.location.reload();
        }
    });
}

function resetEmployeeUserAccountPassword(employeeId) {
    var request = {
        'employeeId': employeeId
    }
    $.ajax({
        url: '/Employee/ResetEmployeeUserAccountPassword',
        type: 'POST',
        cache: false,
        data: request,
        success: function (data) {
            displayPasswordResetResponseModal(data);
        }
    });
}

function displayConfirmEmployeeDeactivationModal() {
    var confirmationModal = $('#ConfirmEmployeeActiveStatusDiv');
    $.ajax({
        url: '/Employee/GetConfirmationModalForEmployeeDeactivation',
        type: 'GET',
        cache: false
    }).done(function (data) {
        confirmationModal.html(data);
        confirmationModal.find('.modal').modal('show');
    });
}

function displayConfirmEmployeeReactivationModal() {
    var confirmationModal = $('#ConfirmEmployeeActiveStatusDiv');
    $.ajax({
        url: '/Employee/GetConfirmationModalForEmployeeReactivation',
        type: 'GET',
        cache: false
    }).done(function (data) {
        confirmationModal.html(data);
        confirmationModal.find('.modal').modal('show');
    });
}

function displayConfirmPasswordResetModal() {
    var confirmationModal = $('#ResetPasswordDiv');
    $.ajax({
        url: '/Employee/GetEmployeePasswordResetConfirmationModal',
        type: 'GET',
        cache: false
    }).done(function (data) {
        confirmationModal.html(data);
        confirmationModal.find('.modal').modal('show');
    });
}

function displayPasswordResetResponseModal(data) {
    var confirmationModal = $('#ResetPasswordDiv');
    confirmationModal.innerHTML = "";
    confirmationModal.find('.modal').modal('hide');

    var passwordResetResponseModal = $('#ResetPasswordResponseDiv');
    passwordResetResponseModal.html(data);
    passwordResetResponseModal.find('.modal').modal('show');
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