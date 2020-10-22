$(document).ready(function () {

    $('#ok').click(function (event) {
        event.preventDefault();
        $('#successModal').modal('hide');
        
    });

    $('#Dashboard').click(function (event) {
        event.preventDefault();
        window.location.href = '/Dashboard/AdminDashboard';
    });

});