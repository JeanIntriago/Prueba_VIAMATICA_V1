using BACKEND_PRUEBA.Models;
using BACKEND_PRUEBA.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BACKEND_PRUEBA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly UsuarioService _service;
        private readonly IConfiguration _configuration;


        public LoginController(UsuarioService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("validar_login")]
        public IActionResult Login([FromBody] LoginUsuario request)
        {
            var usuarioExiste = _service.ValidarUsuario(request.correo, request.clave);
            if (usuarioExiste == null)
            {
                return Unauthorized("Correo o contraseña incorrecto");
            }

            var token = GenerarToken(usuarioExiste);
            return Ok(new { token });
        }

        private string GenerarToken(LoginUsuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("@2024_cl@ve_de@ccesoApl1cac1on@2023_cl@_154920$#@_++&&//_2023$$0o_&%###9000");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("correo", usuario.correo.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer  = "franco31",
                Audience = "jean"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
    

}
