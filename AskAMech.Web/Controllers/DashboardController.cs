using System;
using AskAMech.Core.Dashboard.Interfaces;
using AskAMech.Core.Dashboard.Requests;
using AskAMech.Core.Domain;
using AskAMech.Core.Error;
using AskAMech.Core.Security.Interfaces;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly IUserDashboardUseCase _userDashboardUseCase;
        private readonly IVerifyUserRoleUseCase _verifyUserRoleUseCase;

        public DashboardController(IModelPresenter modelPresenter,
                                   IUserDashboardUseCase userDashboardUseCase, 
                                   IVerifyUserRoleUseCase verifyUserRoleUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _userDashboardUseCase = userDashboardUseCase ?? throw new ArgumentNullException(nameof(userDashboardUseCase));
            _verifyUserRoleUseCase = verifyUserRoleUseCase ?? throw new ArgumentNullException(nameof(verifyUserRoleUseCase));
        }

        [HttpGet]
        public IActionResult UserDashboard()
        {
            _verifyUserRoleUseCase.IsMechanicOrGeneralUser(_modelPresenter);

            if (_modelPresenter.HasValidationErrors)
            {
                var model = _modelPresenter.Model as ErrorResponse;
                return RedirectToAction("Index", "Error",
                    new
                    {
                        message = model?.Message,
                        code = model?.Code
                    });
            }

            var request = new UserDashboardRequest { UserId = UserSecurityManager.UserId };
            _userDashboardUseCase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            _verifyUserRoleUseCase.IsAdmin(_modelPresenter);

            if (!_modelPresenter.HasValidationErrors)
                return View();

            var model = _modelPresenter.Model as ErrorResponse;
            return RedirectToAction("Index", "Error",
                new
                {
                    message = model?.Message,
                    code = model?.Code
                });
        }
    }
}
