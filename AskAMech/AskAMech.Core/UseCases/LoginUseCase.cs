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
            var isAuthenticated = _loginRepository.AuthenticateUserLogin(request.Email, request.Password);
            var response = new LoginResponse { IsAuthenticated = isAuthenticated };
            presenter.Success(response);
        }
    }
}
