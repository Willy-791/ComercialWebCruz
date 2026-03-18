using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComercialWebEN
{
    public class ClienteEN
    {
        [Key]
        [Required]
        public int IdCliente { get; set; }

        [ForeignKey("Residencia")]
        [Required(ErrorMessage = "La residencia es obligatoria.")]
        [Display(Name = "Residencia")]
        public int IdResidencia { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Apellidos")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El número de celular es obligatorio.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El celular debe tener 8 caracteres.")]
        [Phone(ErrorMessage = "El formato del número de celular no es válido.")]
        [Display(Name = "Número de Celular")]
        public string? Celular { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; }
    }
}
