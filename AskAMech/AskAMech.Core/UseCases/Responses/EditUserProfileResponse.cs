using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class EditUserProfileResponse
    {
        public virtual User User { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
