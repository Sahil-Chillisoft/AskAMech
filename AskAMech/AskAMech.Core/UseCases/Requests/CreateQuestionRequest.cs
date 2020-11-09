using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core.UseCases.Requests
{
    public class CreateQuestionRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int AnswerCount { get; set; }
    }
}
