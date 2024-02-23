using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehiculoBack.Models;

public partial class Accesorios
{
    [Key]
    public long AccesorioId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Valor { get; set; }

    public virtual ICollection<Vehiculos> Vehiculos { get; } = new List<Vehiculos>();
}
