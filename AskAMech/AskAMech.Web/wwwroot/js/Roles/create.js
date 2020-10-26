$(document).ready(function () {

    getRolesList();

    $('#create').click(function (event) {
        event.preventDefault();

        var $form = $('#RoleCreateForm');
        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            var formData = $form.serialize();
            $.ajax({
                url: '/Roles/Create',
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

    function getRolesList() {
        var description = $('#rolesListDiv');
        $.ajax({
            url: '/Roles/RolesList',
            type: 'GET',
            cache: false,
            success: function (data) {
                description.html(data);
            }
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

    $('#Confirm').click(function (event) {
        event.preventDefault();
        $('#successModal').modal('hide');
        $('#Description').val('');
        $('#ErrorMessage').text('');
        getRolesList();
    });
});