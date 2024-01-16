using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Employees.Interfaces;
using AskAMech.Core.Employees.Requests;
using AskAMech.Core.Employees.Responses;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Employees.UseCases
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
            var response = new EditEmployeeResponse();
            var currentEmployeeDetails = _employeeRepository.GetEmployeeById(request.Employee.Id);
            
            if (currentEmployeeDetails.Email != request.Employee.Email)
            {
                var isExistingEmployeeEmail = _employeeRepository.IsExistingEmployeeEmail(request.Employee.Email);
                if (isExistingEmployeeEmail)
                {
                    response.ErrorMessage = "Error: Another employee with the same email address already exits on the system";
                    presenter.Error(response, true);
                    return;
                }
            }

            if (currentEmployeeDetails.IdNumber != request.Employee.IdNumber)
            {
                var isExistingEmployeeIdNumber = _employeeRepository.IsExistingEmployeeIdNumber(request.Employee.IdNumber);
                if (isExistingEmployeeIdNumber)
                {
                    response.ErrorMessage = "Error: Another employee with the same ID number already exits on the system";
                    presenter.Error(response, true);
                    return;
                }
            }

            var employee = new Employee
            {
                Id = request.Employee.Id,
                FirstName = request.Employee.FirstName,
                LastName = request.Employee.LastName,
                IdNumber = request.Employee.IdNumber,
                Email = request.Employee.Email,
                LastModifiedByUserId = UserSecurityManager.UserId,
                DateLastModified = DateTime.Now
            };
            _employeeRepository.Update(employee);
            presenter.Success(response);
        }
    }
}
