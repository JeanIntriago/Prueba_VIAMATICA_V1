using BACKEND_PRUEBA.Models;
using BACKEND_PRUEBA.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND_PRUEBA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService service;
        public UsuarioController(UsuarioService _service)
        {
            service = _service;
        }

        
        [HttpGet]
        [Route("all")]
        public IActionResult obtenerTodos()
        {
            var listaUsuario = service.ObtenerTodos();
            return Ok(listaUsuario);
        }

        [HttpPost]
        [Route("registrar")]
        public IActionResult Crear(Usuario usuario)
        {
            service.Agregar(usuario);
            return Ok();
        }

        
    }
}
