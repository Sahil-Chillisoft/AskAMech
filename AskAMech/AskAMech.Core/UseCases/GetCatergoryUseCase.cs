using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.UseCases
{
    public class GetCatergoryUseCase : IGetCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCatergoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public void Execute(CreateCategoryRequest request, IPresenter presenter)
        {
            var allCategories = _categoryRepository.GetCategories();
            var responsee = new GetCategoryResponse
            {
                AllCategories = allCategories
            };
            presenter.Success(responsee);

        }
    }
}
