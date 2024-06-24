using System.ComponentModel.DataAnnotations;

namespace CapaModelo
{
    public class Cliente : BaseEntity
    {
        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]
        public string PrimerNombre { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]

        public string SegundoNombre { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]

        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]

        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "El Correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe de cumplir como correo.")]

        public string Correo { get; set; }

        [Required(ErrorMessage = "El Telefono es obligatorio.")]

        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El Estado debe ser un número positivo.")]

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
