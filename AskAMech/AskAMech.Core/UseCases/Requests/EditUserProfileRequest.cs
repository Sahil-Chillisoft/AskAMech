using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Requests
{
    public class EditUserProfileRequest
    {
        public virtual UserProfile UserProfile { get; set; }
        public virtual User User { get; set; }
    }
}
