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
                    data = $.parseJSON(JSON.stringify(data));
                    response($.map(data.employeeDetails, function (item) {
                        return {
                            label: item["fullName"], value: item["fullName"]
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
        error: function () {
            console.log('Error retrieving data for auto-complete.');
        }
    });

    var currentPage = parseInt($('#Page').val());

    $('#SearchEmployees').click(function (event) {
        event.preventDefault();
        getResults(1, false);
    });

    $('#PreviousPage').click(function (event) {
        event.preventDefault();
        getResults(currentPage - 1, true);
    });

    $('#NextPage').click(function (event) {
        event.preventDefault();
        getResults(currentPage + 1, true);
    });

    pagingControls(currentPage);
});

function renderSearchDivOnPageLoad() {
    var search = $('#Search').val();

    if (search !== '') {
        var searchDiv = $('#searchDiv');
        searchDiv.show();
    }
}

function getResults(page, isPagingRequest) {
    var search = $('#Search').val();
    var totalPages = parseInt($('#TotalPages').val());
    var recordCount = parseInt($('#RecordCount').val());
    var url = '/Employee/Index';

    $.post(url,
        {
            'Search': search,
            'Pagination.Page': page,
            'Pagination.TotalPages': totalPages,
            'Pagination.RecordCount': recordCount,
            'Pagination.IsPagingRequest': isPagingRequest
        }).done(function (data) {
            $('body').html(data);
        });
}

function pagingControls(currentPage) {
    var totalPages = parseInt($('#TotalPages').val());
    var previousPageControl = $('#PreviousPage');
    var nextPageControl = $('#NextPage');

    if (currentPage === 1) {
        previousPageControl.attr('disabled', true);
        previousPageControl.removeClass('btn-success');
    } else {
        previousPageControl.prop('disabled', false);
    }

    if (currentPage === totalPages) {
        nextPageControl.attr('disabled', true);
        nextPageControl.removeClass('btn-success');
    } else {
        nextPageControl.prop('disabled', false);
    }
}