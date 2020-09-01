using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface ILoginRepository
    {
        bool AuthenticateUserLogin(string email, string password);
    }
}
