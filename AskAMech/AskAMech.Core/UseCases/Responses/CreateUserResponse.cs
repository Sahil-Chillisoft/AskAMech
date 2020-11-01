using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class CreateUserResponse
    {
        public User User { get; set; }

        public UserProfile UserProfile { get; set; }

        public Employee Employee { get; set; }

        public IEnumerable<Roles> Roles { get; set; }

        public string Search { get; set; }

        public string ErrorMessage { get; set; }
    }
}
