using BACKEND_PRUEBA.Models;
using BACKEND_PRUEBA.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND_PRUEBA.Service
{
    public class ProductoService:IProducto
    {
        private readonly BdPruebaContext _context;
        private readonly CategoriaService service;
        public ProductoService(BdPruebaContext context)
        {
            _context = context;
        }

        public Producto ObtenerPorNombreCategoria(int idCategoria)
        {

            return _context.Productos.FirstOrDefault(u => u.IdCategoria == idCategoria)!;
        }

        public Producto ObtenerTodosProductos(int idCategoria)
        {
            return _context.Productos.FirstOrDefault(u => u.IdCategoria == idCategoria)!;
        }
    }
}
