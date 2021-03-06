﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationSewingStudio.Models;
using WebApplicationSewingStudio.ViewModels;
using WebApplicationSewingStudio.ViewModels.SuppliesViewModels;

namespace WebApplicationSewingStudio.Controllers
{
    public class SupplyController : Controller
    {
        private SewingStudioContext db;

        public SupplyController(SewingStudioContext db)
        {
            this.db = db;
        }

        public SupplyViewModel supplyViewModel = new SupplyViewModel
        {
            NameMaterial = ""
        };

        public IActionResult Index(string name, int page = 1, SortState sortOrder = SortState.OrderIdAsc)
        {
            int pageSize = 10;
            IQueryable<Supply> source = db.Supplies.Include(p => p.Materials);
            if (!String.IsNullOrEmpty(name))
            {
                source = source.Where(p => p.Supplier.Contains(name));
            }
            switch (sortOrder)
            {
                case SortState.SupplyIdDec:
                    source = source.OrderByDescending(s => s.Id);
                    break;
                case SortState.SupplyNameDec:
                    source = source.OrderByDescending(s => s.Supplier);
                    break;
                case SortState.SupplyMaterialNameDec:
                    source = source.OrderByDescending(s => s.Materials.Name);
                    break;
                case SortState.SupplyQuantityDec:
                    source = source.OrderByDescending(s => s.Quantity);
                    break;
                case SortState.SupplyPriceDec:
                    source = source.OrderByDescending(s => s.Price);
                    break;
                case SortState.SupplyDeliveryDateDec:
                    source = source.OrderByDescending(s => s.Delivery_date);
                    break;
                case SortState.SupplyNameAsc:
                    source = source.OrderBy(s => s.Supplier);
                    break;
                case SortState.SupplyMaterialNameAsc:
                    source = source.OrderBy(s => s.Materials.Name);
                    break;
                case SortState.SupplyQuantityAsc:
                    source = source.OrderBy(s => s.Quantity);
                    break;
                case SortState.SupplyPriceAsc:
                    source = source.OrderBy(s => s.Price);
                    break;
                case SortState.SupplyDeliveryDateAsc:
                    source = source.OrderBy(s => s.Delivery_date);
                    break;
            }
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            SuppliesVeiwModel viewModel = new SuppliesVeiwModel
            {
                Supplies = items,
                PageViewModel = pageViewModel,
                SortViewModel = new SupplySortViewModel(sortOrder),
                SupplyViewModel = supplyViewModel,
                FilterViewModel = new WebApplicationSewingStudio.ViewModels.SuppliesViewModels.FilterViewModel(name)
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var items = db.Supplies.Include(p => p.Materials).Where(p => p.Id == id).ToList();
            var materialList = new SelectList(db.Materials, "Id", "Name", items.First().MaterialId);
            SuppliesVeiwModel viewModel = new SuppliesVeiwModel
            {
                Supplies = items,
                SupplyViewModel = supplyViewModel,
                MaterialsList = materialList
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Supply supply)
        {
            db.Supplies.Update(supply);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var materials = new SelectList(db.Materials, "Id", "Name");
            ViewBag.MaterialId = materials;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Supplies.Add(supply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            Supply supply = db.Supplies.Find(id);
            var material = db.Materials.Where(p => p.Id == supply.MaterialId).First();
            SupplyViewModel supplyView = new SupplyViewModel
            {
                Supplier = supply.Supplier,
                NameMaterial = material.Name,
                QuantityMaterials = supply.Quantity,
                Price = supply.Price,
                Delivery_date = supply.Delivery_date
            };
            SuppliesVeiwModel veiwModel = new SuppliesVeiwModel
            {
                SupplyViewModel = supplyView
            };
            if (supply == null)
                return View("NotFound");
            else
                return View(veiwModel);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Supply supply = db.Supplies.Find(id);
            if (supply != null)
            {
                db.Supplies.Remove(supply);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}