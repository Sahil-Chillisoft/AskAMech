using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetQuestionCategoryUseCase : IGetQuestionCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetQuestionCategoryUseCase(IQuestionRepository questionRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public void Execute(GetQuestionsRequest request, IPresenter presenter)
        {
            var response = new CreateQuestionResponse
            {
                category = _categoryRepository.GetCategories()
            };
            presenter.Success(response);
        }
    }
}
