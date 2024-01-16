using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Users.Interfaces;
using AskAMech.Core.Users.Requests;
using AskAMech.Core.Users.Responses;

namespace AskAMech.Core.Users.UseCases
{
    public class GetViewUserProfileUseCase: IGetViewUserProfile
    {
        private readonly IUserRepository _userRepository;

        public GetViewUserProfileUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Execute(GetViewUserProfileRequest request, IPresenter presenter)
        {
            var userProfile = _userRepository.GetUserProfile(request.Id);
            var response = new GetViewUserProfileResponse
            {
                UserProfile = userProfile
            };

            presenter.Success(response);
        }
    }
}
