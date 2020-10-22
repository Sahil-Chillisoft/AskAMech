$(document).ready(function () {
    showRolesList();
    $('#create').click(function (event) {
        event.preventDefault();

        var $form = $('#RoleCreateForm');
        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            var formData = $form.serialize();
            $.ajax({
                url: '/Roles/Index',
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

    function showRolesList() {
        var description = $('#Description').val();
        var url = '/Roles/RolesList';

        $.get(url,
            {
                'Description': description
            }).done(function (data) {
                $('body').html(data);
            });

    }
    function displaySuccessModal() {
        var successModal = $('#createSuccessDiv');
        $.ajax({
            url: '/Roles/CreateSuccess',
            type: 'GET',
            cache: false,
            success: function (data) {
                successModal.html(data);
                successModal.find('.modal').modal('show');
            }
        });
    }
});