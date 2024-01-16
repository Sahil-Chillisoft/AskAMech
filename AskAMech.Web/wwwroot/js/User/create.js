$(document).ready(function () {

    $("#Search").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Employee/GetEmployeesAutocomplete",
                type: "POST",
                dataType: "JSON",
                data: {
                    search: request.term
                },
                success: function (data) {
                    data = $.parseJSON(JSON.stringify(data));
                    response($.map(data.employeeDetails, function (item) {
                        return {
                            label: item["fullName"], value: item["id"]
                        };
                    }));
                }
            });
        },
        search: function () {
            $(this).addClass('loadingAutocomplete');
        },
        response: function () {
            $(this).removeClass('loadingAutocomplete');
        },
        select: function (event, ui) {
            event.preventDefault();
            var item = ui.item;
            $('#Search').val(item.label);
            $('#EmployeeId').val(item.value);
        },
        error: function () {
            console.log('Error retrieving data for auto-complete.');
        }
    });


    $('#LoadEmployee').click(function (event) {
        event.preventDefault();
        if (isEmployeeDataValid()) {
            $('#Info').text('').removeClass('text-danger');
            var employeeId = $('#EmployeeId').val();
            getEmployeeDetails(employeeId);
        } else {
            $('#Info').text('Please select an employee from the autocomplete to load').addClass('text-danger');
        }
    });


    $('#ClearEmployee').click(function (event) {
        event.preventDefault();
        $('#EmployeeId').val('');
        $('#Search').val('');
        $('#Info').text('');
        $('#createUserDiv').html('');
        $('#ClearEmployee').hide();
    });

    $('#CreateUser').click(function (event) {
        event.preventDefault();
        if (isValidUserData()) {
            createUser();
        } else {
            $('#UsernameValidation').show();
        }
    });

    $('#AddNewUser').click(function (event) {
        event.preventDefault();
        window.location.href = '/User/Create';
    });

    $('#Dashboard').click(function (event) {
        event.preventDefault();
        window.location.href = '/Dashboard/AdminDashboard';
    });

});

function isEmployeeDataValid() {
    if (isEmployeeIdEmpty() === true || isSearchEmpty() === true)
        return false;
    else
        return true;
}

function isEmployeeIdEmpty() {
    var employeeId = $('#EmployeeId').val();
    return employeeId === null || employeeId === '';
}

function isSearchEmpty() {
    var search = $('#Search').val();
    return search === null || search === '';
}

function loadInfo(employeeId) {
    $('#ClearEmployee').show();
    $('#Info').text('Employee ' + employeeId + ' is loaded').removeClass('text-danger');
}

function getEmployeeDetails(employeeId) {
    $.ajax({
        url: '/User/GetEmployee',
        type: 'POST',
        cache: false,
        data: {
            'employeeId': employeeId
        }
    }).done(function (data) {
        $('#createUserDiv').html(data);
        loadInfo(employeeId);
    });
}

function isValidUserData() {
    var username = $('#Username').val();
    return username !== '';
}

function createUser() {
    var user = getUserData();
    var userProfile = getUserProfileData();

    $.ajax({
        url: '/User/Create',
        type: 'POST',
        cache: false,
        data: {
            'user': user,
            'userProfile': userProfile
        }
    }).done(function (data) {
        var successModal = $('#createSuccessDiv');
        successModal.html(data);
        successModal.find('.modal').modal('show');
    });
}

function getUserData() {
    var user = {
        email: $('#Email').val(),
        password: $('#Password').val(),
        userRoleId: $('#RoleId').val(),
        employeeId: $('#EmployeeId').val()
    }
    return user;
}

function getUserProfileData() {
    var userProfile = {
        username: $('#Username').val()
    }
    return userProfile;
}