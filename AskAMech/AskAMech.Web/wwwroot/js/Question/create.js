$(document).ready(function () {

    $('#Create').click(function (event) {
        event.preventDefault();
        var url = '/Question/Create';
        var request = getFormData();
        $.post(url, request).done(function (data) {
            if (data.success) {
                displaySuccessModal();
            } 
        });
    });

    $('#Confirm').click(function (event) {
        event.preventDefault();
        window.location.reload();
        //TODO: Redirect the user to the view/edit version of their question
    });
});

function getFormData() {
    var data = {
        'title': $('#Title').val(),
        'description': $('#Description').val(),
        'categoryId': $('#CategoryId').val()
    }
    return data;
}

function displaySuccessModal() {
    var successModal = $('#QuestionSuccessDiv');
    $.ajax({
        url: '/Question/CreateSuccess',
        type: 'GET',
        cache: false,
        success: function (data) {
            successModal.html(data);
            successModal.find('.modal').modal('show');
        }
    });
}