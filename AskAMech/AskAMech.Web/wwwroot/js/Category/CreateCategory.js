$(document).ready(function () {

    showCatergoryList();

    $('#Create').click(function (event) {
        event.preventDefault();

        var $form = $('#CategoryCreateForm');
        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            var formData = $form.serialize();
            $.ajax({
                url: '/Catergory/Create',
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

    function showCatergoryList() {

        var description = $('#categoryListDiv');
        $.ajax({
            url: '/Catergory/QuestionCatergoryList',
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
            url: '/Catergory/CreateSuccess',
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
        showCatergoryList();
    });
});