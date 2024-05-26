using BACKEND_PRUEBA.Models;

public class OrdenCompraDetalle
{
    public int IdOrdenDetalle { get; set; }
    public int IdOrden { get; set; }
    public int IdProducto { get; set; }

    public virtual OrdenCompra OrdenCompra { get; set; }
    public virtual Producto Producto { get; set; }
}
