using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AskAMech.Core;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
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

        public HomeController(IModelPresenter modelPresenter, ILoginUseCase loginUseCase, IRegisterUseCase registerUseCase)
        {
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

        [HttpPost]
        public IActionResult SignOut()
        {
            UserSecurityManager.SignOut();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
