using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels.ProductCompositionsViewModels
{
    public class ProductCompositionsViewModel
    {
        public PageViewModel PageViewModel { get; set; }
        public IEnumerable<ProductComposition> ProductCompositions { get; set; }
        public ProductComposotionSortViewModel SortViewModel { get; set; }
        public SelectList ProductsList { get; set; }
        public SelectList MaterialsList { get; set; }
        public ProductCompositionViewModel ProductCompositionViewModel { get; set; }
    }
}
