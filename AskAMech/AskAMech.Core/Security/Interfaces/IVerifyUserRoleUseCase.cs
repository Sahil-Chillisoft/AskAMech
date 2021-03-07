using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core.Security.Interfaces
{
    public interface IVerifyUserRoleUseCase
    {
        void IsAdmin(IPresenter presenter);
        void IsMechanicOrGeneralUser(IPresenter presenter);

    }
}
