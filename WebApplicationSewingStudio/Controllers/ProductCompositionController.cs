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
    public class ProductCompositionController : Controller
    {
        private readonly SewingStudioContext db;

        private ProductCompositionViewModel productCompositionViewModel = new ProductCompositionViewModel
        {
            MaterialName = "",
            ProductName = ""
        };

        public ProductCompositionController(SewingStudioContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var productCompstnContext = db.ProductCompositions.Include(p => p.Material).Include(p => p.Product);
            ProductCompositionsViewModel viewModel = new ProductCompositionsViewModel
            {
                ProductCompositions = productCompstnContext.Take(50).ToList(),
                ProductCompositionViewModel = productCompositionViewModel
            };
            return View(viewModel);
        }
    }
}