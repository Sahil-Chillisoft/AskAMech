function Navigate(id) {
    switch (id) {
        case 'divMyQuestions':
            window.location.href = '';
            break;
        case 'divMyAnswers':
            window.location.href = '';
            break;
        case 'divLatestQuestions':
            window.location.href = '';
            break;
        case 'divNewQuestions':
            window.location.href = '/Question/Create';
            break;
        case 'divMyProfile':
            window.location.href = '/User/Edit';
            break;
    }
}