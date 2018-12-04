using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.Models
{
    public class Employee
    {
        //многие 
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name="Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Номер заказа")]
        public int OrderId { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Время начала выполнения заказа")]
        public DateTime Execution_start_date { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Время сдачи заказа")]
        public DateTime Date_of_delivery { get; set; }
        public Order Order { get; set; }
    }
}
