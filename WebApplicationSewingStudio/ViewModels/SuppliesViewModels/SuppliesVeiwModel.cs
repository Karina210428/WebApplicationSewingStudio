using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels.SuppliesViewModels
{
    public class SuppliesVeiwModel
    {
        public IEnumerable<Supply> Supplies { get; set; }
        public SupplyViewModel SupplyViewModel { get; set; }
        public Supply Supply { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SelectList MaterialsList { get; set; }
        public SupplySortViewModel SortViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
