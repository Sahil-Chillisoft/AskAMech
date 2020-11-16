using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IUserProfileRepository
    {
        UserProfile GetUserProfile(int userId);
        bool IsExistingUsername(string username);
        void Create(UserProfile userProfile);
        void Update(UserProfile userProfile);
        
    }
}
