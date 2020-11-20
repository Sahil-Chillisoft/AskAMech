using System;
using AskAMech.Core.Error;
using AskAMech.Core.Security;
using AskAMech.Core.UserRoles.Interfaces;
using AskAMech.Core.UserRoles.Requests;
using AskAMech.Core.UserRoles.Responses;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;
        private readonly ICreateUserRoleUseCase _createUserRoleUseCase;
        private readonly IGetRoleUseCase _getRoleUseCase;

        public RolesController(IModelPresenter modelPresenter,
                               ISecurityManagerUseCase securityManagerUseCase,
                               ICreateUserRoleUseCase createUserRoleUseCase,
                               IGetRoleUseCase getRoleUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _createUserRoleUseCase = createUserRoleUseCase ?? throw new ArgumentNullException(nameof(createUserRoleUseCase));
            _getRoleUseCase = getRoleUseCase ?? throw new ArgumentNullException(nameof(getRoleUseCase));
        }

        [HttpGet]
        public IActionResult Create()
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

        [HttpPost]
        public IActionResult Create(CreateUserRoleRequest request)
        {
            _createUserRoleUseCase.Execute(request, _modelPresenter);

            if (!_modelPresenter.HasValidationErrors)
                return Json(new { Success = true });

            var model = _modelPresenter.Model as CreateUserRoleResponse;
            return Json(new { Sucess = false, Message = model?.ErrorMessage });
        }

        [HttpGet]
        public IActionResult CreateSuccess()
        {
            return PartialView("_CreateSuccess");
        }

        [HttpGet]
        public IActionResult RolesList(CreateUserRoleRequest request)
        {
            _getRoleUseCase.Execute(request, _modelPresenter);
            return PartialView("_RolesList", _modelPresenter.Model);
        }
    }
}