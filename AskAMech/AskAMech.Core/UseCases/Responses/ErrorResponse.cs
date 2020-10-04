using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AskAMech.Core.UseCases.Responses
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
    }
}
