using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComercialWebEN
{
    public class RolEN
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="El Nombre es obligarotio")]
        [StringLength(50, ErrorMessage ="Maximo 50 caracteres")]
        [Display(Name ="Nombre")]
        public string? Nombre { get; set; }
        public List<UsuarioEN> Usuarios { get; set; } = null!;
        [NotMapped]
        public int Top_Aux { get; set; }

    }
}
