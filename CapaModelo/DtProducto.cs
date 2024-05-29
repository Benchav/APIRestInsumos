namespace CapaModelo
{
    public class DtProducto : BaseEntity
    {
        //esta bien mapeado pero ahorita me fije que no deja almacenar nuevos cambios o nuevos registros

        //este es un catalogo secundario
        //hacer una nueba tabla para sacarlo del esquema y agregar el guid a la tabla
        public Guid IdProducto { get; set; }
        public Guid IdMedida { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string Marca { get; set; }

        public Producto objProducto { get; set; }
    }
}
