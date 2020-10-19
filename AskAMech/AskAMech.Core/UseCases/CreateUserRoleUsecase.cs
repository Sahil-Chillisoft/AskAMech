using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.UseCases
{
    public class CreateUserRoleUsecase : ICreateUserRoleUsecase
    {
        private readonly IRolesRepository _rolesRepository;

        public CreateUserRoleUsecase(IRolesRepository rolesRepository)
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
                    ErrorMessage = "Error: An employee with the same details already exits on the system"
                };
                presenter.Error(response, true);
            }

            var allRoles =_rolesRepository.getAllRoles();
            var responsee = new CreateUserRoleResponse
            {
                AllRoles = allRoles

            };
            presenter.Success(responsee);
        }
    }
}
