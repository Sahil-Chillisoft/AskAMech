#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AskAMech.Web.Presenters;
using AskAMech.Web.Models;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;
        private readonly IEmployeeUseCase _employeeUseCase;

        public EmployeeController(IModelPresenter modelPresenter, ISecurityManagerUseCase securityManagerUseCase, IEmployeeUseCase employeeUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _employeeUseCase = employeeUseCase ?? throw new ArgumentNullException(nameof(employeeUseCase));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
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
        public IActionResult Create(EmployeeRequest request)
        {
            _employeeUseCase.Execute(request, _modelPresenter);

            if (!_modelPresenter.HasValidationErrors)
                return Json(new { Success = true, Message = "Employee Successfully Added" });

            var model = _modelPresenter.Model as EmployeeResponse;
            return Json(new { Sucess = false, Message = model?.ErrorMessage });
        }

        [HttpGet]
        public IActionResult CreateSuccess()
        {
            return PartialView("_CreateSuccess");
        }
    }
}