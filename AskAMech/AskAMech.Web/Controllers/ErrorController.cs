using System.Net;
using AskAMech.Core.Error;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Index(string message, HttpStatusCode code)
        {
            var response = new ErrorResponse
            {
                Message = message,
                Code = code
            };
            return View(response);
        }
    }
}
