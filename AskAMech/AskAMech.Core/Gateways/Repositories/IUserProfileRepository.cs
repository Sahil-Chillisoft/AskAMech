using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IUserProfileRepository
    {
        UserProfile GetUserProfile(int userId);
        bool IsExistingUsername(string username);
        string Create(UserProfile userProfile);
    }
}
