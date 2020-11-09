using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class CreateQuestionResponse
    {

        public ViewQuestions viewQuestions { get; set; }

        public IEnumerable<Category> category { get; set; }
    }
}
