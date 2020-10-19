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

        public RolesController(IModelPresenter modelPresenter, ISecurityManagerUseCase securityManagerUseCase, ICreateUserRoleUsecase createUserRoleUsecase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _createUserRoleUsecase = createUserRoleUsecase ?? throw new ArgumentNullException(nameof(createUserRoleUsecase));
            
        }

        [HttpPost]
        public IActionResult Index(CreateUserRoleRequest request)
        {
            _createUserRoleUsecase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpGet]
        public IActionResult CreateSuccess()
        {
            return PartialView("_CreateSuccess");
        }

        [HttpGet]
        public IActionResult RolesList(CreateUserRoleRequest request)
        {
            _createUserRoleUsecase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }
    }
}