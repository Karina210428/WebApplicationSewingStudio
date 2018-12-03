using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.ViewModels
{
    public class SupplyViewModel
    {
        [Display(Name = "Код поставки")]
        public int Id { get; set; }
        [Display(Name = "Поставщик")]
        public string Supplier { get; set; }
        [Display(Name = "Название материала")]
        public string NameMaterial { get; set; }
        [Display(Name = "Стоимость материалов")]
        public float Price { get; set; }
        [Display(Name = "Дата поставки")]
        public DateTime Delivery_date { get; set; }
        [Display(Name = "Количество материалов")]
        public int QuantityMaterials { get; set; }
    }
}
