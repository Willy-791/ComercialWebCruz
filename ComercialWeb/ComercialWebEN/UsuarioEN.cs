using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComercialWebEN
{
    public class UsuarioEN
    {
        [Key]
        [Required]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage ="El Rol es obligatorio")]
        [ForeignKey("Rol")]
        [Display(Name ="Rol")]
        public int IdRol { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        
        [NotMapped]
        [Required(ErrorMessage = "Confirmar Password es obligatorio.")]
        [StringLength(40, ErrorMessage = "Maximo 40 cararteres")]
        public string? Contrasenia { get; set; }

        [Required(ErrorMessage ="El estado es obligatorio")]
        public bool Estado { get; set; }
    }
}
