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
    public class EditEmployeeUseCase : IEditEmployeeUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EditEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public void Execute(EditEmployeeRequest request, IPresenter presenter)
        {
            var response = new EditEmployeeResponse
            {
                Id = request.Employee.Id,
                FirstName = request.Employee.FirstName,
                LastName = request.Employee.LastName,
                IdNumber = request.Employee.IdNumber,
                Email = request.Employee.Email,
            };

            var isExistingEmployeeEmail = _employeeRepository.IsExistingEmployeeEmail(request.Employee.Email);
            var isExistingEmployeeIdNumber = _employeeRepository.IsExistingEmployeeIdNumber(request.Employee.IdNumber);

            if (isExistingEmployeeEmail)
            {
                response.ErrorMessage = "Error: Another employee with the same email address already exits on the system";
                presenter.Error(response, true);
            }
            else if (isExistingEmployeeIdNumber)
            {
                response.ErrorMessage = "Error: Another employee with the same ID number already exits on the system";
                presenter.Error(response, true);
            }
            else
            {
                var employee = new Employee
                {
                    FirstName = request.Employee.FirstName,
                    LastName = request.Employee.LastName,
                    IdNumber = request.Employee.IdNumber,
                    Email = request.Employee.Email,
                    IsActive = true,
                    LastModifiedByUserId = UserSecurityManager.UserId,
                    DateLastModified = DateTime.Now
                };

                _employeeRepository.Update(employee);
                presenter.Success(new EditEmployeeResponse());
            }
        }
    }
}
