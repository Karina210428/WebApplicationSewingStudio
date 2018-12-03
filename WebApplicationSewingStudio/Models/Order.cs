using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.Models
{
    public class Order
    {
        //многие 
        public int Id { get; set; }
        public int ProductId { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Date_of_order { get; set; }
        public DateTime Date_of_sale { get; set; }
        public Product Product { get; set; }
        public ICollection<Employee> Employers { get; set; }
    }
}
