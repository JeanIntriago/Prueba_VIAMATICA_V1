using System;
using System.Collections.Generic;

namespace BACKEND_PRUEBA.Models;

public partial class Usuario
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;
}
