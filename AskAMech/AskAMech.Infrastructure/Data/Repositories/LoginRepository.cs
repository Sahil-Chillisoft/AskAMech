using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Infrastructure.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public bool AuthenticateUserLogin(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
