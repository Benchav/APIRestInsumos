using System.ComponentModel.DataAnnotations;

namespace CapaModelo
{
    public class Producto : BaseEntity
    {


        // hay que mapearlo como principal pa que sirba y resolver fukun fukun 
        [Required(ErrorMessage = "El  Nombre del Producto es obligatorio.")]
        public string NombreProducto { get; set; }

        public Guid IdCategoria { get; set; }

        public Categoria objCategoria { get; set; }

    }
}
