using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Employees.Responses
{
    public class GetEmployeesAutocompleteResponse
    {
        public List<ViewEmployee> EmployeeDetails { get; set; }
    }
}
