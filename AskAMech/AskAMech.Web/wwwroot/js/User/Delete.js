$(document).ready(function () {

    $('#Delete').click(function (event) {
        event.preventDefault();
        displayConfirmDeleteUserAccountModal();
    });


    $('#DeactivateAccount').click(function (event) {
        event.preventDefault();
        deleteUserAccount();
    });


    $('#Confirm').click(function (event) {
        event.preventDefault();
        loadDashboard();
    });


    $('#CancelDeactivateAccount').click(function (event) {
        event.preventDefault();
        window.location.reload();
    });
});

function displayConfirmDeleteUserAccountModal() {
    var deletePasswordDiv = $('#DeletePasswordDiv');
    $.ajax({
        url: '/User/Delete',
        type: 'GET',
        cache: false,
        success: function (data) {
            deletePasswordDiv.html(data);
            deletePasswordDiv.find('.modal').modal('show');
        }
    });
}

function deleteUserAccount() {
    $.ajax({
        url: '/User/DeleteAccount',
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data.success) {
                displayDeleteSuccessModal();
            }
        }
    });
}

function displayDeleteSuccessModal() {
    var successModal = $('#DeletePasswordDiv');
    $.ajax({
        url: '/User/DeleteSuccess',
        type: 'GET',
        cache: false,
        success: function (data) {
            successModal.html(data);
            successModal.find('.modal').modal('show');
        }
    });
}

function loadDashboard() {
    window.location.href = '/Home/Index';
}