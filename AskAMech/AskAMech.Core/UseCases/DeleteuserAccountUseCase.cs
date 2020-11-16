using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;

namespace AskAMech.Core.UseCases
{
    public class DeleteuserAccountUseCase : IDeleteuserAccountUseCase
    {
        private readonly IUserRepository _userRepository;

        public DeleteuserAccountUseCase(IUserRepository userRepository)
        {

            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Execute(IPresenter presenter)
        {
            var UserId = _userRepository.GetUserById(UserSecurityManager.UserId);

            var response = new DeleteUserAccountResponse
            {
                Id = UserId.Id
            };
             _userRepository.UpdateDatedDeleted(UserId.Id);

            presenter.Success(response);
        }

    }
}
