using System;
using AskAMech.Core.Answers.Interfaces;
using AskAMech.Core.Answers.Requests;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Answers.UseCases
{
    public class EditAnswerUseCase: IEditAnswerUseCase
    {
        private readonly IAnswersRepository _answersRepository;

        public EditAnswerUseCase(IAnswersRepository answersRepository)
        {
            _answersRepository = answersRepository ?? throw new ArgumentNullException(nameof(answersRepository));
        }

        public void Execute(EditAnswerRequest request, IPresenter presenter)
        {
            var answer = new Answer
            {
                Id = request.AnswerId, 
                QuestionId = request.QuestionId, 
                Description = request.Description
            };

            _answersRepository.Update(answer);
            presenter.Success(true);
        }
    }
}
