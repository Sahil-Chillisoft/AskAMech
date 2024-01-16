using System;
using AskAMech.Core.Employees.Interfaces;
using AskAMech.Core.Employees.Requests;
using AskAMech.Core.Employees.Responses;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Employees.UseCases
{
    public class GetEmployeesAutocompleteUseCase : IGetEmployeesAutocompleteUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeesAutocompleteUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public void Execute(GetEmployeesAutocompleteRequest request, IPresenter presenter)
        {
            var employees = _employeeRepository.GetEmployeesForAutocomplete(request.Search);
            var response = new GetEmployeesAutocompleteResponse
            {
                EmployeeDetails = employees
            };
            presenter.Success(response);
        }
    }
}
