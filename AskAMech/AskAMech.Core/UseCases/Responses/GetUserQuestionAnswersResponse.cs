using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class GetUserQuestionAnswersResponse
    {
        public IEnumerable<ViewUserQuestionAnswers> UserQuestionAnswers { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int CategoryId { get; set; }
        public Pagination Pagination { get; set; }
    }
}
