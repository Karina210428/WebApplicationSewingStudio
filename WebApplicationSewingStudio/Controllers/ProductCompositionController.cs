﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationSewingStudio.Models;
using WebApplicationSewingStudio.ViewModels;
using WebApplicationSewingStudio.ViewModels.ProductCompositionsViewModels;

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

        public IActionResult Index(string name, int page = 1, SortState sortOrder = SortState.ProductCompositionIdAsc)
        {
            int pageSize = 10;
            IQueryable<ProductComposition> source = db.ProductCompositions.Include(p => p.Material).Include(p => p.Product);
             if (!String.IsNullOrEmpty(name))
            {
                source = source.Where(p => p.Product.Name.Equals(name));
            }
            switch (sortOrder)
            {
                case SortState.ProductCompositionIdDec:
                    source = source.OrderByDescending(s => s.Id);
                    break;
                case SortState.ProductCompositionProductNameDec:
                    source = source.OrderByDescending(s => s.Product.Name);
                    break;
                case SortState.ProductCompositionMaterialNameDec:
                    source = source.OrderByDescending(s => s.Material.Name);
                    break;
                case SortState.ProductCompositionQuantityDec:
                    source = source.OrderByDescending(s => s.Quantity);
                    break;
                case SortState.ProductCompositionProductNameAsc:
                    source = source.OrderBy(s => s.Product.Name);
                    break;
                case SortState.ProductCompositionMaterialNameAsc:
                    source = source.OrderBy(s => s.Material.Name);
                    break;
                case SortState.ProductCompositionQuantityAsc:
                    source = source.OrderBy(s => s.Quantity);
                    break;
            }

            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);


            ProductCompositionsViewModel viewModel = new ProductCompositionsViewModel
            {
                PageViewModel = pageViewModel,
                ProductCompositions = items,
                ProductCompositionViewModel = productCompositionViewModel,
                SortViewModel = new ProductComposotionSortViewModel(sortOrder),
                FilterViewModel = new WebApplicationSewingStudio.ViewModels.ProductCompositionsViewModels.FilterViewModel(name)
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var items = db.ProductCompositions.Include(p=>p.Material).Include(p=>p.Product).Where(p => p.Id == id).ToList();
            var productList = new SelectList(db.Products, "Id", "Name", items.First().ProductId);
            var materialList = new SelectList(db.Materials, "Id", "Name", items.First().MaterialId);
            ProductCompositionsViewModel viewModel = new ProductCompositionsViewModel
            {
                ProductCompositions = items,
                ProductCompositionViewModel= productCompositionViewModel,
                ProductsList = productList,
                MaterialsList = materialList
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductComposition productComposition)
        {
            db.ProductCompositions.Update(productComposition);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var materials = new SelectList(db.Materials, "Id", "Name");
            ViewBag.MaterialId = materials;
            var products = new SelectList(db.Products, "Id", "Name");
            ViewBag.ProductId = products;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductComposition productComposition)
        {
            if (ModelState.IsValid)
            {
                db.ProductCompositions.Add(productComposition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            
            ProductComposition productComposition = db.ProductCompositions.Find(id);
            var products = db.Products.Where(p => p.Id == productComposition.ProductId).First();
            var materials = db.Materials.Where(p => p.Id == productComposition.MaterialId).First();
            ProductCompositionViewModel viewModel = new ProductCompositionViewModel
            {
                ProductName = productComposition.Product.Name,
                MaterialName = productComposition.Material.Name,
                Quantity = productComposition.Quantity,
            };
            ProductCompositionsViewModel productCompositionsViewModel = new ProductCompositionsViewModel
            {
                ProductCompositionViewModel = viewModel
            };
            if (productComposition == null)
                return View("NotFound");
            else
                return View(productCompositionsViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            ProductComposition productComposition = db.ProductCompositions.Find(id);
            if (productComposition != null)
            {
                db.ProductCompositions.Remove(productComposition);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}