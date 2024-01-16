using System;
using AskAMech.Core.Answers.Interfaces;
using AskAMech.Core.Answers.Requests;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Answers.UseCases
{
    public class UpdateIsAcceptedAnswerUseCase: IUpdateIsAcceptedAnswerUseCase
    {
        private readonly IAnswersRepository _answersRepository;

        public UpdateIsAcceptedAnswerUseCase(IAnswersRepository answersRepository)
        {
            _answersRepository = answersRepository ?? throw new ArgumentNullException(nameof(answersRepository));
        }

        public void Execute(UpdateIsAcceptedAnswerRequest request, IPresenter presenter)
        {
            _answersRepository.ClearUpdatedAnswersForQuestion(request.QuestionId);
            _answersRepository.UpdateIsAcceptedAnswer(request.QuestionId, request.AnswerId, request.IsAcceptedAnswer);
            presenter.Success(true);
        }
    }
}
