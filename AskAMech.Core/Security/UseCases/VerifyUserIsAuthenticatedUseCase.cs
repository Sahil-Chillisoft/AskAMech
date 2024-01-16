using System.Net;
using AskAMech.Core.Domain;
using AskAMech.Core.Error;
using AskAMech.Core.Security.Interfaces;

namespace AskAMech.Core.Security.UseCases
{
    public class VerifyUserIsAuthenticatedUseCase : IVerifyUserIsAuthenticatedUseCase
    {
        public void IsAuthenticated(IPresenter presenter)
        {
            if (UserSecurityManager.IsAuthenticated)
            {
                presenter.Success(true);
            }
            else
            {
                var response = new ErrorResponse
                {
                    Message = "Access Denied",
                    Code = HttpStatusCode.Unauthorized
                };
                presenter.Error(response, true);
            }
        }
    }
}