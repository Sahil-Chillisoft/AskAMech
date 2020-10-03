using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AskAMech.Core.UseCases.Responses
{
    public class EmployeeResponses
    {
        [Required(ErrorMessage ="firstname is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Lastname is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="ID number is required")]
        public string IdNumber { get; set; }
        [Required(ErrorMessage ="Email Address is required")]
        [EmailAddress(ErrorMessage ="Please enter  a valid email address")]
        public string Email { get; set; }
    }
}
