using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class GetUserQuestionsResponse
    {
        public IEnumerable<ViewUserQuestions> UserQuestions { get; set; }
    }
}
