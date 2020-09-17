using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;

namespace AskAMech.Core.UseCases
{
    public class RegisterUseCase : IRegisterUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        public RegisterUseCase(IUserRepository userRepository, IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Execute(RegisterRequest request, IPresenter presenter)
        {

            //TODO: Follow the following steps in achieving the validation for the user email and username.
            /*
             * Perform check to see if user email already exists in User table (you will need to create a repository method in the UserRepo for this and write sql to do the check)
             * Perform check to see if username already exists in UserProfile table (you will need to create a repository method for this in the UserProfileRepo and write sql to do the check)
             * If user email or username already exists then return appropriate error back to the controller via the error presenter.
             * If user email and username do not exist then create the user.
             * When the user is created get back the user id.
             * Create the user profile afterwards with the user id.
             * Once the user profile is created load the UserManager Constructor like how it is done in the LoginUseCase
             * Finally return your success presenter.
             */

            /*
             Sample Code:
             var isExistingEmail = _userRepo.CheckExistingUserEmail(email address parameter);
             var isExistingUsername = _userProfileRepo(username parameter);
             ***Use if statements to drive the logic flow.***
             */

            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                UserRoleId = (int)UserRole.PublicUser,
                DateLastLoggedIn = DateTime.Now,
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now
            };
            var userId = _userRepository.Create(user);

            var userProfile = new UserProfile
            {
                UserId = userId,
                Username = request.Username,
                DateLastModified = DateTime.Now
            };
            var username = _userProfileRepository.Create(userProfile);

            var getUser = _userRepository.GetUser(user);
            var response = new RegisterResponce();

            if (getUser.Id == 0)
            {
                response.Email = request.Email;
                response.ErrorMessage = "Error: the email you entered already exist";
                presenter.Error(response, true);
            }
            else
            {
                var usersProfile = _userProfileRepository.GetUserProfile(getUser.Id);
                if (usersProfile.Id == 0)
                {
                    response.Username = request.Username;
                    response.ErrorMessage = "The username you entered has been used";
                    presenter.Error(response, true);
                }
                else
                {
                    presenter.Success(response);
                }
            }
        }
    }
}
