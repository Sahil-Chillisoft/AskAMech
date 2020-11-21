$(document).ready(function () {

    $('#Save').click(function (event) {
        event.preventDefault();

        var $form = $('#EditQuestionForm');
        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            var formData = $form.serialize();
            $.ajax({
                url: '/Question/Edit',
                type: 'POST',
                cache: false,
                enctype: 'multipart/form-data',
                processData: false,
                data: formData,
                success: function (data) {
                    if (data.success)
                        displayEditSuccessModal();
                }
            });
        }
    });


    $('#Confirm').click(function (event) {
        event.preventDefault();
        window.location.reload();
    });
});

function displayEditSuccessModal() {
    var successModal = $('#QuestionEditSuccessDiv');
    $.ajax({
        url: '/Question/EditSuccess',
        type: 'GET',
        cache: false,
        success: function (data) {
            successModal.html(data);
            successModal.find('.modal').modal('show');
        }
    });
}