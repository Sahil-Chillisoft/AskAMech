﻿#nullable enable
using System;
using Microsoft.AspNetCore.Mvc;
using AskAMech.Web.Presenters;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;
        private readonly ICreateEmployeeUseCase _createEmployeeUseCase;
        private readonly IGetEmployeesUseCase _getEmployeesUseCase;
        private readonly IGetEmployeesAutocompleteUseCase _getEmployeesAutocompleteUseCase;
        private readonly IGetEmployeeUseCase _getEmployeeUseCase;
        private readonly IGetAllEmployeesUseCase _getAllEmployeesUseCase;
        private readonly IUpdateEmployeeUseCase _updateEmployeeUseCase;

        public EmployeeController(IModelPresenter modelPresenter,
                                  ISecurityManagerUseCase securityManagerUseCase,
                                  ICreateEmployeeUseCase createEmployeeUseCase,
                                  IGetEmployeesUseCase getEmployeeUseCase,
                                  IGetEmployeesAutocompleteUseCase getEmployeesAutocompleteUseCase,
                                  IGetEmployeeUseCase getEmployeesUseCase,
                                  IGetAllEmployeesUseCase getAllEmployeesUseCase,
                                   IUpdateEmployeeUseCase updateEmployeeUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _createEmployeeUseCase = createEmployeeUseCase ?? throw new ArgumentNullException(nameof(createEmployeeUseCase));
            _getEmployeesUseCase = getEmployeeUseCase ?? throw new ArgumentNullException(nameof(getEmployeeUseCase));
            _getEmployeeUseCase = getEmployeesUseCase ?? throw new ArgumentNullException(nameof(getEmployeesUseCase));
            _getAllEmployeesUseCase = getAllEmployeesUseCase ?? throw new ArgumentNullException(nameof(getAllEmployeesUseCase));
            _getEmployeesAutocompleteUseCase = getEmployeesAutocompleteUseCase ?? throw new ArgumentNullException(nameof(getEmployeesAutocompleteUseCase));
            _updateEmployeeUseCase = updateEmployeeUseCase ?? throw new ArgumentNullException(nameof(updateEmployeeUseCase));

        }

        [HttpGet]
        public IActionResult Index()
        {
            _securityManagerUseCase.VerifyUserIsAdmin(_modelPresenter);

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

            _getEmployeesUseCase.Execute(new GetEmployeesRequest(), _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult Index(GetEmployeesRequest request)
        {
            ModelState.Clear();
            _getEmployeesUseCase.Execute(request, _modelPresenter);
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


       // [HttpPatch]
       // [Route("/UpdateUser/{Id}")]
        public IActionResult UpdateUser()
        {
            _getAllEmployeesUseCase.Execute(new GetEmployeeRequest(), _modelPresenter);
            return View(_modelPresenter);
            
        }

        [HttpPost]
        public IActionResult UpdateUser(UpdateEmployeeRequest request)
        {
            _updateEmployeeUseCase.Execute(request, _modelPresenter);

            if (!_modelPresenter.HasValidationErrors)
                return Json(new { Success = true, Message = "User is Successfully Updated" });

            var model = _modelPresenter.Model as UpdateEmployeeResponse;
            return Json(new { Sucess = false, Message = model?.ErrorMessage });
        }

        [HttpGet]
        public IActionResult CreateSuccess()
        {
            return PartialView("_CreateSuccess");
        }

        [HttpPost]
        public JsonResult GetEmployeesAutocomplete(GetEmployeesAutocompleteRequest request)
        {
            _getEmployeesAutocompleteUseCase.Execute(request, _modelPresenter);
            return Json(_modelPresenter.Model);
        }
    }
}