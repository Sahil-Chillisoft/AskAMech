using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core.Domain
{
    public class ViewUserQuestionAnswers
    {
        public int QuestionId { get; set; }
        public string QuestiotionDescription { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public int QuestionAnswerCategoryId { get; set; }
        public string AskedBy { get; set; }
        public DateTime QuestionCreationDate { get; set; }
    }
}
