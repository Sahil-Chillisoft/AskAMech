using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetCreateCreateQuestionUseCase : IGetCreateQuestionUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCreateCreateQuestionUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public void Execute(IPresenter presenter)
        {
            var categories = _categoryRepository.GetCategories();
            var response = new CreateQuestionResponse
            {
                Question = new Question(),
                Categories = categories
            };

            presenter.Success(response);
        }
    }
}
