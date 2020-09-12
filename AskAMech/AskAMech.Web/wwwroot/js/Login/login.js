$(document).ready(function () {
    var loginModal = $('#modalLoginDiv');

    $('#loginDialog').click(function (event) {
        event.preventDefault();
        var url = $(this).data('url');
        $.ajax({
            url: url,
            type: 'GET',
            cache: false,
            success: function (data) {
                loginModal.html(data);
                loginModal.find('.modal').modal('show');
            }
        });
    });

    loginModal.on('click',
        '[data-save="modal"]',
        function (event) {
            event.preventDefault();

            var $form = $(this).parents('.modal').find('form');
            $.validator.unobtrusive.parse($form);

            if ($form.valid()) {
                var formData = $form.serialize();
                $.ajax({
                    url: 'Home/Login',
                    type: 'POST',
                    cache: false,
                    data: formData
                }).done(function (data) {
                    var modalContent = $('.modal-body', data);
                    loginModal.find('.modal-body').replaceWith(modalContent);
                    var isValid = modalContent.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        loginModal.find('.modal').modal('hide');
                        $('.modal-backdrop').remove();
                        window.location.href = '/Dashboard/UserDashboard';
                    }
                });
            }
        });
});