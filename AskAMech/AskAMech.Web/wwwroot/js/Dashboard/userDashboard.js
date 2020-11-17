function Navigate(id) {
    switch (id) {
        case 'divMyQuestions':
            window.location.href = '/User/MyQuestion';
            break;
        case 'divMyAnswers':
            window.location.href = '';
            break;
        case 'divLatestQuestions':
            window.location.href = '/Question/Index';
            break;
        case 'divNewQuestion':
            window.location.href = '/Question/Create';
            break;
        case 'divMyProfile':
            window.location.href = '/User/Edit';
            break;
    }
}