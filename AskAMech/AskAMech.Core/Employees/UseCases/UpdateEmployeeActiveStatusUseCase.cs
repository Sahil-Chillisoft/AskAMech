using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Employees.Interfaces;
using AskAMech.Core.Employees.Requests;
using AskAMech.Core.Employees.Responses;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Employees.UseCases
{
    public class UpdateEmployeeActiveStatusUseCase : IUpdateEmployeeActiveStatusUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeActiveStatusUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public void Execute(EditEmployeeRequest request, IPresenter presenter)
        {
            var employee = new Employee
            {
                Id = request.Employee.Id, 
                IsActive = request.Employee.IsActive, 
                LastModifiedByUserId = UserSecurityManager.UserId, 
                DateLastModified = DateTime.Now
            };
            _employeeRepository.UpdateActiveStatus(employee);

            presenter.Success(new EditEmployeeResponse());
        }
    }
}
