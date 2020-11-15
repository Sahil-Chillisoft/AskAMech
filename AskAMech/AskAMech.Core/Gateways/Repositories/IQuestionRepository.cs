#nullable enable
using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IQuestionRepository
    {
        List<ViewQuestions> GetQuestions(string? search, int? categoryId, Pagination pagination);
        Question GetQuestion(int id);
        int GetCount(string? search, int? categoryId);
        void CreateQuestion(Question question);
        ViewQuestionDetails GetQuestionDetails(int id);
        void Update(Question question);
    }
}