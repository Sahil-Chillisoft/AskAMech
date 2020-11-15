using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetpdateUserPasswordUseCase : IGetpdateUserPasswordUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetpdateUserPasswordUseCase(IUserRepository userRepository, IUserProfileRepository userProfileRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Execute(IPresenter presenter)
        {
            var user = _userRepository.GetUserById(UserSecurityManager.UserId);
            var response = new UpdateUserPasswordResponse()
            {
               id=user.Id
            };

            presenter.Success(response);
        }
    }
}
