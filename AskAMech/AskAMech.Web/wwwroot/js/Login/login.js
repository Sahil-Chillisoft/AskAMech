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
                loginModal.find('[id="loadingImg"]').removeClass('hide');

                $.ajax({
                    url: 'Home/Login',
                    type: 'POST',
                    cache: false,
                    data: formData
                }).done(function (data) {
                    loginModal.find('[id="loadingImg"]').addClass('hide');

                    var modalContent = $('.modal-body', data);
                    loginModal.find('.modal-body').replaceWith(modalContent);

                    var isValid = modalContent.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        loginModal.find('.modal').modal('hide');
                        $('.modal-backdrop').remove();
                        var userRoleId = modalContent.find('[name="UserRoleId"]').val();
                        loadDashboard(userRoleId);
                    }
                });
            }
        });
});

function loadDashboard(userRoleId) {
    if (userRoleId === '1')
        window.location.href = '/Dashboard/AdminDashboard';
    else
        window.location.href = '/Dashboard/UserDashboard';
}
