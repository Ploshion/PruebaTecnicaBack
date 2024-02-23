using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculoBack.Models;

namespace VehiculoBack.Controllers
{
    [ApiController]
    [Route("api/Ciudades")]
    //    [Authorize]
    public class CiudadController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public CiudadController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Ciudades>> Get()
        {
            var ciudad = await context.Ciudades.ToListAsync();
            return mapper.Map<List<Ciudades>>(ciudad);
        }
    }
}
