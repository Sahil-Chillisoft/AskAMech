$('body').on('keyup', '#ConfirmPassword', function (event) {
    event.preventDefault();

    var confirmPassword = $('#ConfirmPassword').val();
    var password = $('#Password').val();

    if (isPasswordEmpty(password) && isConfirmPasswordEmpty(confirmPassword)) {
        createValidationResponse('', false, false);
    }
    else if (isPasswordEmpty(password)) {
        createValidationResponse('Cannot confirm password if password field is empty', true, false);
    }
    else if (isConfirmPasswordEmpty(confirmPassword)) {
        createValidationResponse('', false, false);
    }
    else {
        matchPasswords(confirmPassword, password);
    }
});

function isPasswordEmpty(password) {
    return password === null || password === '';
}

function isConfirmPasswordEmpty(confirmPassword) {
    return confirmPassword === null || confirmPassword === '';
}

function matchPasswords(confirmPassword, password) {
    if (confirmPassword !== password)
        createValidationResponse('Password does not match', true, false);
    else
        createValidationResponse('Password matches', false, true);
}

function createValidationResponse(message, addClass, addCss) {
    if (addClass && !addCss) {
        $('#PasswordMatcherValidation').html(message).addClass('text-danger');
    }
    else if (addCss && !addClass) {
        $('#PasswordMatcherValidation').html(message).removeClass('text-danger').css('color', '#008000');
    }
    else if (!addCss && !addClass) {
        $('#PasswordMatcherValidation').html(message).removeClass('text-danger');
    }
}