using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Questions.Interfaces;
using AskAMech.Core.Questions.Requests;
using AskAMech.Core.Questions.Responses;

namespace AskAMech.Core.Questions.UseCases
{
    public class GetEditQuestionUseCase: IGetEditQuestionUseCase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetEditQuestionUseCase(IQuestionRepository questionRepository, ICategoryRepository categoryRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public void Execute(GetEditQuestionRequest request, IPresenter presenter)
        {
            var question = _questionRepository.GetQuestion(request.Id);
            var categories = _categoryRepository.GetCategories();

            var response = new EditQuestionResponse
            {
                Id = question.Id, 
                Title = question.Title, 
                Description = question.Description, 
                CategoryId = question.CategoryId, 
                DateCreated = question.DateCreated, 
                DateLastModified = question.DateLastModified, 
                Categories = categories
            };

            presenter.Success(response);
        }
    }
}
