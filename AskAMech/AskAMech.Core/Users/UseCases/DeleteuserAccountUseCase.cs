using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Users.Interfaces;

namespace AskAMech.Core.Users.UseCases
{
    public class DeleteUserAccountUseCase : IDeleteUserAccountUseCase
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
