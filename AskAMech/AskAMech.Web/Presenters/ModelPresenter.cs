using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskAMech.Web.Presenters
{
    public class ModelPresenter : IModelPresenter
    {
        public object Model { get; private set; }
        public void Success<TResponse>(TResponse response)
        {
            Model = response;
        }
    }
}
