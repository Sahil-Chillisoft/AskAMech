using AskAMech.Core.Answers.Interfaces;
using AskAMech.Core.Answers.Requests;
using AskAMech.Core.Answers.Responses;

namespace AskAMech.Core.Answers.UseCases
{
    public class GetConfirmAcceptedAnswerUseCase : IGetConfirmAcceptedAnswerUseCase
    {
        public void Execute(GetConfirmAcceptedAnswerRequest request, IPresenter presenter)
        {
            var response = new GetConfirmAcceptedAnswerResponse();
            if (request.IsAcceptedAnswer)
            {
                response.Title = "Mark As Accepted Answer";
                response.Message = "Are you sure you want to mark the following answer as the accepted answer for this question?";
            }
            else
            {
                response.Title = "Un-mark As Accepted Answer";
                response.Message = "Are you sure you want to un-mark the following answer as the accepted answer for this question?";
            }
            presenter.Success(response);
        }
    }
}
