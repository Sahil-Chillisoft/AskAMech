using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AskAMech.Core.UseCases.Responses
{
    public class UpdateUserPasswordResponse
    {
        public int UserId { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "* Password required")]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "* Confirm Password required")]
        public string confirmPassword { get; set; }
        public string? ErrorMessage { get; set; }

    }
}
