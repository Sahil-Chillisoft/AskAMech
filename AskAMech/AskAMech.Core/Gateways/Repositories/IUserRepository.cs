using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IUserRepository
    {
        User GetUser(User user);
        User GetUserById(int id);
        User GetUserByEmployeeId(int employeeId);
        bool IsExistingUserEmail(string email);
        bool IsExitingEmployeeUser(int employeeId);
        int Create(User user);
        void UpdatePassword(User user);
        void UpdateLastLoggedInDate(int userId);
    }
}
