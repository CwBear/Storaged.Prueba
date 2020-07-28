using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Storaged.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]

        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public double Precio { get; set; }
    }
}