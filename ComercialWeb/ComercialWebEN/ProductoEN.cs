using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComercialWebEN
{
    public class ProductoEN
    {
        [Key]
        [Required]
        public int IdProducto { get; set; }

        [ForeignKey("Categoria")]
        [Required(ErrorMessage = "La categoria es obligatoria.")]
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }

        [ForeignKey("Marca")]
        [Required(ErrorMessage = "La marca es obligatoria.")]
        [Display(Name = "Marca")]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        [StringLength(50, ErrorMessage = "Maximo 200 caracteres")]
        [Display(Name = "Descripcion")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe estar entre 0.01 y 999,999.99")]
        [DataType(DataType.Currency)]
        [Display(Name = "Precio de Venta")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, 10000, ErrorMessage = "El stock debe ser un número positivo (entre 0 y 10,000).")]
        [Display(Name = "Cantidad en existencia")]

        public int Stock { get; set; } = 0;

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; }
    }
}
