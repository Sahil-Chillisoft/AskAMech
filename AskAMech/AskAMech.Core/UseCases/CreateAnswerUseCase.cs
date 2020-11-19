using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;

namespace AskAMech.Core.UseCases
{
    public class CreateAnswerUseCase : ICreateAnswerUseCase
    {
        private readonly IAnswersRepository _answersRepository;

        public CreateAnswerUseCase(IAnswersRepository answersRepository)
        {
            _answersRepository = answersRepository;
        }

        public void Execute(CreateAnswerRequest request, IPresenter presenter)
        {
            var answer = new Answer
            {
                QuestionId = request.QuestionId,
                Description = request.Description,
                AnsweredByUserId = UserSecurityManager.UserId,
                IsAcceptedAnswer = false,
                DateCreated = DateTime.Now
            };
            _answersRepository.Create(answer);
            presenter.Success(true);
        }
    }
}
