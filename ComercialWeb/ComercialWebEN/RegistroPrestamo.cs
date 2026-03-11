using System;
using System.Collections.Generic;
using System.Text;

namespace ComercialWebEN
{
    public class RegistroPrestamo
    {
        public int IdRegistroPrestamo { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int IdEstadoPrestamo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? Detalle { get; set; }
        public bool Estado { get; set; }
    }
}
