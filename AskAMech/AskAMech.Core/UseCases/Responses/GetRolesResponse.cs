using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
   public class GetRolesResponse
    {
        public List<Roles> AllRoles { get; set; }
    }
}
