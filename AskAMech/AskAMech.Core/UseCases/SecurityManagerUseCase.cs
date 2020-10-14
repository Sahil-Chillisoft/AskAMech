using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
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
    }
}
