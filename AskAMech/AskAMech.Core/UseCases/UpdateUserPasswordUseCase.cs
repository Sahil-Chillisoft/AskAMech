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
        private readonly IUpdateUserPasswordUseCase _updateUserPasswordUseCase;

        public UpdateUserPasswordUseCase(IUpdateUserPasswordUseCase updateUserPasswordUseCase)
        {
            _updateUserPasswordUseCase = updateUserPasswordUseCase ?? throw new ArgumentNullException(nameof(updateUserPasswordUseCase));
        }

        public void Execute(UpdateUserPasswordRequest request, IPresenter presenter)
        {
            
        }
    }
}
