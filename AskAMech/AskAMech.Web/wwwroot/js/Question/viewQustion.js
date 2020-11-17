$(document).ready(function () {

    $('#AcceptedAnswer').change(function(event) {
        event.preventDefault();
        var isAcceptedAnswer = $('#AcceptedAnswer');
        if (isAcceptedAnswer.prop("checked") === true)
            console.log('Checked');
        else
            console.log('Unchecked');
    });
});

function updateAcceptedAnswerStatus(questionId, isAcceptedAnswer) {
    $.ajax({
        url: '',
        type: 'POST',
        cache: false,
        data: {
            'id': questionId, 
            'isAcceptedAnswer': isAcceptedAnswer
        }, 
        success: function(data) {
            if (data.success) {
                console.log('Update Success');
                //Display Modal 
            }
        }
    });
}