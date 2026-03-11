using System;
using System.Collections.Generic;
using System.Text;

namespace ComercialWebEN
{
    public class RegistroVentaEN
    {
        public int IdRegistroVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaVenta { get; set; }
        public string? Detalle { get; set; }
        public bool Estado { get; set; }

    }
}
