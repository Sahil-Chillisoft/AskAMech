using System;

namespace AskAMech.Infrastructure.Data.Entities
{
    public class ViewQuestionsEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int AnswerCount { get; set; }
    }
}
