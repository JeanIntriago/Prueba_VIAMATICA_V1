using BACKEND_PRUEBA.Models;

namespace BACKEND_PRUEBA.Interface
{
    public interface IProducto
    {
        public Producto ObtenerPorNombreCategoria(int idCategoria);
    }
}
