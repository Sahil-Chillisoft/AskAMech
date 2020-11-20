using System.Net;
using AskAMech.Core.Domain;
using AskAMech.Core.Error;

namespace AskAMech.Core.Security
{
    public class SecurityManagerUseCase : ISecurityManagerUseCase
    {
        public void VerifyUserIsAdmin(IPresenter presenter)
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

        public void VerifyUserIsMechanicOrGeneralUser(IPresenter presenter)
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

        public void VerifyUserIsAuthenticated(IPresenter presenter)
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
