using BACKEND_PRUEBA.Interface;
using BACKEND_PRUEBA.Models;
using Microsoft.EntityFrameworkCore;

namespace BACKEND_PRUEBA.Service
{
    public class CategoriaService:ICategoria
    {
        private readonly BdPruebaContext _context;
        public CategoriaService(BdPruebaContext context)
        {
            _context = context;
        }
        
        public async Task<int?> ObtenerIdCategoriaPorNombres(string nombreCategoria) {
            var categoria = await _context.Categoria.FirstOrDefaultAsync(c => c.NombreCategoria == nombreCategoria);
            return categoria?.IdCategoria;
        }


        public async Task<IEnumerable<Producto>> ObtenerProductosPorCategoriaId(int categoriaId)
        {
            return await _context.Productos
                .Where(p => p.IdCategoria == categoriaId)
                .ToListAsync();
        }
    }
}
