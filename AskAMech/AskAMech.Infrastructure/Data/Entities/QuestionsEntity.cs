using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Infrastructure.Data.Entities
{
    public class QuestionsEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }
    }
}
