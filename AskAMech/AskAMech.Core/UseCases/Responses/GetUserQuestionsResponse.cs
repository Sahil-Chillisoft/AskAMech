using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class GetUserQuestionsResponse
    {
        public List<ViewUserQuestions> UserQuestions { get; set; }
        public Pagination Pagination { get; set; }
        public bool IsFirstLoad { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
