$(document).ready(function () {

    $('#Delete').click(function (event) {
        event.preventDefault();
        displayDeleteConfirmationModal();
    });


    $('#ConfirmDelete').click(function (event) {
        event.preventDefault();
        deleteQuestion();
    });


    $('#CancelDelete').click(function (event) {
        event.preventDefault();
        window.location.reload();
    });
});

function deleteQuestion() {
    var id = $('#Id').val();
    $.ajax({
        url: '/Question/Delete',
        type: 'POST',
        cache: false,
        data: {
            'id': id
        },
        success: function (data) {
            if (data.success)
                window.location.href = '/Dashboard/UserDashboard';
        }
    });
}

function displayDeleteConfirmationModal() {
    var deleteQuestionModal = $('#DeleteQuestionDiv');
    $.ajax({
        url: '/Question/Delete',
        type: 'GET',
        cache: false,
        success: function (data) {
            deleteQuestionModal.html(data);
            deleteQuestionModal.find('.modal').modal('show');
        }
    });
}