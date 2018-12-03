using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.Models
{
    public class Supply
    {
        public int Id {get;set;}
        public string Supplier { get; set; }
        public int MaterialId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public DateTime Delivery_date { get; set; }
        public Material Materials { get; set; }
    }
}
