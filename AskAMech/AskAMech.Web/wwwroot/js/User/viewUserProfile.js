$(document).ready(function () {
    var userId = $('#UserId').val();
    getUserQuestions(userId);
});

function getUserQuestions(userId) {
    var userQuestionsDiv = $('#UserQuestionsDiv');
    $.ajax({
        url: '/User/UserQuestions',
        type: 'GET',
        cache: false,
        data: {
            'id': userId
        }
    }).done(function (data) {
        userQuestionsDiv.html(data);
    });
}