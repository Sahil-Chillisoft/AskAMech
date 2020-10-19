$(document).ready(function () {

    renderSearchDivOnPageLoad();

    $('#SearchButton').click(function (event) {
        event.preventDefault();
        var searchDiv = $('#searchDiv');
        searchDiv.toggle();
    });

    var currentPage = parseInt($('#Page').val());

    $('#PreviousPage').click(function (event) {
        event.preventDefault();
        getPagedResults(currentPage - 1);
    });

    $('#NextPage').click(function (event) {
        event.preventDefault();
        getPagedResults(currentPage + 1);
    });
});

function renderSearchDivOnPageLoad() {
    var search = $('#Search').val();
    var category = $('#CategoryId').val();

    if (search !== '' || category !== '') {
        var searchDiv = $('#searchDiv');
        searchDiv.show();
    }
}

function getPagedResults(page) {
    var search = $('#Search').val();
    var categoryId = $('#CategoryId').val();
    var url = 'Question/Index';

    $.get(url,
        {
            'Search': search,
            'CategoryId': categoryId,
            'Pagination.Page': page
        }).done(function (data) {
            $('body').html(data);
        });
}