using System;
using AskAMech.Core.Categories.Interfaces;
using AskAMech.Core.Categories.Requests;
using AskAMech.Core.Categories.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Categories.UseCases
{
    public class CreateCategoryUseCase : ICreateCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CreateCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository)); 
        }
        
        public void Execute(CreateCategoryRequest request, IPresenter presenter)
        {
            var category= new Category
            {
                Description = request.Description
            };

            var isExistingCategory = _categoryRepository.IsExistingCategory(category.Description);

            if (!isExistingCategory)
            {
                _categoryRepository.Create(category);
                presenter.Success(new CreateCategoryResponse());
            }
            else
            {
                var response = new CreateCategoryResponse
                {
                    Description = request.Description,
                    ErrorMessage = "Error: A category with the same details already exits on the system"
                };
                presenter.Error(response, true);
            }
        }
    }
}
