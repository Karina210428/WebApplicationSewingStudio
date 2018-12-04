using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.Models
{
    public class Supply
    {
        public int Id {get;set;}
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Поставщик")]
        public string Supplier { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Материал")]
        public int MaterialId { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Стоимость")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Дата поставки")]
        public DateTime Delivery_date { get; set; }
        public Material Materials { get; set; }
    }
}
