using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationSewingStudio.Models;
using WebApplicationSewingStudio.ViewModels;

namespace WebApplicationSewingStudio.Controllers
{
    public class ProductController : Controller
    {
        private SewingStudioContext db;
        public ProductController(SewingStudioContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }
    }
}