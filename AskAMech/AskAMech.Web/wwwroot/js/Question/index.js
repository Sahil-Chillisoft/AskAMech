$(document).ready(function () {
    var search = $('#Search').val();
    var category = $('#CategoryId').val();

    if (search !== '' || category !== '') {
        var searchDiv = $('#searchDiv');
        searchDiv.show();
    }

    $('#SearchButton').click(function (event) {
        event.preventDefault();
        var searchDiv = $('#searchDiv');
        searchDiv.toggle();
    });
});