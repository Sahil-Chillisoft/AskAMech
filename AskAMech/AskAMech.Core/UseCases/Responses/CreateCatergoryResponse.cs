using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AskAMech.Core.UseCases.Responses
{
    public class CreateCatergoryResponse
    {
        [DisplayName(" Catergory Description")]
        [Required(ErrorMessage = "* Catergory Description required")]
        public string Description { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
