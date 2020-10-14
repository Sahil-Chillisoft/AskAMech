using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;
        private readonly IUserDashboardUseCase _userDashboardUseCase;

        public DashboardController(IModelPresenter modelPresenter, ISecurityManagerUseCase securityManagerUseCase, IUserDashboardUseCase userDashboardUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _userDashboardUseCase = userDashboardUseCase ?? throw new ArgumentNullException(nameof(userDashboardUseCase));
        }

        [HttpGet]
        public IActionResult UserDashboard()
        {
            _securityManagerUseCase.VerifyUserIsMechanicOrGeneralUser(_modelPresenter);

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
            _securityManagerUseCase.VerifyUserIsAdmin(_modelPresenter);

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
