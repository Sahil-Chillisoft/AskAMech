#nullable enable
using System;
using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int? id);
        List<Employee> GetEmployees(string search, Pagination pagination);
        void Create(Employee employee);
        bool IsExistingEmployee(Employee employee);
        bool IsExistingEmployeeEmail(string email);
        bool IsExistingEmployeeIdNumber(string idNumber);
        List<ViewEmployee> GetEmployeesForAutocomplete(string search);
        int GetCount(string? search);
        void Update(Employee employee);
        void UpdateActiveStatus(Employee employee);
    }
}
