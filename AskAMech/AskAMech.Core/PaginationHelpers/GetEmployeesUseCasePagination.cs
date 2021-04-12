using System;
using System.Collections.Generic;
using System.Linq;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.PaginationHelpers
{
    public interface IGetEmployeesUseCasePagination : IPagination
    {
    }

    public class GetEmployeesUseCasePagination : IGetEmployeesUseCasePagination
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeesUseCasePagination(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public Pagination GetEntityPagination(Pagination pagination, params object[] filters)
        {
            int recordCount;
            if (pagination != null && pagination.IsPagingRequest)
                recordCount = pagination.RecordCount;
            else
                recordCount = _employeeRepository.GetCount(FilterHandler(filters.FirstOrDefault()));

            var page = pagination?.Page ?? 1;

            var totalPages = (int)Math.Ceiling(recordCount / (double)PageSize.Medium);

            var paginationResult = new Pagination
            {
                Offset = (page - 1) * (int)PageSize.Medium,
                PageSize = (int)PageSize.Medium,
                Page = page,
                TotalPages = totalPages,
                RecordCount = recordCount
            };

            return paginationResult;
        }

        private static string FilterHandler(object filter)
        {
            return filter == null ? "" : filter.ToString();
        }
    }
}
