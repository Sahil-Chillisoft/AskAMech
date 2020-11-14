using System;

namespace AskAMech.Core.Domain
{
    public class ViewAnswers
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public int AnsweredByUserId { get; set; }
        public bool IsAcceptedAnswer { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
