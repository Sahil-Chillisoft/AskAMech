using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Infrastructure.Data.Helpers;

namespace AskAMech.Infrastructure.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SqlHelper _sqlHelper;

        public LoginRepository(SqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
        }

        public bool AuthenticateUserLogin(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
