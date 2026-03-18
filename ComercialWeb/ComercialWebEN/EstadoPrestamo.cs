using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComercialWebEN
{
    public class EstadoPrestamo
    {
        [Key]
        [Required]
        public int IdEstadoPrestamo { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }
    }
}
