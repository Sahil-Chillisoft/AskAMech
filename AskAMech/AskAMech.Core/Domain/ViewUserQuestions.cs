using System;

namespace AskAMech.Core.Domain
{
    public class ViewUserQuestions
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }
        public int AnswerCount { get; set; }
    }
}
