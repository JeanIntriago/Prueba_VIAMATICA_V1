using BACKEND_PRUEBA.Models;

namespace BACKEND_PRUEBA.Interface
{
    public interface IUsuario
    {
        IEnumerable<Usuario> ObtenerTodos();
        void Agregar(Usuario usuario);
        LoginUsuario ValidarUsuario(string correo, string clave);
    }
}
