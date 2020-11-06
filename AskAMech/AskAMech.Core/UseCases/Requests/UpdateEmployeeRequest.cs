using System;
using System.Collections.Generic;
using System.Text;


namespace AskAMech.Core.UseCases.Requests
{
    public class UpdateEmployeeRequest
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Email { get; set; }
    }
}
