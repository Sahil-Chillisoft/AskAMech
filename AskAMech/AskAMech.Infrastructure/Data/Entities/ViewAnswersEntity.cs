using System;

namespace AskAMech.Infrastructure.Data.Entities
{
    public class ViewAnswersEntity
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public int AnsweredByUserId { get; set; }
        public string Username { get; set; }
        public bool IsAcceptedAnswer { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
