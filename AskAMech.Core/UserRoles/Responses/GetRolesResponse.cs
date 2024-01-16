using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UserRoles.Responses
{
    public class GetRolesResponse
    {
        public IEnumerable<Roles> UserRoles { get; set; }
    }
}
