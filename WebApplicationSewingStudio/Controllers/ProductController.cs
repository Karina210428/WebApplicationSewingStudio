using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationSewingStudio.Models;
using WebApplicationSewingStudio.ViewModels;
using WebApplicationSewingStudio.ViewModels.ProductsViewModels;

namespace WebApplicationSewingStudio.Controllers
{
    public class ProductController : Controller
    {
        private SewingStudioContext db;
        public ProductController(SewingStudioContext db)
        {
            this.db = db;
        }

        public SewingStudioContext SewingStudioContext
        {
            get => default(SewingStudioContext);
            set
            {
            }
        }

        public IActionResult Index(int page = 1, SortState sortOrder = SortState.ProductIdAsc)
        {
            int pageSize = 10;
            IQueryable<Product> source = db.Products;
            switch (sortOrder)
            {
                case SortState.ProductNameAsc:
                    source = source.OrderBy(s => s.Name);
                    break;
                case SortState.ProductPriceAsc:
                    source = source.OrderBy(s => s.Price);
                    break;
                case SortState.ProductIdDec:
                    source = source.OrderByDescending(s => s.Id);
                    break;
                case SortState.ProductNameDec:
                    source = source.OrderByDescending(s => s.Name);
                    break;
                case SortState.ProductPriceDec:
                    source = source.OrderByDescending(s => s.Price);
                    break;
            }

            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ProductsViewModel viewModel = new ProductsViewModel
            {
                Products = items,
                PageViewModel = pageViewModel,
                SortViewModel = new ProductSortViewModel(sortOrder)
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            db.Products.Update(product);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            db.Products.Add(product);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            Product product = db.Products.Find(id);

            if (product == null)
                return View("NotFound");
            else
                return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }


    }
}