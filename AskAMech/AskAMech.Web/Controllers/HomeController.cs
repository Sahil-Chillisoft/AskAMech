using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AskAMech.Core;
using AskAMech.Core.UseCases;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AskAMech.Web.Models;
using AskAMech.Web.Presenters;

namespace AskAMech.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IModelPresenter _modelPresenter;
        private readonly ILoginUseCase _loginUseCase;
        private readonly IRegisterUseCase _registerUseCase;

        public HomeController(ILogger<HomeController> logger, IModelPresenter modelPresenter, ILoginUseCase loginUseCase, IRegisterUseCase registerUseCase)
        {
            _logger = logger;
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _loginUseCase = loginUseCase ?? throw new ArgumentNullException(nameof(loginUseCase));
            _registerUseCase = registerUseCase ?? throw new ArgumentNullException(nameof(registerUseCase));
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return PartialView("_Login");
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            _loginUseCase.Execute(request, _modelPresenter);
            //TODO: WIP.
            return View("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return PartialView("_Register");
        }

        [HttpPost]
        public IActionResult Register(RegisterRequest request)
        {
            _registerUseCase.Execute(request, _modelPresenter);
            return View("index");
        }

        [HttpGet]
        public IActionResult Questions()
        {
            throw new NotImplementedException();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
