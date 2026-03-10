using System;
using System.Collections.Generic;
using System.Text;

namespace ComercialWebEN
{
    public class ProductoEN
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public int IdMarca { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }
    }
}
