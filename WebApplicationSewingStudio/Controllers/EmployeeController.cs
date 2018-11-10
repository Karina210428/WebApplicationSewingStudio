using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.Controllers
{
    public class EmployeeController : Controller
    {
        private SewingStudioContext db;

        public EmployeeController(SewingStudioContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var employees = db.Employees.ToList();
            return View(employees);
        }
    }
}