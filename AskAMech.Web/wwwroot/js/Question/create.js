$(document).ready(function () {
    $('#Create').click(function (event) {
        event.preventDefault();

        if (isValidData()) {
            var url = '/Question/Create';
            var request = getFormData();
            $.post(url, request).done(function (data) {
                if (data.success) {
                    displaySuccessModal();
                }
            });
        }
    });

    $('#Confirm').click(function (event) {
        event.preventDefault();
        window.location.href = '/Dashboard/UserDashboard';
    });
});

function isValidData() {
    var isValid = true;
    var title = $('#Title').val();
    var description = $('#Description').val();

    if (title === '') {
        $('#TitleValidation').text('* Question Title Required');
        isValid = false;
    }

    if (description === '') {
        $('#DescriptionValidation').text('* Question Description Required');
        isValid = false;
    }

    return isValid;
}

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