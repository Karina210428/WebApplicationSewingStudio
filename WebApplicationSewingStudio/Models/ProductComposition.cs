﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.Models
{
    public class ProductComposition
    {
        [Key]
        [Display(Name = "Код состава")]
        public int Id { get; set; }
        [Display(Name = "Код продукта")]
        public int ProductId { get; set; }
        [Display(Name = "Код материала")]
        public int MaterialId { get; set; }
        [Display(Name = "Количество материала")]
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Material Material { get; set; } 
    }
}
