using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class EditUserProfileUseCase : IEditUserProfileUseCase
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public EditUserProfileUseCase(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
        }

        public void Execute(EditUserProfileRequest request, IPresenter presenter)
        {
            /*Check if username is not the same as original username and
             does not exist for another username has changed then check if the username
            does not exist for another user on the system*/
            
            var userProfile = request.UserProfile;
            _userProfileRepository.Update(userProfile);
            presenter.Success(new EditUserProfileResponse());
        }
    }
}


