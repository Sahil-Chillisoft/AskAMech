using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Users.Interfaces;
using AskAMech.Core.Users.Requests;
using AskAMech.Core.Users.Responses;

namespace AskAMech.Core.Users.UseCases
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
            var response = new EditUserProfileResponse();
            
            if (request.UserProfile.Username != UserSecurityManager.Username)
            {
                var isExistingUsername = _userProfileRepository.IsExistingUsername(request.UserProfile.Username);
                if (isExistingUsername)
                {
                    response.ErrorMessage = "Error: Username already exits on the system";
                    presenter.Error(response, true);
                    return;
                }
            }

            var userProfile = new UserProfile
            {
                Id = request.UserProfile.Id,
                UserId = request.UserProfile.UserId,
                Username = request.UserProfile.Username,
                About = request.UserProfile.About,
                DateLastModified = request.UserProfile.DateLastModified

            };

            _userProfileRepository.Update(userProfile);
            presenter.Success(response);
        }

    }
}



