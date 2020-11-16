using System;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.UseCases
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
