using System;
using AskAMech.Core.Answers.Interfaces;
using AskAMech.Core.Answers.Requests;
using AskAMech.Core.Answers.Responses;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Answers.UseCases
{
    public class GetUserAnswerUseCase: IGetUserAnswerUseCase
    {
        private readonly IAnswersRepository _answersRepository;

        public GetUserAnswerUseCase(IAnswersRepository answersRepository)
        {
            _answersRepository = answersRepository ?? throw new ArgumentNullException(nameof(answersRepository));
        }

        public void Execute(GetUserAnswerRequest request, IPresenter presenter)
        {
            var answer = _answersRepository.GetAnswer(request.QuestionId, request.AnswerId);
            var response = new GetUserAnswerResponse
            {
                QuestionId = answer.QuestionId,
                AnswerId = answer.Id,
                Description = answer.Description
            };

            presenter.Success(response);
        }
    }
}
