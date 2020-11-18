using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class GetUserQuestionAnswersResponse
    {
        public List<ViewUserQuestionAnswers> userQuestions { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string Search { get; set; }
        public int CategoryId { get; set; }
        public Pagination Pagination { get; set; }
    }
}
