using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Requests
{
    public class GetAllEmployeesRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Email { get; set; }
    }
}
