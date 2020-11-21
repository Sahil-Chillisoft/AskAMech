$(document).ready(function () {

    $('#ConfirmAcceptedAnswer').click(function (event) {
        event.preventDefault();
        updateAcceptedAnswerStatus();
    });


    $('#CloseConfirmAcceptedAnswer').click(function (event) {
        event.preventDefault();
        window.location.reload();
    });


    $('#PostAnswer').click(function (event) {
        event.preventDefault();
        var isAuthenticatedUser = $('#IsAuthenticatedUser').val();
        if (isAuthenticatedUser === 'True')
            displayAnswerModal();
        else
            displayErrorModal();
    });


    $('#CreateAnswer').click(function (event) {
        event.preventDefault();
        var answer = $('#Answer').val();
        if (isValidAnswer(answer)) {
            createAnswer(answer);
        }
        else {
            $('#AnswerValidation').text('* Answer cannot be blank');
        }
    });


    $('#ClosePostAnswer').click(function (event) {
        event.preventDefault();
        window.location.reload();
    });


    $('#ConfirmError').click(function (event) {
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

function createAnswer(answer) {
    $.ajax({
        url: '/Answer/Create',
        type: 'POST',
        cache: false,
        data: {
            'questionId': questionId,
            'description': answer
        },
        success: function (data) {
            if (data.success) {
                window.location.reload();
            }
        }
    });
}

function isValidAnswer(answer) {
    if (answer === '')
        return false;
    else
        return true;
}

function editAnswerOnClick(answerId) {
    displayEditAnswerModal(questionId, answerId);
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

function displayAnswerModal() {
    var answerModal = $('#CreateAnswerDiv');
    $.ajax({
        url: '/Answer/Create',
        type: 'GET',
        cache: false,
        success: function (data) {
            answerModal.html(data);
            answerModal.find('.modal').modal('show');
        }
    });
}

function displayEditAnswerModal(questionId, answerId) {
    var editAnswerModal = $('#EditAnswerDiv');
    $.ajax({
        url: '/Answer/Edit',
        type: 'GET',
        cache: false,
        data: {
            'questionId': questionId,
            'answerId': answerId
        },
        success: function (data) {
            editAnswerModal.html(data);
            editAnswerModal.find('.modal').modal('show');
        }
    });
}

function displayErrorModal() {
    var errorModal = $('#ErrorDiv');
    $.ajax({
        url: '/Answer/Error',
        type: 'GET',
        cache: false,
        success: function (data) {
            errorModal.html(data);
            errorModal.find('.modal').modal('show');
        }
    });
}