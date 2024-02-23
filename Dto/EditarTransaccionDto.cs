namespace WebApplication1.Dto
{
    public class EditarTransaccionDto
    {
        public long TransaccionId { get; set; }
        public string? NumTransaccion { get; set; }

        public string? Estado { get; set; }

        public decimal Valor { get; set; }

        public long MetodoPagoId { get; set; }

        public long UsuarioId { get; set; }

        public long vehiculoId { get; set; }

        public long ClienteId { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public long CiudadId { get; set; }
        public long FacturaId { get; set; }
    }
}
