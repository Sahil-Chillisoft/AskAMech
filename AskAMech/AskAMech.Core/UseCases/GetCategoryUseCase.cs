using System;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.UseCases
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
            var allCategories = _categoryRepository.GetCategories();
            var response = new GetCategoryResponse
            {
                AllCategories = allCategories
            };
            presenter.Success(response);

        }
    }
}
