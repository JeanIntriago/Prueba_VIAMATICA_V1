using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BACKEND_PRUEBA.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string NombreCategoria { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
