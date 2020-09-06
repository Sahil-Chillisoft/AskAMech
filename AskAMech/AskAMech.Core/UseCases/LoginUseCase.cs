using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginUseCase(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(loginRepository));
        }

        public void Execute(LoginRequest request, IPresenter presenter)
        {
            var user = _loginRepository.GetUser(request.Email, request.Password);
            /*
             * TODO: Check if user object is not null.
             * TODO: If user obj is not null updated user last logged in and set user manager class details.
             * TODO: If user obj is null then return back a error response to the controller.
             */

            var response = new LoginResponse {IsAuthenticated = false};
            presenter.Success(response);
        }
    }
}
