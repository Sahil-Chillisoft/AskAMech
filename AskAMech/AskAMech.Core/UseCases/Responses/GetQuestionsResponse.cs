using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class GetQuestionsResponse
    {
        public List<ViewQuestions> Questions { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string Search { get; set; }
        public int CategoryId { get; set; }
        public Pagination Pagination { get; set; }
    }
}
