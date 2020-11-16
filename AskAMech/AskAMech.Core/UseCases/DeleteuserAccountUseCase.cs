using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;

namespace AskAMech.Core.UseCases
{
    public class DeleteUserAccountUseCase : IDeleteuserAccountUseCase
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserAccountUseCase(IUserRepository userRepository)
        {

            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Execute(IPresenter presenter)
        {
            _userRepository.UpdateDatedDeleted(UserSecurityManager.UserId);
            UserSecurityManager.SignOut();
            presenter.Success(true);
        }
    }
}
