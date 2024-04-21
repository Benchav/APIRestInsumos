using System.ComponentModel.DataAnnotations;

namespace CapaModelo
{
    public  class Rol : BaseEntity
    {
        [Required(ErrorMessage = "La Descripcion es obligatorio.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de creacion es obligatorio.")]
        public DateTime FechaCreacion { get; set; }
    }
}
