using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;

namespace AskAMech.Core.UseCases
{
    public class UpdateEmployeeUseCase : IUpdateEmployeeUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
       

        public UpdateEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }
        public void Execute(UpdateEmployeeRequest request, IPresenter presenter)
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
                _employeeRepository.Update(employee);
                presenter.Success(new UpdateEmployeeResponse());
            }
            else
            {
                var response = new UpdateEmployeeResponse
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
