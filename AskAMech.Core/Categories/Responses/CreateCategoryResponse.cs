using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AskAMech.Core.Categories.Responses
{
    public class CreateCategoryResponse
    {
        [DisplayName(" Category Description")]
        [Required(ErrorMessage = "* Category Description required")]
        public string Description { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
