using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class RegisterUsecase:IRegisterUsecase
    {
        private readonly IRegisterRepository _registerRepository;
        public RegisterUsecase(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository ?? throw new ArgumentNullException(nameof(registerRepository));
        }

    }
}
