using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels.ProductCompositionsViewModels
{
    public class ProductComposotionSortViewModel
    {
        public SortState ProductCompositionId { get; set; }
        public SortState ProductCompositionProductName { get; set; }
        public SortState ProductCompositionMaterialName { get; set; }
        public SortState ProductCompositionQuantity { get; set; }
        public SortState Current { get; private set; }

        public ProductComposotionSortViewModel(SortState sortOrder)
        {
            ProductCompositionId = sortOrder == SortState.ProductCompositionIdAsc ? SortState.ProductCompositionIdDec : SortState.ProductCompositionIdAsc;
            ProductCompositionProductName = sortOrder == SortState.ProductCompositionProductNameAsc ? SortState.ProductCompositionProductNameDec : SortState.ProductCompositionProductNameAsc;
            ProductCompositionMaterialName = sortOrder == SortState.ProductCompositionMaterialNameAsc ? SortState.ProductCompositionMaterialNameDec : SortState.ProductCompositionMaterialNameAsc;
            ProductCompositionQuantity = sortOrder == SortState.ProductCompositionQuantityAsc ? SortState.ProductCompositionQuantityDec : SortState.ProductCompositionQuantityAsc;
            Current = sortOrder;
        }

    }
}
