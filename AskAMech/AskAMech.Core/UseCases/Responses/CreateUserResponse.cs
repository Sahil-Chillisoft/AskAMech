using System.ComponentModel.DataAnnotations;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class CreateUserResponse
    {
        public User User { get; set; }

        public UserProfile UserProfile { get; set; }

        [Required(ErrorMessage = "Please enter an employee to be loaded")]
        public string Search { get; set; }

        public string ErrorMessage { get; set; }
    }
}
