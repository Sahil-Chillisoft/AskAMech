$(document).ready(function () {

    showCategoryList();

    $('#Create').click(function (event) {
        event.preventDefault();

        var $form = $('#CategoryCreateForm');
        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            var formData = $form.serialize();
            $.ajax({
                url: '/Category/Create',
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

    function showCategoryList() {
        var description = $('#categoryListDiv');
        $.ajax({
            url: '/Category/QuestionCategoryList',
            type: 'GET',
            cache: false,
            success: function (data) {
                description.html(data)
            }
        });
    }

    function displaySuccessModal() {
        var successModal = $('#createSuccessDiv');
        $.ajax({
            url: '/Category/CreateSuccess',
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
        $('#ErrorMessage').text('');
        showCategoryList();
    });
});