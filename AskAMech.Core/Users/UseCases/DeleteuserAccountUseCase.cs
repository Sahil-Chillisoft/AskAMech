using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Security.Interfaces;
using AskAMech.Core.Users.Interfaces;

namespace AskAMech.Core.Users.UseCases
{
    public class DeleteUserAccountUseCase : IDeleteUserAccountUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;

        public DeleteUserAccountUseCase(IUserRepository userRepository, ISecurityManagerUseCase securityManagerUseCase)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
        }

        public void Execute(IPresenter presenter)
        {
            _userRepository.UpdateDateDeleted(UserSecurityManager.UserId);
            _securityManagerUseCase.SignOut();
            presenter.Success(true);
        }
    }
}
