using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IAnswersRepository
    {
        void Create(Answer answer);
        List<ViewAnswers> GetAnswers(int questionId);
        List<ViewUserQuestionAnswers> GetUserQuestionAnswers(int userId, int? categoryId, Pagination pagination);
        int GetUserQuestionAnswerCount(int userId, int? categoryId);
        void UpdateIsAcceptedAnswer(int questionId, int answerId, bool isAcceptedAnswer);
        void ClearUpdatedAnswersForQuestion(int questionId);
        Answer GetAnswer(int questionId, int answerId);
        void Update(Answer answer);
        void Delete(Answer answer);
    }
}
