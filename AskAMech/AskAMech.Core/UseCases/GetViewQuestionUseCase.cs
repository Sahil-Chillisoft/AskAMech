using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetViewQuestionUseCase : IGetQuestionViewUseCase
    {
        private readonly IQuestionRepository _questionRepository;

        public GetViewQuestionUseCase(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        }

        public void Execute(GetViewQuestionRequest request, IPresenter presenter)
        {
            var questionDetails = _questionRepository.GetQuestionDetails(request.Id);
            var response = new GetViewQuestionResponse
            {
                QuestionDetails = questionDetails
            };
            presenter.Success(response);
        }
    }
}
