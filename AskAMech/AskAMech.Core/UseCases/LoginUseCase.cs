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
        private readonly IUserProfileRepository _userProfileRepository;

        public LoginUseCase(IUserRepository userRepository, IUserProfileRepository userProfileRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
        }

        public void Execute(LoginRequest request, IPresenter presenter)
        {
            var user = new User
            {
                Email = request.Email,
                Password = request.Password
            };

            var getUser = _userRepository.GetUser(user);
            var response = new LoginResponse();
            
            if (getUser.Id == 0)
            {
                response.Email = request.Email;
                response.Password = request.Password;
                response.LoginErrorMessage = "Error: Email address or password is incorrect";
                presenter.Error(response, true);   
            }
            else
            {
                var userProfile = _userProfileRepository.GetUserProfile(getUser.Id);
                if (userProfile.Id == 0)
                {
                    response.Email = request.Email;
                    response.Password = request.Password;
                    response.LoginErrorMessage = "Error: No associated user profile found for this user account, please contact support";
                    presenter.Error(response, true);
                }
                else
                {
                    UserSecurityManager.InitializeUser(getUser.Id, userProfile.Username, getUser.UserRoleId, true);
                    _userRepository.UpdateLastLoggedInDate(getUser.Id);
                    presenter.Success(response);
                }
            }
        }
    }
}
