using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Код заказа")]
        public int Id { get; set; }
        [Display(Name = "Название изделия")]
        public string NameProduct { get; set; }
        [Display(Name = "Стоимость заказа")]
        public float Price { get; set; }
        [Display(Name = "Дата заказа")]
        public DateTime Date_of_order { get; set; }
        [Display(Name = "Дата реализациия заказа")]
        public DateTime Date_of_sale { get; set; }
        [Display(Name = "Количество изделий")]
        public int Quantity { get; set; }
    }
}
