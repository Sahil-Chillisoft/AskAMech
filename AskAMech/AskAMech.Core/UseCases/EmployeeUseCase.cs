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
    public class EmployeeUseCase : IEmployeeUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));

        }
        public void Execute(EmployeeRequest request, IPresenter presenter)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdNumber = request.IdNumber,
                Email = request.Email,
                CreatedByUserId = UserSecurityManager.UserId,
                LastModifiedByUserId = UserSecurityManager.UserId,
            };

            var isExistingEmployee = _employeeRepository.IsExistingEmployee(employee);

            if (!isExistingEmployee)
            {
                _employeeRepository.Create(employee);
                presenter.Success(new EmployeeResponse());
            }
            else
            {
                var response = new EmployeeResponse
                {
                    Email = employee.Email,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    IdNumber = employee.IdNumber,
                    ErrorMessage = "Error: An employee with the same details already exits on the system"
                };
                presenter.Error(response, true);
            }
        }
    }
}
