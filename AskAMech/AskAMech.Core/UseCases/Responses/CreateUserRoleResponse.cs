using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class CreateUserRoleResponse
    {
        [DisplayName(" Role Description")]
        [Required(ErrorMessage = "* Role Description required")]
        public string Description { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
