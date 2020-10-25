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
    public class CreateCatergoryUseCase : ICreateCatergoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCatergoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository)); 
        }
        public void Execute(CreateCatergoryRequest request, IPresenter presenter)
        {
            var catergory= new Category
            {
                Description = request.Description
            };

            var isExistingCategory = _categoryRepository.IsExistingCategory(catergory.Description);

            if (!isExistingCategory)
            {
                _categoryRepository.Create(catergory);
                presenter.Success(new CreateCatergoryResponse());
            }
            else
            {
                var response = new CreateCatergoryResponse
                {
                    Description = request.Description,
                    ErrorMessage = "Error: A category with the same details already exits on the system"
                };
                presenter.Error(response, true);
            }
        }
    }
}
