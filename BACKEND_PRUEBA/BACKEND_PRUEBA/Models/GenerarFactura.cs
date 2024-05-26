namespace BACKEND_PRUEBA.Models
{
    public class GenerarFactura
    {
        public decimal Total { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<DetalleProducto> Productos { get; set; }
    }

    public class DetalleProducto
    {
        public int IdProducto { get; set; }
    }
}
