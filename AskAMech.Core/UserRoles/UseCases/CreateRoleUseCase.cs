using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UserRoles.Interfaces;
using AskAMech.Core.UserRoles.Requests;
using AskAMech.Core.UserRoles.Responses;

namespace AskAMech.Core.UserRoles.UseCases
{
    public class CreateRoleUseCase : ICreateUserRoleUseCase
    {
        private readonly IRolesRepository _rolesRepository;

        public CreateRoleUseCase(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));
        }

        public void Execute(CreateUserRoleRequest request, IPresenter presenter)
        {
            var roles = new Roles
            {
                Description = request.Description
            };

            var isExistingRole = _rolesRepository.IsExistingRole(roles.Description);

            if (!isExistingRole)
            {
                _rolesRepository.Create(roles);
                presenter.Success(new CreateUserRoleResponse());
            }
            else
            {
                var response = new CreateUserRoleResponse
                {
                    Description = request.Description,
                    ErrorMessage = "Error: A role with the same details already exits on the system"
                };
                presenter.Error(response, true);
            }
        }
    }
}
