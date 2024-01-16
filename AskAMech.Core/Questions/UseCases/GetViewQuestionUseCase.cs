using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Questions.Interfaces;
using AskAMech.Core.Questions.Requests;
using AskAMech.Core.Questions.Responses;

namespace AskAMech.Core.Questions.UseCases
{
    public class GetViewQuestionUseCase : IGetQuestionViewUseCase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswersRepository _answersRepository;
        public GetViewQuestionUseCase(IQuestionRepository questionRepository, IAnswersRepository answersRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _answersRepository = answersRepository ?? throw new ArgumentNullException(nameof(answersRepository));
        }

        public void Execute(GetViewQuestionRequest request, IPresenter presenter)
        {
            var questionDetails = _questionRepository.GetQuestionDetails(request.Id);
            var answers = _answersRepository.GetAnswers(request.Id);

            var response = new GetViewQuestionResponse
            {
                QuestionDetails = questionDetails, 
                Answers = answers
            };

            presenter.Success(response);
        }
    }
}
