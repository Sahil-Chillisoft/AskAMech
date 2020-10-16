#nullable enable
using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IQuestionRepository
    {
        List<ViewQuestions> GetQuestions(string? search, int? categoryId);
    }
}