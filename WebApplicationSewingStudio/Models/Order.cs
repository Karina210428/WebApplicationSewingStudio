using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.Models
{
    public class Order
    {
        //многие 
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Изделие")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Стоимость")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата заказа")]
        public DateTime Date_of_order { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата сдачи заказа")]
        public DateTime Date_of_sale { get; set; }
        public Product Product { get; set; }
        public ICollection<Employee> Employers { get; set; }

    }
}
