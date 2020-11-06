using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetAllEmployeesUseCase : IGetAllEmployeesUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRolesRepository _rolesRepository;

        public GetAllEmployeesUseCase(IEmployeeRepository employeeRepository,
                                  IUserRepository userRepository,
                                  IRolesRepository rolesRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));
        }

        public void Execute(GetEmployeeRequest request, IPresenter presenter)
        {
            var employee = _employeeRepository.GetEmployeeById(request.EmployeeId);
            var response = new UpdateEmployeeResponse();
            
                response.emp = employee;

                presenter.Success(response);
            
        }

        }
    }
