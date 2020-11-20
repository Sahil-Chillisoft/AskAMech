using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Questions.Interfaces;
using AskAMech.Core.Questions.Requests;
using AskAMech.Core.Questions.Responses;

namespace AskAMech.Core.Questions.UseCases
{
    public class CreateQuestionUseCase : ICreateQuestionUseCase
    {
        private readonly IQuestionRepository _questionRepository;

        public CreateQuestionUseCase(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        }

        public void Execute(CreateQuestionRequest request, IPresenter presenter)
        {
            var question = new Question
            {
                Title = request.Title,
                Description = request.Description,
                CategoryId = request.CategoryId,
                CreatedByUserId = UserSecurityManager.UserId,
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now
            };
            _questionRepository.CreateQuestion(question);

            presenter.Success(new CreateQuestionResponse());
        }
    }
}
