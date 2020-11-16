$(document).ready(function () {
    var userId = $('#UserId').val();

    var isFirstLoad = $('#IsFirstLoad').val();
    if (isFirstLoad == undefined) {
        isFirstLoad = true;
    } else {
        isFirstLoad = false;
    }

    if (isFirstLoad)
        getUserQuestions(userId, 1, false, true);

    var currentPage = parseInt($('#Page').val());

    $('#PreviousPage').click(function (event) {
        event.preventDefault();
        getUserQuestions(userId, currentPage - 1, true, isFirstLoad);
    });

    $('#NextPage').click(function (event) {
        event.preventDefault();
        getUserQuestions(userId, currentPage + 1, true, isFirstLoad);
    });

    pagingControls(currentPage);
});

function getUserQuestions(userId, page, isPagingRequest, isFirstLoad) {
    var userQuestionsDiv = $('#UserQuestionsDiv');
    var totalPages = parseInt($('#TotalPages').val());
    var recordCount = parseInt($('#RecordCount').val());
    var url = '/User/UserQuestions';

    $.post(url,
        {
            'userId': userId,
            'Pagination.Page': page,
            'Pagination.TotalPages': totalPages,
            'Pagination.RecordCount': recordCount,
            'Pagination.IsPagingRequest': isPagingRequest,
            'isFirstLoad': isFirstLoad
        }).done(function (data) {
            userQuestionsDiv.html(data);
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