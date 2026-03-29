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
        public int IdUsuario { get; set; }
        [ForeignKey("Rol")]
        [Required(ErrorMessage = "Rol es obligatorio")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "Nombre de usuario es obligatorio")]
        [StringLength(40, ErrorMessage = "Maximo 40 carecteres")]
        [Display(Name = "Nombre Usuario")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido de usuario es obligatorio")]
        [StringLength(40, ErrorMessage = "Maximo 40 carecteres")]
        [Display(Name = "Apellido Usuario")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Login de usuario es obligatorio")]
        [StringLength(200, ErrorMessage = "Maximo 200 carecteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password es obligatorio")]
        [StringLength(40, ErrorMessage = "Maximo 40 carecteres")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Estado es Obligatorio")]
        public byte Estatus { get; set; } 

        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
        public RolEN Rol { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Confirmar password es obligatorio")]
        [StringLength(40, ErrorMessage = "Maximo 40 carecteres")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password y Confirmar password deben ser iguales")]
        [Display(Name = "Confirmar Password")]
        public string ConfirmPassword_aux { get; set; }
    }

    public enum Estatus_Usuario
    { 
        ACTIVO = 1,
        INACTIVO =2
    }
}
