using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels.ProductsViewModels
{
    public class ProductsViewModel
    {
        public PageViewModel PageViewModel { get; set; }
        public Product Product { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public ProductSortViewModel SortViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
