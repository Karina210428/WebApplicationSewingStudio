using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable <Product> Products { get; set; }
        public IEnumerable<Material> Materials { get; set; }
        public IEnumerable<ProductCompositionViewModel> ProductCompositionViewModels { get; set; }
    }
}
