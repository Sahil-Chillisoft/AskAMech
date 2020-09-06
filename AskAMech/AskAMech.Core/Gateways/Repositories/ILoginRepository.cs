using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface ILoginRepository
    {
        User GetUser(string email, string password);
    }
}
