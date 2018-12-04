using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSewingStudio.Models;
using Microsoft.EntityFrameworkCore;
using WebApplicationSewingStudio.ViewModels;
using WebApplicationSewingStudio.ViewModels.MaterialsViewModels;

namespace WebApplicationSewingStudio.Controllers
{
    public class MaterialController : Controller
    {
        private SewingStudioContext db;

        public MaterialController(SewingStudioContext db)
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

        public IActionResult Index(int page=1, SortState sortOrder = SortState.MaterialIdAsc)
        {
            int pageSize = 10;
            IQueryable<Material> source = db.Materials;
            switch (sortOrder)
            {
                case SortState.MaterialNameAsc:
                    source = source.OrderBy(s => s.Name);
                    break;
                case SortState.MaterialTypeAsc:
                    source = source.OrderBy(s => s.Type);
                    break;
                case SortState.MaterialIdDec:
                    source = source.OrderByDescending(s => s.Id);
                    break;
                case SortState.MaterialNameDec:
                    source = source.OrderByDescending(s => s.Name);
                    break;
                case SortState.MaterialTypeDec:
                    source = source.OrderByDescending(s => s.Type);
                    break;
            }

            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            MaterialsViewModel viewModel = new MaterialsViewModel
            {
                Materials = items,
                PageViewModel = pageViewModel,
                SortViewModel = new MaterialSortViewModel(sortOrder)
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Material material)
        {
            db.Materials.Update(material);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Material material = db.Materials.Find(id);
            return View(material);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Material material)
        {
            db.Materials.Add(material);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            Material material = db.Materials.Find(id);

            if (material == null)
                return View("NotFound");
            else
                return View(material);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Material material = db.Materials.Find(id);
            if (material != null)
            {
                db.Materials.Remove(material);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }

    }
}