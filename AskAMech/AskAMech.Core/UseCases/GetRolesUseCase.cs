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
    public class GetRolesUseCase : IGetRoleUseCase
    {
        private readonly IRolesRepository _rolesRepository;

        public GetRolesUseCase(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));

        }


        public void Execute(CreateUserRoleRequest request, IPresenter presenter)
        {
            var allRoles = _rolesRepository.getAllRoles();
            var responsee = new CreateUserRoleResponse
            {
                AllRoles = allRoles

            };
            presenter.Success(responsee);

        }
    }
}
