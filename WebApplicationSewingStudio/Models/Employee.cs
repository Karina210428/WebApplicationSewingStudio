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
        [Display(Name="Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Display(Name = "Номер заказа")]
        public int OrderId { get; set; }
        [Display(Name = "Время начала выполнения заказа")]
        public DateTime Execution_start_date { get; set; }
        [Display(Name = "Время сдачи заказа")]
        public DateTime Date_of_delivery { get; set; }
        public Order Order { get; set; }
    }
}
