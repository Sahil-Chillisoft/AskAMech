using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Responses
{
    public class GetCategoryResponse
    {
        public List<Category> AllCategories { get; set; }
    }
}
