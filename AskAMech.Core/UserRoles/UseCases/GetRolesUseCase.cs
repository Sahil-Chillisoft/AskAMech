using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UserRoles.Interfaces;
using AskAMech.Core.UserRoles.Requests;
using AskAMech.Core.UserRoles.Responses;

namespace AskAMech.Core.UserRoles.UseCases
{
    public class GetRolesUseCase : IGetRoleUseCase
    {
        private readonly IRolesRepository _rolesRepository;

        public GetRolesUseCase(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));

        }
        public void Execute(CreateUserRoleRequest request, IPresenter presenter)
        {
            var userRoles = _rolesRepository.GetRoles();
            var response = new GetRolesResponse
            {
                UserRoles = userRoles
            };

            presenter.Success(response);
        }
    }
}
