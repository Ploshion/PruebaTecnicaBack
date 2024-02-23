using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehiculoBack.Models;

public partial class Ciudades
{
    [Key]
    public long CiudadId { get; set; }

    public string Nombre { get; set; } = null!;

    public long PaisId { get; set; }

    public virtual ICollection<Clientes> Clientes { get; } = new List<Clientes>();

    public virtual ICollection<Concesionarios> Concesionarios { get; } = new List<Concesionarios>();

    public virtual Paises Pais { get; set; } = null!;
}
