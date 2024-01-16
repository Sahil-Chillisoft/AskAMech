$(document).ready(function () {

    var answerId = $('#EditAnswerId').val();
    var questionId = $('#EditAnswerQuestionId').val();

    $('#SaveEditAnswer').click(function (event) {
        event.preventDefault();
        if (isValidAnswer())
            saveAnswer(answerId, questionId);
        else
            $('#EditAnswerValidation').text('* Answer cannot be blank');
    });

    $('#CloseEditAnswer').click(function (event) {
        event.preventDefault();
        window.location.reload();
    });
});

function isValidAnswer() {
    var answer = $('#ModifiedAnswer').val();
    console.log(answer);
    if (answer === '')
        return false;
    else
        return true;
}

function saveAnswer(answerId, questionId) {
    var answer = $('#ModifiedAnswer').val();
    $.ajax({
        url: '/Answer/Edit',
        type: 'POST',
        cache: false,
        data: {
            'description': answer,
            'answerId': answerId,
            'questionId': questionId
        },
        success: function (data) {
            if (data.success) {
                window.location.reload();
            }
        }
    });
}