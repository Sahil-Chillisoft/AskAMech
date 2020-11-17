﻿using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IAnswersRepository
    {
        void Add(Answer answer);
        List<ViewAnswers> GetAnswers(int questionId);
        List<ViewUserQuestionAnswers> GetUserQuestionAnswers(int userId);
    }
}
