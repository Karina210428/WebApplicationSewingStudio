using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels.MaterialsViewModels
{
    public class MaterialSortViewModel
    {
        public SortState MaterialId { get; set; }
        public SortState MaterialName { get; set; }
        public SortState MaterialType { get; set; }
        public SortState Current { get; set; }

        public MaterialSortViewModel(SortState sortOrder)
        {
            MaterialId = sortOrder == SortState.MaterialIdAsc ? SortState.MaterialIdDec : SortState.MaterialIdAsc;
            MaterialName = sortOrder == SortState.MaterialNameAsc ? SortState.MaterialNameDec : SortState.MaterialNameAsc;
            MaterialType = sortOrder == SortState.MaterialTypeAsc ? SortState.MaterialTypeDec : SortState.MaterialTypeAsc;
            Current = sortOrder;
        }
    }
}
