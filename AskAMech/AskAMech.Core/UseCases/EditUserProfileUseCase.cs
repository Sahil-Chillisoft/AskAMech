
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
    public class EditUserProfileUseCase : IEditUserProfileUseCase
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public EditUserProfileUseCase(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
        }

        public void Execute(EditUserProfileRequest request, IPresenter presenter)
        {
            var response = new EditUserProfileResponse
            {
                userId = request.userProfile.UserId,
                Username = request.userProfile.Username,
                About = request.userProfile.About

            };

            var IsExistingUsername = _userProfileRepository.IsExistingUsername(request.userProfile.Username);

            if (IsExistingUsername)
            {
                response.ErrorMessage = "Error: Another user with the same username already exits on the system";
                presenter.Error(response, true);
            }
            else
            {
                var viewUserInfo = new ViewUserInfo
                {
                    userProfile=new UserProfile
                    {
                    UserId = request.userProfile.UserId,
                    Username = request.userProfile.Username,
                    About=request.userProfile.About,
                    DateLastModified = request.userProfile.DateLastModified

                    }

                };

                _userProfileRepository.UpdateUserProfile(viewUserInfo.userProfile);
                presenter.Success(new EditUserProfileResponse());
            }
        }
    }
}

