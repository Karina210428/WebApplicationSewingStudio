using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels.SuppliesViewModels
{
    public class SupplySortViewModel
    {
        public SortState SupplyId { get; private set; }
        public SortState SupplyName { get; private set; }
        public SortState SupplyMaterialName { get; private set; }
        public SortState SupplyQuantity { get; private set; }
        public SortState SupplyPrice { get; private set; }
        public SortState SupplyDeliveryDate { get; private set; }
        public SortState Current { get; private set; }

        public SupplySortViewModel(SortState sortOrder)
        {
            SupplyId = sortOrder == SortState.SupplyIdAsc ? SortState.SupplyIdDec : SortState.SupplyIdAsc;
            SupplyName = sortOrder == SortState.SupplyNameAsc ? SortState.SupplyNameDec : SortState.SupplyNameAsc;
            SupplyMaterialName = sortOrder == SortState.SupplyMaterialNameAsc ? SortState.SupplyIdDec : SortState.SupplyIdAsc;
            SupplyQuantity = sortOrder == SortState.SupplyQuantityAsc ? SortState.SupplyQuantityDec : SortState.SupplyQuantityAsc;
            SupplyPrice = sortOrder == SortState.SupplyPriceAsc ? SortState.SupplyPriceDec : SortState.SupplyPriceAsc;
            SupplyDeliveryDate = sortOrder == SortState.SupplyDeliveryDateAsc ? SortState.SupplyDeliveryDateDec : SortState.SupplyDeliveryDateAsc;
            Current = sortOrder;
        }
    }
}
