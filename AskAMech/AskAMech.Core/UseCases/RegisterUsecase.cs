using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class RegisterUseCase: IRegisterUseCase
    {
        private readonly IRegisterRepository _registerRepository;
        public RegisterUseCase(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository ?? throw new ArgumentNullException(nameof(registerRepository));
        }

        public void Execute(RegisterRequest request, IPresenter presenter)
        {

           // throw new NotImplementedException();
        }
    }
}
