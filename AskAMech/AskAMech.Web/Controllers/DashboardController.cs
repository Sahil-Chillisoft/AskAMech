using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskAMech.Core.Domain;
using AskAMech.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class DashboardController : Controller
    {
        /*
         * TODO:
         * Create a custom error page and not use the ErrorViewModel
         * Perform the UserRole check in a UseCase where a Model needs to be returned for KPI's
         * Load custom error page if the presenter has errors or load the dashboard if there are no errors.
         */

        [HttpGet]
        public IActionResult UserDashboard()
        {
            if (UserSecurityManager.UserRoleId == (int)UserRole.Mechanic ||
                UserSecurityManager.UserRoleId == (int)UserRole.PublicUser)
                return View();
            else
                return View(new ErrorViewModel());
        }

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            return UserSecurityManager.UserRoleId == (int)UserRole.Admin ? View() : View(new ErrorViewModel());
        }
    }
}
