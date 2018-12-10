using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.Controllers
{
    public class SalesDepartmentController : Controller
    {
        private SewingStudioContext db;
        public SalesDepartmentController(SewingStudioContext db)
        {
            this.db = db;
        }
        
        public IActionResult Information(int ?year)
        {
            if (year != null)
            {
                double sum = db.Orders.Where(s => s.Date_of_sale.Year == year).Sum(s => s.Price * s.Quantity);
                double sum1 = db.Supplies.Where(s => s.Delivery_date.Year == year).Sum(s => s.Price * s.Quantity);
                ViewData["sum"] = sum;
                ViewData["year"] = year;
                ViewData["sum1"] = sum1;
                return View();
            }
            else
            {
                double sum = db.Orders.Where(s => s.Date_of_sale.Year == DateTime.Now.Year).Sum(s => s.Price * s.Quantity);
                double sum1 = db.Supplies.Where(s => s.Delivery_date.Year == DateTime.Now.Year).Sum(s => s.Price * s.Quantity);
                ViewData["sum"] = sum;
                ViewData["year"] = DateTime.Now.Year;
                ViewData["sum1"] = sum1;
            }
            return View();
        }
    }
}