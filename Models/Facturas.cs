using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehiculoBack.Models;

public partial class Facturas
{
    [Key]
    public long FacturaId { get; set; }

    public DateTime FechaVenta { get; set; }

    public decimal PrecioVenta { get; set; }

    public long TransaccionId { get; set; }

    public virtual Transacciones Transaccion { get; set; } = null!;
}
