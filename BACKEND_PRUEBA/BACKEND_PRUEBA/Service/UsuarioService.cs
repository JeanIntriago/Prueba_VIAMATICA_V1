using BACKEND_PRUEBA.Interface;
using BACKEND_PRUEBA.Models;
using Microsoft.Data.SqlClient;

namespace BACKEND_PRUEBA.Service
{
    public class UsuarioService:IUsuario
    {
        private readonly BdPruebaContext _context;
        private readonly string _connection;

        public UsuarioService(BdPruebaContext context, IConfiguration configuration) {
            _context = context;
            _connection = configuration.GetConnectionString("Conexion")!;
        }


        public IEnumerable<Usuario> ObtenerTodos()
        {
            return _context.Usuarios.ToList();
        }

        public void Agregar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public LoginUsuario ValidarUsuario(string correo, string clave)
        {
            using (var connection = new SqlConnection(_connection)) {
                connection.Open();
                using (var script = new SqlCommand("ValidarUsuario", connection)) {
                    script.CommandType = System.Data.CommandType.StoredProcedure;
                    script.Parameters.AddWithValue("@Correo",correo);
                    script.Parameters.AddWithValue("@Clave", clave);

                    using (var reader = script.ExecuteReader()) {
                        if (reader.Read()) {
                            var datosEncontrados = new LoginUsuario
                            {
                                correo = reader["Correo"].ToString()!,
                                clave = reader["Clave"].ToString()!
                            };

                            if (datosEncontrados.clave == clave) {
                                return datosEncontrados;
                            }
                        }
                    }
                }
            }
            return null!;
        }
    }
}
