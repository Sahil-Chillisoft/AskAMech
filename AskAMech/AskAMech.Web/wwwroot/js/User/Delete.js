$(document).ready(function () {

    $('#Delete').click(function (event) {
        event.preventDefault();
        displayDeletePasswordModal()
        $.ajax({
            url: '/User/DeleteAccount',
            type: 'POST',
            success: function (data) {
                if(data.success) {
                    displaySuccessModal();
                }   
            }
        });
    });
});

function displaySuccessModal() {
    var successModal = $('#DeleteSuccessDiv');
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
function displayDeletePasswordModal() {
    var deletePasswordModal = $('#DeleteSuccessDiv');
    $.ajax({
        url: '/User/Delete',
        type: 'GET',
        cache: false,
        success: function (data) {
            deletePasswordModal.html(data);
            deletePasswordModal.find('.modal').modal('show');
            $('#DeleteSuccessDiv').hide();
        }
    });
}