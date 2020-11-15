using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetEditQuestionUseCase: IGetEditQuestionUseCase
    {
        private readonly IQuestionRepository _questionRepository;

        public GetEditQuestionUseCase(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public void Execute(GetEditQuestionRequest request, IPresenter presenter)
        {
            var question = _questionRepository.GetQuestion(request.Id);
            var response = new EditQuestionResponse
            {
                Id = question.Id, 
                Title = question.Title, 
                Description = question.Description, 
                CategoryId = question.CategoryId, 
                DateCreated = question.DateCreated, 
                DateLastModified = question.DateLastModified
            };
            presenter.Success(response);
        }
    }
}
