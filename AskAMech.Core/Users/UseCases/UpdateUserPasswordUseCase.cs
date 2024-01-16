using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Users.Interfaces;
using AskAMech.Core.Users.Requests;

namespace AskAMech.Core.Users.UseCases
{
    public class UpdateUserPasswordUseCase : IUpdateUserPasswordUseCase
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserPasswordUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Execute(UpdateUserPasswordRequest request, IPresenter presenter)
        {
            var user = new User
            {
                Id = UserSecurityManager.UserId,
                Password = request.Password, 
                DateLastModified = DateTime.Now
            };
            _userRepository.UpdatePassword(user);
            
            presenter.Success(true);
        }
    }
}
