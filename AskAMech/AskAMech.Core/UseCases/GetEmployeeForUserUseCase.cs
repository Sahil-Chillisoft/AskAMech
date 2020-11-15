using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetEmployeeForUserUseCase : IGetEmployeeForUserUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRolesRepository _rolesRepository;

        public GetEmployeeForUserUseCase(IEmployeeRepository employeeRepository,
                                  IUserRepository userRepository,
                                  IRolesRepository rolesRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));
        }

        public void Execute(GetEmployeeForUserRequest request, IPresenter presenter)
        {
            var employee = _employeeRepository.GetEmployeeById(request.EmployeeId);
            var isExistingEmployeeUser = _userRepository.IsExitingEmployeeUser(request.EmployeeId);

            var response = new CreateUserResponse();
            if (isExistingEmployeeUser)
            {
                response.ErrorMessage = $"Error: Employee {request.EmployeeId} is already registered as a user";
                presenter.Error(response, true);
            }
            else
            {
                response.Employee = employee;
                response.Roles = _rolesRepository.GetRoles();
                response.User = new User { Password = "Password@1" }; ;
                presenter.Success(response);
            }
        }
    }
}
