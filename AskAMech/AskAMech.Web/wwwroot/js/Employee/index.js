$(document).ready(function () {

    renderSearchDivOnPageLoad();

    $('#SearchButton').click(function (event) {
        event.preventDefault();
        var searchDiv = $('#searchDiv');
        searchDiv.toggle();
    });

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
                    response(data.employeeDetails);
                }
            });
        },
        search: function (event, ui) {
            $(this).addClass('loadingAutocomplete');
        },
        response: function (event, ui) {
            $(this).removeClass('loadingAutocomplete');
        },
        error: function () {
            console.log('Error retrieving data for auto-complete.');
        }
    });

});

function renderSearchDivOnPageLoad() {
    var search = $('#Search').val();

    if (search !== '') {
        var searchDiv = $('#searchDiv');
        searchDiv.show();
    }
}