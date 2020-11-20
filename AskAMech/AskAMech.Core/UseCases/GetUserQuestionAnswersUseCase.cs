﻿using System;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.UseCases
{
    public class GetUserQuestionAnswersUseCase : IGetUserQuestionAnswersUseCase
    {
        private readonly IAnswersRepository _answersRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetUserQuestionAnswersUseCase(IAnswersRepository answersRepository,
                                             ICategoryRepository categoryRepository)
        {
            _answersRepository = answersRepository ?? throw new ArgumentNullException(nameof(answersRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public void Execute(GetUserQuestionAnswersRequest request, IPresenter presenter)
        {
            int recordCount;
            if (request.Pagination != null && request.Pagination.IsPagingRequest)
                recordCount = request.Pagination.RecordCount;
            else
                recordCount = _answersRepository.GetUserQuestionAnswerCount(UserSecurityManager.UserId, request.CategoryId);

            var page = request.Pagination?.Page ?? 1;

            var totalPages = (int)Math.Ceiling(recordCount / (double)PageSize.Medium);

            var pagination = new Pagination
            {
                Offset = (page - 1) * (int)PageSize.Medium,
                PageSize = (int)PageSize.Medium
            };

            var questionsAnswer = _answersRepository.GetUserQuestionAnswers(UserSecurityManager.UserId, request.CategoryId, pagination);
            var categories = _categoryRepository.GetCategories();

            var response = new GetUserQuestionAnswersResponse
            {
                UserQuestionAnswers = questionsAnswer,
                Categories = categories,
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
