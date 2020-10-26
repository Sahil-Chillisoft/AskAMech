using System;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.UseCases
{
    public class CreateRoleUseCase : ICreateUserRoleUsecase
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
