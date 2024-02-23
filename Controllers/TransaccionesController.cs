using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculoBack.Dto;
using VehiculoBack.Models;
using WebApplication1.Dto;

namespace VehiculoBack.Controllers
{
    [ApiController]
    [Route("api/Transacciones")]
    //    [Authorize]
    public class TransaccionesController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TransaccionesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Transacciones>> Get()
        {
            var transaccion = await context.Transacciones
                .Include(x => x.Facturas)
                .Include(x => x.Cliente)
                .Include(x => x.Vehiculo)
                .ToListAsync();
            return mapper.Map<List<Transacciones>>(transaccion);
        }



        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreacionTransaccionDto transacciones)
        {
            DateTime now = DateTime.Now;

            var crearCliente = new Clientes
            {

                Nombres = transacciones.Nombres,

                Apellidos = transacciones.Apellidos,

                Email = transacciones.Email,

                Telefono = transacciones.Telefono,

                Direccion = transacciones.Direccion,

                CiudadId = transacciones.CiudadId

            };

            context.Clientes.Add(crearCliente);
            await context.SaveChangesAsync();

            if (crearCliente.ClienteId != 0)
            {
                var crearTransaccion = new Transacciones
                {
                    NumTransaccion = transacciones.NumTransaccion,
                    Estado = transacciones.Estado,
                    Valor = transacciones.Valor,
                    ClienteId = crearCliente.ClienteId,
                    MetodoPagoId = transacciones.MetodoPagoId,
                    UsuarioId = transacciones.UsuarioId,
                    VehiculoId = transacciones.vehiculoId
                };

                context.Transacciones.Add(crearTransaccion);
                await context.SaveChangesAsync();

                if (crearTransaccion.TransaccionId != 0)
                {
                    var crearfactura = new Facturas
                    {
                        FechaVenta = now,
                        PrecioVenta = crearTransaccion.Valor,
                        TransaccionId = crearTransaccion.TransaccionId
                    };

                    context.Facturas.Add(crearfactura);
                    await context.SaveChangesAsync();
                }

            }

            return Ok("OK");

        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EditarTransaccionDto transacciones)
        {

            var existe = await context.Transacciones.AnyAsync(x => x.TransaccionId == transacciones.TransaccionId);

            if (!existe)
            {
                return NotFound();
            }

            DateTime now = DateTime.Now;

            var crearCliente = new Clientes
            {
                ClienteId = transacciones.ClienteId,

                Nombres = transacciones.Nombres,

                Apellidos = transacciones.Apellidos,

                Email = transacciones.Email,

                Telefono = transacciones.Telefono,

                Direccion = transacciones.Direccion,

                CiudadId = transacciones.CiudadId

            };

            context.Clientes.Update(crearCliente);
            await context.SaveChangesAsync();

            if (crearCliente.ClienteId != 0)
            {
                var crearTransaccion = new Transacciones
                {
                    TransaccionId = transacciones.TransaccionId,
                    NumTransaccion = transacciones.NumTransaccion,
                    Estado = transacciones.Estado,
                    Valor = transacciones.Valor,
                    ClienteId = crearCliente.ClienteId,
                    MetodoPagoId = transacciones.MetodoPagoId,
                    UsuarioId = transacciones.UsuarioId,
                    VehiculoId = transacciones.vehiculoId
                };

                context.Transacciones.Update(crearTransaccion);
                await context.SaveChangesAsync();

                if (crearTransaccion.TransaccionId != 0)
                {
                    var crearfactura = new Facturas
                    {
                        FacturaId = transacciones.FacturaId,
                        FechaVenta = now,
                        PrecioVenta = crearTransaccion.Valor,
                        TransaccionId = crearTransaccion.TransaccionId
                    };

                    context.Facturas.Update(crearfactura);
                    await context.SaveChangesAsync();
                }

            }

            return Ok("OK");

        }


    }
}
