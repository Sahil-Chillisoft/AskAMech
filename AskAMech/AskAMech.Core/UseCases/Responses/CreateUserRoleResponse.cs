using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace AskAMech.Core.UseCases.Responses
{
    public class CreateUserRoleResponse
    {
        [DisplayName("Description")]
        [Required(ErrorMessage = "* Role Description required")]
        public string Description { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
