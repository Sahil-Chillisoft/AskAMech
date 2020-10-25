using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface ICategoryRepository
    {
        int Create(Category category);
        bool IsExistingCategory(string description);
        List<Category> GetCategories();
    }
}
