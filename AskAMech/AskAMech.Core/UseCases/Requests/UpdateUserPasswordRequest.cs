using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core.UseCases.Requests
{
    public class UpdateUserPasswordRequest
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}
