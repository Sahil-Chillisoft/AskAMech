using System;
using AskAMech.Core.Categories.Interfaces;
using AskAMech.Core.Categories.Requests;
using AskAMech.Core.Categories.Responses;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Categories.UseCases
{
    public class GetCategoryUseCase : IGetCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public GetCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public void Execute(CreateCategoryRequest request, IPresenter presenter)
        {
            var categories = _categoryRepository.GetCategories();
            var response = new GetCategoryResponse
            {
                Categories = categories
            };
            presenter.Success(response);
        }
    }
}
