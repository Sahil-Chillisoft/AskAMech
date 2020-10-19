using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
   public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        void Create(Employee employee);
        bool IsExistingEmployee(Employee employee);
    }
}
