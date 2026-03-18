using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComercialWebEN
{
    public class CategoriaEN
    {
        [Key]
        [Required]
        public int IdCategoria { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre de la categoria debe contener menos de 50 caracteres")]
        [Display(Name = "Nombre de la categoria")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage ="El estado es obligatorio")]
        public bool Estado { get; set; }
    }
}
