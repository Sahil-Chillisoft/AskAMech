function Navigate(id) {
    switch (id) {
        case 'divEmployees':
            window.location.href = '/Employee/Index';
            break;
        case 'divNewEmployees':
            window.location.href = '/Employee/Create'; 
            break;
        case 'divCreateUserFromEmployee':
            window.location.href = '';
            break;
        case 'divNewQuestionCategory':
            window.location.href = '/QuestionCatergory/Create';
            break;
        case 'divUserRole':
            window.location.href = '/Roles/Create';
            break;
    }
}