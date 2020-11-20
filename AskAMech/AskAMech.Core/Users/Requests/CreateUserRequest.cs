using AskAMech.Core.Domain;

namespace AskAMech.Core.Users.Requests
{
    public class CreateUserRequest
    {
        public User User { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
