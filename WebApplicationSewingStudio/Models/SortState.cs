using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.Models
{
    public enum SortState
    {
        EmployeeIdAsc,
        EmployeeIdDec,
        EmployeeNameAsc,
        EmployeeNameDec,
        EmployeeSurnameAsc,
        EmployeeSurnameDec,
        EmployeePatronymicAsc,
        EmployeePatronymicDec,
        EmployeeExecutionStartDateAsc,
        EmployeeExecutionStartDateDec,
        EmployeeDateOfDeliveryAsc,
        EmployeeDateOfDeliveryDec,
        EmployeeOrderIdAsc,
        EmployeeOrderIdDec,

        MaterialIdAsc,
        MaterialIdDec,
        MaterialNameAsc,
        MaterialNameDec,
        MaterialTypeAsc,
        MaterialTypeDec,

        ProductIdAsc,
        ProductIdDec,
        ProductNameAsc,
        ProductNameDec,
        ProductPriceAsc,
        ProductPriceDec,

        OrderIdAsc,
        OrderIdDec,
        OrderProductNameAsc,
        OrderProductNameDec,
        OrderPriceAsc,
        OrderPriceDec,
        OrderQuantityAsc,
        OrderQuantityDec,
        OrderDateOfOrderAsc,
        OrderDateOfOrderDec,
        OrderDateOfSaleAsc,
        OrderDateOfSaleDec,

        SupplyIdAsc,
        SupplyIdDec,
        SupplyNameAsc,
        SupplyNameDec,
        SupplyMaterialNameAsc,
        SupplyMaterialNameDec,
        SupplyPriceAsc,
        SupplyPriceDec,
        SupplyQuantityAsc,
        SupplyQuantityDec,
        SupplyDeliveryDateAsc,
        SupplyDeliveryDateDec,

        ProductCompositionIdAsc,
        ProductCompositionIdDec,
        ProductCompositionMaterialNameAsc,
        ProductCompositionMaterialNameDec,
        ProductCompositionProductNameAsc,
        ProductCompositionProductNameDec,
        ProductCompositionQuantityAsc,
        ProductCompositionQuantityDec,
    };
}
