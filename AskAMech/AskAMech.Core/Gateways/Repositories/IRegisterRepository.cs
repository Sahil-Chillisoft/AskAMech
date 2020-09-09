using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.Gateways.Repositories
{
   public interface IRegisterRepository
    {
        int Create(RegisterResponce registerResponce);
    }
}
