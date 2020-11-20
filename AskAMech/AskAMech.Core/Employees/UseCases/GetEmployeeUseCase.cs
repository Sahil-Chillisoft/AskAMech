using AskAMech.Core.Employees.Interfaces;
using AskAMech.Core.Employees.Requests;
using AskAMech.Core.Employees.Responses;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Employees.UseCases
{
    public class GetEmployeeUseCase : IGetEmployeeUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Execute(GetEmployeeRequest request, IPresenter presenter)
        {
            var employee = _employeeRepository.GetEmployeeById(request.Id);
            var response = new GetEmployeeResponse
            {
                Employee = employee
            };
            presenter.Success(response);
        }
    }
}