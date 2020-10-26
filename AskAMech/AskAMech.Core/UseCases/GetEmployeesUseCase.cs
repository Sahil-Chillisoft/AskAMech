using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.UseCases
{
    public class GetEmployeesUseCase : IGetEmployeesUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeesUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public void Execute(GetEmployeesRequest request, IPresenter presenter)
        {
            int recordCount;
            if (request.Pagination != null && request.Pagination.IsPagingRequest)
                recordCount = request.Pagination.RecordCount;
            else
                recordCount = _employeeRepository.GteCount(request.Search);

            var page = request.Pagination?.Page ?? 1;

            var totalPages = (int)Math.Ceiling(recordCount / (double)PageSize.Medium);

            var pagination = new Pagination
            {
                Offset = (page - 1) * (int)PageSize.Medium,
                PageSize = (int)PageSize.Medium
            };

            var employees = _employeeRepository.GetEmployees(request.Search, pagination);

            var response = new GetEmployeesResponse
            {
                Employees = employees,
                Search = request.Search,
                Pagination = new Pagination
                {
                    Page = page,
                    TotalPages = totalPages,
                    RecordCount = recordCount
                }
            };
            presenter.Success(response);
        }
    }
}
