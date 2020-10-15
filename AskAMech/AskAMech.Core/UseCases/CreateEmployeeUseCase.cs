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
    public class CreateEmployeeUseCase : ICreateEmployeeUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public void Execute(CreateEmployeeRequest request, IPresenter presenter)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdNumber = request.IdNumber,
                Email = request.Email,
                IsActive = true, 
                CreatedByUserId = UserSecurityManager.UserId,
                LastModifiedByUserId = UserSecurityManager.UserId,
            };

            var isExistingEmployee = _employeeRepository.IsExistingEmployee(employee);

            if (!isExistingEmployee)
            {
                _employeeRepository.Create(employee);
                presenter.Success(new CreateEmployeeResponse());
            }
            else
            {
                var response = new CreateEmployeeResponse
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    IdNumber = request.IdNumber,
                    ErrorMessage = "Error: An employee with the same details already exits on the system"
                };
                presenter.Error(response, true);
            }
        }
    }
}
