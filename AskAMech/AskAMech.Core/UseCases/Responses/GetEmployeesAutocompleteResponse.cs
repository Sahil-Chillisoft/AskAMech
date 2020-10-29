using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class GetEmployeesAutocompleteResponse
    {
        public List<ViewEmployee> EmployeeDetails { get; set; }
    }
}
