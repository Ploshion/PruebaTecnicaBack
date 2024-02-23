using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculoBack.Models;

namespace VehiculoBack.Controllers
{
    [ApiController]
    [Route("api/Vehiculos")]
    //    [Authorize]
    public class VehiculoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public VehiculoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<List<Vehiculos>> Get()
        {
            var vehi = await context.Vehiculos
                .Include(x => x.Modelo).AsNoTracking()
                .Include(x => x.Marca).AsNoTracking()
                .ToListAsync();
            return mapper.Map<List<Vehiculos>>(vehi);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Vehiculos>> GetbyId(long Id)
        {
            var vehi = await context.Vehiculos.Where(x => x.VehiculoId == Id).FirstOrDefaultAsync();
            return mapper.Map<Vehiculos>(vehi);
        }

    }

}
