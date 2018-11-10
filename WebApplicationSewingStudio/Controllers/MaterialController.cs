using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSewingStudio.Models;
using Microsoft.EntityFrameworkCore;
using WebApplicationSewingStudio.ViewModels;

namespace WebApplicationSewingStudio.Controllers
{
    public class MaterialController : Controller
    {
        private SewingStudioContext db;

        public MaterialController(SewingStudioContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var materials = db.Materials.ToList();
            return View(materials);
        }
    }
}