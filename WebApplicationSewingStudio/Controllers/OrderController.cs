using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationSewingStudio.Models;
using WebApplicationSewingStudio.ViewModels;
using WebApplicationSewingStudio.ViewModels.OrdersViewModels;

namespace WebApplicationSewingStudio.Controllers
{
    public class OrderController : Controller
    {
        private SewingStudioContext db;

        private OrderViewModel orderViewModel = new OrderViewModel
        {
            NameProduct = ""
        };

        public OrderController(SewingStudioContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int id, int page = 1, SortState sortOrder = SortState.OrderIdAsc)
        {
            int pageSize = 10;
            IQueryable<Order> source = db.Orders.Include(p => p.Product);
            if (id!=0)
            {
                source = source.Where(p => p.Id == id);
            }
            switch (sortOrder)
            {
                case SortState.OrderIdDec:
                    source = source.OrderByDescending(s => s.Id);
                    break;
                case SortState.OrderProductNameDec:
                    source = source.OrderByDescending(s => s.Product.Name);
                    break;
                case SortState.OrderQuantityDec:
                    source = source.OrderByDescending(s => s.Quantity);
                    break;
                case SortState.OrderPriceDec:
                    source = source.OrderByDescending(s => s.Price);
                    break;
                case SortState.OrderDateOfOrderDec:
                    source = source.OrderByDescending(s => s.Date_of_order);
                    break;
                case SortState.OrderDateOfSaleDec:
                    source = source.OrderByDescending(s => s.Date_of_sale);
                    break;
                case SortState.OrderProductNameAsc:
                    source = source.OrderBy(s => s.Product.Name);
                    break;
                case SortState.OrderQuantityAsc:
                    source = source.OrderBy(s => s.Quantity);
                    break;
                case SortState.OrderPriceAsc:
                    source = source.OrderBy(s => s.Price);
                    break;
                case SortState.OrderDateOfOrderAsc:
                    source = source.OrderBy(s => s.Date_of_order);
                    break;
                case SortState.OrderDateOfSaleAsc:
                    source = source.OrderBy(s => s.Date_of_sale);
                    break;
            }

            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);


            OrdersViewModel viewModel = new OrdersViewModel
            {
                Orders = items,
                OrderViewModel = orderViewModel,
                SortViewModel = new OrderSortViewModel(sortOrder),
                PageViewModel = pageViewModel,
                FilterViewModel = new FilterViewModel(id)
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var orders = db.Orders.Include(p => p.Product);
            var items = orders.Where(p => p.Id == id).ToList();
            var productList = new SelectList(db.Products, "Name", "Name", items.First().ProductId);
            OrdersViewModel viewModel = new OrdersViewModel
            {
                Orders = items,
                OrderViewModel = orderViewModel,
                ProductsList = productList
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            db.Orders.Update(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Create()
        {
            var products = new SelectList(db.Products, "Id", "Name");
            ViewBag.ProductId = products;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            db.Orders.Add(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            Order order = db.Orders.Find(id);

            if (order == null)
                return View("NotFound");
            else
                return View(order);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}