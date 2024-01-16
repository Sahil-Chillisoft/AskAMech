using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Questions.Responses
{
    public class CreateQuestionResponse
    {
        public Question Question { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
