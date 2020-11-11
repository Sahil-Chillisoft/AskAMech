using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AskAMech.Core.UseCases.Responses
{
    public class EditUserProfileResponse
    {
        public int? userId { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "* Username required")]
        public string Username { get; set; }
        [DisplayName("About")]
        public string About { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        public string confirmPassword { get; set;}
        public string? ErrorMessage { get; set; }
    }
}
