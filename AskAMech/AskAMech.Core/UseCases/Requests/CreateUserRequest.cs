using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Requests
{
    public class CreateUserRequest
    {
        public User User { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
