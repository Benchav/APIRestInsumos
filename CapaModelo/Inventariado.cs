namespace CapaModelo
{
    public class Inventariado:BaseEntity
    {
      public Guid IdDetalleProd {  get; set; }
        public Guid IdProveedor { get; set; }
        public int Existencia { get; set; }
        public string Lote { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set;}
        public DateTime FechaCompra { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public DtProducto objDtProducto { get; set; }

    }
}
