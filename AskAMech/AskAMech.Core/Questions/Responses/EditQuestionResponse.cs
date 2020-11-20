using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Questions.Responses
{
    public class EditQuestionResponse
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "* Question title required")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "* Question description required")]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        public DateTime DateLastModified { get; set; }
        
        public IEnumerable<Category> Categories { get; set; }
    }
}
