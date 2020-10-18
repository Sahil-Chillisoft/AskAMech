using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
   public class GetAllEmployeesResponse
    {
        public List<Employee> AllEmployees { get; set; }
     
    }
}
