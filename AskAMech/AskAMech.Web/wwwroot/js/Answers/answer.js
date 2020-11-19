$(document).ready(function () {

    $('#ConfirmAcceptedAnswer').click(function (event) {
        event.preventDefault();
        updateAcceptedAnswerStatus();
    });

    $('#CloseConfirmAcceptedAnswer').click(function (event) {
        event.preventDefault();
        window.location.reload();
    });
});

var questionId = $('#QuestionId').val();
var answerId;
var isChecked;

function onMarkAsAcceptedAnswerChange(checkbox, id) {
    answerId = id;
    isChecked = checkbox.checked;
    displayConfirmAcceptedAnswerModal(isChecked);
}

function updateAcceptedAnswerStatus() {
    $.ajax({
        url: '/Answer/UpdateAcceptedAnswer',
        type: 'POST',
        cache: false,
        data: {
            'questionId': questionId,
            'answerId': answerId,
            'isAcceptedAnswer': isChecked
        },
        success: function (data) {
            if (data.success) {
                window.location.reload();
            }
        }
    });
}

function displayConfirmAcceptedAnswerModal(isAcceptedAnswer) {
    var confirmAcceptedAnswerModal = $('#ConfirmAcceptedAnswerDiv');
    $.ajax({
        url: '/Answer/ConfirmAcceptedAnswer',
        type: 'GET',
        cache: false,
        data: { 'isAcceptedAnswer': isAcceptedAnswer },
        success: function (data) {
            confirmAcceptedAnswerModal.html(data);
            confirmAcceptedAnswerModal.find('.modal').modal('show');
        }
    });
}