using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Interfaces
{
    public interface ISecurityManagerUseCase
    {
        void VerifyUserIsAdmin(IPresenter presenter);
        void VerifyUserIsMechanicOrGeneralUser(IPresenter presenter);
    }
}
