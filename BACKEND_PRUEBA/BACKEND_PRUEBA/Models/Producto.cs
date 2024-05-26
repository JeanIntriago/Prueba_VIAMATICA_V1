using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BACKEND_PRUEBA.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }

        public string NombreProducto { get; set; } = null!;

        public double? Precio { get; set; }

        public int? Cantidad { get; set; }

        public int? IdCategoria { get; set; }

        [JsonIgnore]
        public virtual Categoria? IdCategoriaNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrdenCompraDetalle>? OrdenCompraDetalles { get; set; } // Relación con los detalles de la orden de compra
    }
}
