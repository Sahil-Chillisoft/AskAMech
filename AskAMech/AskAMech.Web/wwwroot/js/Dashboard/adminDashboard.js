function Navigate(id) {
    switch (id) {
        case 'divEmployees':
            window.location.href = '/Employee/Index';
            break;
        case 'divNewEmployees':
            window.location.href = '/Employee/Create'; 
            break;
        case 'divCreateUserFromEmployee':
            window.location.href = '/User/Create';
            break;
        case 'divNewQuestionCategory':
            window.location.href = '/Category/Create';
            break;
        case 'divUserRole':
            window.location.href = '/Roles/Create';
            break;
        case 'divMyProfile':
            window.location.href = '/User/Edit';
            break;
    }
}