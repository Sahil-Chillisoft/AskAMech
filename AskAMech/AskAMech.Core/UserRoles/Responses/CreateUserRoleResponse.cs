using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AskAMech.Core.UserRoles.Responses
{
    public class CreateUserRoleResponse
    {
        [DisplayName("Description")]
        [Required(ErrorMessage = "* Role Description required")]
        public string Description { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
