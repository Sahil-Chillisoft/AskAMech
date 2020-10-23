using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core
{
    public interface IReadOnlyUseCase
    {
        void Execute(IPresenter presenter);
    }
}
