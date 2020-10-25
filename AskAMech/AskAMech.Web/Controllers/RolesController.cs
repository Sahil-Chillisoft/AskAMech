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
    public class RolesController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;
        private readonly ICreateUserRoleUsecase _createUserRoleUsecase;
        private readonly IGetRoleUseCase _getRoleUseCase;

        public RolesController(IModelPresenter modelPresenter, ISecurityManagerUseCase securityManagerUseCase, ICreateUserRoleUsecase createUserRoleUsecase, IGetRoleUseCase getRoleUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _createUserRoleUsecase = createUserRoleUsecase ?? throw new ArgumentNullException(nameof(createUserRoleUsecase));
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
            _createUserRoleUsecase.Execute(request, _modelPresenter);
            
            if (!_modelPresenter.HasValidationErrors)
                return Json(new { Success = true, Message = "Role Successfully Added" });

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
            return PartialView("_RolesList",_modelPresenter.Model);
        }
    }
}