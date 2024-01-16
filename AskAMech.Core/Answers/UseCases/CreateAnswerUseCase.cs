using System;
using AskAMech.Core.Answers.Interfaces;
using AskAMech.Core.Answers.Requests;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Answers.UseCases
{
    public class CreateAnswerUseCase : ICreateAnswerUseCase
    {
        private readonly IAnswersRepository _answersRepository;

        public CreateAnswerUseCase(IAnswersRepository answersRepository)
        {
            _answersRepository = answersRepository ?? throw new ArgumentNullException(nameof(answersRepository));
        }
        
        public void Execute(CreateAnswerRequest request, IPresenter presenter)
        {
            var answer = new Answer
            {
                QuestionId = request.QuestionId,
                Description = request.Description,
                AnsweredByUserId = UserSecurityManager.UserId,
                IsAcceptedAnswer = false,
                DateCreated = DateTime.Now, 
                DateLastModified = DateTime.Now
            };
            _answersRepository.Create(answer);
            presenter.Success(true);
        }
    }
}
