using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateLastLoggedIn { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }
    }
}
