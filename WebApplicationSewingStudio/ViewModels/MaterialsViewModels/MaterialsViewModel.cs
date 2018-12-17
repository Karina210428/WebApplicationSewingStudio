using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels.MaterialsViewModels
{
    public class MaterialsViewModel
    {
        public Material Material { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public MaterialSortViewModel SortViewModel { get; set; }
        public IEnumerable<Material> Materials { get; set; } 
        public FilterViewModel FilterViewModel { get; set; }
    }
}
