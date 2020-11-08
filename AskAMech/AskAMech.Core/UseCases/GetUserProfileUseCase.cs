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

        public void Execute(GetUserProfileRequest request, IPresenter presenter)
        {
            var user = _userProfileRepository.GetUserProfile(request.UserProfileId);
            var response = new GetUserProfileResponse
            {
                userProfile = user
            };
            presenter.Success(response);
        }


    }
}
