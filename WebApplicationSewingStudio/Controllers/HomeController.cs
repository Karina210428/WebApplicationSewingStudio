using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.Controllers
{
    public class HomeController : Controller
    {
        private SewingStudioContext db;
        public HomeController(SewingStudioContext db)
        {
            this.db = db;
        }
        
        public IActionResult Index()
        {
            var materialsList = db.Materials.Take(10).ToList();
            var productsList = db.Products.Take(10).ToList();
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
