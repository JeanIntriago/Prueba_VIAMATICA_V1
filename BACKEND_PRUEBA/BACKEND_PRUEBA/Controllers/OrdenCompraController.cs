using System;
using System.Linq;
using BACKEND_PRUEBA.Models;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND_PRUEBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenCompraController : ControllerBase
    {
        private readonly BdPruebaContext _context;

        public OrdenCompraController(BdPruebaContext context)
        {
            _context = context;
        }

        [HttpPost("guardar")]
        public IActionResult GuardarOrdenCompra([FromBody] GenerarFactura ordenCompra)
        {
            if (ordenCompra == null)
            {
                return BadRequest(new { mensaje = "La orden de compra es nula" });
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var nuevaOrden = new OrdenCompra
                    {
                        Total = (double)ordenCompra.Total,
                        FechaRegistro = ordenCompra.FechaRegistro
                    };

                    _context.OrdenesCompra.Add(nuevaOrden);
                    _context.SaveChanges();

                    foreach (var producto in ordenCompra.Productos)
                    {
                        var detalle = new OrdenCompraDetalle
                        {
                            IdOrden = nuevaOrden.IdOrden,
                            IdProducto = producto.IdProducto,
                        };

                        _context.OrdenCompraDetalles.Add(detalle);
                    }

                    _context.SaveChanges();
                    transaction.Commit();

                    return Ok(new { mensaje = "Orden de compra generada con éxito" });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, new { mensaje = "Error interno del servidor", detalle = ex.Message });
                }
            }
        }
    }
}
