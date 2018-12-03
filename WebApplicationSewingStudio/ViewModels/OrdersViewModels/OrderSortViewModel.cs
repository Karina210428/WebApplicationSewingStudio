using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels.OrdersViewModels
{
    public class OrderSortViewModel
    {
        public SortState OrderId { get; private set; }
        public SortState OrderProductName { get; private set; }
        public SortState OrderQuantity { get; private set; }
        public SortState OrderPrice { get; private set; }
        public SortState OrderDateOfOrder { get; private set; }
        public SortState OrderDateOfSale { get; private set; }
        public SortState Current { get; private set; }

        public OrderSortViewModel(SortState sortOrder)
        {
            OrderId = sortOrder == SortState.OrderIdAsc ? SortState.OrderIdDec : SortState.OrderIdAsc;
            OrderProductName = sortOrder == SortState.OrderProductNameAsc ? SortState.OrderProductNameDec : SortState.OrderProductNameAsc;
            OrderQuantity = sortOrder == SortState.OrderQuantityAsc ? SortState.OrderQuantityDec : SortState.OrderQuantityAsc;
            OrderPrice = sortOrder == SortState.OrderPriceAsc ? SortState.OrderPriceDec : SortState.OrderPriceAsc;
            OrderDateOfOrder = sortOrder == SortState.OrderDateOfOrderAsc ? SortState.OrderDateOfOrderDec : SortState.OrderDateOfOrderAsc;
            OrderDateOfSale = sortOrder == SortState.OrderDateOfSaleAsc ? SortState.OrderDateOfSaleDec : SortState.OrderDateOfSaleAsc;
            Current = sortOrder;
        }
    }
}
