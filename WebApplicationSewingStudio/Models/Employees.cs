using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int IdOrder { get; set; }
        public DateTime Execution_start_date { get; set; }
        public DateTime Date_of_delivery { get; set; }
        public Order Order { get; set; }
    }
}
