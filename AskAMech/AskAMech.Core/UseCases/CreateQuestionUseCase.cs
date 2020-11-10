using System;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.UseCases
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
