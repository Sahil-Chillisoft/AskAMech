$(document).ready(function () {
    var registerModal = $('#modalRegisterDiv');

    $('#registerDialog').click(function (event) {
        event.preventDefault();
        var url = $(this).data('url');
        $.ajax({
            url: url,
            type: 'GET',
            cache: false,
            success: function (data) {
                registerModal.html(data);
                registerModal.find('.modal').modal('show');
            }
        });

        registerModal.on('click',
            '[data-save="modal"]',
            function (event) {
                event.preventDefault();

                var $form = $(this).parents('.modal').find('form');
                $.validator.unobtrusive.parse($form);

                if ($form.valid()) {
                    var formData = $form.serialize();
                    registerModal.find('[id="loadingImg"]').removeClass('hide');

                    $.ajax({
                        url: 'Home/Register',
                        type: 'POST',
                        cache: false,
                        data: formData
                    }).done(function (data) {
                        registerModal.find('[id="loadingImg"]').addClass('hide');

                        var modalContent = $('.modal-body', data);
                        registerModal.find('.modal-body').replaceWith(modalContent);

                        var isValid = modalContent.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            registerModal.find('.modal').modal('hide');
                            $('.modal-backdrop').remove();
                            window.location.href = '/Dashboard/UserDashboard';
                        }
                    });
                }
            });
    });

    registerModal.on('change',
        '[Checkbox_CheckedChanged="modal"]',
        function (event) {
            event.preventDefault();
            var password = registerModal.find('[id="Password"]');
            var confirmPassword = registerModal.find('[id="ConfirmPassword"]');
            if (password.attr('type') === 'password') {
                password.attr('type', 'text');
                confirmPassword.attr('type', 'text');
            } else {
                password.attr('type', 'password');
                confirmPassword.attr('type', 'password');
            }
        });
});
