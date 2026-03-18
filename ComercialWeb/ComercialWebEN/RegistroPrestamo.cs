using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComercialWebEN
{
    public class RegistroPrestamo
    {
        [Key]
        [Required]
        public int IdRegistroPrestamo { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio.")]
        [ForeignKey("Cliente")]
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }

        [ForeignKey("Producto")]
        [Required(ErrorMessage = "El producto es obligatorio.")]
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }

        [ForeignKey("Estado Prestamo")]
        [Required(ErrorMessage = "El estado Prestamo es obligatorio.")]
        [Display(Name = "Estado Prestamo")]
        public int IdEstadoPrestamo { get; set; }

        
        [Display(Name = "Fecha registro")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha Fin")]
        public DateTime FechaFin { get; set; }

        [StringLength(250, ErrorMessage = "Maximo 250 caracteres")]
        public string? Detalle { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; }
    }
}
