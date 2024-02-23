using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehiculoBack.Models;

public partial class Transacciones
{
    [Key]
    public long TransaccionId { get; set; }

    public string? NumTransaccion { get; set; }

    public string? Estado { get; set; }

    public decimal Valor { get; set; }

    public long ClienteId { get; set; }

    public long MetodoPagoId { get; set; }

    public long UsuarioId { get; set; }

    public long VehiculoId { get; set; }

    public virtual Clientes Cliente { get; set; } = null!;

    public virtual ICollection<Facturas> Facturas { get; } = new List<Facturas>();

    public virtual MetodoPagos MetodoPago { get; set; } = null!;

    public virtual Usuarios Usuario { get; set; } = null!;

    public virtual Vehiculos Vehiculo { get; set; } = null!;
}
