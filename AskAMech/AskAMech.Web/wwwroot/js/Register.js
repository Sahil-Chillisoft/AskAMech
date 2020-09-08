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

        $("#ConfirmPassword").keyup(function () {
            if ($("#Password").val() != $("#ConfirmPassword").val()) {
                $("#msg").html("Password do not match").css("color", "red");
            } else {
                $("#msg").html("Password matched").css("color", "green");
            }
        });
    });
    

    registerModal.on('click',
        '[data-save="modal"]',
        function (event) {
            event.preventDefault();

            var $form = $(this).parents('.modal').find('form');
            $.validator.unobtrusive.parse($form);

            if ($form.valid()) {
                var formData = $form.serialize();
                $.ajax({
                    url: 'Home/Register',
                    type: 'POST',
                    cache: false,
                    data: formData
                })
                    .done(function (data) {
                    var modalContent = $('.modal-body', data);
                        registerModal.find('.modal-body')
                            .replaceWith(modalContent);
                        var isValid = modalContent.find('[name="IsValid"]')
                            .val() === 'True';
                    if (isValid) {
                        registerModal.find('.modal').modal('hide');
                        //TODO: Load the dashboard page if valid 
                    }
                });
            }
            else {
                return false;
            }
        });
});