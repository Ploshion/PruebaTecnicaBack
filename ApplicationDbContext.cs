using Microsoft.EntityFrameworkCore;
using VehiculoBack.Models;

namespace VehiculoBack
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Transacciones> Transacciones { get; set; }

        public DbSet<Accesorios> Accesorios { get; set; }

        public DbSet<Ciudades> Ciudades { get; set; }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Concesionarios> Concesionarios { get; set; }

        public DbSet<Marcas> Marcas { get; set; }

        public DbSet<MetodoPagos> MetodoPagos { get; set; }

        public DbSet<Modelos> Modelos { get; set; }

        public DbSet<Paises> Paises { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Vehiculos> Vehiculos { get; set; }

        public DbSet<Facturas> Facturas { get; set; }


    }
}
