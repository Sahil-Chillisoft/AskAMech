using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class GetUserQuestionsUseCase : IGetUserQuestions
    {
        private readonly IQuestionRepository _questionRepository;

        public GetUserQuestionsUseCase(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public void Execute(GetUserQuestionsRequest request, IPresenter presenter)
        {
            var userQuestions = _questionRepository.GetUserQuestions(request.UserId);
            var response = new GetUserQuestionsResponse
            {
                UserQuestions = userQuestions
            };
            presenter.Success(response);
        }
    }
}
