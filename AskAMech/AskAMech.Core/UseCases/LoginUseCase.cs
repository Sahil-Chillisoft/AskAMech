using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        public LoginUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Execute(LoginRequest request, IPresenter presenter)
        {
            //TODO: WIP
            var user = new User
            {
                Email = request.Email,
                Password = request.Password
            };
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
