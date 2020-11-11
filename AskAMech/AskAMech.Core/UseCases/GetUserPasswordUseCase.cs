using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetUserPasswordUseCase: IGetUserPasswordUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserPasswordUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Execute(EditUserProfileRequest request, IPresenter presenter)
        {
            var users = _userRepository.GetUserById(request.user.Id);
            var response = new EditUserProfileResponse()
            {
                Password = users.Password,
               
            };
            presenter.Success(response);
        }
    }
}
