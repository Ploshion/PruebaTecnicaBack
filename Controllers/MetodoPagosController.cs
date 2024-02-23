using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculoBack.Models;

namespace VehiculoBack.Controllers
{
    [ApiController]
    [Route("api/MetodoPagos")]
    public class MetodoPagosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MetodoPagosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<List<MetodoPagos>> Get()
        {
            var metodo = await context.MetodoPagos.ToListAsync();
            return mapper.Map<List<MetodoPagos>>(metodo);
        }

    }
}
