using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.ViewModels
{
    public class ProductCompositionViewModel
    {
        [Display(Name = "Код состава")]
        public int Id { get; set; }
        [Display(Name = "Название продукта")]
        public string ProductName { get; set; }
        [Display(Name = "Название материала")]
        public string MaterialName { get; set; }
        [Display(Name = "Количество материала")]
        public int Quantity { get; set; }
    }
}
