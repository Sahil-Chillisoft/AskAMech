using System.Net;
using AskAMech.Core.Domain;
using AskAMech.Core.Error;
using AskAMech.Core.Security.Interfaces;

namespace AskAMech.Core.Security.UseCases
{
    public class VerifyUserRoleUseCase : IVerifyUserRoleUseCase
    {
        public void IsAdmin(IPresenter presenter)
        {
            if (UserSecurityManager.IsAuthenticated &&
                UserSecurityManager.UserRoleId == (int)UserRole.Admin)
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

        public void IsMechanicOrGeneralUser(IPresenter presenter)
        {
            if (UserSecurityManager.IsAuthenticated &&
                (UserSecurityManager.UserRoleId == (int)UserRole.Mechanic ||
                 UserSecurityManager.UserRoleId == (int)UserRole.GeneralUser))
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
