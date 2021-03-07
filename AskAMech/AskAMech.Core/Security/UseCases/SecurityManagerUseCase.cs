using AskAMech.Core.Domain;
using AskAMech.Core.Security.Interfaces;

namespace AskAMech.Core.Security.UseCases
{
    public class SecurityManagerUseCase : ISecurityManagerUseCase
    {
        public UserSecurityManager UserSecurity;

        public void SignOut()
        {
            UserSecurity = new UserSecurityManager(0, string.Empty, 0, false);
        }

        public void InitializeUser(int userId, string username, int userRoleId, bool isAuthenticated)
        {
            UserSecurity = new UserSecurityManager(userId, username, userRoleId, isAuthenticated);
        }
    }
}
