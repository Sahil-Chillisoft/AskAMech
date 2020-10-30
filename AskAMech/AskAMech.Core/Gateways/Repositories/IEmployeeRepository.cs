#nullable enable
using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IEmployeeRepository
    {
        public Employee GetEmployeeById(int id);
        List<Employee> GetEmployees(string search, Pagination pagination);
        void Create(Employee employee);
        bool IsExistingEmployee(Employee employee);
        List<ViewEmployee> GetEmployeesForAutocomplete(string search);
        int GetCount(string? search);
        void Update(Employee employee);
    }
}
