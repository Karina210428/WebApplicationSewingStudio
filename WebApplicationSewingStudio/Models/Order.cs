using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Date_of_order { get; set; }
        public DateTime Date_of_sale { get; set; }
        public Product Product { get; set; }
        public ICollection<Employees> Employers { get; set; }
    }
}
