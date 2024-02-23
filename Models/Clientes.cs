using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehiculoBack.Models;

public partial class Clientes
{
    [Key]
    public long ClienteId { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public long CiudadId { get; set; }

    public virtual Ciudades Ciudad { get; set; } = null!;

    public virtual ICollection<Transacciones> Transacciones { get; } = new List<Transacciones>();
}
