using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels.OrdersViewModels
{
    public class OrdersViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public OrderViewModel OrderViewModel { get; set; }
        public Order Order { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SelectList ProductsList { get; set; }
        public OrderSortViewModel SortViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
