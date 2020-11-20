using System.Collections.Generic;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        bool IsExistingCategory(string description);
        List<Category> GetCategories();
    }
}
