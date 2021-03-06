﻿$(document).ready(function () {

    renderSearchDivOnPageLoad();

    $('#SearchButton').click(function (event) {
        event.preventDefault();
        var searchDiv = $('#searchDiv');
        searchDiv.toggle();
    });

    var currentPage = parseInt($('#Page').val());

    $('#Search').click(function (event) {
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
    var category = $('#CategoryId').val();

    if (category !== '') {
        var searchDiv = $('#searchDiv');
        searchDiv.show();
    }
}

function getResults(page, isPagingRequest) {

    var categoryId = parseInt($('#CategoryId').val());
    var totalPages = parseInt($('#TotalPages').val());
    var recordCount = parseInt($('#RecordCount').val());
    var url = '/Answer/MyAnswers';

    $.post(url,
        {
            'CategoryId': categoryId,
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