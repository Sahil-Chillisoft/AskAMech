using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Infrastructure.Data.Entities
{
    public class ViewUserQuestionAnswersEntity
    {
        public int QuestionId { get; set; }
        public string QuestiotionDescription { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public string AskedBy { get; set; }
        public DateTime QuestionCreationDate { get; set; }
    }
}
