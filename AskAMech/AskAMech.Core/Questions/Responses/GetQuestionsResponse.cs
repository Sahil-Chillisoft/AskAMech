using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Questions.Responses
{
    public class GetQuestionsResponse : Pagination
    {
        public IEnumerable<ViewQuestions> Questions { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string Search { get; set; }
        public int CategoryId { get; set; }
        public Pagination Pagination { get; set; }
    }
}
