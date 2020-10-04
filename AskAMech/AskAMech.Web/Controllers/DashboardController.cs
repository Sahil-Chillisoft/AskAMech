using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Web.Models;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AskAMech.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly IUserDashboardUseCase _userDashboardUseCase;

        public DashboardController(IModelPresenter modelPresenter, IUserDashboardUseCase userDashboardUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _userDashboardUseCase = userDashboardUseCase ?? throw new ArgumentNullException(nameof(userDashboardUseCase));
        }

        [HttpGet]
        public IActionResult UserDashboard()
        {
            var request = new UserDashboardRequest
            {
                UserId = UserSecurityManager.UserId
            };
            _userDashboardUseCase.Execute(request, _modelPresenter);

            if (_modelPresenter.HasValidationErrors)
                return RedirectToAction("Index", "Error",
                    new
                    {
                        message = "Access Denied",
                        code = HttpStatusCode.Unauthorized,
                    });

            return View(_modelPresenter.Model);
        }

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            if (UserSecurityManager.UserRoleId != (int)UserRole.Admin)
            {
                return RedirectToAction("Index", "Error",
                    new
                    {
                        message = "Access Denied",
                        code = HttpStatusCode.Unauthorized,
                    });
            }

            return View();
        }
    }
}
