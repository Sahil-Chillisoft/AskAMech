using System;
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

        public GetQuestionsUseCase(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        }

        public void Execute(GetQuestionsRequest request, IPresenter presenter)
        {
            var questions = _questionRepository.GetQuestions();
            var response = new GetQuestionsResponse
            {
                Questions = questions
            };
            presenter.Success(response);
        }
    }
}
