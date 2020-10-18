#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AskAMech.Web.Presenters;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;
        private readonly ICreateEmployeeUseCase _createEmployeeUseCase;
        private readonly IEmployeeListUsecase _employeeListUsecase;

        public EmployeeController(IModelPresenter modelPresenter, ISecurityManagerUseCase securityManagerUseCase,ICreateEmployeeUseCase createEmployeeUseCase, IEmployeeListUsecase employeeListUsecase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _createEmployeeUseCase = createEmployeeUseCase ?? throw new ArgumentNullException(nameof(createEmployeeUseCase));
            _employeeListUsecase = employeeListUsecase ?? throw new ArgumentNullException(nameof(employeeListUsecase));
        }

        [HttpGet]
        public IActionResult Index(GetAllEmployeesRequest request)
        {
           _employeeListUsecase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
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
        public IActionResult Create(CreateEmployeeRequest request)
        {
            _createEmployeeUseCase.Execute(request, _modelPresenter);

            if (!_modelPresenter.HasValidationErrors)
                return Json(new { Success = true, Message = "Employee Successfully Added" });

            var model = _modelPresenter.Model as CreateEmployeeResponse;
            return Json(new { Sucess = false, Message = model?.ErrorMessage });
        }

        [HttpGet]
        public IActionResult CreateSuccess()
        {
            return PartialView("_CreateSuccess");
        }
    }
}