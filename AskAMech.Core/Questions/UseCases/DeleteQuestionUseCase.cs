using System;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Questions.Interfaces;
using AskAMech.Core.Questions.Requests;

namespace AskAMech.Core.Questions.UseCases
{
    public class DeleteQuestionUseCase : IDeleteQuestionUseCase
    {
        private readonly IQuestionRepository _questionRepository;

        public DeleteQuestionUseCase(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        }

        public void Execute(DeleteQuestionRequest request, IPresenter presenter)
        {
            _questionRepository.Delete(request.Id);
            presenter.Success(true);
        }
    }
}
