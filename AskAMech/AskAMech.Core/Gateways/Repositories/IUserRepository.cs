using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IUserRepository
    {
        User GetUser(User user);
        int GetUserBy(int id);
        int GetUserBy(string email);
        bool IsExistingUserEmail(string email);
        int Create(User user);
        void UpdateLastLoggedInDate(int userId);
    }
}
