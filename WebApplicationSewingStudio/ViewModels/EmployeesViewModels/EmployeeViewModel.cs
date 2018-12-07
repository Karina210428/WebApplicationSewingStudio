using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels
{
    public class EmployeeViewModel
    {
        [Display(Name = "Код состава")]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Дата начала исполнения")]
        public DateTime Execution_start_date { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Дата сдачи заказа")]
        public DateTime Date_of_delivery { get; set; }
        [Display(Name = "Код заказа")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
