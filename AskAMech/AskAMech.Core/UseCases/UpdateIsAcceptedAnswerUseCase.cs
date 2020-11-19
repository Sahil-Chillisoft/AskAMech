using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Requests;

namespace AskAMech.Core.UseCases
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
