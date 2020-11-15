$(document).ready(function () {

    $('#Save').click(function(event) {
        event.preventDefault();

        var $form = $('#EditQuestionForm');
        $.validator.unobtrusive.parse($form);

        if ($form.valid()) {
            var formData = $form.serialize();
            $.ajax({
                url: '/Question/Edit',
                type: 'POST', 
                cache: false, 
                enctype: 'multipart/form-data',
                processData: false,
                data: formData,
                success: function(data) {
                    if (data.success)
                        console.log('Edit was a success');
                    //TODO: Display a modal
                }
            });
        }
    });

});