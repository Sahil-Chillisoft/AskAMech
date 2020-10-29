#nullable enable
using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
   public interface IEmployeeRepository
    {
        List<Employee> GetEmployees(string search, Pagination pagination);
        void Create(Employee employee);
        bool IsExistingEmployee(Employee employee);
        List<string> GetEmployeesForAutocomplete(string search);
        int GteCount(string? search);
        void Update(Employee employee);
    }
}
