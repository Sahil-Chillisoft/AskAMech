using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
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
