﻿using System;

namespace AskAMech.Infrastructure.Data.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRoleId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateLastLoggedIn { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
