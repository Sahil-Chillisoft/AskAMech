using AskAMech.Core.Domain;

namespace AskAMech.Core.Users.Requests
{
    public class EditUserProfileRequest
    {
        public virtual UserProfile UserProfile { get; set; }
        public virtual User User { get; set; }
    }
}
