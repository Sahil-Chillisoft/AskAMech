$(document).ready(function () {

    $('#AddNewEmployee').click(function (event) {
        event.preventDefault();
        window.location.href = '/Employee/Create';
    });

    $('#Dashboard').click(function (event) {
        event.preventDefault();
        window.location.href = '/Dashboard/AdminDashboard';
    });

});