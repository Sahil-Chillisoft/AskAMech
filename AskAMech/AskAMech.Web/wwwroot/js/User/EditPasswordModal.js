$(document).ready(function () {
    var verifyModal = $('#VerifyPasswordDiv');

    $('#UpdatePassword').click(function (event) {
        event.preventDefault();
        $.ajax({
            url: '/User/UpdatePassword',
            type: 'GET',
            cache: false,
                verifyModal.find('.modal').modal('show');
            }
        });


        updateModal.on('click',
            '[data-save="modal"]',
            function (event) {
                event.preventDefault();

                var $form = $(this).parents('.modal').find('form');
                $.validator.unobtrusive.parse($form);

                if ($form.valid()) {
                    var formData = $form.serialize();
                    updateModal.find('[id="loadingImg"]').removeClass('hide');

                    $.ajax({
                        url: 'User/UpdatePassword',
                        type: 'POST',
                        cache: false,
                        data: formData
                    }).done(function (data) {
                        updateModal.find('[id="loadingImg"]').addClass('hide');

                        var modalContent = $('.modal-body', data);
                        updateModal.find('.modal-body').replaceWith(modalContent);

                        var isValid = modalContent.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            updateModal.find('.modal').modal('hide');
                            $('.modal-backdrop').remove();
                            window.location.href = '/Dashboard/UserDashboard';
                        }
                    });
                }
            });
    });
});