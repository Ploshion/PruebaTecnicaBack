using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculoBack.Models;

namespace VehiculoBack.Controllers
{
    [ApiController]
    [Route("api/Facturas")]
    //    [Authorize]
    public class FacturaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;


        public FacturaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Facturas>> Get()
        {
            var facturas = await context.Facturas
                 .Include(x => x.Transaccion).ThenInclude(x => x.Cliente)
                 .Include(x => x.Transaccion).ThenInclude(x => x.Vehiculo)
                .ToListAsync();
            return mapper.Map<List<Facturas>>(facturas);
        }

        [HttpGet("byId/{Id:int}")]
        public async Task<ActionResult<Facturas>> GetById(int Id)
        {
            var facturas = await context.Facturas
                .Include(x => x.Transaccion).ThenInclude(x => x.Cliente).AsNoTracking()
                 .Include(x => x.Transaccion).ThenInclude(x => x.Vehiculo).AsNoTracking()
                 .Where(x => x.FacturaId == Id).FirstOrDefaultAsync();

            return mapper.Map<Facturas>(facturas);
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var existe = await context.Facturas.AnyAsync(x => x.FacturaId == Id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Facturas() { FacturaId = Id });
            await context.SaveChangesAsync();
            return Ok();

        }


    }
}
