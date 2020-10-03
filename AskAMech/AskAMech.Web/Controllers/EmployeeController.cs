using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: AdminCreate_Employee
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCreate_Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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