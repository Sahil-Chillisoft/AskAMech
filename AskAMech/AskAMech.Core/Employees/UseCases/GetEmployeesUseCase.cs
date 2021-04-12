using System;
using AskAMech.Core.Employees.Interfaces;
using AskAMech.Core.Employees.Requests;
using AskAMech.Core.Employees.Responses;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.PaginationHelpers;

namespace AskAMech.Core.Employees.UseCases
{
    public class GetEmployeesUseCase : IGetEmployeesUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IGetEmployeesUseCasePagination _getEmployeesUseCasePagination;

        public GetEmployeesUseCase(IEmployeeRepository employeeRepository, 
                                   IGetEmployeesUseCasePagination getEmployeesUseCasePagination)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _getEmployeesUseCasePagination = getEmployeesUseCasePagination ?? throw new ArgumentNullException(nameof(getEmployeesUseCasePagination));
        }

        public void Execute(GetEmployeesRequest request, IPresenter presenter)
        {
            var pagination = _getEmployeesUseCasePagination.GetEntityPagination(request.Pagination, request.Search);

            var employees = _employeeRepository.GetEmployees(request.Search, pagination);

            var response = new GetEmployeesResponse
            {
                Employees = employees,
                Search = request.Search,
                Pagination = pagination
            };
            presenter.Success(response);
        }
    }
}
