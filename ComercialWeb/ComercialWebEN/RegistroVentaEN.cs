using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComercialWebEN
{
    public class RegistroVentaEN
    {
        [Key]
        public int IdRegistroVenta { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio.")]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio.")]
        [ForeignKey("Producto")]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, 1000)]
        public int Cantidad { get; set; }

        public DateTime FechaVenta { get; set; }

        [StringLength(250)]
        public string? Detalle { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public ClienteEN? Cliente { get; set; }
        public ProductoEN? Producto { get; set; }
    }
}