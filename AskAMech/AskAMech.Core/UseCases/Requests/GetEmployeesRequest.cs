using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Requests
{
    public class GetEmployeesRequest
    {
        public string Search { get; set; }
        public Pagination Pagination { get; set; }
    }
}
