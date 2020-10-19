$(document).ready(function () {

    $('#AddNewRole').click(function (event) {
        event.preventDefault();
        window.location.href = '/Roles/Index';
    });

    $('#Dashboard').click(function (event) {
        event.preventDefault();
        window.location.href = '/Dashboard/AdminDashboard';
    });

});