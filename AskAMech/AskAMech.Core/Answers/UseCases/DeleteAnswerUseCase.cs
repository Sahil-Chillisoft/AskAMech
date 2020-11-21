using System;
using AskAMech.Core.Answers.Interfaces;
using AskAMech.Core.Answers.Requests;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Answers.UseCases
{
    public class DeleteAnswerUseCase : IDeleteAnswerUseCase
    {
        private readonly IAnswersRepository _answersRepository;

        public DeleteAnswerUseCase(IAnswersRepository answersRepository)
        {
            _answersRepository = answersRepository ?? throw new ArgumentNullException(nameof(answersRepository));
        }

        public void Execute(DeleteAnswerRequest request, IPresenter presenter)
        {
            var answer = new Answer
            {
                Id = request.AnswerId,
                QuestionId = request.QuestionId
            };

            _answersRepository.Delete(answer);
            presenter.Success(true);
        }
    }
}
