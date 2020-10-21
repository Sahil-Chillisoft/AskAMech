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
            var recordCount = request.IsPagingRequest ? request.Pagination.RecordCount : _questionRepository.GetCount(request.Search, request.CategoryId);
            var page = request.Pagination?.Page ?? 1;
            const int pageSize = 10;
            var totalPages = (int)Math.Ceiling(recordCount / (double)pageSize);

            var pagination = new Pagination
            {
                Offset = (page - 1) * pageSize,
                PageSize = pageSize
            };

            var questions = _questionRepository.GetQuestions(request.Search, request.CategoryId, pagination);
            var categories = _categoryRepository.GetCategories();

            var response = new GetQuestionsResponse
            {
                Questions = questions,
                Categories = categories,
                Search = request.Search,
                CategoryId = request.CategoryId,
                Pagination = new Pagination
                {
                    Page = page,
                    TotalPages = totalPages,
                    RecordCount = recordCount
                }
            };
            presenter.Success(response);
        }
    }
}
