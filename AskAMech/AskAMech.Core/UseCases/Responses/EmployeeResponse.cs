using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AskAMech.Core.UseCases.Responses
{
    public class EmployeeResponse
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage ="Employee first name required")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage ="Employee last name is required")]
        public string LastName { get; set; }

        [DisplayName("ID Number")]
        [Required(ErrorMessage ="Employee ID number is required")]
        public string IdNumber { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage ="Email Address is required")]
        [EmailAddress(ErrorMessage ="Please enter  a valid email address")]
        public string Email { get; set; }
        
        public string? ErrorMessage { get; set; }
    }
}
