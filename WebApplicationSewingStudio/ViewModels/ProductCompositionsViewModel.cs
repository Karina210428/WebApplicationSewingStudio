using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels
{
    public class ProductCompositionsViewModel
    {
        public IEnumerable<ProductComposition> ProductCompositions { get; set; }
        public ProductCompositionViewModel ProductCompositionViewModel { get; set; }
    }
}
