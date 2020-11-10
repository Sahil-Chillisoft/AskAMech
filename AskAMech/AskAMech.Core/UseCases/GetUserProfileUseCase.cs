using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetUserProfileUseCase : IGetUserProfileUseCase
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public GetUserProfileUseCase(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
        }

        public void Execute(EditUserProfileRequest request, IPresenter presenter)
        {
            var users = _userProfileRepository.GetUserProfile(request.userProfile.UserId);
            var response = new EditUserProfileResponse()
            {
                userId = users.UserId,
                Username = users.Username,
                About = users.About
            };
            presenter.Success(response);
        }
    }
}