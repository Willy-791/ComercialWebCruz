using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComercialWebEN
{
    public class ResidenciaEN
    {

        [Key]
        [Required]
        public int IdResidencia { get; set; }

        [Required(ErrorMessage ="Nombre es requerido")]
        [Display(Name ="Nombre")]
        [StringLength(50, ErrorMessage ="Maximo 50 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage ="El estado es obligatorio")]
        public bool Estado { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
