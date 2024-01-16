using System;
using AskAMech.Core.Employees.Interfaces;
using AskAMech.Core.Employees.Requests;
using AskAMech.Core.Employees.Responses;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Employees.UseCases
{
    public class GetEmployeeForEditUseCase : IGetEmployeeForEditUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeForEditUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public void Execute(EditEmployeeRequest request, IPresenter presenter)
        {
            var employee = _employeeRepository.GetEmployeeById(request.Employee.Id);
            var response = new EditEmployeeResponse()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email, 
                IdNumber = employee.IdNumber,
                IsActive = employee.IsActive
            };
            presenter.Success(response);
        }
    }
}
