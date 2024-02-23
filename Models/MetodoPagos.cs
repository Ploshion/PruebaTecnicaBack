using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehiculoBack.Models;

public partial class MetodoPagos
{
    [Key]
    public long MetodoPagoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Transacciones> Transacciones { get; } = new List<Transacciones>();
}
