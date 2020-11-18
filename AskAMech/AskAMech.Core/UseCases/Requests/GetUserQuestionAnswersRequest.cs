using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Requests
{
    public class GetUserQuestionAnswersRequest
    {
        public ViewUserQuestionAnswers questionAnswers { get; set; }
        public string Search { get; set; }
        public int CategoryId { get; set; }
        public Pagination Pagination { get; set; }
    }
}
