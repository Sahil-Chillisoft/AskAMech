using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;

namespace AskAMech.Core.UseCases
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
            
            presenter.Success(new UpdateUserPasswordResponse());
        }
    }
}
