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