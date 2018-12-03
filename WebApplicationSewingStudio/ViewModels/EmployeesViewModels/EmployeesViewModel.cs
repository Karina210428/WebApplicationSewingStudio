using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels.EmployeesViewModels
{
    public class EmployeesViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public EmployeeViewModel EmployeeViewModel { get; set; }
        public Employee Employee { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SelectList OrdersList { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public EmployeeSortViewModel SortViewModel { get; set; }
    }
}
