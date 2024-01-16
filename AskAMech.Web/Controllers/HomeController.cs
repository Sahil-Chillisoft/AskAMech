using System;
using System.Diagnostics;
using AskAMech.Core.Login.Interfaces;
using AskAMech.Core.Login.Requests;
using AskAMech.Core.Register.Interfaces;
using AskAMech.Core.Register.Requests;
using AskAMech.Core.Security.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AskAMech.Web.Models;
using AskAMech.Web.Presenters;

namespace AskAMech.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ILoginUseCase _loginUseCase;
        private readonly IRegisterUseCase _registerUseCase;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;

        public HomeController(IModelPresenter modelPresenter,
                              ILoginUseCase loginUseCase,
                              IRegisterUseCase registerUseCase, 
                              ISecurityManagerUseCase securityManagerUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _loginUseCase = loginUseCase ?? throw new ArgumentNullException(nameof(loginUseCase));
            _registerUseCase = registerUseCase ?? throw new ArgumentNullException(nameof(registerUseCase));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
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

            if (_modelPresenter.HasValidationErrors)
            {
                ModelState.AddModelError("Login", "Incorrect Login Details");
                return PartialView("_Login", _modelPresenter.Model);
            }

            return PartialView("_Login");
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

            if (_modelPresenter.HasValidationErrors)
            {
                ModelState.AddModelError("Register", "Registration Details Invalid");
                return PartialView("_Register", _modelPresenter.Model);
            }

            return PartialView("_Register");
        }

        [HttpGet]
        public IActionResult Questions()
        {
            return RedirectToAction("Index", "Question");
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            _securityManagerUseCase.SignOut();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
