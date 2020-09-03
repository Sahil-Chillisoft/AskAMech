using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AskAMech.Core.UseCases.Responses
{
    public class LoginResponse
    {
        [Required(ErrorMessage = "Email address required!")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required!")]
        public string Password { get; set; }
        
        public bool IsAuthenticated { get; set; }
    }
}
