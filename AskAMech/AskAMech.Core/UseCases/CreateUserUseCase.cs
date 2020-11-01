using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public CreateUserUseCase(IUserRepository userRepository, IUserProfileRepository userProfileRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
        }

        public void Execute(CreateUserRequest request, IPresenter presenter)
        {
            var user = new User
            {
                Email = request.User.Email,
                Password = request.User.Password,
                UserRoleId = request.User.UserRoleId,
                EmployeeId = request.User.EmployeeId,
                DateLastLoggedIn = null,
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now
            };
            var userId = _userRepository.Create(user);

            var about = string.Empty;
            if (request.User.UserRoleId == (int)UserRole.Admin)
                about = "Administrator on AskAMech.co.za";
            else if (request.User.UserRoleId == (int)UserRole.Mechanic)
                about = "Certified mechanic on AskAMech.co.za";

            var userProfile = new UserProfile
            {
                UserId = userId,
                Username = request.UserProfile.Username,
                About = about,
                DateLastModified = DateTime.Now
            };
            _userProfileRepository.Create(userProfile);

            presenter.Success(new CreateUserResponse());
        }
    }
}
