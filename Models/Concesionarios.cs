using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehiculoBack.Models;

public partial class Concesionarios
{
    [Key]
    public long ConcesionarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public long CiudadId { get; set; }

    public virtual Ciudades Ciudad { get; set; } = null!;

    public virtual ICollection<Vehiculos> Vehiculos { get; } = new List<Vehiculos>();
}
