using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Infrastructure.Data.Entities
{
    public class UserProfileEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string About { get; set; }
        public DateTime DateLastModified { get; set; }
    }
}
