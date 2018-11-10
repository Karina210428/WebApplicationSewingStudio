using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.Models
{
    public class Product
    {
        [Key]
        [Display(Name ="Код изделия")]
        public int Id { get; set; }
        [Display(Name = "Название изделия")]
        public String Name { get; set; }
        [Display(Name = "Стоимость")]
        public double Price { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductComposition> ProductCompositions { get; set; }

        public Product()
        {
            Orders = new List<Order>();
            ProductCompositions = new List<ProductComposition>();
        }
    }
}
