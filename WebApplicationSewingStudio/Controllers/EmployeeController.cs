using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationSewingStudio.Models;
using WebApplicationSewingStudio.ViewModels;
using WebApplicationSewingStudio.ViewModels.EmployeesViewModels;

namespace WebApplicationSewingStudio.Controllers
{
    public class EmployeeController : Controller
    {
        private SewingStudioContext db;

        private EmployeeViewModel employeeViewModel = new EmployeeViewModel
        {
            OrderId = 0
        };

        public EmployeeController(SewingStudioContext db)
        {
            this.db = db;
        }

        public IActionResult Index(string name, string surname, string patronymic, int page = 1, SortState sortOrder = SortState.EmployeeIdAsc )
        {
            int pageSize = 15;
            var employees = db.Employees.Include(p => p.Order);
            IQueryable<Employee> source = db.Employees.Include(p => p.Order);

            if (!String.IsNullOrEmpty(name))
            {
                source = source.Where(p => p.Name.Contains(name));
            }
            if (!String.IsNullOrEmpty(surname))
            {
                source = source.Where(p => p.Surname.Contains(surname));
            }
            if (!String.IsNullOrEmpty(patronymic))
            {
                source = source.Where(p => p.Patronymic.Contains(patronymic));
            }

            switch (sortOrder)
            {
                case SortState.EmployeeIdDec:
                    source = source.OrderByDescending(s => s.Id);
                    break;
                case SortState.EmployeeNameDec:
                    source = source.OrderByDescending(s => s.Name);
                    break;
                case SortState.EmployeeSurnameDec:
                    source = source.OrderByDescending(s => s.Surname);
                    break;
                case SortState.EmployeePatronymicDec:
                    source = source.OrderByDescending(s => s.Patronymic);
                    break;
                case SortState.EmployeeExecutionStartDateDec:
                    source = source.OrderByDescending(s => s.Execution_start_date);
                    break;
                case SortState.EmployeeDateOfDeliveryDec:
                    source = source.OrderByDescending(s => s.Date_of_delivery);
                    break;
                case SortState.EmployeeNameAsc:
                    source = source.OrderBy(s => s.Name);
                    break;
                case SortState.EmployeeSurnameAsc:
                    source = source.OrderBy(s => s.Surname);
                    break;
                case SortState.EmployeePatronymicAsc:
                    source = source.OrderBy(s => s.Patronymic);
                    break;
                case SortState.EmployeeExecutionStartDateAsc:
                    source = source.OrderBy(s => s.Execution_start_date);
                    break;
                case SortState.EmployeeDateOfDeliveryAsc:
                    source = source.OrderBy(s => s.Date_of_delivery);
                    break;
                default:
                    source = source.OrderBy(s => s.Id);
                    break;
            }
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            EmployeesViewModel viewModel = new EmployeesViewModel
            {
                Employees = items,
                EmployeeViewModel = employeeViewModel,
                SortViewModel = new EmployeeSortViewModel(sortOrder),
                PageViewModel = pageViewModel,
                FilterViewModel = new FilterViewModel(name, surname, patronymic)
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var items = db.Employees.Include(p => p.Order).Where(p => p.Id == id).ToList();
            var orderList = new SelectList(db.Orders, "Id", "Id", items.First().OrderId);
            EmployeesViewModel viewModel = new EmployeesViewModel
            {
                Employees = items,
                EmployeeViewModel = employeeViewModel,
                OrdersList = orderList
            };
            return View(viewModel); 
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            db.Employees.Update(employee);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            var orders = new SelectList(db.Orders, "Id", "Id");
            ViewBag.OrderId = orders;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                // сохраняем в бд все изменения
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            var employee = db.Employees.Find(id);

            if (employee == null)
                return View("NotFound");
            else
                return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            var employee = db.Employees.Find(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ViewResult DetailsOrder(int id)
        {
            Order order = db.Orders.Find(id);
            return View(order);
        }

    }
}