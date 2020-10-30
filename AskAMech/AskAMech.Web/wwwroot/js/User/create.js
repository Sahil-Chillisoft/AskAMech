$(document).ready(function () {

    $('#ClearEmployee').hide();

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
            loadInfo(item.value);
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
        $('#ClearEmployee').hide();
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
        console.log(data);
    });
}

