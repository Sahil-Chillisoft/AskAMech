using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AskAMech.Web.Presenters;
using AskAMech.Web.Models;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;

namespace AskAMech.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IModelPresenter _modelPresenter;
        private readonly IEmployeesUsecase _employeesUsecase;

        public EmployeeController(ILogger<EmployeeController> logger, IModelPresenter modelPresenter, IEmployeesUsecase employeesUsecase)
        {
            _logger = logger;
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _employeesUsecase = employeesUsecase ?? throw new ArgumentNullException(nameof(employeesUsecase));

        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminCreate_Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminCreate_Employee/Create
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: AdminCreate_Employee/Create
        [HttpPost]
        public ActionResult AddEmployee(EmployeeRequest request)
        {
            _employeesUsecase.Execute(request, _modelPresenter);
            if (_modelPresenter.HasValidationErrors)
            {
                ModelState.AddModelError("Employee", "Registration Details Invalid");
                return View("AddEmployee", _modelPresenter.Model);
            }

            return View();

        }

        // GET: AdminCreate_Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminCreate_Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminCreate_Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminCreate_Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}