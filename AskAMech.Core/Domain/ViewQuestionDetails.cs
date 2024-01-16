using System;

namespace AskAMech.Core.Domain
{
    public class ViewQuestionDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryDescription { get; set; }
        public int CreatedByUserId { get; set; }
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
