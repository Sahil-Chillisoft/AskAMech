$(document).ready(function () {
    getCategories();
    $('#CreateQuestion').click(function (event) {
        event.preventDefault();

        var $form = $('#CreateQuestionForm');
        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            var formData = $form.serialize();
            $.ajax({
                url: '/Question/Create',
                type: 'POST',
                cache: false,
                enctype: 'multipart/form-data',
                processData: false,
                data: formData,
                success: function (data) {
                    if (data.success) {
                        displaySuccessModal();
                    } else {
                        $('#ErrorMessage').text(data.message);
                    }
                }
            });
        }
    });

    function getCategories() {
        
        $.ajax({
            url: '/Question/Create',
            type: 'GET',
            cache: false,
            success: function (data) {
                description.html(data);
            }
        });
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

    $('#Confirm').click(function (event) {
        event.preventDefault();
        $('#successModal').modal('hide');
        $('#Description').val('');
        $('#CategoryId').val('');
    });

});