#nullable enable
using System;
using AskAMech.Core.Domain;
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
        private readonly IGetEmployeeForEditUseCase _getEmployeeForEditUseCase;
        private readonly IEditEmployeeUseCase _editEmployeeUseCase;

        public EmployeeController(IModelPresenter modelPresenter,
                                  ISecurityManagerUseCase securityManagerUseCase,
                                  ICreateEmployeeUseCase createEmployeeUseCase,
                                  IGetEmployeesUseCase getEmployeeUseCase,
                                  IGetEmployeesAutocompleteUseCase getEmployeesAutocompleteUseCase,
                                  IGetEmployeeUseCase getEmployeesUseCase,
                                  IGetEmployeeForEditUseCase getEmployeeForEditUseCase,
                                   IEditEmployeeUseCase editEmployeeUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _createEmployeeUseCase = createEmployeeUseCase ?? throw new ArgumentNullException(nameof(createEmployeeUseCase));
            _getEmployeesUseCase = getEmployeeUseCase ?? throw new ArgumentNullException(nameof(getEmployeeUseCase));
            _getEmployeeUseCase = getEmployeesUseCase ?? throw new ArgumentNullException(nameof(getEmployeesUseCase));
            _getEmployeeForEditUseCase = getEmployeeForEditUseCase ?? throw new ArgumentNullException(nameof(getEmployeeForEditUseCase));
            _getEmployeesAutocompleteUseCase = getEmployeesAutocompleteUseCase ?? throw new ArgumentNullException(nameof(getEmployeesAutocompleteUseCase));
            _editEmployeeUseCase = editEmployeeUseCase ?? throw new ArgumentNullException(nameof(editEmployeeUseCase));

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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var request = new EditEmployeeRequest()
            {
                Employee = new Employee()
                {
                    Id = id
                }
            };

            _getEmployeeForEditUseCase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult Edit(Employee? employee)
        {
            EditEmployeeRequest request = new EditEmployeeRequest()
            {
                Employee = new Employee()
                {
                    Id = employee.Id,
                    FirstName=employee.FirstName,
                    LastName=employee.LastName,
                    IdNumber=employee.IdNumber,
                    Email=employee.Email,
                    LastModifiedByUserId=employee.LastModifiedByUserId,
                    DateLastModified=employee.DateLastModified
                }
            };
            _editEmployeeUseCase.Execute(request, _modelPresenter);

            if (!_modelPresenter.HasValidationErrors)
                return Json(new { Success = true, Message = "Employee has been successfully updated" });

            var model = _modelPresenter.Model as EditEmployeeResponse;
            return Json(new { Sucess = false, Message = model?.ErrorMessage });
        }

        [HttpGet]
        public IActionResult CreateSuccess()
        {
            return PartialView("_CreateSuccess");
        }
        [HttpGet]
        public IActionResult EditSuccess()
        {
            return PartialView("_EditSuccess");
        }

        [HttpPost]
        public JsonResult GetEmployeesAutocomplete(GetEmployeesAutocompleteRequest request)
        {
            _getEmployeesAutocompleteUseCase.Execute(request, _modelPresenter);
            return Json(_modelPresenter.Model);
        }
    }
}