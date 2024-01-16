using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Employees.Responses
{
   public class GetEmployeesResponse
    {
        public List<Employee> Employees { get; set; }
        public string Search { get; set; }
        public Pagination Pagination { get; set; }
    }
}
