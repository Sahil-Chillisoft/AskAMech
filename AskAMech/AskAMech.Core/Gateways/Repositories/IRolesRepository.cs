using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IRolesRepository
    {
         List<Roles> getAllRoles();
         int Create(Roles roles);
         bool IsExistingRole(string description);
    }
}
