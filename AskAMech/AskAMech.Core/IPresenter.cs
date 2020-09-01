using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core
{
    public interface IPresenter
    {
        void Success<TResponse>(TResponse response);
    }
}
