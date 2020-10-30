using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetEmployeeUseCase : IGetEmployeeUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public void Execute(GetEmployeeRequest request, IPresenter presenter)
        {
            var employee = _employeeRepository.GetEmployeeById(request.EmployeeId);
            var response = new GetEmployeeResponse { Employee = employee };
            presenter.Success(response);
        }
    }
}
