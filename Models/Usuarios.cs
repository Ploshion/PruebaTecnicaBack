using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehiculoBack.Models;

public partial class Usuarios
{
    [Key]
    public long UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual ICollection<Transacciones> Transacciones { get; } = new List<Transacciones>();
}
