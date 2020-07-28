using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storaged.Models.ViewModels
{
    public class ListProductoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}