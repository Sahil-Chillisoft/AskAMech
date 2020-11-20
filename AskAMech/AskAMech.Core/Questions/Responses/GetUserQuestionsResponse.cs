using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Questions.Responses
{
    public class GetUserQuestionsResponse
    {
        public IEnumerable<ViewUserQuestions> UserQuestions { get; set; }
        public Pagination Pagination { get; set; }
        public bool IsFirstLoad { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
