using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Users.Interfaces;
using AskAMech.Core.Users.Responses;

namespace AskAMech.Core.Users.UseCases
{
    public class GetUserProfileUseCase : IGetUserProfileUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public GetUserProfileUseCase(IUserRepository userRepository,
                                     IUserProfileRepository userProfileRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
        }

        public void Execute(IPresenter presenter)
        {
            var user = _userRepository.GetUserById(UserSecurityManager.UserId);
            var userProfile = _userProfileRepository.GetUserProfile(UserSecurityManager.UserId);

            var response = new EditUserProfileResponse
            {
                User = user,
                UserProfile = userProfile
            };

            presenter.Success(response);
        }
    }
}