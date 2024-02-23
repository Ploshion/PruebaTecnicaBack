using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehiculoBack.Models;

public partial class Paises
{
    [Key]
    public long PaisId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Ciudades> Ciudades { get; } = new List<Ciudades>();
}
