using System;
using System.Collections.Generic;

namespace BACKEND_PRUEBA.Models
{
    public class OrdenCompra
    {
        public int IdOrden { get; set; }
        public double Total { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }
    }
}
