using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Register.Interfaces;
using AskAMech.Core.Register.Requests;
using AskAMech.Core.Register.Responses;
using AskAMech.Core.Security.Interfaces;

namespace AskAMech.Core.Register.UseCases
{
    public class RegisterUseCase : IRegisterUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;
       
        public RegisterUseCase(IUserRepository userRepository, 
                               IUserProfileRepository userProfileRepository, 
                               ISecurityManagerUseCase securityManagerUseCase)
        {
            _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Execute(RegisterRequest request, IPresenter presenter)
        {
            var response = new RegisterResponse();

            var isExistingEmail = _userRepository.IsExistingUserEmail(request.Email);
            if (!isExistingEmail)
            {
                var isExistingUsername = _userProfileRepository.IsExistingUsername(request.Username);
                if (!isExistingUsername)
                {
                    var userId = CreateUserAndReturnId(request);
                    CreateUserProfile(userId, request.Username);
                    var user = _userRepository.GetUserById(userId);
                    _securityManagerUseCase.InitializeUser(user.Id, request.Username, user.UserRoleId, true);
                    _userRepository.UpdateLastLoggedInDate(userId);
                    presenter.Success(response);
                }
                else
                {
                    response.Email = request.Email;
                    response.Username = request.Username;
                    response.Password = request.Password;
                    response.RegisterErrorMessage = "Error: The username you entered already exists";
                    presenter.Error(response, true);
                }
            }
            else
            {
                response.Email = request.Email;
                response.Username = request.Username;
                response.Password = request.Password;
                response.RegisterErrorMessage = "Error: The email you entered already exists";
                presenter.Error(response, true);
            }
        }

        private int CreateUserAndReturnId(RegisterRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                UserRoleId = (int)UserRole.GeneralUser,
                EmployeeId = null,
                DateLastLoggedIn = DateTime.Now,
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now
            };

            return _userRepository.Create(user);
        }

        private void CreateUserProfile(int userId, string username)
        {
            var userProfile = new UserProfile
            {
                UserId = userId,
                Username = username,
                About = "This user has not said anything about themselves yet and seems to prefer the life of secrecy",
                DateLastModified = DateTime.Now
            };

            _userProfileRepository.Create(userProfile);
        }
    }
}
