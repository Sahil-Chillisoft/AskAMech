using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult UserDashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
