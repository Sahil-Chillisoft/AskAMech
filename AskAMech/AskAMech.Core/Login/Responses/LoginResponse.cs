using System.ComponentModel.DataAnnotations;

namespace AskAMech.Core.Login.Responses
{
    public class LoginResponse
    {
        [Required(ErrorMessage = "Email address required!")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required!")]
        public string Password { get; set; }

        public string? LoginErrorMessage { get; set; }
    }
}
