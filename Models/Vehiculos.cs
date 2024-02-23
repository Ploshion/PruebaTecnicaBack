using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehiculoBack.Models;

public partial class Vehiculos
{
    [Key]
    public long VehiculoId { get; set; }

    public string Anio { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Observacion { get; set; }

    public long MarcaId { get; set; }

    public long ModeloId { get; set; }

    public long AccesorioId { get; set; }

    public long ConcesionarioId { get; set; }

    public string ImagenUrl { get; set; } = null!;

    public virtual Accesorios Accesorio { get; set; } = null!;

    public virtual Concesionarios Concesionario { get; set; } = null!;

    public virtual Marcas Marca { get; set; } = null!;

    public virtual Modelos Modelo { get; set; } = null!;

    public virtual ICollection<Transacciones> Transacciones { get; } = new List<Transacciones>();
}
