using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskAMech.Core;

namespace AskAMech.Web.Presenters
{
    public interface IModelPresenter : IPresenter
    {
        object Model { get; }
        bool HasValidationErrors { get; }
    }
}
