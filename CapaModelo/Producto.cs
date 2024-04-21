using System.ComponentModel.DataAnnotations;

namespace CapaModelo
{
    public class Producto : BaseEntity
    {
        [Required(ErrorMessage = "El  Nombre del Producto es obligatorio.")]
        public string NombreProducto { get; set; }

        public Guid IdCategoria { get; set; }

        public Categoria objCategoria { get; set; }

    }
}
