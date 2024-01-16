using System;

namespace AskAMech.Core.Domain
{
    public class ViewUserQuestionAnswers
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string CategoryDescription { get; set; }
        public string AskedBy { get; set; }
        public DateTime QuestionCreationDate { get; set; }
    }
}
