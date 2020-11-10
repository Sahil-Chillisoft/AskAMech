using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core.Domain
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string About { get; set; }
        public DateTime DateLastModified { get; set; }
    }
}
