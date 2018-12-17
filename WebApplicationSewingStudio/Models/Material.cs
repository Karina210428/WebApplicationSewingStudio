using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.Models
{
    public class Material 
    {
        [Key]
        [Display(Name = "Код материала")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название материала")]
        public String Name { get; set; }

        [Display(Name = "Тип материала")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public String Type { get; set; }
        public virtual ICollection<ProductComposition> ProductCompositions { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }

        public Material()
        {
            ProductCompositions = new List<ProductComposition>();
            Supplies = new List<Supply>();
        }
    }
}
