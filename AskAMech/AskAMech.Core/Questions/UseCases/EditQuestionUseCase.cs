using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Questions.Interfaces;
using AskAMech.Core.Questions.Requests;
using AskAMech.Core.Questions.Responses;

namespace AskAMech.Core.Questions.UseCases
{
    public class EditQuestionUseCase: IEditQuestionUseCase
    {
        private readonly IQuestionRepository _questionRepository;

        public EditQuestionUseCase(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        }

        public void Execute(EditQuestionRequest request, IPresenter presenter)
        {
            var question = new Question
            {
                Id = request.Id, 
                Title = request.Title, 
                Description = request.Description, 
                CategoryId = request.CategoryId, 
                DateLastModified = DateTime.Now
            };
            _questionRepository.Update(question);

            presenter.Success(new EditQuestionResponse());
        }
    }
}
