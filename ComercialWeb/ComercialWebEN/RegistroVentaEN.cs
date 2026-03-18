using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComercialWebEN
{
    public class RegistroVentaEN
    {
        [Key]
        [Required]
        public int IdRegistroVenta { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio.")]
        [ForeignKey("Cliente")]
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }

        [ForeignKey("Producto")]
        [Required(ErrorMessage = "El producto es obligatorio.")]
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }

        [Display(Name ="Fecha de la venta")]
        public DateTime FechaVenta { get; set; }

        [StringLength(250, ErrorMessage = "Maximo 250 caracteres")]
        public string? Detalle { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; }

    }
}
