using System.ComponentModel.DataAnnotations;

namespace CapaModelo
{
    public class Usuario : BaseEntity
    {

        public Guid IdRol { get; set; }

        [Required(ErrorMessage = "El Primer Nombre es obligatorio.")]
        public string PrimerNombre { get; set; }
        
        [StringLength(15, ErrorMessage = "La longitud máxima para Segundo Nombre es de 15 caracteres.")]

        public string SegundoNombre { get; set; }

        [Required(ErrorMessage = "El Primer Apellido es obligatorio.")]
        public string PrimerApellido { get; set; }

        [StringLength(15, ErrorMessage = "La longitud máxima para Segundo Apellido es de 15 caracteres.")]
        public string SegundoApellido { get; set; }


        [Required(ErrorMessage = "El Correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe de cumplir como correo.")]

        public string Correo { get; set; }


        [Required(ErrorMessage = "El  Estado es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El estado debe ser un número positivo.")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "Campo Sexo obligatorio.")]

        public string Sexo{ get; set; }

        [Required(ErrorMessage = "El Nombre de usuario es obligatorio.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatorio.")]
        public string Contraseña { get; set; }


        [Required(ErrorMessage = "La fecha de creacion es obligatorio.")]
        public DateTime FechaCreacion { get; set; }

       // public Rol objRol { get; set; }

    }
}
