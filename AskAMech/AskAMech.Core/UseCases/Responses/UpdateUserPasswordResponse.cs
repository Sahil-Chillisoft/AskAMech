using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class UpdateUserPasswordResponse
    {
        [DisplayName("Password")]
        [Required(ErrorMessage = "* Password required")]
        public string Password { get; set; }
        
        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "* Confirm Password required")]
        public string ConfirmPassword { get; set; }
        public int id { get; set; }
    }
}
