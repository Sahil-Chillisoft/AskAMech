$(document).ready(function () {

    var questionId = $('#QuestionId').val();
    var isAcceptedAnswer = $('#AcceptedAnswer');

    $('#AcceptedAnswer').change(function (event) {
        event.preventDefault();
        if (isAcceptedAnswer.prop("checked") === true)
            updateAcceptedAnswerStatus(questionId, true);
        else
            updateAcceptedAnswerStatus(questionId, false);
    });
});

function updateAcceptedAnswerStatus(questionId, isAcceptedAnswer) {
    $.ajax({
        url: '/Answer/UpdateAcceptedAnswer',
        type: 'POST',
        cache: false,
        data: {
            'id': questionId,
            'isAcceptedAnswer': isAcceptedAnswer
        },
        success: function (data) {
            if (data.success) {
                console.log('Update Success');
                //Display Modal 
            }
        }
    });
}

function displayConfirmAcceptedAnswerModal() {
    $.ajax({
        url: '/Answer/ConfirmAcceptedAnswer',
        type: 'GET',
        cache: false,
        success: function (data) {
            if (data.success) {
                console.log('Update Success');
                //Display Modal 
            }
        }
    });
}