using System;
using System.Collections.Generic;
using System.Text;

namespace ComercialWebEN
{
    public class ClienteEN
    {
        public int IdCliente { get; set; }
        public int IdRol { get; set; }
        public int IdResidencia { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Celular { get; set; }
        public bool Estado { get; set; }
    }
}
