using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
   public class GetEmployeesResponse
    {
        public List<Employee> Employees { get; set; }
        public string Search { get; set; }
        public Pagination Pagination { get; set; }
    }
}
