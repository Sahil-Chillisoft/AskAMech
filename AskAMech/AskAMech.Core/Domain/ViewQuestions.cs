﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core.Domain
{
    public class ViewQuestions
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
