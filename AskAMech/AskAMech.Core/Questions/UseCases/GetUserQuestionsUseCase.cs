using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Questions.Interfaces;
using AskAMech.Core.Questions.Requests;
using AskAMech.Core.Questions.Responses;

namespace AskAMech.Core.Questions.UseCases
{
    public class GetUserQuestionsUseCase : IGetUserQuestions
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetUserQuestionsUseCase(IQuestionRepository questionRepository,
                                       ICategoryRepository categoryRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public void Execute(GetUserQuestionsRequest request, IPresenter presenter)
        {
            int recordCount;
            if (request.Pagination != null && request.Pagination.IsPagingRequest)
                recordCount = request.Pagination.RecordCount;
            else
                recordCount = _questionRepository.GetUserQuestionCount(request.UserId, request.CategoryId);

            var page = 1;
            if (request.Pagination?.Page != 0)
                page = request.Pagination?.Page ?? 1;

            var totalPages = (int)Math.Ceiling(recordCount / (double)PageSize.Medium);

            var pagination = new Pagination
            {
                Offset = (page - 1) * (int)PageSize.Medium,
                PageSize = (int)PageSize.Medium
            };

            var userQuestions = _questionRepository.GetUserQuestions(request.UserId, request.CategoryId, pagination);
            var categories = _categoryRepository.GetCategories();

            var response = new GetUserQuestionsResponse
            {
                UserQuestions = userQuestions,
                Pagination = new Pagination
                {
                    Page = page,
                    TotalPages = totalPages,
                    RecordCount = recordCount
                },
                IsFirstLoad = false,
                CategoryId = request.CategoryId,
                Categories = categories
            };
            presenter.Success(response);
        }
    }
}
