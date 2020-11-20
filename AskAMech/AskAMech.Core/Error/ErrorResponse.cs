using System.Net;

namespace AskAMech.Core.Error
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
    }
}
