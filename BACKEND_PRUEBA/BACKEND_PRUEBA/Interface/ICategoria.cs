using BACKEND_PRUEBA.Models;

namespace BACKEND_PRUEBA.Interface
{
    public interface ICategoria
    {
        Task<IEnumerable<Producto>> ObtenerProductosPorCategoriaId(int idCategoria);
        Task<int?> ObtenerIdCategoriaPorNombres(string nombreCategoria);

    }
}
