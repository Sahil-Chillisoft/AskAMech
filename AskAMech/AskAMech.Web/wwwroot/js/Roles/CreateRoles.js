$(document).ready(function () {
    

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
        showRolesList();
    });

    function showRolesList() {
        
        var description = $('#rolesListDiv');
        $.ajax({
            url: '/Roles/RolesList',
            type: 'GET',
            cache: false,
            success: function (data) {
                console.log(data);
                description.html(data)
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
});