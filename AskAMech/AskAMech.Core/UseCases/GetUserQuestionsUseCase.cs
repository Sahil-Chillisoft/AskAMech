using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetUserQuestionsUseCase : IGetUserQuestions
    {
        private readonly IQuestionRepository _questionRepository;

        public GetUserQuestionsUseCase(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public void Execute(GetUserQuestionsRequest request, IPresenter presenter)
        {
            int recordCount;
            if (request.Pagination != null && request.Pagination.IsPagingRequest)
                recordCount = request.Pagination.RecordCount;
            else
                recordCount = _questionRepository.GetUserQuestionCount(request.UserId);

            var page = 1;
            if (request.Pagination?.Page != 0)
                page = request.Pagination?.Page ?? 1;

            var totalPages = (int)Math.Ceiling(recordCount / (double)PageSize.Medium);

            var pagination = new Pagination
            {
                Offset = (page - 1) * (int)PageSize.Medium,
                PageSize = (int)PageSize.Medium
            };

            var userQuestions = _questionRepository.GetUserQuestions(request.UserId, pagination);
            var response = new GetUserQuestionsResponse
            {
                UserQuestions = userQuestions,
                Pagination = new Pagination
                {
                    Page = page,
                    TotalPages = totalPages,
                    RecordCount = recordCount
                }, 
                IsFirstLoad = false
            };
            presenter.Success(response);
        }
    }
}
