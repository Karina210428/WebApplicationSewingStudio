using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels.ProductsViewModels
{
    public class ProductSortViewModel
    {
        public SortState ProductId { get; set; }
        public SortState ProductName { get; set; }
        public SortState ProductPrice { get; set; }
        public SortState Current { get; set; }

        public ProductSortViewModel(SortState sortOrder)
        {
            ProductId = sortOrder == SortState.ProductIdAsc ? SortState.ProductIdDec : SortState.ProductIdAsc;
            ProductName = sortOrder == SortState.ProductNameAsc ? SortState.ProductNameDec : SortState.ProductNameAsc;
            ProductPrice = sortOrder == SortState.ProductPriceAsc ? SortState.ProductPriceDec : SortState.ProductPriceAsc;
            Current = sortOrder;
        }
    }
}
