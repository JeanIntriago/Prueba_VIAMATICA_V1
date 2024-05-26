using BACKEND_PRUEBA.Interface;
using BACKEND_PRUEBA.Models;

namespace BACKEND_PRUEBA.Service
{
    public class OrdenCompraService:IOrdenCompra
    {
        private readonly BdPruebaContext _context;
        public OrdenCompraService(BdPruebaContext context)
        {
            _context = context;
        }

        public void GuardarOrdenCompra(OrdenCompra ordenCompra)
        {
            _context.OrdenesCompra.Add(ordenCompra);
            _context.SaveChanges();
        }
    }
}
