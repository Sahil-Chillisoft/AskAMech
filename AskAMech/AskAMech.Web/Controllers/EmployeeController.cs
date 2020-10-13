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
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace AskAMech.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly IEmployeeUseCase _employeeUseCase;

        public EmployeeController(IModelPresenter modelPresenter, IEmployeeUseCase employeeUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _employeeUseCase = employeeUseCase ?? throw new ArgumentNullException(nameof(employeeUseCase));
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeRequest request)
        {
            _employeeUseCase.Execute(request, _modelPresenter);

            if (!_modelPresenter.HasValidationErrors)
                return Json(new { Success = true, Message = "Employee Successfully Added" });

            var model = _modelPresenter.Model as EmployeeResponse;
            return Json(new { Sucess = false, Message = model?.ErrorMessage });
        }
    }
}