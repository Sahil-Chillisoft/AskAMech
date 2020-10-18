using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core
{
    public interface IUseCase<in TRequest>
    {
        void Execute(TRequest request, IPresenter presenter);

    }
}
