using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetQuestionsUseCase : IGetQuestionsUseCase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetQuestionsUseCase(IQuestionRepository questionRepository, ICategoryRepository categoryRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public void Execute(GetQuestionsRequest request, IPresenter presenter)
        {
            var pagination = new Pagination
            {
                Page = request.Pagination?.Page ?? 1,
                Next = 10,
                Offset = 10
            };

            var questions = _questionRepository.GetQuestions(request.Search, request.CategoryId, pagination);
            var categories = _categoryRepository.GetCategories();

            var response = new GetQuestionsResponse
            {
                Questions = questions,
                Categories = categories,
                Search = request.Search,
                CategoryId = request.CategoryId,
                Pagination = new Pagination { Page = pagination.Page }
            };
            presenter.Success(response);
        }
    }
}
