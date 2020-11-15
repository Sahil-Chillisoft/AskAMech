using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class GetViewQuestionResponse
    {
        public ViewQuestionDetails QuestionDetails { get; set;}
        public IEnumerable<ViewAnswers> Answers { get; set; }
    }
}
