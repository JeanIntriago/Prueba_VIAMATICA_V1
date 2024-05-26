using BACKEND_PRUEBA.Service;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND_PRUEBA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly CategoriaService _service;
        public CategoriaController(CategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{nombre}/productos")]

        public async Task<IActionResult> ObtenerProductosPorNombreCategoria(string nombre)
        {
            var categoriaId = await _service.ObtenerIdCategoriaPorNombres(nombre);
            if (categoriaId == null)
            {
                return NotFound("No se encontró la categoría especificada.");
            }

            var productos = await _service.ObtenerProductosPorCategoriaId(categoriaId.Value);
            if (productos == null || !productos.Any())
            {
                return NotFound("No se encontraron productos para la categoría especificada.");
            }

            return Ok(productos);
        }
    }
}
