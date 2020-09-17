using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AskAMech.Core.UseCases.Responses
{
    public class RegisterResponce
    {
        [Required(ErrorMessage = "Username Required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email address required!")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please re-enter your password.")]
        public string ConfirmPassword { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
