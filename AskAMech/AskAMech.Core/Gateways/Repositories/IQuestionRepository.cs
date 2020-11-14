#nullable enable
using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IQuestionRepository
    {
        List<ViewQuestions> GetQuestions(string? search, int? categoryId, Pagination pagination);
        int GetCount(string? search, int? categoryId);
        void CreateQuestion(Question question);
        ViewQuestionDetails GetQuestionDetails(int id);
    }
}