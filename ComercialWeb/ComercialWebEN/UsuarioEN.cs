using System;
using System.Collections.Generic;
using System.Text;

namespace ComercialWebEN
{
    public class UsuarioEN
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string? Nombre { get; set; }
        public string? Contrasenia { get; set; }
        public bool Estado { get; set; }
    }
}
