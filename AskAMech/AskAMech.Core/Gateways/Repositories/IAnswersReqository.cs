using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IAnswersRepository
    {
        void Create(Answer answer);
        List<ViewAnswers> GetAnswers(int questionId);
        List<ViewUserQuestionAnswers> GetUserQuestionAnswers(int userId, Pagination pagination);
        int GetUserQuestionAnswerCount(int userId);
        void UpdateIsAcceptedAnswer(int questionId, int answerId, bool isAcceptedAnswer);
        void ClearUpdatedAnswersForQuestion(int questionId);
    }
}
