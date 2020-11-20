using System;

namespace AskAMech.Infrastructure.Data.Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Email { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public int LastModifiedByUserId { get; set; }
        public DateTime DateLastModified { get; set; }
        public bool IsActive { get; set; }
    }
}
