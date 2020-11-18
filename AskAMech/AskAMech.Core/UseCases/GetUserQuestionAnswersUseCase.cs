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
    public class GetUserQuestionAnswersUseCase : IGetUserQuestionAnswersUseCase
    {
        private readonly IAnswersRepository _answersRepository ;
        private readonly IQuestionRepository _questionRepository;

        public GetUserQuestionAnswersUseCase(IAnswersRepository answersRepository, IQuestionRepository questionRepository)
        {
            _answersRepository = answersRepository ?? throw new ArgumentNullException(nameof(answersRepository));
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        }


        public void Execute(GetUserQuestionAnswersRequest request, IPresenter presenter)
        {
            int recordCount;
            if (request.Pagination != null && request.Pagination.IsPagingRequest)
                recordCount = request.Pagination.RecordCount;
            else
                recordCount = _questionRepository.GetUserQuestionCount(request.questionAnswers.QuestionId);

            var page = request.Pagination?.Page ?? 1;

            var totalPages = (int)Math.Ceiling(recordCount / (double)PageSize.Medium);

            var pagination = new Pagination
            {
                Offset = (page - 1) * (int)PageSize.Medium,
                PageSize = (int)PageSize.Medium
            };
            var questionsAnswer = _answersRepository.GetUserQuestionAnswers(request.questionAnswers.QuestionId,  pagination);
            {
                var response = new GetUserQuestionAnswersResponse
                {
                    userQuestions = questionsAnswer,
                    Pagination = new Pagination
                    {
                        Page = page,
                        TotalPages = totalPages,
                        RecordCount = recordCount
                    },

                };
                presenter.Success(response);

            }

        }
         
    }
}
