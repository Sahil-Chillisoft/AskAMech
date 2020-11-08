
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
            var response = new EditEmployeeResponse
            {
                Id = request.userProfile.Id,
                
            };

            var IsExistingUsername = _userProfileRepository.IsExistingUsername(request.userProfile.Username);
           
            if (IsExistingUsername)
            {
                response.ErrorMessage = "Error: Another employee with the same username already exits on the system";
                presenter.Error(response, true);
            }
            else
            {
                var userProfile = new UserProfile
                {
                    UserId = request.userProfile.UserId,
                    Username = request.userProfile.Username,
                    DateLastModified = request.userProfile.DateLastModified
                };

                _userProfileRepository.UpdateUserProfile(userProfile);
                presenter.Success(new EditUserProfileResponse());
            }
        }
    }
}

