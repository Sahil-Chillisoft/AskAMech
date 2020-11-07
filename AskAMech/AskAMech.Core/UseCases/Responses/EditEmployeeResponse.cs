using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AskAMech.Core.UseCases.Responses
{
    public class EditEmployeeResponse
    {
        public int? Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "* Employee first name required")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "* Employee last name required")]
        public string LastName { get; set; }

        [DisplayName("ID Number")]
        [Required(ErrorMessage = "* Employee ID number required")]
        public string IdNumber { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage = "* Employee email Address required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
