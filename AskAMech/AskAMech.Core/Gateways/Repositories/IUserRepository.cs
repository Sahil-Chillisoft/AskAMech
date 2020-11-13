using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IUserRepository
    {
        User GetUser(User user);
        User GetUserByEmployeeId(int? employeeId);
        bool IsExitingEmployeeUser(int? employeeId);
        User GetUserById(int? id);
        bool IsExistingUserEmail(string email);
        int Create(User user);
        void UpdateLastLoggedInDate(int? userId);
        void UpdatePassword(User user);

    }
}
