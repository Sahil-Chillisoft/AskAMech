namespace AskAMech.Core.Security.Interfaces
{
    public interface ISecurityManagerUseCase
    {
        void SignOut();
        void InitializeUser(int userId, string username, int userRoleId, bool isAuthenticated);
    }
}
