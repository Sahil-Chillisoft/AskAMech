using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetUserProfileUseCase : IGetUserProfileUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public GetUserProfileUseCase(IUserRepository userRepository, IUserProfileRepository userProfileRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
        }

        public void Execute(EditUserProfileRequest request, IPresenter presenter)
        {
            var user = _userRepository.GetUserById(request.User.Id);
            var userProfile = _userProfileRepository.GetUserProfile(request.userProfile.UserId);

            var response = new EditUserProfileResponse()
            {
                User = user, 
                UserProfile = userProfile
                
            };

            presenter.Success(response);
        }
    }
}