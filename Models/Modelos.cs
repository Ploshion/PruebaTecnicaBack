using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehiculoBack.Models;

public partial class Modelos
{
    [Key]
    public long ModeloId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Vehiculos> Vehiculos { get; } = new List<Vehiculos>();
}
