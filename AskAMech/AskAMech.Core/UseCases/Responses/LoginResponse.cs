using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core.UseCases.Responses
{
    public class LoginResponse
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
