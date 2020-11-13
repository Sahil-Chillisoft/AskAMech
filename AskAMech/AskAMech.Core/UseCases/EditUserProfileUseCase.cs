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
            /*Check if username is not the same as original username and
             does not exist for another username has changed then check if the username
            does not exist for another user on the system*/
            var response = new EditUserProfileResponse
            {
                UserProfile = request.userProfile   
            };
            var isExistingUsername = _userProfileRepository.IsExistingUsername(request.userProfile.Username);
            if (isExistingUsername)
            {
                response.ErrorMessage = "Error: Username already exits on the system";
                presenter.Error(response, true);
            }
            else
            {
                var userPro = new UserProfile
                {
                    Id = request.userProfile.Id,
                    UserId = request.userProfile.UserId,
                    Username = request.userProfile.Username,
                    About = request.userProfile.About,
                    DateLastModified = request.userProfile.DateLastModified

                };
                //var userProfile = request.UserProfile;
                _userProfileRepository.Update(userPro);
                presenter.Success(new EditUserProfileResponse());

            }

        }
    }
}


